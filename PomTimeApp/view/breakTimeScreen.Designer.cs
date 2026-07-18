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
            breakLabelOnBreakScreen = new Label();
            timerOnBreakScreen = new Label();
            labelTemp = new Label();
            SuspendLayout();
            // 
            // breakLabelOnBreakScreen
            // 
            breakLabelOnBreakScreen.AutoSize = true;
            breakLabelOnBreakScreen.Location = new Point(591, 178);
            breakLabelOnBreakScreen.Name = "breakLabelOnBreakScreen";
            breakLabelOnBreakScreen.Size = new Size(73, 32);
            breakLabelOnBreakScreen.TabIndex = 0;
            breakLabelOnBreakScreen.Text = "Break";
            // 
            // timerOnBreakScreen
            // 
            timerOnBreakScreen.AutoSize = true;
            timerOnBreakScreen.Location = new Point(591, 393);
            timerOnBreakScreen.Name = "timerOnBreakScreen";
            timerOnBreakScreen.Size = new Size(71, 32);
            timerOnBreakScreen.TabIndex = 1;
            timerOnBreakScreen.Text = "00:00";
            // 
            // labelTemp
            // 
            labelTemp.AutoSize = true;
            labelTemp.Location = new Point(502, 586);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new Size(266, 32);
            labelTemp.TabIndex = 2;
            labelTemp.Text = "Break activity here(Wip)";
            // 
            // breakTimeScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelTemp);
            Controls.Add(timerOnBreakScreen);
            Controls.Add(breakLabelOnBreakScreen);
            Name = "breakTimeScreen";
            Size = new Size(1283, 789);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label breakLabelOnBreakScreen;
        private Label timerOnBreakScreen;
        private Label labelTemp;
    }
}
