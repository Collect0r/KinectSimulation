﻿using System;
using System.Net;
using System.Net.Sockets;

namespace KinectDummy.InputSources
{
    class AstraProAdapter
    {
        // image parameters
        private const int WIDTH = 640;
        private const int HEIGHT = 480;
        private const int LINES_PER_FRAGMENT = 40;

        // connection parameters
        private const int PORT = 13000;
        private IPAddress LOCAL_ADDRESS = IPAddress.Parse("127.0.0.1");
        private TcpListener server = null;
        private volatile bool shouldStop = false;

        // data buffer. Do not take it for the whole image. Just an excerpt.
        // bytes per pixel (short): 2
        private Byte[] buf = new Byte[WIDTH * LINES_PER_FRAGMENT * 2];

        private int fragmentId = 0;

        private ushort[] curImageData = new ushort[WIDTH * HEIGHT];
        private long frameIndex = 0;

        public DepthFrame LastFrame {
            get
            {
                return new DepthFrame(curImageData);
            }
            private set { }
        }


        public AstraProAdapter()
        {
            // TcpListener server = new TcpListener(port);
            server = new TcpListener(LOCAL_ADDRESS, PORT);
        }

        /// <summary>
        /// Starts server and begins listening. Caution: should not be called from main thread! Will block otherwise.
        /// </summary>
        public void start()
        {
            shouldStop = false;

            try
            {
                // Start listening for client requests.
                server.Start();

                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                fragmentId = 0;

                // Enter the listening loop.
                while (!shouldStop)
                {
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(buf, 0, buf.Length)) != 0)
                    {
                        // TODO check if always working
                        fragmentId = (fragmentId + 1) % 12;     // mod 12: each frame is split into 12 fragments.
                        copy(buf, fragmentId, curImageData);

                        // increasing frame index when whole image was transmitted
                        frameIndex = fragmentId == 0 ? frameIndex + 1 : frameIndex;
                    }
                }


                // Shutdown and end connection
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        public void stop()
        {
            shouldStop = true;
        }

        private void copy(byte[] fragment, int fragmentId, ushort[] destImage)
        {
            for (int i = 0, j = fragmentId * WIDTH * LINES_PER_FRAGMENT; i < WIDTH * LINES_PER_FRAGMENT; i++, j++)
                destImage[j] = (ushort)BitConverter.ToInt16(fragment, i * 2);   // i * 2 because two bytes per short
        }

    }
}
