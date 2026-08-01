namespace PomTimeApp.view
{
    partial class WorkTimeScreen
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
            timerOnWorkScreen = new Label();
            oneMinutesWarner = new Label();
            PauseButton = new themeButton();
            ResumeButton = new themeButton();
            ResetButton = new themeButton();
            pauseMusicButton = new themeButton();
            SuspendLayout();
            // 
            // screenTitle
            // 
            screenTitle.AutoSize = true;
            screenTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            screenTitle.ForeColor = Color.White;
            screenTitle.Location = new Point(81, 65);
            screenTitle.Name = "screenTitle";
            screenTitle.Size = new Size(208, 89);
            screenTitle.TabIndex = 0;
            screenTitle.Text = "Work";
            // 
            // timerOnWorkScreen
            // 
            timerOnWorkScreen.AutoSize = true;
            timerOnWorkScreen.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            timerOnWorkScreen.ForeColor = Color.White;
            timerOnWorkScreen.Location = new Point(19, 163);
            timerOnWorkScreen.Name = "timerOnWorkScreen";
            timerOnWorkScreen.Size = new Size(337, 142);
            timerOnWorkScreen.TabIndex = 1;
            timerOnWorkScreen.Text = "00:00";
            // 
            // oneMinutesWarner
            // 
            oneMinutesWarner.AutoSize = true;
            oneMinutesWarner.Location = new Point(123, 295);
            oneMinutesWarner.Name = "oneMinutesWarner";
            oneMinutesWarner.Size = new Size(0, 32);
            oneMinutesWarner.TabIndex = 2;
            // 
            // PauseButton
            // 
            PauseButton.BackColor = Color.White;
            PauseButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            PauseButton.ForeColor = Color.FromArgb(167, 199, 231);
            PauseButton.Location = new Point(81, 347);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(208, 72);
            PauseButton.TabIndex = 3;
            PauseButton.Text = "Pause";
            PauseButton.UseVisualStyleBackColor = false;
            PauseButton.Click += PauseButton_Click;
            // 
            // ResumeButton
            // 
            ResumeButton.BackColor = Color.White;
            ResumeButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ResumeButton.ForeColor = Color.FromArgb(167, 199, 231);
            ResumeButton.Location = new Point(13, 347);
            ResumeButton.Name = "ResumeButton";
            ResumeButton.Size = new Size(169, 72);
            ResumeButton.TabIndex = 4;
            ResumeButton.Text = "Resume";
            ResumeButton.UseVisualStyleBackColor = false;
            ResumeButton.Click += ResumeButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.BackColor = Color.White;
            ResetButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ResetButton.ForeColor = Color.FromArgb(167, 199, 231);
            ResetButton.Location = new Point(203, 347);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(153, 72);
            ResetButton.TabIndex = 5;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // pauseMusicButton
            // 
            pauseMusicButton.BackColor = Color.White;
            pauseMusicButton.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            pauseMusicButton.ForeColor = Color.FromArgb(167, 199, 231);
            pauseMusicButton.Location = new Point(123, 446);
            pauseMusicButton.Name = "pauseMusicButton";
            pauseMusicButton.Size = new Size(101, 95);
            pauseMusicButton.TabIndex = 6;
            pauseMusicButton.Text = "▶";
            pauseMusicButton.UseVisualStyleBackColor = false;
            pauseMusicButton.Click += pauseMusicButton_Click;
            // 
            // WorkTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(167, 199, 231);
            Controls.Add(pauseMusicButton);
            Controls.Add(ResetButton);
            Controls.Add(ResumeButton);
            Controls.Add(PauseButton);
            Controls.Add(oneMinutesWarner);
            Controls.Add(timerOnWorkScreen);
            Controls.Add(screenTitle);
            Name = "WorkTimeScreen";
            Size = new Size(374, 562);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenTitle;
        private Label timerOnWorkScreen;
        private Label oneMinutesWarner;
        private themeButton PauseButton;
        private themeButton ResumeButton;
        private themeButton ResetButton;
        private themeButton pauseMusicButton;
    }
}
