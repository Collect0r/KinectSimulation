using System;
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
        private static CapturingController captureController;

        private static CaptureControlGUI gui;

        internal static void startGUIParallel(CapturingController kinectCapturing)
        {
            if (kinectCapturing == null)
                throw new InvalidOperationException("KinectCapturing must be initialized.");

            if (captureController != null)
                throw new InvalidOperationException("GUI already started!");

            captureController = kinectCapturing;

            Thread thread = new Thread(startGUI);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void startGUI()
        {
            gui = new CaptureControlGUI(captureController);
            Application.Run(gui);
        }

        internal static CaptureControlGUI getGUI()
        {
            return gui;
        }
    }
}
