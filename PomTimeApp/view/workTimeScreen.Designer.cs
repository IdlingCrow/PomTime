namespace PomTimeApp.view
{
    partial class workTimeScreen
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
            WarkLableOnWorkScreen = new Label();
            timerOnWorkScreen = new Label();
            SuspendLayout();
            // 
            // WarkLableOnWorkScreen
            // 
            WarkLableOnWorkScreen.AutoSize = true;
            WarkLableOnWorkScreen.Location = new Point(149, 84);
            WarkLableOnWorkScreen.Name = "WarkLableOnWorkScreen";
            WarkLableOnWorkScreen.Size = new Size(69, 32);
            WarkLableOnWorkScreen.TabIndex = 0;
            WarkLableOnWorkScreen.Text = "Work";
            // 
            // timerOnWorkScreen
            // 
            timerOnWorkScreen.AutoSize = true;
            timerOnWorkScreen.Location = new Point(147, 218);
            timerOnWorkScreen.Name = "timerOnWorkScreen";
            timerOnWorkScreen.Size = new Size(71, 32);
            timerOnWorkScreen.TabIndex = 1;
            timerOnWorkScreen.Text = "00:00";
            // 
            // workTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(timerOnWorkScreen);
            Controls.Add(WarkLableOnWorkScreen);
            Name = "workTimeScreen";
            Size = new Size(374, 396);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WarkLableOnWorkScreen;
        private Label timerOnWorkScreen;
    }
}
