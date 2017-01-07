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
            this.selectionRangeSlider1 = new KinectDummy.SelectionRangeSlider();
            this.freezeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(194, 139);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(140, 33);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // toggleStreamButton
            // 
            this.toggleStreamButton.Location = new System.Drawing.Point(201, 388);
            this.toggleStreamButton.Name = "toggleStreamButton";
            this.toggleStreamButton.Size = new System.Drawing.Size(142, 50);
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
            this.headline2.Location = new System.Drawing.Point(192, 41);
            this.headline2.Name = "headline2";
            this.headline2.Size = new System.Drawing.Size(145, 51);
            this.headline2.TabIndex = 9;
            this.headline2.Text = "Player";
            // 
            // headline1
            // 
            this.headline1.AutoSize = true;
            this.headline1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headline1.ForeColor = System.Drawing.Color.Gray;
            this.headline1.Location = new System.Drawing.Point(109, 9);
            this.headline1.Name = "headline1";
            this.headline1.Size = new System.Drawing.Size(315, 32);
            this.headline1.TabIndex = 8;
            this.headline1.Text = "Kinect v2 Depth-Stream";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(121, 116);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(286, 20);
            this.filePathLabel.TabIndex = 10;
            this.filePathLabel.Text = "Choose Recorded Depth-Stream-File";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.Location = new System.Drawing.Point(171, 218);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(186, 20);
            this.fpsLabel.TabIndex = 11;
            this.fpsLabel.Text = "Set Frames per Second";
            // 
            // fpsSetter
            // 
            this.fpsSetter.Location = new System.Drawing.Point(240, 241);
            this.fpsSetter.Name = "fpsSetter";
            this.fpsSetter.Size = new System.Drawing.Size(48, 22);
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
            this.upperBoundBox.Location = new System.Drawing.Point(477, 343);
            this.upperBoundBox.Name = "upperBoundBox";
            this.upperBoundBox.Size = new System.Drawing.Size(57, 22);
            this.upperBoundBox.TabIndex = 15;
            this.upperBoundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upperBoundBox.TextChanged += new System.EventHandler(this.upperBoundBox_TextChanged);
            // 
            // currentPositionBox
            // 
            this.currentPositionBox.Location = new System.Drawing.Point(241, 343);
            this.currentPositionBox.Name = "currentPositionBox";
            this.currentPositionBox.Size = new System.Drawing.Size(64, 22);
            this.currentPositionBox.TabIndex = 16;
            this.currentPositionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPositionBox.TextChanged += new System.EventHandler(this.currentPositionBox_TextChanged);
            // 
            // lowerBoundBox
            // 
            this.lowerBoundBox.Location = new System.Drawing.Point(12, 343);
            this.lowerBoundBox.Name = "lowerBoundBox";
            this.lowerBoundBox.Size = new System.Drawing.Size(57, 22);
            this.lowerBoundBox.TabIndex = 17;
            this.lowerBoundBox.TextChanged += new System.EventHandler(this.lowerBoundBox_TextChanged);
            // 
            // selectionRangeSlider1
            // 
            this.selectionRangeSlider1.Location = new System.Drawing.Point(12, 290);
            this.selectionRangeSlider1.Max = ((long)(100));
            this.selectionRangeSlider1.Min = ((long)(0));
            this.selectionRangeSlider1.Name = "selectionRangeSlider1";
            this.selectionRangeSlider1.SelectedMax = ((long)(100));
            this.selectionRangeSlider1.SelectedMin = ((long)(0));
            this.selectionRangeSlider1.Size = new System.Drawing.Size(522, 47);
            this.selectionRangeSlider1.TabIndex = 14;
            this.selectionRangeSlider1.Value = ((long)(50));
            this.selectionRangeSlider1.SelectionChanged += new System.EventHandler(this.selectionRangeSlider1_SelectionChanged);
            this.selectionRangeSlider1.ValueChanged += new System.EventHandler(this.selectionRangeSlider1_ValueChanged);
            this.selectionRangeSlider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseDown);
            this.selectionRangeSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseUp);
            // 
            // freezeButton
            // 
            this.freezeButton.Location = new System.Drawing.Point(406, 402);
            this.freezeButton.Name = "freezeButton";
            this.freezeButton.Size = new System.Drawing.Size(115, 23);
            this.freezeButton.TabIndex = 18;
            this.freezeButton.Text = "Freeze Frame";
            this.freezeButton.UseVisualStyleBackColor = true;
            this.freezeButton.Click += new System.EventHandler(this.freezeButton_Click);
            // 
            // StreamControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 450);
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
    }
}