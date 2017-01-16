using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDummy
{
    public class IsAvailableChangedEventArgs : EventArgs
    {
        public bool IsAvailable { get; } = true;

        public IsAvailableChangedEventArgs()
        {

        }
    }
}
