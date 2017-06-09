using System;

namespace KinectDummy
{
    //public delegate void EventHandler<IsAvailableChangedEventArgs>(object sender, IsAvailableChangedEventArgs e);

    public class KinectSensor
    {
        public DepthFrameSource DepthFrameSource { get; }

        public bool IsAvailable { get; } = true;

        public EventHandler<IsAvailableChangedEventArgs> IsAvailableChanged;

        internal static KinectSensor currentKinectSensorForInternalPurposes;

        internal KinectSensor()
        {
            try
            {
                DepthFrameSource = new DepthFrameSource(this);
            }
            catch (Exception e)
            {
                Console.WriteLine("No real Kinect found. Initializing Player without Kinect.");
                DepthFrameSource = new DepthFrameSource(this);
            }
        }

        public void Open()
        {
            // just dummy method to keept the kinect API
        }

        public void Close()
        {
            // dummy method
        }

        public static KinectSensor GetDefault()
        {
            currentKinectSensorForInternalPurposes = new KinectSensor();
            return currentKinectSensorForInternalPurposes;
        }
    }
}
