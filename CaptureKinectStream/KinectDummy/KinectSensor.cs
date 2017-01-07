using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class KinectSensor
    {
        public DepthFrameSource DepthFrameSource { get; set; }

        public KinectSensor()
        {
            DepthFrameSource = new DepthFrameSource();
        }

        public void Open()
        {
            
        }

        public static KinectSensor GetDefault()
        {
            return new KinectSensor();
        }
    }
}
