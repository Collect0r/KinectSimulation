using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class DepthFrame : IDisposable
    {
        private ushort[] fakeFrameDataAsArray;

        public ushort DepthMinReliableDistance = 500;
        public ushort DepthMaxReliableDistance = ushort.MaxValue;

        public DepthFrame(ushort[] fakeFrameDataAsArray)
        {
            this.fakeFrameDataAsArray = fakeFrameDataAsArray;
        }

        public void CopyFrameDataToArray(ref ushort[] frameDataToBeFilled)
        {
            frameDataToBeFilled = fakeFrameDataAsArray;
        }

        public KinectBuffer LockImageBuffer()
        {
            return new KinectBuffer(fakeFrameDataAsArray);
        }

        public void Dispose()
        {
            // ?? maybe dispose kinectbuffer
        }
    }
}
