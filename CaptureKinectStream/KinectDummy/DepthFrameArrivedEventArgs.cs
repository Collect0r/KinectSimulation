using System;

namespace KinectDummy
{
    public enum InputType { KINECT, ASTRA_PRO, RECORDED }

    public class DepthFrameArrivedEventArgs : EventArgs
    {
        public DepthFrameReference FrameReference { get; }

        public InputType InputDevice { get; }

        internal DepthFrameArrivedEventArgs(DepthFrame depthFrame, InputType device)
        {
            FrameReference = new DepthFrameReference(depthFrame);
            InputDevice = device;
        }
    }
}
