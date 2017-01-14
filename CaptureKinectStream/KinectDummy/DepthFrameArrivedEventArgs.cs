using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class DepthFrameArrivedEventArgs : EventArgs
    {
        public DepthFrameReference FrameReference;

        public DepthFrameArrivedEventArgs(DepthFrame depthFrame)
        {
            FrameReference = new DepthFrameReference(depthFrame);
        }
    }
}
