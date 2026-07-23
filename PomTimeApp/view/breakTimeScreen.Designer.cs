namespace PomTimeApp.view
{
    partial class breakTimeScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            screenTitle = new Label();
            timerOnBreakScreen = new Label();
            pictureBox1 = new PictureBox();
            exersizeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // screenTitle
            // 
            screenTitle.AutoSize = true;
            screenTitle.Font = new Font("Segoe UI", 15F);
            screenTitle.Location = new Point(1062, 25);
            screenTitle.Name = "screenTitle";
            screenTitle.Size = new Size(121, 54);
            screenTitle.TabIndex = 0;
            screenTitle.Text = "Break";
            // 
            // timerOnBreakScreen
            // 
            timerOnBreakScreen.AutoSize = true;
            timerOnBreakScreen.Font = new Font("Segoe UI", 20F);
            timerOnBreakScreen.Location = new Point(1050, 116);
            timerOnBreakScreen.Name = "timerOnBreakScreen";
            timerOnBreakScreen.Size = new Size(158, 72);
            timerOnBreakScreen.TabIndex = 1;
            timerOnBreakScreen.Text = "00:00";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.boxBreathingTechnique;
            pictureBox1.Location = new Point(393, 177);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(540, 540);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // exersizeLabel
            // 
            exersizeLabel.AutoSize = true;
            exersizeLabel.Location = new Point(594, 126);
            exersizeLabel.Name = "exersizeLabel";
            exersizeLabel.Size = new Size(156, 32);
            exersizeLabel.TabIndex = 3;
            exersizeLabel.Text = "boxBreathing";
            // 
            // breakTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exersizeLabel);
            Controls.Add(pictureBox1);
            Controls.Add(timerOnBreakScreen);
            Controls.Add(screenTitle);
            Name = "breakTimeScreen";
            Size = new Size(1283, 789);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenTitle;
        private Label timerOnBreakScreen;
        private PictureBox pictureBox1;
        private Label exersizeLabel;
    }
}
