using KinectDummy.InputSources;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace KinectDummy
{
    public delegate void EventHandler<DepthFrameArrivedEventArgs>(object sender, DepthFrameArrivedEventArgs e);


    public enum FrameSource { KINECT, RECORDED, ASTRA_PRO }

    public class DepthFrameReader
    {
        private ushort[] recentylReadFrameData = new ushort[new FrameDescription().Height * new FrameDescription().Width];
        private long recentlyReadFrameByteOffset = 0;

        public bool IsPaused { get; private set; } = true;

        public event EventHandler<DepthFrameArrivedEventArgs> FrameArrived;
        internal BinaryReader streamReader;

        private String savedStreamFilePath;

        //private ConcurrentQueue<ushort[]> concQueue = new ConcurrentQueue<ushort[]>();
        private ConcurrentQueue<Tuple<long,ushort[]>> concurrentReadingQueue = new ConcurrentQueue<Tuple<long, ushort[]>>();
        private bool pauseReadingRequested = false;
        private bool pauseStreamingRequested = false;
        private bool currentlyReading = false;
        private bool currentlyDequeing = false;
        private bool initiallyStarted = false;
        private bool savedStreamFileSet = false;
        private bool sensorOpened = false;
        private bool frameArrivedEventSet = false;
        private bool freezeCurrentFrame = false;
        //private bool pauseStreaming = false; // set to true if the queue has to buffer before being able to stream or if the bounds/currentPosition has been changed in the GUI and the queue has to be cleared up
        //private bool queueAccessable = false; // gets set to true at the next frame-kick after 'pauseStreaming' was set to true
        //private bool currentlyReading = false;
        //private bool readStopRequested = false;

        public static List<int> performanceTestList = new List<int>(400);

        private AccurateTimer frameArrivedTimer;
        private AccurateTimer dequeueFrameTimer;

        internal static Stopwatch sw = new Stopwatch();

        private DepthFrame currentDepthFrame;

        private long fileSizeInBytes;
        private long lowerBoundByteOffset;
        private long upperBoundByteOffset;
        private int frameLengthInBytes = new FrameDescription().Height * new FrameDescription().Width * 2;
        private Tuple<long, ushort[]> currentFrame;

        private long fileLengthMilliseconds;

        private Microsoft.Kinect.KinectSensor realKinectSensor { get; } = null;
        private Microsoft.Kinect.DepthFrameReader realDepthFrameReader { get; } = null;

        private Thread astraAdapterThread;
        private AstraProAdapter astraAdapter = new AstraProAdapter();

        internal bool realKinectSet { get; } = false;

        internal DepthFrameReader(Microsoft.Kinect.KinectSensor realKinectSensor) : this()
        {
            this.realKinectSensor = realKinectSensor;
            realDepthFrameReader = realKinectSensor.DepthFrameSource.OpenReader();
            realKinectSensor.Open();
            realDepthFrameReader.FrameArrived += realFrameArrived;
            realKinectSet = true;
        }

        internal DepthFrameReader()
        {
            //ushort Min = 2000;
            //ushort Max = 6000;
            //Random randNum = new Random();
            //mostRecentStreamedFrameData = Enumerable.Repeat(0, mostRecentStreamedFrameData.Length).Select(i => (ushort)randNum.Next(Min, Max)).ToArray();

            //currentDepthFrame = new DepthFrame(mostRecentStreamedFrameData);

            //streamReader.BaseStream.Seek((long)firstFrameOffset * fakeFrameDataAsArray.Length * 2, SeekOrigin.Begin);
            dequeueFrameTimer = new AccurateTimer() { Interval = 33 };

            GUIControl.startGUIParallel(this);

            // starting the astra pro server socket. will wait for connections. TODO: start astra pro sender as process
            astraAdapterThread = new Thread(astraAdapter.run);
            astraAdapterThread.Start();
        }

        internal void setRepeatingInterval(long lowerBoundMS, long upperBoundMS)
        {
            if (!initiallyStarted)
                return;

            requestFullQueueAccess(); // may freeze everything?? nvm
            
            Tuple<long, ushort[]> tempPosition;
            bool success = concurrentReadingQueue.TryDequeue(out tempPosition);
            if (success)
                streamReader.BaseStream.Position = tempPosition.Item1;

            cleanUpQueue();

            lowerBoundByteOffset = Math.Max(transformMillisecondsToBytes(lowerBoundMS), 0);
            upperBoundByteOffset = Math.Min(transformMillisecondsToBytes(upperBoundMS), fileSizeInBytes);

            pauseReadingRequested = false;
            pauseStreamingRequested = false;
        }

        internal void setTimelinePosition(long currentMS)
        {
            if (!initiallyStarted)
                return;

            requestFullQueueAccess(); // may freeze everything??

            cleanUpQueue();

            long tempBytes = transformMillisecondsToBytes(currentMS);
            if (tempBytes >= 0 && tempBytes < fileSizeInBytes)
            {
                streamReader.BaseStream.Position = tempBytes;
                streamReader.BaseStream.Flush();
            }
            
            pauseReadingRequested = false;
            pauseStreamingRequested = false;
        }

        private void requestFullQueueAccess()
        {
            pauseReadingRequested = true;
            pauseStreamingRequested = true;

            while (currentlyReading || currentlyDequeing)
            {
                new ManualResetEvent(false).WaitOne(10);
            }
        }

        private void cleanUpQueue()
        {
            Tuple<long, ushort[]> dummy;

            while (!concurrentReadingQueue.IsEmpty)
            {
                concurrentReadingQueue.TryDequeue(out dummy);
            }
        }

        internal long getLowerBoundMilliseconds()
        {
            return transformBytesToMilliseconds(lowerBoundByteOffset);
        }

        internal long getUpperBoundMilliseconds()
        {
            return transformBytesToMilliseconds(upperBoundByteOffset);
        }

        internal long getCurrentFrameMilliseconds()
        {
            if (currentFrame != null)
                return transformBytesToMilliseconds(currentFrame.Item1);
            return 0;
        }

        public void Dispose()
        {
            requestFullQueueAccess();

            detachEventsFromTimers();
            
            streamReader.Dispose();
        }

        internal void changeFPS(int fps)
        {
            int interval = (int)Math.Round(1000d / fps);
                                    
            if (frameArrivedTimer == null)
            {
                frameArrivedTimer = new AccurateTimer() { Interval = interval };
            }
            else
            {
                if (frameArrivedEventSet)
                    frameArrivedTimer.Stop();

                frameArrivedTimer.Interval = interval;
            }
            
            if (frameArrivedEventSet)
                frameArrivedTimer.Start();
        }

        private void attachEventsToTimers()
        {
            frameArrivedEventSet = true;
            dequeueFrameTimer.Elapsed += dequeueFrame;
            frameArrivedTimer.Elapsed += kickFrameArrivedEvent;
            dequeueFrameTimer.Start();
            frameArrivedTimer.Start();
        }

        private void detachEventsFromTimers()
        {
            frameArrivedEventSet = false;

            if (dequeueFrameTimer != null)
            {
                dequeueFrameTimer.Elapsed -= dequeueFrame;
                dequeueFrameTimer.Stop();
            }
            if (frameArrivedTimer != null)
            {
                frameArrivedTimer.Elapsed -= kickFrameArrivedEvent;
                frameArrivedTimer.Stop();
            }
        }

        internal void startStreaming(int fps)
        {
            if (savedStreamFileSet)
            {
                changeFPS(fps);
                startFillingQueueFromFile();
                attachEventsToTimers();
                pauseStreamingRequested = false;
                initiallyStarted = true;
                IsPaused = false;
            }
        }

        internal void pauseStreamingByGUI()
        {
            detachEventsFromTimers();
            pauseStreamingRequested = true;
            currentlyDequeing = false;
            IsPaused = true;
        }

        internal void startStreamingSolelyLiveFrames(int fps)
        {
            changeFPS(fps);
            frameArrivedTimer.Elapsed += kickFrameArrivedEvent;
            frameArrivedTimer.Start();
            IsPaused = false;
        }

        internal void pauseStreamingSolelyLiveFrames()
        {
            frameArrivedTimer.Elapsed -= kickFrameArrivedEvent;
            frameArrivedTimer.Stop();
            IsPaused = true;
        }

        internal void setSavedStreamFilePath(String savedStreamFilePath)
        {
            if (initiallyStarted)
            {
                return;
            }

            if (savedStreamFilePath != null && savedStreamFilePath.EndsWith(".kcs"))
            {
                streamReader = new BinaryReader(File.Open(savedStreamFilePath, FileMode.Open, FileAccess.Read));
                fileSizeInBytes = streamReader.BaseStream.Length;
                fileLengthMilliseconds = (long)Math.Round((float)fileSizeInBytes / (frameLengthInBytes) * (100f / 3));
                lowerBoundByteOffset = 0;
                upperBoundByteOffset = fileSizeInBytes;

                this.savedStreamFilePath = savedStreamFilePath;
                savedStreamFileSet = true;
                return;
            }

            savedStreamFileSet = false;
        }

        public DepthFrameReader Open()
        {
            sensorOpened = true;
            sw.Start();
            return this;
        }

        internal void dequeueFrame(object sender, EventArgs e)
        {
            if (!pauseStreamingRequested)
            {
                currentlyDequeing = true;

                bool success;
                if (freezeCurrentFrame)
                    success = concurrentReadingQueue.TryPeek(out currentFrame);
                else
                    success = concurrentReadingQueue.TryDequeue(out currentFrame);

                if (success)
                {
                    currentDepthFrame = new DepthFrame(currentFrame.Item2);

                    ////Console.WriteLine(calcFrameNumber(currentFrame.Item1) + " (deq)");
                }
                
            }

            if (pauseStreamingRequested)
            {
                //Console.WriteLine("Steraming was paused due to buffering or cleaning up the queue. Occurs when changes are made in the GUI while running.");
                currentlyDequeing = false;
            }
        }


        private FrameSource inputSource = FrameSource.KINECT;
        private DepthFrame liveDepthFrame;
        private ushort[] realFrameDataAsArray = new ushort[new FrameDescription().Height* new FrameDescription().Width];
        private bool newRealFrame = false;
        private bool currentlyProcessingFrameDataExternal = false;

        internal void kickFrameArrivedEvent(object sender, EventArgs e)
        {
            if (sensorOpened && FrameArrived != null && !currentlyProcessingFrameDataExternal)
            {

                DepthFrameArrivedEventArgs depthEvent = null;
                if (inputSource == FrameSource.KINECT && newRealFrame)
                {
                    depthEvent = new DepthFrameArrivedEventArgs(liveDepthFrame);
                    newRealFrame = false;
                }
                else if (inputSource == FrameSource.RECORDED && currentDepthFrame != null) 
                {
                    depthEvent = new DepthFrameArrivedEventArgs(currentDepthFrame);
                }
                else if (inputSource == FrameSource.ASTRA_PRO)
                {
                    depthEvent = new DepthFrameArrivedEventArgs(astraAdapter.LastFrame);
                }

                currentlyProcessingFrameDataExternal = true;

                if (depthEvent != null)
                    FrameArrived(this, depthEvent);

                currentlyProcessingFrameDataExternal = false;
            }

            // if (currentFrame != null)
            //Console.WriteLine(calcFrameNumber(currentFrame.Item1) + " (streamed)");
        }

        internal void realFrameArrived(object sender, Microsoft.Kinect.DepthFrameArrivedEventArgs e)
        {
            if (inputSource == FrameSource.KINECT)
            {
                using (Microsoft.Kinect.DepthFrame tempRealDepthFrame = realDepthFrameReader.AcquireLatestFrame())
                {
                    if (tempRealDepthFrame != null)
                    {
                        if (!freezeCurrentFrame)
                        {
                            tempRealDepthFrame.CopyFrameDataToArray(realFrameDataAsArray);
                            liveDepthFrame = new DepthFrame(realFrameDataAsArray);
                        }
                        newRealFrame = true;
                    }
                }
            }
        }
        
        public DepthFrame AcquireLatestFrame()
        {
            if (inputSource == FrameSource.KINECT)
                return liveDepthFrame;
            else
                return currentDepthFrame;
        }

        internal void startFillingQueueFromFile()
        {
            if (initiallyStarted)
            {
                //Console.WriteLine("Already reading from file.");
                return;
            }
                
            Thread readDataThread = new Thread(fillQueueFromFileLoop);
            readDataThread.Start();
        }

        private void fillQueueFromFileLoop()
        {
            while (true)
            {
                if (!pauseReadingRequested)
                {
                    if (concurrentReadingQueue.Count < 100)
                    {
                        //int previousMS = (int)sw.ElapsedMilliseconds;

                        try
                        {
                            if (streamReader.BaseStream.Position < lowerBoundByteOffset || streamReader.BaseStream.Position >= upperBoundByteOffset)
                            {
                                //Console.WriteLine("End of repeating interval reached at Position: " + streamReader.BaseStream.Position);
                                streamReader.BaseStream.Position = lowerBoundByteOffset;
                                streamReader.BaseStream.Flush();
                            }

                            recentlyReadFrameByteOffset = streamReader.BaseStream.Position;
                            for (int i = 0; i < recentylReadFrameData.Length; i++)
                            {
                                recentylReadFrameData[i] = streamReader.ReadUInt16();
                            }

                            ////Console.WriteLine(calcFrameNumber(recentlyReadFrameByteOffset) + " (read)");

                            concurrentReadingQueue.Enqueue(new Tuple<long, ushort[]>(recentlyReadFrameByteOffset, recentylReadFrameData));
                        }
                        catch (EndOfStreamException ex)
                        {
                            //Console.WriteLine("Stream reached EOF, returning to beginning.");
                            streamReader.BaseStream.Position = lowerBoundByteOffset;
                            streamReader.BaseStream.Flush();
                        }
                        catch (ObjectDisposedException ex)
                        {
                            //Console.WriteLine("Stream already closed (Exception).");
                        }
                        catch (Exception e)
                        {
                            streamReader.BaseStream.Position = lowerBoundByteOffset;
                            streamReader.BaseStream.Flush();
                        }

                        //int testMS = (int)DepthFrameReader.sw.ElapsedMilliseconds;
                        //DepthFrameReader.performanceTestList.Add(testMS - previousMS);
                    }
                    else
                    {
                        new ManualResetEvent(false).WaitOne(20);
                    }
                }
                else
                {
                    currentlyReading = false;
                    new ManualResetEvent(false).WaitOne(20);
                }
            }
        }

        internal void changeFreezeMarker()
        {
            freezeCurrentFrame = !freezeCurrentFrame;
        }


        private long transformMillisecondsToBytes(long ms)
        {
            return (long)Math.Round((double)ms / 100 * 3) * recentylReadFrameData.Length * 2;
        }

        private long transformBytesToMilliseconds(long bytes)
        {
            return bytes / (recentylReadFrameData.Length * 2) * 100 / 3;
        }

        private long calcFrameNumber(long frameBytes)
        {
            return frameBytes / (recentylReadFrameData.Length * 2);
        }

        internal long getFileSizeInMS()
        {
            return transformBytesToMilliseconds(fileSizeInBytes);
        }


        internal void setFrameSource(FrameSource src)
        {
            this.inputSource = src;
            if (inputSource == FrameSource.RECORDED)
                pauseStreamingRequested = true;
            else
                pauseStreamingRequested = false;
        }
    }
}