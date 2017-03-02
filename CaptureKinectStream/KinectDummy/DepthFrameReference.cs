using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class DepthFrameReference
    {
        private DepthFrame depthFrame;

        internal DepthFrameReference(DepthFrame depthFrame)
        {
            this.depthFrame = depthFrame.getDeepCopy();
        }
        
        public DepthFrame AcquireFrame()
        {
            return depthFrame;  
        }
    }
}
