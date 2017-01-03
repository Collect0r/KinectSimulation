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
            this.selectionRangeSlider1 = new KinectDummy.SelectionRangeSlider();
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
            this.toggleStreamButton.Location = new System.Drawing.Point(201, 360);
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
            // 
            // selectionRangeSlider1
            // 
            this.selectionRangeSlider1.Location = new System.Drawing.Point(12, 290);
            this.selectionRangeSlider1.Max = 100;
            this.selectionRangeSlider1.Min = 0;
            this.selectionRangeSlider1.Name = "selectionRangeSlider1";
            this.selectionRangeSlider1.SelectedMax = 100;
            this.selectionRangeSlider1.SelectedMin = 0;
            this.selectionRangeSlider1.Size = new System.Drawing.Size(522, 47);
            this.selectionRangeSlider1.TabIndex = 14;
            this.selectionRangeSlider1.Value = 50;
            this.selectionRangeSlider1.SelectionChanged += new System.EventHandler(this.selectionRangeSlider1_SelectionChanged);
            this.selectionRangeSlider1.ValueChanged += new System.EventHandler(this.selectionRangeSlider1_ValueChanged);
            this.selectionRangeSlider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseDown);
            this.selectionRangeSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectionRangeSlider1_MouseUp);
            // 
            // StreamControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 433);
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
    }
}