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
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.toggleStreamButton = new System.Windows.Forms.Button();
            this.headline2 = new System.Windows.Forms.Label();
            this.headline1 = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
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
            this.selectionRangeSlider1 = new KinectDummy.SelectionRangeSlider();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(146, 113);
            this.chooseFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(105, 27);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // toggleStreamButton
            // 
            this.toggleStreamButton.Location = new System.Drawing.Point(151, 325);
            this.toggleStreamButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(91, 94);
            this.filePathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(241, 17);
            this.filePathLabel.TabIndex = 10;
            this.filePathLabel.Text = "Choose Recorded Depth-Stream-File";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.Location = new System.Drawing.Point(128, 177);
            this.fpsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(157, 17);
            this.fpsLabel.TabIndex = 11;
            this.fpsLabel.Text = "Set Frames per Second";
            // 
            // fpsSetter
            // 
            this.fpsSetter.Location = new System.Drawing.Point(180, 196);
            this.fpsSetter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.upperBoundBox.Location = new System.Drawing.Point(358, 279);
            this.upperBoundBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.upperBoundBox.Name = "upperBoundBox";
            this.upperBoundBox.Size = new System.Drawing.Size(44, 20);
            this.upperBoundBox.TabIndex = 15;
            this.upperBoundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upperBoundBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.upperBoundBox_KeyDown);
            // 
            // currentPositionBox
            // 
            this.currentPositionBox.Location = new System.Drawing.Point(181, 279);
            this.currentPositionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.currentPositionBox.Name = "currentPositionBox";
            this.currentPositionBox.Size = new System.Drawing.Size(49, 20);
            this.currentPositionBox.TabIndex = 16;
            this.currentPositionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPositionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentPositionBox_KeyDown);
            // 
            // lowerBoundBox
            // 
            this.lowerBoundBox.Location = new System.Drawing.Point(9, 279);
            this.lowerBoundBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lowerBoundBox.Name = "lowerBoundBox";
            this.lowerBoundBox.Size = new System.Drawing.Size(44, 20);
            this.lowerBoundBox.TabIndex = 17;
            this.lowerBoundBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lowerBoundBox_KeyDown);
            // 
            // freezeButton
            // 
            this.freezeButton.Location = new System.Drawing.Point(270, 330);
            this.freezeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.fileSetLabel.Location = new System.Drawing.Point(9, 142);
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
            this.measureUnitButton.Location = new System.Drawing.Point(52, 331);
            this.measureUnitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.measureUnitButton.Name = "measureUnitButton";
            this.measureUnitButton.Size = new System.Drawing.Size(86, 29);
            this.measureUnitButton.TabIndex = 20;
            this.measureUnitButton.Text = "Toggle Unit";
            this.measureUnitButton.UseVisualStyleBackColor = true;
            this.measureUnitButton.Click += new System.EventHandler(this.measureUnitButton_Click);
            // 
            // unitLabelTwo
            // 
            this.unitLabelTwo.Location = new System.Drawing.Point(181, 298);
            this.unitLabelTwo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelTwo.Name = "unitLabelTwo";
            this.unitLabelTwo.Size = new System.Drawing.Size(48, 14);
            this.unitLabelTwo.TabIndex = 22;
            this.unitLabelTwo.Text = "ms";
            this.unitLabelTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unitLabelOne
            // 
            this.unitLabelOne.Location = new System.Drawing.Point(7, 298);
            this.unitLabelOne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelOne.Name = "unitLabelOne";
            this.unitLabelOne.Size = new System.Drawing.Size(48, 14);
            this.unitLabelOne.TabIndex = 23;
            this.unitLabelOne.Text = "ms";
            this.unitLabelOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unitLabelThree
            // 
            this.unitLabelThree.Location = new System.Drawing.Point(356, 298);
            this.unitLabelThree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitLabelThree.Name = "unitLabelThree";
            this.unitLabelThree.Size = new System.Drawing.Size(48, 14);
            this.unitLabelThree.TabIndex = 24;
            this.unitLabelThree.Text = "ms";
            this.unitLabelThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectionRangeSlider1
            // 
            this.selectionRangeSlider1.Location = new System.Drawing.Point(9, 236);
            this.selectionRangeSlider1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectionRangeSlider1.Max = ((long)(100));
            this.selectionRangeSlider1.Min = ((long)(0));
            this.selectionRangeSlider1.Name = "selectionRangeSlider1";
            this.selectionRangeSlider1.SelectedMax = ((long)(100));
            this.selectionRangeSlider1.SelectedMin = ((long)(0));
            this.selectionRangeSlider1.Size = new System.Drawing.Size(392, 38);
            this.selectionRangeSlider1.TabIndex = 14;
            this.selectionRangeSlider1.Value = ((long)(50));
            this.selectionRangeSlider1.SelectionChanged += new System.EventHandler(this.selectionRangeSlider1_SelectionChanged);
            this.selectionRangeSlider1.ValueChanged += new System.EventHandler(this.selectionRangeSlider1_ValueChanged);
            this.selectionRangeSlider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseDown);
            this.selectionRangeSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StreamControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 379);
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
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.headline2);
            this.Controls.Add(this.headline1);
            this.Controls.Add(this.toggleStreamButton);
            this.Controls.Add(this.chooseFileButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StreamControlGUI";
            this.Text = "StreamControlGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamControlGUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fpsSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Button toggleStreamButton;
        private System.Windows.Forms.Label headline2;
        private System.Windows.Forms.Label headline1;
        private System.Windows.Forms.Label filePathLabel;
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
    }
}