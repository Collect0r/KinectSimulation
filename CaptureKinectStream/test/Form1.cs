using CaptureKinectStream;
using KinectDummy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public String savedKinectStreamFilePath;
        public int fps = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "kinect files (*.kcs)|*.kcs";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savedKinectStreamFilePath = openFileDialog1.FileName;

                //Console.WriteLine(savedKinectStreamFilePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KinectSensor kinect = KinectSensor.GetDefault();
            DepthFrameReader reader = kinect.DepthFrameSource.OpenReader();
            reader.FrameArrived += myDummyMethod;
        }

        private void myDummyMethod(object sender, DepthFrameArrivedEventArgs e)
        {
            // don't do anything
        }
    }
}
