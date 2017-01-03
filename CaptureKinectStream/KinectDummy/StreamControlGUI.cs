using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectDummy
{
    public partial class StreamControlGUI : Form
    {
        private String savedKinectStreamFilePath;
        private DepthFrameReader depthFrameReader;
        private bool currentlyStreaming = false;
        private bool mouseDown = false;
        
        public StreamControlGUI(DepthFrameReader depthFrameReader)
        {
            this.depthFrameReader = depthFrameReader;
            InitializeComponent();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "kinect files (*.kcs)|*.kcs";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savedKinectStreamFilePath = openFileDialog1.FileName;
            }
        }

        private void toggleStreamButton_Click(object sender, EventArgs e)
        {
            if (currentlyStreaming)
            {
                toggleStreamButton.Text = "Start Streaming";
                depthFrameReader.pauseStreamingByGUI();
            }
            else
            {
                toggleStreamButton.Text = "Pause Streaming";
                depthFrameReader.setSavedStreamFilePath(savedKinectStreamFilePath);
                depthFrameReader.startStreaming();
            }
            currentlyStreaming = !currentlyStreaming;
        }

        private void selectionRangeSlider1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void selectionRangeSlider1_SelectionChanged(object sender, EventArgs e)
        {

        }

        // to prevent the reading-loop from updating the Slider in the GUI
        private void selectionRangeSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void selectionRangeSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void updateSliderGUI(object sender, EventArgs e)
        {
            if (!mouseDown)
            {
                //depthFrameReader
            }
        }
    }
}
