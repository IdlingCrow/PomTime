namespace PomTimeApp;

partial class StartingUI
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        oneMinutesWarner = new Label();
        SuspendLayout();
        // 
        // oneMinutesWarner
        // 
        oneMinutesWarner.AutoSize = true;
        oneMinutesWarner.Location = new Point(80, 520);
        oneMinutesWarner.Name = "oneMinutesWarner";
        oneMinutesWarner.Size = new Size(0, 32);
        oneMinutesWarner.TabIndex = 14;
        // 
        // StartingUI
        // 
        ClientSize = new Size(519, 350);
        Controls.Add(oneMinutesWarner);
        KeyPreview = true;
        Name = "StartingUI";
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion
    private Label oneMinutesWarner;
}
