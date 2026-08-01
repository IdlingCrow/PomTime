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
            workTimeButton = new themeButton();
            BreakTimeButton = new themeButton();
            SessionButton = new themeButton();
            SessionLabel = new Label();
            secondsLabel = new Label();
            IncreaseMinutesBtn = new Button();
            DecreaseMinutesBtn = new Button();
            IncreaseSessionBtn = new Button();
            DecreaseSessionBtn = new Button();
            IncreaseSecondsBtn = new Button();
            DecreaseSecondsBtn = new Button();
            startBtn = new themeButton();
            MinutesLabel = new Label();
            SuspendLayout();
            // 
            // workTimeButton
            // 
            workTimeButton.BackColor = Color.White;
            workTimeButton.FlatAppearance.BorderColor = Color.White;
            workTimeButton.FlatAppearance.BorderSize = 3;
            workTimeButton.FlatStyle = FlatStyle.Flat;
            workTimeButton.Font = new Font("Segoe UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            workTimeButton.ForeColor = Color.FromArgb(167, 199, 231);
            workTimeButton.Location = new Point(65, 46);
            workTimeButton.Name = "workTimeButton";
            workTimeButton.Size = new Size(339, 104);
            workTimeButton.TabIndex = 0;
            workTimeButton.Text = "Work";
            workTimeButton.UseVisualStyleBackColor = false;
            workTimeButton.Click += workTimeButton_Click;
            // 
            // BreakTimeButton
            // 
            BreakTimeButton.BackColor = Color.White;
            BreakTimeButton.FlatAppearance.BorderColor = Color.White;
            BreakTimeButton.FlatAppearance.BorderSize = 3;
            BreakTimeButton.FlatStyle = FlatStyle.Flat;
            BreakTimeButton.Font = new Font("Segoe UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BreakTimeButton.ForeColor = Color.FromArgb(167, 199, 231);
            BreakTimeButton.Location = new Point(484, 46);
            BreakTimeButton.Name = "BreakTimeButton";
            BreakTimeButton.Size = new Size(339, 104);
            BreakTimeButton.TabIndex = 1;
            BreakTimeButton.Text = "Break";
            BreakTimeButton.UseVisualStyleBackColor = false;
            BreakTimeButton.Click += BreakTimeButton_Click;
            // 
            // SessionButton
            // 
            SessionButton.BackColor = Color.White;
            SessionButton.FlatAppearance.BorderColor = Color.White;
            SessionButton.FlatAppearance.BorderSize = 3;
            SessionButton.FlatStyle = FlatStyle.Flat;
            SessionButton.Font = new Font("Segoe UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SessionButton.ForeColor = Color.FromArgb(167, 199, 231);
            SessionButton.Location = new Point(898, 46);
            SessionButton.Name = "SessionButton";
            SessionButton.Size = new Size(339, 104);
            SessionButton.TabIndex = 2;
            SessionButton.Text = "Session";
            SessionButton.UseVisualStyleBackColor = false;
            SessionButton.Click += SessionButton_Click;
            // 
            // SessionLabel
            // 
            SessionLabel.AutoSize = true;
            SessionLabel.BackColor = Color.Transparent;
            SessionLabel.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SessionLabel.ForeColor = Color.White;
            SessionLabel.Location = new Point(590, 344);
            SessionLabel.MinimumSize = new Size(90, 142);
            SessionLabel.Name = "SessionLabel";
            SessionLabel.Size = new Size(90, 142);
            SessionLabel.TabIndex = 4;
            SessionLabel.Text = ":";
            SessionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // secondsLabel
            // 
            secondsLabel.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            secondsLabel.ForeColor = Color.White;
            secondsLabel.Location = new Point(652, 344);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new Size(193, 142);
            secondsLabel.TabIndex = 5;
            secondsLabel.Text = "00";
            secondsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IncreaseMinutesBtn
            // 
            IncreaseMinutesBtn.BackColor = Color.FromArgb(167, 199, 231);
            IncreaseMinutesBtn.FlatAppearance.BorderSize = 0;
            IncreaseMinutesBtn.FlatStyle = FlatStyle.Flat;
            IncreaseMinutesBtn.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            IncreaseMinutesBtn.ForeColor = Color.White;
            IncreaseMinutesBtn.Location = new Point(484, 243);
            IncreaseMinutesBtn.Name = "IncreaseMinutesBtn";
            IncreaseMinutesBtn.Size = new Size(100, 98);
            IncreaseMinutesBtn.TabIndex = 6;
            IncreaseMinutesBtn.Text = "▲";
            IncreaseMinutesBtn.TextAlign = ContentAlignment.TopCenter;
            IncreaseMinutesBtn.UseVisualStyleBackColor = false;
            IncreaseMinutesBtn.Click += IncreaseMinutesBtn_Click;
            // 
            // DecreaseMinutesBtn
            // 
            DecreaseMinutesBtn.BackColor = Color.FromArgb(167, 199, 231);
            DecreaseMinutesBtn.FlatAppearance.BorderSize = 0;
            DecreaseMinutesBtn.FlatStyle = FlatStyle.Flat;
            DecreaseMinutesBtn.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            DecreaseMinutesBtn.ForeColor = Color.White;
            DecreaseMinutesBtn.Location = new Point(484, 478);
            DecreaseMinutesBtn.Name = "DecreaseMinutesBtn";
            DecreaseMinutesBtn.Size = new Size(100, 98);
            DecreaseMinutesBtn.TabIndex = 7;
            DecreaseMinutesBtn.Text = "▼";
            DecreaseMinutesBtn.UseVisualStyleBackColor = false;
            DecreaseMinutesBtn.Click += DecreaseMinutesBtn_Click;
            // 
            // IncreaseSessionBtn
            // 
            IncreaseSessionBtn.BackColor = Color.FromArgb(167, 199, 231);
            IncreaseSessionBtn.FlatAppearance.BorderSize = 0;
            IncreaseSessionBtn.FlatStyle = FlatStyle.Flat;
            IncreaseSessionBtn.Font = new Font("Segoe UI", 30F);
            IncreaseSessionBtn.ForeColor = Color.White;
            IncreaseSessionBtn.Location = new Point(590, 243);
            IncreaseSessionBtn.Name = "IncreaseSessionBtn";
            IncreaseSessionBtn.Size = new Size(100, 98);
            IncreaseSessionBtn.TabIndex = 8;
            IncreaseSessionBtn.Text = "▲";
            IncreaseSessionBtn.UseVisualStyleBackColor = false;
            IncreaseSessionBtn.Click += IncreaseSessionBtn_Click;
            // 
            // DecreaseSessionBtn
            // 
            DecreaseSessionBtn.BackColor = Color.FromArgb(167, 199, 231);
            DecreaseSessionBtn.FlatAppearance.BorderSize = 0;
            DecreaseSessionBtn.FlatStyle = FlatStyle.Flat;
            DecreaseSessionBtn.Font = new Font("Segoe UI", 30F);
            DecreaseSessionBtn.ForeColor = Color.White;
            DecreaseSessionBtn.Location = new Point(590, 478);
            DecreaseSessionBtn.Name = "DecreaseSessionBtn";
            DecreaseSessionBtn.Size = new Size(100, 98);
            DecreaseSessionBtn.TabIndex = 9;
            DecreaseSessionBtn.Text = "▼";
            DecreaseSessionBtn.UseVisualStyleBackColor = false;
            DecreaseSessionBtn.Click += DecreaseSessionBtn_Click;
            // 
            // IncreaseSecondsBtn
            // 
            IncreaseSecondsBtn.BackColor = Color.FromArgb(167, 199, 231);
            IncreaseSecondsBtn.FlatAppearance.BorderSize = 0;
            IncreaseSecondsBtn.FlatStyle = FlatStyle.Flat;
            IncreaseSecondsBtn.Font = new Font("Segoe UI", 30F);
            IncreaseSecondsBtn.ForeColor = Color.White;
            IncreaseSecondsBtn.Location = new Point(696, 243);
            IncreaseSecondsBtn.Name = "IncreaseSecondsBtn";
            IncreaseSecondsBtn.Size = new Size(100, 98);
            IncreaseSecondsBtn.TabIndex = 10;
            IncreaseSecondsBtn.Text = "▲";
            IncreaseSecondsBtn.UseVisualStyleBackColor = false;
            IncreaseSecondsBtn.Click += IncreaseSecondsBtn_Click;
            // 
            // DecreaseSecondsBtn
            // 
            DecreaseSecondsBtn.BackColor = Color.FromArgb(167, 199, 231);
            DecreaseSecondsBtn.FlatAppearance.BorderSize = 0;
            DecreaseSecondsBtn.FlatStyle = FlatStyle.Flat;
            DecreaseSecondsBtn.Font = new Font("Segoe UI", 30F);
            DecreaseSecondsBtn.ForeColor = Color.White;
            DecreaseSecondsBtn.Location = new Point(696, 478);
            DecreaseSecondsBtn.Name = "DecreaseSecondsBtn";
            DecreaseSecondsBtn.Size = new Size(100, 98);
            DecreaseSecondsBtn.TabIndex = 11;
            DecreaseSecondsBtn.Text = "▼";
            DecreaseSecondsBtn.UseVisualStyleBackColor = false;
            DecreaseSecondsBtn.Click += DecreaseSecondsBtn_Click;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.White;
            startBtn.FlatAppearance.BorderColor = Color.White;
            startBtn.FlatAppearance.BorderSize = 3;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Segoe UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startBtn.ForeColor = Color.FromArgb(167, 199, 231);
            startBtn.Location = new Point(432, 635);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(413, 104);
            startBtn.TabIndex = 12;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // MinutesLabel
            // 
            MinutesLabel.BackColor = Color.Transparent;
            MinutesLabel.Font = new Font("Segoe UI", 40.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MinutesLabel.ForeColor = Color.White;
            MinutesLabel.Location = new Point(432, 344);
            MinutesLabel.Name = "MinutesLabel";
            MinutesLabel.Size = new Size(195, 142);
            MinutesLabel.TabIndex = 14;
            MinutesLabel.Text = "25";
            MinutesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // settingUpScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(167, 199, 231);
            Controls.Add(secondsLabel);
            Controls.Add(SessionLabel);
            Controls.Add(MinutesLabel);
            Controls.Add(startBtn);
            Controls.Add(DecreaseSecondsBtn);
            Controls.Add(IncreaseSecondsBtn);
            Controls.Add(DecreaseSessionBtn);
            Controls.Add(IncreaseSessionBtn);
            Controls.Add(DecreaseMinutesBtn);
            Controls.Add(IncreaseMinutesBtn);
            Controls.Add(SessionButton);
            Controls.Add(BreakTimeButton);
            Controls.Add(workTimeButton);
            ForeColor = Color.White;
            Name = "settingUpScreen";
            Size = new Size(1283, 789);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label SessionLabel;
        private Label secondsLabel;
        private Button IncreaseMinutesBtn;
        private Button DecreaseMinutesBtn;
        private Button IncreaseSessionBtn;
        private Button DecreaseSessionBtn;
        private Button IncreaseSecondsBtn;
        private Button DecreaseSecondsBtn;
        private Label MinutesLabel;
        private themeButton workTimeButton;
        private themeButton BreakTimeButton;
        private themeButton SessionButton;
        private themeButton startBtn;
    }
}
