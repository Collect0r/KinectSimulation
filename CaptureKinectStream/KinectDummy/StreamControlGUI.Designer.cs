namespace KinectDummy
{
    partial class StreamControlGUI
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
            this.toggleStreamButton = new System.Windows.Forms.Button();
            this.headline2 = new System.Windows.Forms.Label();
            this.headline1 = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.fpsSetter = new System.Windows.Forms.NumericUpDown();
            this.upperBoundBox = new System.Windows.Forms.TextBox();
            this.currentPositionBox = new System.Windows.Forms.TextBox();
            this.lowerBoundBox = new System.Windows.Forms.TextBox();
            this.freezeButton = new System.Windows.Forms.Button();
            this.fileSetLabel = new System.Windows.Forms.Label();
            this.measureUnitButton = new System.Windows.Forms.Button();
            this.unitLabelTwo = new System.Windows.Forms.Label();
            this.unitLabelOne = new System.Windows.Forms.Label();
            this.unitLabelThree = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.currentModeLabel = new System.Windows.Forms.Label();
            this.onlyRealKinectButton = new System.Windows.Forms.Button();
            this.bothDataSourcesButton = new System.Windows.Forms.Button();
            this.onlyRecordedDataButton = new System.Windows.Forms.Button();
            this.selectionRangeSlider1 = new KinectDummy.SelectionRangeSlider();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleStreamButton
            // 
            this.toggleStreamButton.Enabled = false;
            this.toggleStreamButton.Location = new System.Drawing.Point(151, 385);
            this.toggleStreamButton.Margin = new System.Windows.Forms.Padding(2);
            this.toggleStreamButton.Name = "toggleStreamButton";
            this.toggleStreamButton.Size = new System.Drawing.Size(106, 41);
            this.toggleStreamButton.TabIndex = 1;
            this.toggleStreamButton.Text = "Start Streaming";
            this.toggleStreamButton.UseVisualStyleBackColor = true;
            this.toggleStreamButton.Click += new System.EventHandler(this.toggleStreamButton_Click);
            // 
            // headline2
            // 
            this.headline2.AutoSize = true;
            this.headline2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headline2.ForeColor = System.Drawing.Color.Black;
            this.headline2.Location = new System.Drawing.Point(144, 33);
            this.headline2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headline2.Name = "headline2";
            this.headline2.Size = new System.Drawing.Size(116, 39);
            this.headline2.TabIndex = 9;
            this.headline2.Text = "Player";
            // 
            // headline1
            // 
            this.headline1.AutoSize = true;
            this.headline1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headline1.ForeColor = System.Drawing.Color.Gray;
            this.headline1.Location = new System.Drawing.Point(82, 7);
            this.headline1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headline1.Name = "headline1";
            this.headline1.Size = new System.Drawing.Size(244, 26);
            this.headline1.TabIndex = 8;
            this.headline1.Text = "Kinect v2 Depth-Stream";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.Location = new System.Drawing.Point(128, 249);
            this.fpsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(157, 17);
            this.fpsLabel.TabIndex = 11;
            this.fpsLabel.Text = "Set Frames per Second";
            // 
            // fpsSetter
            // 
            this.fpsSetter.Location = new System.Drawing.Point(189, 268);
            this.fpsSetter.Margin = new System.Windows.Forms.Padding(2);
            this.fpsSetter.Name = "fpsSetter";
            this.fpsSetter.Size = new System.Drawing.Size(36, 20);
            this.fpsSetter.TabIndex = 12;
            this.fpsSetter.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fpsSetter.ValueChanged += new System.EventHandler(this.fpsSetter_ValueChanged);
            // 
            // upperBoundBox
            // 
            this.upperBoundBox.Location = new System.Drawing.Point(358, 339);
            this.upperBoundBox.Margin = new System.Windows.Forms.Padding(2);
            this.upperBoundBox.Name = "upperBoundBox";
            this.upperBoundBox.Size = new System.Drawing.Size(44, 20);
            this.upperBoundBox.TabIndex = 15;
            this.upperBoundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upperBoundBox.Visible = false;
            this.upperBoundBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.upperBoundBox_KeyDown);
            // 
            // currentPositionBox
            // 
            this.currentPositionBox.Location = new System.Drawing.Point(181, 339);
            this.currentPositionBox.Margin = new System.Windows.Forms.Padding(2);
            this.currentPositionBox.Name = "currentPositionBox";
            this.currentPositionBox.Size = new System.Drawing.Size(49, 20);
            this.currentPositionBox.TabIndex = 16;
            this.currentPositionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPositionBox.Visible = false;
            this.currentPositionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentPositionBox_KeyDown);
            // 
            // lowerBoundBox
            // 
            this.lowerBoundBox.Location = new System.Drawing.Point(9, 339);
            this.lowerBoundBox.Margin = new System.Windows.Forms.Padding(2);
            this.lowerBoundBox.Name = "lowerBoundBox";
            this.lowerBoundBox.Size = new System.Drawing.Size(44, 20);
            this.lowerBoundBox.TabIndex = 17;
            this.lowerBoundBox.Visible = false;
            this.lowerBoundBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lowerBoundBox_KeyDown);
            // 
            // freezeButton
            // 
            this.freezeButton.Enabled = false;
            this.freezeButton.Location = new System.Drawing.Point(270, 390);
            this.freezeButton.Margin = new System.Windows.Forms.Padding(2);
            this.freezeButton.Name = "freezeButton";
            this.freezeButton.Size = new System.Drawing.Size(86, 29);
            this.freezeButton.TabIndex = 18;
            this.freezeButton.Text = "Freeze Frame";
            this.freezeButton.UseVisualStyleBackColor = true;
            this.freezeButton.Click += new System.EventHandler(this.freezeButton_Click);
            // 
            // fileSetLabel
            // 
            this.fileSetLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.fileSetLabel.Location = new System.Drawing.Point(11, 179);
            this.fileSetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileSetLabel.Name = "fileSetLabel";
            this.fileSetLabel.Size = new System.Drawing.Size(392, 16);
            this.fileSetLabel.TabIndex = 19;
            this.fileSetLabel.Text = "File set!";
            this.fileSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileSetLabel.Visible = false;
            // 
            // measureUnitButton
            // 
            this.measureUnitButton.Enabled = false;
            this.measureUnitButton.Location = new System.Drawing.Point(52, 391);
            this.measureUnitButton.Margin = new System.Windows.Forms.Padding(2);
            this.measureUnitButton.Name = "measureUnitButton";
            this.measureUnitButton.Size = new System.Drawing.Size(86, 29);
            this.measureUnitButton.TabIndex = 20;
            this.measureUnitButton.Text = "Toggle Unit";
            this.measureUnitButton.UseVisualStyleBackColor = true;
            this.measureUnitButton.Click += new System.EventHandler(this.measureUnitButton_Click);
            // 
            // unitLabelTwo
            // 
            this.unitLabelTwo.Location = new System.Drawing.Point(181, 358);
            this.unitLabelTwo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelTwo.Name = "unitLabelTwo";
            this.unitLabelTwo.Size = new System.Drawing.Size(48, 14);
            this.unitLabelTwo.TabIndex = 22;
            this.unitLabelTwo.Text = "ms";
            this.unitLabelTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unitLabelTwo.Visible = false;
            // 
            // unitLabelOne
            // 
            this.unitLabelOne.Location = new System.Drawing.Point(7, 358);
            this.unitLabelOne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelOne.Name = "unitLabelOne";
            this.unitLabelOne.Size = new System.Drawing.Size(48, 14);
            this.unitLabelOne.TabIndex = 23;
            this.unitLabelOne.Text = "ms";
            this.unitLabelOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unitLabelOne.Visible = false;
            // 
            // unitLabelThree
            // 
            this.unitLabelThree.Location = new System.Drawing.Point(356, 358);
            this.unitLabelThree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelThree.Name = "unitLabelThree";
            this.unitLabelThree.Size = new System.Drawing.Size(48, 14);
            this.unitLabelThree.TabIndex = 24;
            this.unitLabelThree.Text = "ms";
            this.unitLabelThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unitLabelThree.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(155, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Toggle Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // currentModeLabel
            // 
            this.currentModeLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.currentModeLabel.Location = new System.Drawing.Point(9, 227);
            this.currentModeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentModeLabel.Name = "currentModeLabel";
            this.currentModeLabel.Size = new System.Drawing.Size(392, 16);
            this.currentModeLabel.TabIndex = 26;
            this.currentModeLabel.Text = "Streaming Recorded Frames";
            this.currentModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentModeLabel.Visible = false;
            // 
            // onlyRealKinectButton
            // 
            this.onlyRealKinectButton.Enabled = false;
            this.onlyRealKinectButton.Location = new System.Drawing.Point(14, 75);
            this.onlyRealKinectButton.Name = "onlyRealKinectButton";
            this.onlyRealKinectButton.Size = new System.Drawing.Size(121, 101);
            this.onlyRealKinectButton.TabIndex = 29;
            this.onlyRealKinectButton.Text = "ONLY\r\nreal kinect";
            this.onlyRealKinectButton.UseVisualStyleBackColor = true;
            this.onlyRealKinectButton.Click += new System.EventHandler(this.onlyRealKinectButton_Click);
            // 
            // bothDataSourcesButton
            // 
            this.bothDataSourcesButton.Enabled = false;
            this.bothDataSourcesButton.Location = new System.Drawing.Point(145, 75);
            this.bothDataSourcesButton.Name = "bothDataSourcesButton";
            this.bothDataSourcesButton.Size = new System.Drawing.Size(121, 101);
            this.bothDataSourcesButton.TabIndex = 30;
            this.bothDataSourcesButton.Text = "BOTH\r\nreal kinect + recorded";
            this.bothDataSourcesButton.UseVisualStyleBackColor = true;
            this.bothDataSourcesButton.Click += new System.EventHandler(this.bothDataSourcesButton_Click);
            // 
            // onlyRecordedDataButton
            // 
            this.onlyRecordedDataButton.Location = new System.Drawing.Point(276, 75);
            this.onlyRecordedDataButton.Name = "onlyRecordedDataButton";
            this.onlyRecordedDataButton.Size = new System.Drawing.Size(121, 101);
            this.onlyRecordedDataButton.TabIndex = 31;
            this.onlyRecordedDataButton.Text = "ONLY\r\nrecorded data";
            this.onlyRecordedDataButton.UseVisualStyleBackColor = true;
            this.onlyRecordedDataButton.Click += new System.EventHandler(this.onlyRecordedDataButton_Click);
            // 
            // selectionRangeSlider1
            // 
            this.selectionRangeSlider1.Location = new System.Drawing.Point(9, 296);
            this.selectionRangeSlider1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectionRangeSlider1.Max = ((long)(100));
            this.selectionRangeSlider1.Min = ((long)(0));
            this.selectionRangeSlider1.Name = "selectionRangeSlider1";
            this.selectionRangeSlider1.SelectedMax = ((long)(100));
            this.selectionRangeSlider1.SelectedMin = ((long)(0));
            this.selectionRangeSlider1.Size = new System.Drawing.Size(392, 38);
            this.selectionRangeSlider1.TabIndex = 14;
            this.selectionRangeSlider1.Value = ((long)(50));
            this.selectionRangeSlider1.Visible = false;
            this.selectionRangeSlider1.SelectionChanged += new System.EventHandler(this.selectionRangeSlider1_SelectionChanged);
            this.selectionRangeSlider1.ValueChanged += new System.EventHandler(this.selectionRangeSlider1_ValueChanged);
            this.selectionRangeSlider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseDown);
            this.selectionRangeSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseUp);
            // 
            // StreamControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 434);
            this.Controls.Add(this.onlyRecordedDataButton);
            this.Controls.Add(this.bothDataSourcesButton);
            this.Controls.Add(this.onlyRealKinectButton);
            this.Controls.Add(this.currentModeLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unitLabelThree);
            this.Controls.Add(this.unitLabelOne);
            this.Controls.Add(this.unitLabelTwo);
            this.Controls.Add(this.measureUnitButton);
            this.Controls.Add(this.fileSetLabel);
            this.Controls.Add(this.freezeButton);
            this.Controls.Add(this.lowerBoundBox);
            this.Controls.Add(this.currentPositionBox);
            this.Controls.Add(this.upperBoundBox);
            this.Controls.Add(this.selectionRangeSlider1);
            this.Controls.Add(this.fpsSetter);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.headline2);
            this.Controls.Add(this.headline1);
            this.Controls.Add(this.toggleStreamButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StreamControlGUI";
            this.Text = "StreamControlGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamControlGUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fpsSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button toggleStreamButton;
        private System.Windows.Forms.Label headline2;
        private System.Windows.Forms.Label headline1;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.NumericUpDown fpsSetter;
        private SelectionRangeSlider selectionRangeSlider1;
        private System.Windows.Forms.TextBox upperBoundBox;
        private System.Windows.Forms.TextBox currentPositionBox;
        private System.Windows.Forms.TextBox lowerBoundBox;
        private System.Windows.Forms.Button freezeButton;
        private System.Windows.Forms.Label fileSetLabel;
        private System.Windows.Forms.Button measureUnitButton;
        private System.Windows.Forms.Label unitLabelTwo;
        private System.Windows.Forms.Label unitLabelOne;
        private System.Windows.Forms.Label unitLabelThree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label currentModeLabel;
        private System.Windows.Forms.Button onlyRealKinectButton;
        private System.Windows.Forms.Button bothDataSourcesButton;
        private System.Windows.Forms.Button onlyRecordedDataButton;
    }
}