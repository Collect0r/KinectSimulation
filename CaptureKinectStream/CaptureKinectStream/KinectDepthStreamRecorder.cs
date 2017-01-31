//using KinectDummy;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureKinectStream
{
    public static class KinectDepthStreamRecorder
    {
        public static void startController()
        {
            GUIControl.startGUIParallel();
        }

        public static void recordThisFrame(DepthFrame currentFrame)
        {
            GUIControl.recordThisFrame(currentFrame);
        }

        public static void recordThisFrame(KinectDummy.DepthFrame currentFrame)
        {
            GUIControl.recordThisFrame(currentFrame);
        }
    }
}
