using System;
using KinectDummy;
using System.Diagnostics;

namespace CaptureKinectStream
{
    internal class CapturingController
    {
        private static Stopwatch sw;
        
        private DepthFrameReader depthFrameReader;
        private ushort[] depthFrameAsArray;
        private int width;
        private int height;
        private bool firstFrame = true;
        private int secondsToCapture;

        internal CapturingController()
        {
        }

        internal void startCapturing(String filePath, int secondsToCapture = 0)
        {
            this.secondsToCapture = secondsToCapture;

            width = 512;
            height = 424;
            depthFrameAsArray = new ushort[width * height];
            
            sw = new Stopwatch();

            DataStreamHandler.startWritingQueueToFile(filePath);
            
            //depthFrameReader.FrameArrived += depthDataReadyEventHandler;
            currentlyCapturing = true;
        }

        internal void stopCapturing()
        {
            sw.Stop();
            sw.Reset();
            DataStreamHandler.requestWriteStop();
            //depthFrameReader.FrameArrived -= depthDataReadyEventHandler;
            currentlyCapturing = false;
            firstFrame = true;

            //Console.WriteLine("STOPPED");
        }

        private void depthDataReadyEventHandler(object sender, DepthFrameArrivedEventArgs e)
        {
            if (firstFrame)
            {
                firstFrame = false;
                sw.Start();
            }

            // if secondsToCapture == 0 then the capturing stops only if the user clicks the stop-button
            if (secondsToCapture > 0 && sw.ElapsedMilliseconds > 1000 * secondsToCapture)
            {
                stopCapturing();
            }
            else
            {
                using (DepthFrame tempRealDepthFrame = e.FrameReference.AcquireFrame())
                {
                    if (tempRealDepthFrame != null)
                    {
                        tempRealDepthFrame.CopyFrameDataToArray(ref depthFrameAsArray);
                        DataStreamHandler.addFrameToQueue(depthFrameAsArray);
                    }
                    else
                    {
                        //Console.WriteLine("nope");
                    }
                }
            }
        }

        private bool currentlyCapturing = false;

        internal void recordThisFrame(KinectDummy.DepthFrame currentFrame)
        {
            if (currentlyCapturing)
            {
                if (firstFrame)
                {
                    firstFrame = false;
                    sw.Start();
                }

                // if secondsToCapture == 0 then the capturing stops only if the user clicks the stop-button
                if (secondsToCapture > 0 && sw.ElapsedMilliseconds > 1000 * secondsToCapture)
                {
                    stopCapturing();
                }
                else
                {
                    currentFrame.CopyFrameDataToArray(ref depthFrameAsArray);

                    DataStreamHandler.addFrameToQueue(depthFrameAsArray);
                }
            }
        }
    }
}