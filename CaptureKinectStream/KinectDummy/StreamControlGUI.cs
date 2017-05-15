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
    internal partial class StreamControlGUI : Form
    {
        enum SliderValueChangeType { SelectedBound, SelectedValue }
        enum DataSourceMode { REAL_KINECT, RECORDED_DATA, REAL_KINECT_AND_RECORDED_DATA, ASTRA_PRO }

        private String savedKinectStreamFilePath;
        private String savedKinectStreamFolderPath;
        private DepthFrameReader depthFrameReader;
        private bool currentlyStreaming = false;
        private bool mouseDown = false;
        private AccurateTimer updateGUItimer = new AccurateTimer() { Interval = 200 };
        private long fileLengthMS;
        private bool firstStart = true;
        private SliderValueChangeType recentlyChangedValue;
        private int fps = 30;
        private bool changedByReader = false;
        private bool temporaryUpdateStop = false;
        private bool showFramesInsteadOfMS = false;
        private DataSourceMode dataSourceMode;
        private bool solelyStreamLiveFrames;

        private delegate void updateTimeBarDelegate();

        internal StreamControlGUI(DepthFrameReader depthFrameReader)
        {
            this.depthFrameReader = depthFrameReader;
            InitializeComponent();
            
            if (Properties.Settings.Default.StreamFilePath != "null")
            {
                savedKinectStreamFolderPath = Properties.Settings.Default.StreamFilePath;
            }
            else
            {
                savedKinectStreamFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            if (depthFrameReader.realKinectSet)
            {
                BtnKinect.Enabled = true;
                BtnDataSources.Enabled = true;
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void openFileDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = savedKinectStreamFolderPath;
            openFileDialog1.Filter = "kinect files (*.kcs)|*.kcs";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savedKinectStreamFilePath = openFileDialog1.FileName;
                savedKinectStreamFolderPath = System.IO.Path.GetDirectoryName(savedKinectStreamFilePath);
                Properties.Settings.Default.StreamFilePath = savedKinectStreamFolderPath;
                Properties.Settings.Default.Save();
                fileSetLabel.Text = savedKinectStreamFilePath;
                fileSetLabel.Visible = true;
                toggleStreamButton.Enabled = true;
            }
        }

        private void toggleStreamButton_Click(object sender, EventArgs e)
        {
            if (!solelyStreamLiveFrames)
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
                        selectionRangeSlider1.Visible = true;
                        lowerBoundBox.Visible = true;
                        currentPositionBox.Visible = true;
                        upperBoundBox.Visible = true;
                        unitLabelOne.Visible = true;
                        unitLabelTwo.Visible = true;
                        unitLabelThree.Visible = true;
                        measureUnitButton.Enabled = true;
                        freezeButton.Enabled = true;
                        BtnToggleMode.Enabled = true;

                        if (depthFrameReader.realKinectSet)
                        {
                            BtnToggleMode.Enabled = true;
                            currentModeLabel.Visible = true;
                        }

                        fileLengthMS = depthFrameReader.getFileSizeInMS();
                        selectionRangeSlider1.Max = fileLengthMS;
                        selectionRangeSlider1.Min = 0;
                        selectionRangeSlider1.SelectedMax = fileLengthMS;
                        upperBoundBox.Text = transformMillisecondsToFrames(fileLengthMS).ToString();
                        lowerBoundBox.Text = "0";
                    }

                    depthFrameReader.startStreaming(fps);

                    updateGUItimer.Elapsed += invokeUpdateTimeBar;
                    updateGUItimer.Start();

                    firstStart = false;
                }

                currentlyStreaming = !currentlyStreaming;
            }
            else // solelyStreamLiveFrames
            {
                if (currentlyStreaming)
                {
                    toggleStreamButton.Text = "Start Streaming";
                    depthFrameReader.pauseStreamingSolelyLiveFrames();
                }
                else
                {
                    toggleStreamButton.Text = "Pause Streaming";
                    
                    depthFrameReader.startStreamingSolelyLiveFrames(fps);
                }

                currentlyStreaming = !currentlyStreaming;
            }
            
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
                if (!temporaryUpdateStop)
                    selectionRangeSlider1.Value = tempVal;

                if (!currentPositionBox.Focused)
                {
                    changedByReader = true;
                    currentPositionBox.Text = transformMillisecondsToFrames(tempVal).ToString();
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
            changedByReader = true;
            changeTimelineValues();

            mouseDown = false;
        }

        private void changeTimelineValues()
        {
            switch (recentlyChangedValue)
            {
                case SliderValueChangeType.SelectedValue:
                    depthFrameReader.setTimelinePosition(selectionRangeSlider1.Value);
                    break;
                default:
                    depthFrameReader.setRepeatingInterval(selectionRangeSlider1.SelectedMin, selectionRangeSlider1.SelectedMax);
                    lowerBoundBox.Text = transformMillisecondsToFrames(depthFrameReader.getLowerBoundMilliseconds()).ToString();
                    upperBoundBox.Text = transformMillisecondsToFrames(depthFrameReader.getUpperBoundMilliseconds()).ToString();
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
        
        private void freezeButton_Click(object sender, EventArgs e)
        {
            depthFrameReader.changeFreezeMarker();
        }

        private void lowerBoundBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long potentialNewLowerBound;
                bool success = Int64.TryParse(lowerBoundBox.Text, out potentialNewLowerBound);

                if (success && showFramesInsteadOfMS)
                {
                    potentialNewLowerBound = transformFramesToMilliseconds(potentialNewLowerBound);
                }

                if (success && potentialNewLowerBound >= 0 && potentialNewLowerBound <= fileLengthMS && potentialNewLowerBound <= selectionRangeSlider1.SelectedMax)
                {
                    selectionRangeSlider1.SelectedMin = potentialNewLowerBound;
                    recentlyChangedValue = SliderValueChangeType.SelectedBound;
                    changeTimelineValues();
                }
                else
                {
                    lowerBoundBox.Text = transformMillisecondsToFrames(depthFrameReader.getLowerBoundMilliseconds()).ToString();
                }
            }
        }

        private void currentPositionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                temporaryUpdateStop = true;
                long potentialNewSliderPosition;
                bool success = Int64.TryParse(currentPositionBox.Text, out potentialNewSliderPosition);

                if (success && showFramesInsteadOfMS)
                {
                    potentialNewSliderPosition = transformFramesToMilliseconds(potentialNewSliderPosition);
                }

                if (success && potentialNewSliderPosition >= 0 && potentialNewSliderPosition <= fileLengthMS)
                {
                    selectionRangeSlider1.Value = potentialNewSliderPosition;
                    recentlyChangedValue = SliderValueChangeType.SelectedValue;
                    changeTimelineValues();
                }
                else
                {
                    currentPositionBox.Text = transformMillisecondsToFrames(depthFrameReader.getCurrentFrameMilliseconds()).ToString();
                }
                temporaryUpdateStop = false;
                upperBoundBox.Focus();
            }
        }

        private void upperBoundBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long potentialNewUpperBound;
                bool success = Int64.TryParse(upperBoundBox.Text, out potentialNewUpperBound);

                if (success && showFramesInsteadOfMS)
                {
                    potentialNewUpperBound = transformFramesToMilliseconds(potentialNewUpperBound);
                }

                if (success && potentialNewUpperBound >= 0 && potentialNewUpperBound <= fileLengthMS && potentialNewUpperBound >= selectionRangeSlider1.SelectedMin)
                {
                    selectionRangeSlider1.SelectedMax = potentialNewUpperBound;
                    recentlyChangedValue = SliderValueChangeType.SelectedBound;
                    changeTimelineValues();
                }
                else
                {
                    upperBoundBox.Text = transformMillisecondsToFrames(depthFrameReader.getUpperBoundMilliseconds()).ToString();
                }
            }
        }

        private void measureUnitButton_Click(object sender, EventArgs e)
        {
            showFramesInsteadOfMS = !showFramesInsteadOfMS;

            if (showFramesInsteadOfMS)
            {
                unitLabelOne.Text = "frames";
                unitLabelTwo.Text = "frames";
                unitLabelThree.Text = "frames";
            }
            else
            {
                unitLabelOne.Text = "ms";
                unitLabelTwo.Text = "ms";
                unitLabelThree.Text = "ms";
            }

            lowerBoundBox.Text = transformMillisecondsToFrames(selectionRangeSlider1.SelectedMin).ToString();
            upperBoundBox.Text = transformMillisecondsToFrames(selectionRangeSlider1.SelectedMax).ToString();
        }

        private long transformFramesToMilliseconds(long frames)
        {
            if (showFramesInsteadOfMS)
                return (long)Math.Round((double)frames / 3 * 100);
            else
                return frames;
        }

        private long transformMillisecondsToFrames(long milliseconds)
        {
            if (showFramesInsteadOfMS)
                return (long)Math.Round((double)milliseconds / 100 * 3);
            else
                return milliseconds;
        }

        private void BtnToggleMode_Click(object sender, EventArgs e)
        {
            if (dataSourceMode == DataSourceMode.REAL_KINECT)
            {
                changeDataSourceMode(DataSourceMode.RECORDED_DATA);
                depthFrameReader.setFrameSource(FrameSource.RECORDED);
            }
            else
            {
                changeDataSourceMode(DataSourceMode.REAL_KINECT);
                depthFrameReader.setFrameSource(FrameSource.KINECT);
            } 
        }

        private void changeDataSourceMode(DataSourceMode newDSM)
        {
            dataSourceMode = newDSM;

            switch (dataSourceMode)
            {
                case DataSourceMode.REAL_KINECT:
                    currentModeLabel.Text = "Streaming Kinect Frames";
                    break;
                case DataSourceMode.REAL_KINECT_AND_RECORDED_DATA:
                case DataSourceMode.RECORDED_DATA:
                    currentModeLabel.Text = "Streaming Recorded Frames";
                    break;
                case DataSourceMode.ASTRA_PRO:
                    currentModeLabel.Text = "Streaming AstraPro Frames";
                    break;
            }

            currentModeLabel.Visible = true;
        }

        private void BtnKinect_Click(object sender, EventArgs e)
        {
            changeDataSourceMode(DataSourceMode.REAL_KINECT);

            BtnOnlyRecordedData.Visible = false;
            BtnDataSources.Visible = false;
            BtnAstraPro.Visible = false;
            BtnKinect.Enabled = false;
            

            solelyStreamLiveFrames = true;
            toggleStreamButton.Enabled = true;
            depthFrameReader.setFrameSource(FrameSource.KINECT);
        }

        private void BtnDataSources_Click(object sender, EventArgs e)
        {
            changeDataSourceMode(DataSourceMode.RECORDED_DATA);

            openFileDialog();

            BtnKinect.Visible = false;
            BtnOnlyRecordedData.Visible = false;
            BtnAstraPro.Visible = false;
            BtnDataSources.Enabled = false;
            

            BtnToggleMode.Visible = true;
            BtnToggleMode.Enabled = false;

            solelyStreamLiveFrames = false;
        }

        private void BtnOnlyRecordedData_Click(object sender, EventArgs e)
        {
            changeDataSourceMode(DataSourceMode.RECORDED_DATA);

            openFileDialog();

            BtnKinect.Visible = false;
            BtnDataSources.Visible = false;
            BtnAstraPro.Visible = false;
            BtnOnlyRecordedData.Enabled = false;
            

            solelyStreamLiveFrames = false;
        }

        private void BtnAstraPro_Click(object sender, EventArgs e)
        {
            changeDataSourceMode(DataSourceMode.ASTRA_PRO);

            BtnOnlyRecordedData.Visible = false;
            BtnDataSources.Visible = false;
            BtnKinect.Visible = false;
            BtnAstraPro.Enabled = false;

            solelyStreamLiveFrames = true;
            toggleStreamButton.Enabled = true;
            depthFrameReader.setFrameSource(FrameSource.ASTRA_PRO);
        }
    }
}
