namespace CaptureKinectStream
{
    partial class CaptureControlGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recordingToggle = new System.Windows.Forms.Button();
            this.chooseFolder = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.headline1 = new System.Windows.Forms.Label();
            this.headline2 = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.currentFolderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recordSuccessfulLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // recordingToggle
            // 
            this.recordingToggle.Location = new System.Drawing.Point(72, 306);
            this.recordingToggle.Margin = new System.Windows.Forms.Padding(2);
            this.recordingToggle.Name = "recordingToggle";
            this.recordingToggle.Size = new System.Drawing.Size(107, 34);
            this.recordingToggle.TabIndex = 0;
            this.recordingToggle.Text = "Start Recording";
            this.recordingToggle.UseVisualStyleBackColor = true;
            this.recordingToggle.Click += new System.EventHandler(this.recordingToggle_Click);
            // 
            // chooseFolder
            // 
            this.chooseFolder.Location = new System.Drawing.Point(76, 100);
            this.chooseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.chooseFolder.Name = "chooseFolder";
            this.chooseFolder.Size = new System.Drawing.Size(88, 24);
            this.chooseFolder.TabIndex = 1;
            this.chooseFolder.Text = "Choose Folder";
            this.chooseFolder.UseVisualStyleBackColor = true;
            this.chooseFolder.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.ForeColor = System.Drawing.Color.Gray;
            this.folderLabel.Location = new System.Drawing.Point(104, 121);
            this.folderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(0, 13);
            this.folderLabel.TabIndex = 2;
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(69, 166);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(117, 17);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "Choose Filename";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(44, 186);
            this.fileName.Margin = new System.Windows.Forms.Padding(2);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(167, 20);
            this.fileName.TabIndex = 4;
            this.fileName.Text = "recordedKinectDepthStream.kcs";
            this.fileName.TextChanged += new System.EventHandler(this.fileName_TextChanged);
            // 
            // headline1
            // 
            this.headline1.AutoSize = true;
            this.headline1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headline1.ForeColor = System.Drawing.Color.Gray;
            this.headline1.Location = new System.Drawing.Point(9, 2);
            this.headline1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headline1.Name = "headline1";
            this.headline1.Size = new System.Drawing.Size(244, 26);
            this.headline1.TabIndex = 6;
            this.headline1.Text = "Kinect v2 Depth-Stream";
            // 
            // headline2
            // 
            this.headline2.AutoSize = true;
            this.headline2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headline2.ForeColor = System.Drawing.Color.Black;
            this.headline2.Location = new System.Drawing.Point(48, 28);
            this.headline2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headline2.Name = "headline2";
            this.headline2.Size = new System.Drawing.Size(160, 39);
            this.headline2.TabIndex = 7;
            this.headline2.Text = "Recorder";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(32, 81);
            this.filePathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(204, 17);
            this.filePathLabel.TabIndex = 8;
            this.filePathLabel.Text = "Choose Path to save Stream to";
            // 
            // currentFolderLabel
            // 
            this.currentFolderLabel.ForeColor = System.Drawing.Color.Gray;
            this.currentFolderLabel.Location = new System.Drawing.Point(9, 127);
            this.currentFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentFolderLabel.Name = "currentFolderLabel";
            this.currentFolderLabel.Size = new System.Drawing.Size(234, 14);
            this.currentFolderLabel.TabIndex = 9;
            this.currentFolderLabel.Text = "current folder path";
            this.currentFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 232);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Choose Recording Duration";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(106, 251);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(23, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(leave at zero to stop recording manually)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(142, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "seconds";
            // 
            // recordSuccessfulLabel
            // 
            this.recordSuccessfulLabel.AutoSize = true;
            this.recordSuccessfulLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.recordSuccessfulLabel.Location = new System.Drawing.Point(70, 341);
            this.recordSuccessfulLabel.Name = "recordSuccessfulLabel";
            this.recordSuccessfulLabel.Size = new System.Drawing.Size(112, 13);
            this.recordSuccessfulLabel.TabIndex = 14;
            this.recordSuccessfulLabel.Text = "successfully recorded!";
            this.recordSuccessfulLabel.Visible = false;
            // 
            // CaptureControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 363);
            this.Controls.Add(this.recordSuccessfulLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentFolderLabel);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.headline2);
            this.Controls.Add(this.headline1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.chooseFolder);
            this.Controls.Add(this.recordingToggle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CaptureControlGUI";
            this.Text = "CaptureControlGUI";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button recordingToggle;
        private System.Windows.Forms.Button chooseFolder;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label headline1;
        private System.Windows.Forms.Label headline2;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label currentFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label recordSuccessfulLabel;
    }
}