using System;
using System.Windows.Forms;

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
