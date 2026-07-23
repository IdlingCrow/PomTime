namespace PomTimeApp.view
{
    partial class settingUpScreen
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
            SessionsInput = new MaskedTextBox();
            SessionsTitle = new Label();
            startBtn = new Button();
            BreakTimeSecondsInput = new MaskedTextBox();
            label2 = new Label();
            BreakTimeMinutesInput = new MaskedTextBox();
            WorkTimeSecondsInput = new MaskedTextBox();
            label1 = new Label();
            WorkTimeMinutesInput = new MaskedTextBox();
            Break_Time_Title = new Label();
            Work_Time_Title = new Label();
            screenTitle = new Label();
            SuspendLayout();
            // 
            // SessionsInput
            // 
            SessionsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SessionsInput.AsciiOnly = true;
            SessionsInput.Location = new Point(873, 392);
            SessionsInput.Mask = "00";
            SessionsInput.Name = "SessionsInput";
            SessionsInput.PromptChar = ' ';
            SessionsInput.Size = new Size(129, 39);
            SessionsInput.TabIndex = 25;
            SessionsInput.Text = "00";
            SessionsInput.TextAlign = HorizontalAlignment.Center;
            SessionsInput.ValidatingType = typeof(int);
            // 
            // SessionsTitle
            // 
            SessionsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SessionsTitle.AutoSize = true;
            SessionsTitle.Location = new Point(884, 335);
            SessionsTitle.Name = "SessionsTitle";
            SessionsTitle.Size = new Size(104, 32);
            SessionsTitle.TabIndex = 24;
            SessionsTitle.Text = "Sessions";
            SessionsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(552, 559);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(150, 46);
            startBtn.TabIndex = 22;
            startBtn.Text = "start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // BreakTimeSecondsInput
            // 
            BreakTimeSecondsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BreakTimeSecondsInput.Location = new Point(645, 392);
            BreakTimeSecondsInput.Mask = "00";
            BreakTimeSecondsInput.Name = "BreakTimeSecondsInput";
            BreakTimeSecondsInput.PromptChar = ' ';
            BreakTimeSecondsInput.Size = new Size(48, 39);
            BreakTimeSecondsInput.TabIndex = 21;
            BreakTimeSecondsInput.Text = "00";
            BreakTimeSecondsInput.TextAlign = HorizontalAlignment.Center;
            BreakTimeSecondsInput.ValidatingType = typeof(int);
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(620, 392);
            label2.Name = "label2";
            label2.Size = new Size(19, 32);
            label2.TabIndex = 20;
            label2.Text = ":";
            // 
            // BreakTimeMinutesInput
            // 
            BreakTimeMinutesInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BreakTimeMinutesInput.Location = new Point(566, 390);
            BreakTimeMinutesInput.Mask = "00";
            BreakTimeMinutesInput.Name = "BreakTimeMinutesInput";
            BreakTimeMinutesInput.PromptChar = ' ';
            BreakTimeMinutesInput.Size = new Size(48, 39);
            BreakTimeMinutesInput.TabIndex = 19;
            BreakTimeMinutesInput.Text = "00";
            BreakTimeMinutesInput.TextAlign = HorizontalAlignment.Center;
            BreakTimeMinutesInput.ValidatingType = typeof(int);
            // 
            // WorkTimeSecondsInput
            // 
            WorkTimeSecondsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WorkTimeSecondsInput.Location = new Point(331, 392);
            WorkTimeSecondsInput.Mask = "00";
            WorkTimeSecondsInput.Name = "WorkTimeSecondsInput";
            WorkTimeSecondsInput.PromptChar = ' ';
            WorkTimeSecondsInput.Size = new Size(48, 39);
            WorkTimeSecondsInput.TabIndex = 18;
            WorkTimeSecondsInput.Text = "00";
            WorkTimeSecondsInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(306, 390);
            label1.Name = "label1";
            label1.Size = new Size(19, 32);
            label1.TabIndex = 17;
            label1.Text = ":";
            // 
            // WorkTimeMinutesInput
            // 
            WorkTimeMinutesInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WorkTimeMinutesInput.AsciiOnly = true;
            WorkTimeMinutesInput.Location = new Point(252, 392);
            WorkTimeMinutesInput.Mask = "00";
            WorkTimeMinutesInput.Name = "WorkTimeMinutesInput";
            WorkTimeMinutesInput.PromptChar = ' ';
            WorkTimeMinutesInput.Size = new Size(48, 39);
            WorkTimeMinutesInput.TabIndex = 16;
            WorkTimeMinutesInput.Text = "00";
            WorkTimeMinutesInput.TextAlign = HorizontalAlignment.Center;
            WorkTimeMinutesInput.ValidatingType = typeof(int);
            // 
            // Break_Time_Title
            // 
            Break_Time_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Break_Time_Title.AutoSize = true;
            Break_Time_Title.Location = new Point(568, 335);
            Break_Time_Title.Name = "Break_Time_Title";
            Break_Time_Title.Size = new Size(133, 32);
            Break_Time_Title.TabIndex = 15;
            Break_Time_Title.Text = "Break Time";
            Break_Time_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Work_Time_Title
            // 
            Work_Time_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Work_Time_Title.AutoSize = true;
            Work_Time_Title.Location = new Point(252, 335);
            Work_Time_Title.Name = "Work_Time_Title";
            Work_Time_Title.Size = new Size(129, 32);
            Work_Time_Title.TabIndex = 14;
            Work_Time_Title.Text = "Work Time";
            Work_Time_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // screenTitle
            // 
            screenTitle.AutoSize = true;
            screenTitle.Font = new Font("Segoe UI", 15F);
            screenTitle.Location = new Point(523, 123);
            screenTitle.MaximumSize = new Size(208, 54);
            screenTitle.MinimumSize = new Size(208, 54);
            screenTitle.Name = "screenTitle";
            screenTitle.Size = new Size(208, 54);
            screenTitle.TabIndex = 26;
            screenTitle.Text = "Setting up";
            // 
            // settingUpScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(screenTitle);
            Controls.Add(SessionsInput);
            Controls.Add(SessionsTitle);
            Controls.Add(startBtn);
            Controls.Add(BreakTimeSecondsInput);
            Controls.Add(label2);
            Controls.Add(BreakTimeMinutesInput);
            Controls.Add(WorkTimeSecondsInput);
            Controls.Add(label1);
            Controls.Add(WorkTimeMinutesInput);
            Controls.Add(Break_Time_Title);
            Controls.Add(Work_Time_Title);
            Name = "settingUpScreen";
            Size = new Size(1283, 789);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox SessionsInput;
        private Label SessionsTitle;
        private Button startBtn;
        private MaskedTextBox BreakTimeSecondsInput;
        private Label label2;
        private MaskedTextBox BreakTimeMinutesInput;
        private MaskedTextBox WorkTimeSecondsInput;
        private Label label1;
        private MaskedTextBox WorkTimeMinutesInput;
        private Label Break_Time_Title;
        private Label Work_Time_Title;
        private Label screenTitle;
    }
}
