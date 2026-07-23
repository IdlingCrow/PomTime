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
            SuspendLayout();
            // 
            // screenTitle
            // 
            screenTitle.AutoSize = true;
            screenTitle.Font = new Font("Segoe UI", 15F);
            screenTitle.Location = new Point(123, 85);
            screenTitle.Name = "screenTitle";
            screenTitle.Size = new Size(115, 54);
            screenTitle.TabIndex = 0;
            screenTitle.Text = "Work";
            // 
            // timerOnWorkScreen
            // 
            timerOnWorkScreen.AutoSize = true;
            timerOnWorkScreen.Font = new Font("Segoe UI", 20F);
            timerOnWorkScreen.Location = new Point(105, 170);
            timerOnWorkScreen.Name = "timerOnWorkScreen";
            timerOnWorkScreen.Size = new Size(158, 72);
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
            // WorkTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(oneMinutesWarner);
            Controls.Add(timerOnWorkScreen);
            Controls.Add(screenTitle);
            Name = "WorkTimeScreen";
            Size = new Size(374, 396);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenTitle;
        private Label timerOnWorkScreen;
        private Label oneMinutesWarner;
    }
}
