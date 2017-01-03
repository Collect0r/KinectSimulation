using KinectDummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureKinectStream
{
    public static class KinectDepthStreamRecorder
    {
        public static void startController(KinectSensor kinect)
        {
            GUIControl.startGUIParallel(new CapturingController(kinect));
        }
    }
}
