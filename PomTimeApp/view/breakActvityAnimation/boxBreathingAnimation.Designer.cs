namespace PomTimeApp.view
{
    partial class boxBreathingAnimation
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
            tester = new Button();
            SuspendLayout();
            // 
            // tester
            // 
            tester.Location = new Point(121, 193);
            tester.Name = "tester";
            tester.Size = new Size(150, 46);
            tester.TabIndex = 0;
            tester.Text = "button1";
            tester.UseVisualStyleBackColor = true;
            tester.Click += tester_Click;
            // 
            // boxBreathingAnimation
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tester);
            Name = "boxBreathingAnimation";
            Size = new Size(402, 402);
            ResumeLayout(false);
        }

        #endregion

        private Button tester;
    }
}
