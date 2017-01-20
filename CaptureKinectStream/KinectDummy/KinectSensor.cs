using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Kinect;

namespace KinectDummy
{
    //public delegate void EventHandler<IsAvailableChangedEventArgs>(object sender, IsAvailableChangedEventArgs e);

    public class KinectSensor
    {
        public DepthFrameSource DepthFrameSource { get; }

        public bool IsAvailable { get; } = true;

        public EventHandler<IsAvailableChangedEventArgs> IsAvailableChanged;

        public KinectSensor()
        {
            DepthFrameSource = new DepthFrameSource();
        }

        public void Open()
        {
            
        }

        public void Close()
        {

        }

        public static KinectSensor GetDefault()
        {
            return new KinectSensor();
        }

        //public void setRealKinectSensor()
    }
}
