using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    //public delegate void EventHandler<IsAvailableChangedEventArgs>(object sender, IsAvailableChangedEventArgs e);

    public class KinectSensor
    {
        public DepthFrameSource DepthFrameSource { get; }

        public bool IsAvailable { get; } = true;

        public EventHandler<IsAvailableChangedEventArgs> IsAvailableChanged;

        private Microsoft.Kinect.KinectSensor realKinectSensor;

        internal static KinectSensor currentKinectSensorForInternalPurposes;

        internal KinectSensor()
        {
            try
            {
                realKinectSensor = Microsoft.Kinect.KinectSensor.GetDefault();
                DepthFrameSource = new DepthFrameSource(this, realKinectSensor);
            }
            catch (Exception e)
            {
                Console.WriteLine("No real Kinect found. Initializing Player without Kinect.");
                DepthFrameSource = new DepthFrameSource(this);
            }
        }

        public void Open()
        {
            if (realKinectSensor != null)
                realKinectSensor.Open();
        }

        public void Close()
        {
            if (realKinectSensor != null)
                realKinectSensor.Close();
        }

        public static KinectSensor GetDefault()
        {
            currentKinectSensorForInternalPurposes = new KinectSensor();
            return currentKinectSensorForInternalPurposes;
        }
    }
}
