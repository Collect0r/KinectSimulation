using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    public class DepthFrameReader
    {
        private ushort[] recentylReadFrameData = new ushort[new FrameDescription().Height * new FrameDescription().Width];
        private long recentlyReadFrameByteOffset = 0;

        public EventHandler<DepthFrameArrivedEventArgs> FrameArrived;
        public BinaryReader streamReader;

        private String savedStreamFilePath;

        //private ConcurrentQueue<ushort[]> concQueue = new ConcurrentQueue<ushort[]>();
        private ConcurrentQueue<Tuple<long,ushort[]>> concurrentReadingQueue = new ConcurrentQueue<Tuple<long, ushort[]>>();
        private bool pauseReadingRequested = false;
        private bool pauseStreamingRequested = false;
        private bool currentlyReading = false;
        private bool currentlyStreaming = false;
        private bool initiallyStarted = false;
        private bool savedStreamFileSet = false;
        private bool sensorOpened = false;
        //private bool pauseStreaming = false; // set to true if the queue has to buffer before being able to stream or if the bounds/currentPosition has been changed in the GUI and the queue has to be cleared up
        //private bool queueAccessable = false; // gets set to true at the next frame-kick after 'pauseStreaming' was set to true
        //private bool currentlyReading = false;
        //private bool readStopRequested = false;

        public static List<int> performanceTestList = new List<int>(400);

        private AccurateTimer frameArrivedTimer = new AccurateTimer() { Interval = 33 };
        private int frameEveryXms;
        private int frameMScounter;
        private int frameCounter;

        public static Stopwatch sw = new Stopwatch();

        private DepthFrame currentDepthFrame;

        private long fileSizeInBytes;
        private long lowerBoundByteOffset;
        private long upperBoundByteOffset;
        private int frameLengthInBytes = new FrameDescription().Height * new FrameDescription().Width * 2;
        private Tuple<long, ushort[]> currentFrame;

        private long fileLengthMilliseconds;
        //private long lowerBoundMilliseconds;
        //private long upperBoundMilliseconds;
        //private long currentPositionMilliseconds;

        private int counter;

        public DepthFrameReader(int fps)
        {
            //ushort Min = 2000;
            //ushort Max = 6000;
            //Random randNum = new Random();
            //mostRecentStreamedFrameData = Enumerable.Repeat(0, mostRecentStreamedFrameData.Length).Select(i => (ushort)randNum.Next(Min, Max)).ToArray();

            //currentDepthFrame = new DepthFrame(mostRecentStreamedFrameData);

            //streamReader.BaseStream.Seek((long)firstFrameOffset * fakeFrameDataAsArray.Length * 2, SeekOrigin.Begin);

            frameEveryXms = (int)Math.Round(1000d / fps);
            frameMScounter = 0;
            frameCounter = 0;

            GUIControl.startGUIParallel(this);
        }

        public void setRepeatingInterval(long lowerBoundMS, long upperBoundMS)
        {
            if (!initiallyStarted)
                return;

            requestFullQueueAccess(); // may freeze everything??
            
            Tuple<long, ushort[]> tempPosition;
            bool success = concurrentReadingQueue.TryDequeue(out tempPosition);
            if (success)
                streamReader.BaseStream.Position = tempPosition.Item1;

            cleanUpQueue();

            lowerBoundByteOffset = transformMillisecondsToBytes(lowerBoundMS);
            upperBoundByteOffset = transformMillisecondsToBytes(upperBoundMS);

            pauseReadingRequested = false;
            pauseStreamingRequested = false;
        }

        public void setTimelinePosition(long currentMS)
        {
            if (!initiallyStarted)
                return;

            requestFullQueueAccess(); // may freeze everything??

            cleanUpQueue();

            streamReader.BaseStream.Position = transformMillisecondsToBytes(currentMS);
            streamReader.BaseStream.Flush();
            
            pauseReadingRequested = false;
            pauseStreamingRequested = false;
        }

        private void requestFullQueueAccess()
        {
            pauseReadingRequested = true;
            pauseStreamingRequested = true;

            while (!currentlyReading || !currentlyStreaming)
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
        
        public long getLowerBoundMilliseconds()
        {
            return transformBytesToMilliseconds(lowerBoundByteOffset);
        }

        public long getUpperBoundMilliseconds()
        {
            return transformBytesToMilliseconds(upperBoundByteOffset);
        }

        public long getCurrentFrameMilliseconds()
        {
            return transformBytesToMilliseconds(currentFrame.Item1);
        }

        public void Dispose()
        {
            frameArrivedTimer.Elapsed -= frameArrived;

            if (frameArrivedTimer.IsRunning)
                frameArrivedTimer.Stop();

            streamReader.Dispose();
            
            using (StreamWriter fs = new StreamWriter(@"C:\\Users\\Joachim\\Desktop\\IFL\\performanceTest.txt"))
            {
                foreach (int val in performanceTestList)
                {
                    fs.WriteLine(val);
                }
            }
        }

        public void startStreaming()
        {
            if (savedStreamFileSet)
            {
                startFillingQueueFromFile();
                frameArrivedTimer.Elapsed += frameArrived;
                pauseStreamingRequested = false;
                initiallyStarted = true;
            }
        }

        public void pauseStreamingByGUI()
        {
            frameArrivedTimer.Elapsed -= frameArrived;
            pauseStreamingRequested = true;
            currentlyStreaming = false;
        }

        public void setSavedStreamFilePath(String savedStreamFilePath)
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
            }

            savedStreamFileSet = false;
        }

        public DepthFrameReader Open()
        {
            sensorOpened = true;
            sw.Start();
            return this;
        }

        public void frameArrived(object sender, EventArgs e)
        {
            if (!pauseStreamingRequested)
            {
                currentlyStreaming = true;
                frameMScounter += 33;

                if (frameMScounter >= frameEveryXms)
                {
                    frameMScounter -= frameEveryXms;

                    bool success = concurrentReadingQueue.TryDequeue(out currentFrame);

                    if (success)
                        currentDepthFrame = new DepthFrame(currentFrame.Item2);

                    Console.WriteLine(++counter);

                    if (sensorOpened && success && FrameArrived != null)
                        FrameArrived(this, new DepthFrameArrivedEventArgs(currentDepthFrame));
                }
            }

            if (pauseStreamingRequested)
            {
                Console.WriteLine("Steraming was paused due to buffering or cleaning up the queue. Occurs when changes are made in the GUI while running.");
                currentlyStreaming = false;
            }
        }

        public DepthFrame AcquireLatestFrame()
        {
            return currentDepthFrame;
        }

        public void startFillingQueueFromFile()
        {
            if (initiallyStarted)
            {
                Console.WriteLine("Already reading from file.");
                return;
            }
                
            Thread readDataThread = new Thread(fillQueueFromFileLoop);
            readDataThread.Start();
        }

        private void fillQueueFromFileLoop()
        {
            frameArrivedTimer.Start();

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
                                Console.WriteLine("End of repeating interval reached at Position: " + streamReader.BaseStream.Position);
                                streamReader.BaseStream.Position = lowerBoundByteOffset;
                                streamReader.BaseStream.Flush();
                            }

                            recentlyReadFrameByteOffset = streamReader.BaseStream.Position;
                            for (int i = 0; i < recentylReadFrameData.Length; i++)
                            {
                                recentylReadFrameData[i] = streamReader.ReadUInt16();
                            }

                            Console.WriteLine(calcFrameNumber(recentlyReadFrameByteOffset));

                            concurrentReadingQueue.Enqueue(new Tuple<long, ushort[]>(recentlyReadFrameByteOffset, recentylReadFrameData));
                        }
                        catch (EndOfStreamException ex)
                        {
                            Console.WriteLine("Stream reached EOF, returning to beginning.");
                            streamReader.BaseStream.Position = lowerBoundByteOffset;
                            streamReader.BaseStream.Flush();
                        }
                        catch (ObjectDisposedException ex)
                        {
                            Console.WriteLine("Stream already closed (Exception).");
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
                    streamReader.BaseStream.Flush();
                    new ManualResetEvent(false).WaitOne(20);
                }
            }
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
        
    }
}