namespace PomTimeApp.view
{
    partial class stickyNotes
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
            label1 = new Label();
            reminderDescription = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(196, 9);
            label1.Name = "label1";
            label1.Size = new Size(328, 86);
            label1.TabIndex = 0;
            label1.Text = "Reminder";
            // 
            // reminderDescription
            // 
            reminderDescription.BackColor = Color.FromArgb(255, 255, 136);
            reminderDescription.Font = new Font("Segoe UI", 12.125F);
            reminderDescription.Location = new Point(1, 98);
            reminderDescription.Multiline = true;
            reminderDescription.Name = "reminderDescription";
            reminderDescription.Size = new Size(752, 471);
            reminderDescription.TabIndex = 1;
            // 
            // stickyNotes
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 136);
            ClientSize = new Size(753, 570);
            Controls.Add(reminderDescription);
            Controls.Add(label1);
            Name = "stickyNotes";
            Text = "stickyNotes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox reminderDescription;
    }
}