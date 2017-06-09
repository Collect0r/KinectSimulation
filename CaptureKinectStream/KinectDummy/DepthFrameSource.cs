using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class DepthFrameSource
    {
        public FrameDescription FrameDescription { get; }
        public ushort DepthMinReliableDistance { get; } = 500;
        public ushort DepthMaxReliableDistance { get; } = ushort.MaxValue;
        public bool IsActive { get; private set; } = false;
        public KinectSensor KinectSensor { get; private set; }

        private DepthFrameReader depthFrameReader;

        internal DepthFrameSource(KinectSensor currentSensor)
        {
            this.KinectSensor = currentSensor;
            FrameDescription = new FrameDescription();
            depthFrameReader = new DepthFrameReader();
        }

        public DepthFrameReader OpenReader()
        {
            IsActive = true;
            return depthFrameReader.Open();
        }
    }
}
