using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectDummy
{
    internal static class GUIControl
    {
        private static DepthFrameReader dfr;

        internal static void startGUIParallel(DepthFrameReader depthFrameReader)
        {
            dfr = depthFrameReader;
            Thread thread = new Thread(startGUI);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void startGUI()
        {
            Application.Run(new StreamControlGUI(dfr));
        }
    }
}
