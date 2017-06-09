using System;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;
using KinectDummy;

namespace CaptureKinectStream
{
    internal static class DataStreamHandler
    {
        //static int counter = 0;
        //static int counter2 = 0;
        private static ConcurrentQueue<ushort[]> concurrentWritingQueue = new ConcurrentQueue<ushort[]>();
        private static String filePath;
        private static bool writeStopRequested = true;
        private static int unsuccessfulTries = 0;

        internal static void requestWriteStop()
        {
            writeStopRequested = true;
        }

        internal static void addFrameToQueue(ushort[] frame)
        {
            concurrentWritingQueue.Enqueue(frame);
            
            //Console.WriteLine(counter2++ + " enqueued");
        }

        internal static void startWritingQueueToFile(String filePathNew)
        {
            writeStopRequested = false;
            filePath = filePathNew;

            Thread writeDataThread = new Thread(writeQueueToFileLoop);
            writeDataThread.Start();
        }

        private static void writeQueueToFileLoop()
        {
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Create));

            ushort[] currentFrameDepthData;
            bool success = false;

            while (!(writeStopRequested && concurrentWritingQueue.IsEmpty && unsuccessfulTries >= 100))
            {
                if (!concurrentWritingQueue.IsEmpty)
                {
                    //int previousMS = (int)DepthFrameReader.sw.ElapsedMilliseconds;

                    success = concurrentWritingQueue.TryDequeue(out currentFrameDepthData);

                    if (success)
                    {
                        for (int i = 0; i < currentFrameDepthData.Length; i++)
                        {
                            binaryWriter.Write(currentFrameDepthData[i]);
                        }

                        //Console.WriteLine(counter++ + " written");
                        unsuccessfulTries = 0;
                        //byte[] compressedData = getCompressedData(currentFrameDepthData);
                        //binaryWriter.Write(compressedData);

                        ////Console.WriteLine(counter++);
                    }
                }
                else
                {
                    new ManualResetEvent(false).WaitOne(10);
                    unsuccessfulTries++;
                }
            }

            //Console.WriteLine("Finished writing data to file.");

            if (GUIControl.getGUI() != null)
                GUIControl.getGUI().sendStopRecordingCallback();

            binaryWriter.Dispose();
        }

    }
}
