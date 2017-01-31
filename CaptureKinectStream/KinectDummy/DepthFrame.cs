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

        public ushort DepthMinReliableDistance { get; } = 500;
        public ushort DepthMaxReliableDistance { get; } = ushort.MaxValue;
        public FrameDescription FrameDescription { get; } = new FrameDescription();
        public DepthFrameSource DepthFrameSource { get; } = KinectSensor.currentKinectSensorForInternalPurposes.DepthFrameSource;

        internal DepthFrame(ushort[] fakeFrameDataAsArray)
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
