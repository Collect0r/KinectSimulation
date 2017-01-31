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
    internal static class GUIControl
    {
        private static CapturingController captureController = null;

        private static CaptureControlGUI gui;

        internal static void startGUIParallel()
        {
            if (captureController != null)
                throw new InvalidOperationException("GUI already started!");
            
            Thread thread = new Thread(startGUI);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void startGUI()
        {
            captureController = new CapturingController();
            gui = new CaptureControlGUI(captureController);
            Application.Run(gui);
        }

        internal static CaptureControlGUI getGUI()
        {
            return gui;
        }

        internal static void recordThisFrame(DepthFrame currentFrame)
        {
            if (captureController != null)
                captureController.recordThisFrame(currentFrame);
        }

        internal static void recordThisFrame(KinectDummy.DepthFrame currentFrame)
        {
            if (captureController != null)
                captureController.recordThisFrame(currentFrame);
        }
    }
}
