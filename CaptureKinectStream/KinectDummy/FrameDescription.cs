using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class FrameDescription
    {
        public int Width { get; } //512 underlaying buffer
        public int Height { get; } //424 underlaying buffer

        public uint BytesPerPixel { get; } = 2;

        /*using (KinectDummy.KinectBuffer depthBuffer = DepthFrame.LockImageBuffer()) {
    
    depthBuffer.UnderlyingBuffer}

        public int Height { get; } // 424*/

        public FrameDescription()
        {
            Width = 512;
            Height = 424;
        }
    }
}
