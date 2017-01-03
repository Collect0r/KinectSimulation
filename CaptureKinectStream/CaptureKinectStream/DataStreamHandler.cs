using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
using KinectDummy;

namespace CaptureKinectStream
{
    // TODO: non public
    static class DataStreamHandler
    {
        private static int counter = 0;
        private static Mutex mutex = new Mutex();

        private static ConcurrentQueue<ushort[]> concurrentWritingQueue = new ConcurrentQueue<ushort[]>();
        private static String filePath;
        private static bool writeStopRequested = true;

        public static void requestWriteStop()
        {
            writeStopRequested = true;
        }

        public static void addFrameToQueue(ushort[] frame)
        {
            concurrentWritingQueue.Enqueue(frame);
        }

        public static void startWritingQueueToFile(String filePathNew)
        {
            if (!writeStopRequested)
            {
                Console.WriteLine("Alreaady writing to file.");
                return;
            }

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

            while (!(writeStopRequested && concurrentWritingQueue.IsEmpty))
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

                        //byte[] compressedData = getCompressedData(currentFrameDepthData);
                        //binaryWriter.Write(compressedData);

                        //Console.WriteLine(counter++);
                    }
                }
                else
                {
                    new ManualResetEvent(false).WaitOne(10);
                }
            }

            Console.WriteLine("Finished writing data to file.");
            binaryWriter.Dispose();
        }
        
        
        private static byte[] getCompressedData(ushort[] plainData)
        {
            byte[] compressedData = null;

            byte[] uncompressedData = new byte[plainData.Length * sizeof(ushort)];
            Buffer.BlockCopy(plainData, 0, uncompressedData, 0, plainData.Length * sizeof(ushort));

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (GZipStream zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(uncompressedData, 0, uncompressedData.Length);
                }
                //Dont get the MemoryStream data before the GZipStream is closed 
                //since it doesn’t yet contain complete compressed data.
                //GZipStream writes additional data including footer information when its been disposed
                compressedData = outputStream.ToArray();
            }

            return compressedData;
        }

        private static byte[] getDecompressedData(byte[] compressedData)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.

            using (GZipStream stream = new GZipStream(new MemoryStream(compressedData),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

    }
}
