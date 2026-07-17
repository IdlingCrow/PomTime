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
        Displayed_Timer = new Label();
        Work_Time_Title = new Label();
        Break_Time_Title = new Label();
        WorkTimeMinutesInput = new MaskedTextBox();
        label1 = new Label();
        WorkTimeSecondsInput = new MaskedTextBox();
        BreakTimeSecondsInput = new MaskedTextBox();
        label2 = new Label();
        BreakTimeMinutesInput = new MaskedTextBox();
        startBtn = new Button();
        pauseBtn = new Button();
        BreakOrWorkTimeDispalyed = new Label();
        SessionsInput = new MaskedTextBox();
        SessionsTitle = new Label();
        oneMinutesWarner = new Label();
        SuspendLayout();
        // 
        // Displayed_Timer
        // 
        Displayed_Timer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Displayed_Timer.AutoSize = true;
        Displayed_Timer.Font = new Font("Segoe UI", 20F);
        Displayed_Timer.Location = new Point(538, 198);
        Displayed_Timer.Name = "Displayed_Timer";
        Displayed_Timer.Size = new Size(158, 72);
        Displayed_Timer.TabIndex = 0;
        Displayed_Timer.Text = "00:00";
        // 
        // Work_Time_Title
        // 
        Work_Time_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Work_Time_Title.AutoSize = true;
        Work_Time_Title.Location = new Point(237, 382);
        Work_Time_Title.Name = "Work_Time_Title";
        Work_Time_Title.Size = new Size(129, 32);
        Work_Time_Title.TabIndex = 1;
        Work_Time_Title.Text = "Work Time";
        Work_Time_Title.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Break_Time_Title
        // 
        Break_Time_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Break_Time_Title.AutoSize = true;
        Break_Time_Title.Location = new Point(553, 382);
        Break_Time_Title.Name = "Break_Time_Title";
        Break_Time_Title.Size = new Size(133, 32);
        Break_Time_Title.TabIndex = 2;
        Break_Time_Title.Text = "Break Time";
        Break_Time_Title.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // WorkTimeMinutesInput
        // 
        WorkTimeMinutesInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        WorkTimeMinutesInput.AsciiOnly = true;
        WorkTimeMinutesInput.Location = new Point(237, 439);
        WorkTimeMinutesInput.Mask = "00";
        WorkTimeMinutesInput.Name = "WorkTimeMinutesInput";
        WorkTimeMinutesInput.PromptChar = ' ';
        WorkTimeMinutesInput.Size = new Size(48, 39);
        WorkTimeMinutesInput.TabIndex = 3;
        WorkTimeMinutesInput.Text = "00";
        WorkTimeMinutesInput.TextAlign = HorizontalAlignment.Center;
        WorkTimeMinutesInput.ValidatingType = typeof(int);
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9F);
        label1.Location = new Point(291, 437);
        label1.Name = "label1";
        label1.Size = new Size(19, 32);
        label1.TabIndex = 4;
        label1.Text = ":";
        // 
        // WorkTimeSecondsInput
        // 
        WorkTimeSecondsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        WorkTimeSecondsInput.Location = new Point(316, 439);
        WorkTimeSecondsInput.Mask = "00";
        WorkTimeSecondsInput.Name = "WorkTimeSecondsInput";
        WorkTimeSecondsInput.PromptChar = ' ';
        WorkTimeSecondsInput.Size = new Size(48, 39);
        WorkTimeSecondsInput.TabIndex = 5;
        WorkTimeSecondsInput.Text = "00";
        WorkTimeSecondsInput.TextAlign = HorizontalAlignment.Center;
        // 
        // BreakTimeSecondsInput
        // 
        BreakTimeSecondsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        BreakTimeSecondsInput.Location = new Point(630, 439);
        BreakTimeSecondsInput.Mask = "00";
        BreakTimeSecondsInput.Name = "BreakTimeSecondsInput";
        BreakTimeSecondsInput.PromptChar = ' ';
        BreakTimeSecondsInput.Size = new Size(48, 39);
        BreakTimeSecondsInput.TabIndex = 8;
        BreakTimeSecondsInput.Text = "00";
        BreakTimeSecondsInput.TextAlign = HorizontalAlignment.Center;
        BreakTimeSecondsInput.ValidatingType = typeof(int);
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 9F);
        label2.Location = new Point(605, 439);
        label2.Name = "label2";
        label2.Size = new Size(19, 32);
        label2.TabIndex = 7;
        label2.Text = ":";
        // 
        // BreakTimeMinutesInput
        // 
        BreakTimeMinutesInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        BreakTimeMinutesInput.Location = new Point(551, 437);
        BreakTimeMinutesInput.Mask = "00";
        BreakTimeMinutesInput.Name = "BreakTimeMinutesInput";
        BreakTimeMinutesInput.PromptChar = ' ';
        BreakTimeMinutesInput.Size = new Size(48, 39);
        BreakTimeMinutesInput.TabIndex = 6;
        BreakTimeMinutesInput.Text = "00";
        BreakTimeMinutesInput.TextAlign = HorizontalAlignment.Center;
        BreakTimeMinutesInput.ValidatingType = typeof(int);
        // 
        // startBtn
        // 
        startBtn.Location = new Point(411, 588);
        startBtn.Name = "startBtn";
        startBtn.Size = new Size(150, 46);
        startBtn.TabIndex = 9;
        startBtn.Text = "start";
        startBtn.UseVisualStyleBackColor = true;
        startBtn.Click += startBtn_Click;
        // 
        // pauseBtn
        // 
        pauseBtn.Location = new Point(654, 588);
        pauseBtn.Name = "pauseBtn";
        pauseBtn.Size = new Size(150, 46);
        pauseBtn.TabIndex = 10;
        pauseBtn.Text = "pause";
        pauseBtn.UseVisualStyleBackColor = true;
        // 
        // BreakOrWorkTimeDispalyed
        // 
        BreakOrWorkTimeDispalyed.AutoSize = true;
        BreakOrWorkTimeDispalyed.Font = new Font("Segoe UI", 15F);
        BreakOrWorkTimeDispalyed.Location = new Point(514, 122);
        BreakOrWorkTimeDispalyed.MaximumSize = new Size(208, 54);
        BreakOrWorkTimeDispalyed.MinimumSize = new Size(208, 54);
        BreakOrWorkTimeDispalyed.Name = "BreakOrWorkTimeDispalyed";
        BreakOrWorkTimeDispalyed.Size = new Size(208, 54);
        BreakOrWorkTimeDispalyed.TabIndex = 11;
        BreakOrWorkTimeDispalyed.Text = "Setting up";
        // 
        // SessionsInput
        // 
        SessionsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        SessionsInput.AsciiOnly = true;
        SessionsInput.Location = new Point(858, 439);
        SessionsInput.Mask = "00";
        SessionsInput.Name = "SessionsInput";
        SessionsInput.PromptChar = ' ';
        SessionsInput.Size = new Size(129, 39);
        SessionsInput.TabIndex = 13;
        SessionsInput.Text = "00";
        SessionsInput.TextAlign = HorizontalAlignment.Center;
        SessionsInput.ValidatingType = typeof(int);
        // 
        // SessionsTitle
        // 
        SessionsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        SessionsTitle.AutoSize = true;
        SessionsTitle.Location = new Point(869, 382);
        SessionsTitle.Name = "SessionsTitle";
        SessionsTitle.Size = new Size(104, 32);
        SessionsTitle.TabIndex = 12;
        SessionsTitle.Text = "Sessions";
        SessionsTitle.TextAlign = ContentAlignment.MiddleCenter;
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
        ClientSize = new Size(1257, 718);
        Controls.Add(oneMinutesWarner);
        Controls.Add(SessionsInput);
        Controls.Add(SessionsTitle);
        Controls.Add(BreakOrWorkTimeDispalyed);
        Controls.Add(pauseBtn);
        Controls.Add(startBtn);
        Controls.Add(BreakTimeSecondsInput);
        Controls.Add(label2);
        Controls.Add(BreakTimeMinutesInput);
        Controls.Add(WorkTimeSecondsInput);
        Controls.Add(label1);
        Controls.Add(WorkTimeMinutesInput);
        Controls.Add(Break_Time_Title);
        Controls.Add(Work_Time_Title);
        Controls.Add(Displayed_Timer);
        KeyPreview = true;
        Name = "StartingUI";
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private Label Displayed_Timer;
    private Label Work_Time_Title;
    private Label Break_Time_Title;
    private MaskedTextBox WorkTimeMinutesInput;
    private Label label1;
    private MaskedTextBox WorkTimeSecondsInput;
    private MaskedTextBox BreakTimeSecondsInput;
    private Label label2;
    private MaskedTextBox BreakTimeMinutesInput;
    private Button startBtn;
    private Button pauseBtn;
    private Label BreakOrWorkTimeDispalyed;
    private MaskedTextBox SessionsInput;
    private Label SessionsTitle;
    private Label oneMinutesWarner;
}
