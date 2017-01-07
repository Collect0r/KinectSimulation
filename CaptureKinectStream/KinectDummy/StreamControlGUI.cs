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
        enum SliderValueChangeType { SelectedBound, SelectedValue }

        private String savedKinectStreamFilePath;
        private DepthFrameReader depthFrameReader;
        private bool currentlyStreaming = false;
        private bool mouseDown = false;
        private AccurateTimer updateGUItimer = new AccurateTimer() { Interval = 200 };
        private long fileLengthMS;
        private bool firstStart = true;
        private SliderValueChangeType recentlyChangedValue;
        private int fps = 30;
        private bool changedByReader = false;

        private delegate void updateTimeBarDelegate();

        public StreamControlGUI(DepthFrameReader depthFrameReader)
        {
            this.depthFrameReader = depthFrameReader;
            InitializeComponent();

        }
        
        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                updateGUItimer.Elapsed -= invokeUpdateTimeBar;
                updateGUItimer.Stop();
            }
            else
            {
                toggleStreamButton.Text = "Pause Streaming";
                depthFrameReader.setSavedStreamFilePath(savedKinectStreamFilePath);

                if (firstStart)
                {
                    fileLengthMS = depthFrameReader.getFileSizeInMS();
                    selectionRangeSlider1.Max = fileLengthMS;
                    selectionRangeSlider1.Min = 0;
                    selectionRangeSlider1.SelectedMax = fileLengthMS;
                }

                depthFrameReader.startStreaming(fps);

                updateGUItimer.Elapsed += invokeUpdateTimeBar;
                updateGUItimer.Start();

                firstStart = false;
            }
            currentlyStreaming = !currentlyStreaming;
        }


        private void invokeUpdateTimeBar(object sender, EventArgs e)
        {
            if (!mouseDown)
                selectionRangeSlider1.Invoke(new updateTimeBarDelegate(updateTimeBar));
        }

        private void updateTimeBar()
        {
            long tempVal = depthFrameReader.getCurrentFrameMilliseconds();

            if (tempVal > 0 && tempVal < fileLengthMS)
            {
                selectionRangeSlider1.Value = tempVal;

                if (!currentPositionBox.Focused)
                {
                    changedByReader = true;
                    currentPositionBox.Text = tempVal.ToString();
                }
            }
        }
        
        private void selectionRangeSlider1_ValueChanged(object sender, EventArgs e)
        {
            recentlyChangedValue = SliderValueChangeType.SelectedValue;   
        }

        private void selectionRangeSlider1_SelectionChanged(object sender, EventArgs e)
        {
            recentlyChangedValue = SliderValueChangeType.SelectedBound;
        }

        // to prevent the reading-loop from updating the Slider in the GUI
        private void selectionRangeSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void selectionRangeSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            changeTimelineValues();

            mouseDown = false;
        }

        private void changeTimelineValues()
        {
            switch (recentlyChangedValue)
            {
                case SliderValueChangeType.SelectedValue:
                    depthFrameReader.setTimelinePosition(selectionRangeSlider1.Value);
                    currentPositionBox.Text = depthFrameReader.getCurrentFrameMilliseconds().ToString();
                    break;
                default:
                    depthFrameReader.setRepeatingInterval(selectionRangeSlider1.SelectedMin, selectionRangeSlider1.SelectedMax);
                    lowerBoundBox.Text = depthFrameReader.getLowerBoundMilliseconds().ToString();
                    upperBoundBox.Text = depthFrameReader.getUpperBoundMilliseconds().ToString();
                    break;
            }
        }

        private void fpsSetter_ValueChanged(object sender, EventArgs e)
        {
            if (fpsSetter.Value < 1)
                fpsSetter.Value = 1;

            if (fpsSetter.Value > 30)
                fpsSetter.Value = 30;

            fps = (int)fpsSetter.Value;

            depthFrameReader.changeFPS(fps);
        }

        private void StreamControlGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            depthFrameReader.Dispose();
        }

        private void lowerBoundBox_TextChanged(object sender, EventArgs e)
        {
            int potentialNewLowerBound;
            bool success = Int32.TryParse(lowerBoundBox.Text, out potentialNewLowerBound);
            if (success && potentialNewLowerBound >= 0 && potentialNewLowerBound <= fileLengthMS && potentialNewLowerBound <= selectionRangeSlider1.SelectedMax)
            {
                selectionRangeSlider1.SelectedMin = potentialNewLowerBound;
                recentlyChangedValue = SliderValueChangeType.SelectedBound;
                changeTimelineValues();
            }
            else
            {
                lowerBoundBox.Text = depthFrameReader.getLowerBoundMilliseconds().ToString();
            }
        }

        private void currentPositionBox_TextChanged(object sender, EventArgs e)
        {
            if (changedByReader)
            {
                changedByReader = false;
                return;
            }
            int potentialNewSliderPosition;
            bool success = Int32.TryParse(currentPositionBox.Text, out potentialNewSliderPosition);
            if (success && potentialNewSliderPosition >= 0 && potentialNewSliderPosition <= fileLengthMS)
            {
                selectionRangeSlider1.Value = potentialNewSliderPosition;
                recentlyChangedValue = SliderValueChangeType.SelectedValue;
                changeTimelineValues();
            }
            else
            {
                currentPositionBox.Text = depthFrameReader.getCurrentFrameMilliseconds().ToString();
            }
        }

        private void upperBoundBox_TextChanged(object sender, EventArgs e)
        {
            int potentialNewUpperBound;
            bool success = Int32.TryParse(upperBoundBox.Text, out potentialNewUpperBound);
            if (success && potentialNewUpperBound >= 0 && potentialNewUpperBound <= fileLengthMS && potentialNewUpperBound >= selectionRangeSlider1.SelectedMin)
            {
                selectionRangeSlider1.SelectedMax = potentialNewUpperBound;
                recentlyChangedValue = SliderValueChangeType.SelectedBound;
                changeTimelineValues();
            }
            else
            {
                upperBoundBox.Text = depthFrameReader.getUpperBoundMilliseconds().ToString();
            }
        }

        private void freezeButton_Click(object sender, EventArgs e)
        {
            depthFrameReader.changeFreezeMarker();
        }
    }
}
