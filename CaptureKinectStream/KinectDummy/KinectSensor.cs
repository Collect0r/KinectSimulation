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

        public KinectSensor(int fps)
        {
            DepthFrameSource = new DepthFrameSource(fps);
        }

        public void Open()
        {
            
        }

        public static KinectSensor GetDefault()
        {
            return new KinectSensor(30);
        }
    }
}
