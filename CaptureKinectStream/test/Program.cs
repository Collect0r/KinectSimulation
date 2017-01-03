using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaptureKinectStream;
using System.IO;
using System.Text;
using KinectDummy;
using System.Threading;

namespace test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //KinectSensor kinect = new KinectSensor();

            //KinectCapturing capturer = new KinectCapturing(kinect);
            //capturer.startCapturing("C:\\Users\\Joachim\\Desktop\\kinectTestCompressed");
            
            //Thread.Sleep(100000);
            
        }
    }
}
