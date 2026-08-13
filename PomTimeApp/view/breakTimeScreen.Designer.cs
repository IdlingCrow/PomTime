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
            breakTimeActivity = new PictureBox();
            ResumeButton = new themeButton();
            PauseButton = new themeButton();
            ResetButton = new themeButton();
            ((System.ComponentModel.ISupportInitialize)breakTimeActivity).BeginInit();
            SuspendLayout();
            // 
            // screenTitle
            // 
            screenTitle.Anchor = AnchorStyles.None;
            screenTitle.AutoSize = true;
            screenTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            screenTitle.ForeColor = Color.White;
            screenTitle.Location = new Point(1045, 27);
            screenTitle.Name = "screenTitle";
            screenTitle.Size = new Size(131, 54);
            screenTitle.TabIndex = 0;
            screenTitle.Text = "Break";
            // 
            // timerOnBreakScreen
            // 
            timerOnBreakScreen.Anchor = AnchorStyles.None;
            timerOnBreakScreen.AutoSize = true;
            timerOnBreakScreen.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            timerOnBreakScreen.ForeColor = Color.White;
            timerOnBreakScreen.Location = new Point(1033, 118);
            timerOnBreakScreen.Name = "timerOnBreakScreen";
            timerOnBreakScreen.Size = new Size(169, 72);
            timerOnBreakScreen.TabIndex = 1;
            timerOnBreakScreen.Text = "00:00";
            // 
            // breakTimeActivity
            // 
            breakTimeActivity.Anchor = AnchorStyles.None;
            breakTimeActivity.Location = new Point(393, 177);
            breakTimeActivity.Name = "breakTimeActivity";
            breakTimeActivity.Size = new Size(540, 540);
            breakTimeActivity.SizeMode = PictureBoxSizeMode.StretchImage;
            breakTimeActivity.TabIndex = 2;
            breakTimeActivity.TabStop = false;
            // 
            // ResumeButton
            // 
            ResumeButton.Anchor = AnchorStyles.None;
            ResumeButton.AutoSize = true;
            ResumeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ResumeButton.BackColor = Color.White;
            ResumeButton.FlatAppearance.BorderColor = Color.White;
            ResumeButton.FlatAppearance.BorderSize = 3;
            ResumeButton.FlatStyle = FlatStyle.Flat;
            ResumeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ResumeButton.ForeColor = Color.FromArgb(167, 199, 231);
            ResumeButton.Location = new Point(984, 216);
            ResumeButton.Name = "ResumeButton";
            ResumeButton.Size = new Size(127, 53);
            ResumeButton.TabIndex = 4;
            ResumeButton.Text = "resume";
            ResumeButton.UseVisualStyleBackColor = false;
            ResumeButton.Click += ResumeButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Anchor = AnchorStyles.None;
            PauseButton.AutoSize = true;
            PauseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PauseButton.BackColor = Color.White;
            PauseButton.FlatAppearance.BorderColor = Color.White;
            PauseButton.FlatAppearance.BorderSize = 3;
            PauseButton.FlatStyle = FlatStyle.Flat;
            PauseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            PauseButton.ForeColor = Color.FromArgb(167, 199, 231);
            PauseButton.Location = new Point(1068, 216);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(108, 53);
            PauseButton.TabIndex = 5;
            PauseButton.Text = "pause";
            PauseButton.UseVisualStyleBackColor = false;
            PauseButton.Click += PauseButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Anchor = AnchorStyles.None;
            ResetButton.AutoSize = true;
            ResetButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ResetButton.BackColor = Color.White;
            ResetButton.FlatAppearance.BorderColor = Color.White;
            ResetButton.FlatAppearance.BorderSize = 3;
            ResetButton.FlatStyle = FlatStyle.Flat;
            ResetButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ResetButton.ForeColor = Color.FromArgb(167, 199, 231);
            ResetButton.Location = new Point(1129, 216);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(97, 53);
            ResetButton.TabIndex = 6;
            ResetButton.Text = "reset";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // breakTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(167, 199, 231);
            Controls.Add(ResetButton);
            Controls.Add(PauseButton);
            Controls.Add(ResumeButton);
            Controls.Add(breakTimeActivity);
            Controls.Add(timerOnBreakScreen);
            Controls.Add(screenTitle);
            Name = "breakTimeScreen";
            Size = new Size(1283, 789);
            ((System.ComponentModel.ISupportInitialize)breakTimeActivity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenTitle;
        private Label timerOnBreakScreen;
        private PictureBox breakTimeActivity;
        private themeButton ResumeButton;
        private themeButton PauseButton;
        private themeButton ResetButton;
    }
}
