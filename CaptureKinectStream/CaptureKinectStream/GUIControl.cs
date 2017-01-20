using System;
using Microsoft.Kinect;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureKinectStream
{
    public static class GUIControl
    {
        private static CapturingController captureController = null;

        private static KinectSensor thisKinect;

        private static CaptureControlGUI gui;

        public static void startGUIParallel(KinectSensor kinect)
        {
            if (kinect == null)
                throw new InvalidOperationException("Kinect not found.");

            if (captureController != null)
                throw new InvalidOperationException("GUI already started!");

            thisKinect = kinect;

            Thread thread = new Thread(startGUI);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void startGUI()
        {
            captureController = new CapturingController(thisKinect);
            gui = new CaptureControlGUI(captureController);
            Application.Run(gui);
        }

        public static CaptureControlGUI getGUI()
        {
            return gui;
        }

        public static void recordThisFrame(DepthFrame currentFrame)
        {
            if (captureController != null)
                captureController.recordThisFrame(currentFrame);
        }
    }
}
