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

        public DepthFrameReference(DepthFrame depthFrame)
        {
            this.depthFrame = depthFrame;
        }
        
        public DepthFrame AcquireFrame()
        {
            return depthFrame;  
        }
    }
}
