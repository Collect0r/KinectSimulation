using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureKinectStream
{
    public partial class CaptureControlGUI : Form
    {
        private bool currentlyRecording = false;

        private String saveFolderPath;

        private String saveFileName = "recordedKinectDepthStream.kcs";

        private CapturingController captureController;

        private int recordingDuration = 0;

        private delegate void stopRecordingCallbackDelegate();

        public CaptureControlGUI(CapturingController captureController)
        {
            InitializeComponent();

            if (Properties.Settings.Default.SaveFolderPath != "null")
            {
                saveFolderPath = Properties.Settings.Default.SaveFolderPath;
            }
            else
            {
                saveFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            currentFolderLabel.Text = saveFolderPath;
            this.captureController = captureController;
        }

        public void sendStopRecordingCallback()
        {
            Invoke(new stopRecordingCallbackDelegate(displayRecordingStopped));
        }

        private void displayRecordingStopped()
        {
            recordingToggle.Text = "Start Recording";
            recordSuccessfulLabel.Visible = true;
            currentlyRecording = false;
        }

        private void recordingToggle_Click(object sender, EventArgs e)
        {
            if (!currentlyRecording)
            {
                recordingToggle.Text = "Stop Recording";
                recordSuccessfulLabel.Visible = false;
                captureController.startCapturing(saveFolderPath + "//" + saveFileName, recordingDuration);
                currentlyRecording = true;
            }
            else
            {
                captureController.stopCapturing();
            }
        }

        private void chooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFolderBrowser = new FolderBrowserDialog();

            saveFolderBrowser.RootFolder = Environment.SpecialFolder.Desktop;

            if (saveFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                saveFolderPath = saveFolderBrowser.SelectedPath;
                folderLabel.Text = saveFolderPath;

                Properties.Settings.Default.SaveFolderPath = saveFolderPath;
                Properties.Settings.Default.Save();
            }

        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {
            if (fileName.Text.Length == 0)
            {
                saveFileName = "recordedKinectDepthStream.kcs";
            }
            else if (fileName.Text.Length >= 5 && fileName.Text.EndsWith(".kcs"))
            {
                saveFileName = fileName.Text;
            }
            else
            {
                saveFileName = fileName.Text + ".kcs";
            }

            fileName.Text = saveFileName;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            recordingDuration = (int)numericUpDown1.Value;
        }
    }
}
