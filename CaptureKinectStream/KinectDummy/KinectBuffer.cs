using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class KinectBuffer : IDisposable
    {
        public uint Size { get; } = 434176;
        public IntPtr UnderlyingBuffer { get; }

        private GCHandle pinnedFrameData;

        public KinectBuffer(byte[] frameData)
        {
            pinnedFrameData = GCHandle.Alloc(frameData, GCHandleType.Pinned);
            UnderlyingBuffer = pinnedFrameData.AddrOfPinnedObject();
        }

        public void Dispose()
        {
            pinnedFrameData.Free();
        }
    }
}
