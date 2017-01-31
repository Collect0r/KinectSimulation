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

        internal FrameDescription()
        {
            Width = 512;
            Height = 424;
        }
    }
}
