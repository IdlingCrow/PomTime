namespace PomTimeApp.view
{
    partial class settingScreen
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
            titleLable = new Label();
            backButton = new themeButton();
            themeLable = new Label();
            MusicManagementLabel = new Label();
            TimePresetLabel = new Label();
            ImportBreakLabel = new Label();
            theme1Button = new themeButton();
            splitter1 = new Splitter();
            theme2Button = new themeButton();
            theme3Button = new themeButton();
            addCustomTheme = new themeButton();
            musicManagementButton = new themeButton();
            SuspendLayout();
            // 
            // titleLable
            // 
            titleLable.AutoSize = true;
            titleLable.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            titleLable.Location = new Point(490, 22);
            titleLable.Name = "titleLable";
            titleLable.Size = new Size(351, 106);
            titleLable.TabIndex = 0;
            titleLable.Text = "Settings";
            // 
            // backButton
            // 
            backButton.BackColor = Color.White;
            backButton.FlatAppearance.BorderColor = Color.White;
            backButton.FlatAppearance.BorderSize = 3;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            backButton.ForeColor = Color.FromArgb(167, 199, 231);
            backButton.Location = new Point(36, 22);
            backButton.Name = "backButton";
            backButton.Size = new Size(124, 106);
            backButton.TabIndex = 1;
            backButton.Text = "🡐";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // themeLable
            // 
            themeLable.AutoSize = true;
            themeLable.FlatStyle = FlatStyle.Flat;
            themeLable.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            themeLable.Location = new Point(99, 170);
            themeLable.Name = "themeLable";
            themeLable.Size = new Size(202, 72);
            themeLable.TabIndex = 2;
            themeLable.Text = "Theme";
            // 
            // MusicManagementLabel
            // 
            MusicManagementLabel.AutoSize = true;
            MusicManagementLabel.FlatStyle = FlatStyle.Flat;
            MusicManagementLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            MusicManagementLabel.Location = new Point(99, 341);
            MusicManagementLabel.Name = "MusicManagementLabel";
            MusicManagementLabel.Size = new Size(532, 72);
            MusicManagementLabel.TabIndex = 3;
            MusicManagementLabel.Text = "Music Management";
            // 
            // TimePresetLabel
            // 
            TimePresetLabel.AutoSize = true;
            TimePresetLabel.FlatStyle = FlatStyle.Flat;
            TimePresetLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            TimePresetLabel.Location = new Point(99, 498);
            TimePresetLabel.Name = "TimePresetLabel";
            TimePresetLabel.Size = new Size(327, 72);
            TimePresetLabel.TabIndex = 4;
            TimePresetLabel.Text = "Time Preset";
            // 
            // ImportBreakLabel
            // 
            ImportBreakLabel.AutoSize = true;
            ImportBreakLabel.FlatStyle = FlatStyle.Flat;
            ImportBreakLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            ImportBreakLabel.Location = new Point(99, 660);
            ImportBreakLabel.Name = "ImportBreakLabel";
            ImportBreakLabel.Size = new Size(574, 72);
            ImportBreakLabel.TabIndex = 6;
            ImportBreakLabel.Text = "Import Break Activity";
            // 
            // theme1Button
            // 
            theme1Button.BackColor = Color.White;
            theme1Button.FlatAppearance.BorderColor = Color.White;
            theme1Button.FlatAppearance.BorderSize = 3;
            theme1Button.FlatStyle = FlatStyle.Flat;
            theme1Button.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            theme1Button.ForeColor = Color.FromArgb(167, 199, 231);
            theme1Button.Location = new Point(788, 170);
            theme1Button.Name = "theme1Button";
            theme1Button.Size = new Size(85, 72);
            theme1Button.TabIndex = 7;
            theme1Button.Text = "1";
            theme1Button.UseVisualStyleBackColor = false;
            theme1Button.Click += Theme1Button_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(6, 789);
            splitter1.TabIndex = 8;
            splitter1.TabStop = false;
            // 
            // theme2Button
            // 
            theme2Button.BackColor = Color.White;
            theme2Button.FlatAppearance.BorderColor = Color.White;
            theme2Button.FlatAppearance.BorderSize = 3;
            theme2Button.FlatStyle = FlatStyle.Flat;
            theme2Button.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            theme2Button.ForeColor = Color.FromArgb(167, 199, 231);
            theme2Button.Location = new Point(904, 169);
            theme2Button.Name = "theme2Button";
            theme2Button.Size = new Size(85, 72);
            theme2Button.TabIndex = 9;
            theme2Button.Text = "2";
            theme2Button.UseVisualStyleBackColor = false;
            theme2Button.Click += theme2Button_Click;
            // 
            // theme3Button
            // 
            theme3Button.BackColor = Color.White;
            theme3Button.FlatAppearance.BorderColor = Color.White;
            theme3Button.FlatAppearance.BorderSize = 3;
            theme3Button.FlatStyle = FlatStyle.Flat;
            theme3Button.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            theme3Button.ForeColor = Color.FromArgb(167, 199, 231);
            theme3Button.Location = new Point(1029, 169);
            theme3Button.Name = "theme3Button";
            theme3Button.Size = new Size(85, 72);
            theme3Button.TabIndex = 10;
            theme3Button.Text = "3";
            theme3Button.UseVisualStyleBackColor = false;
            theme3Button.Click += theme3Button_Click;
            // 
            // addCustomTheme
            // 
            addCustomTheme.BackColor = Color.White;
            addCustomTheme.FlatAppearance.BorderColor = Color.White;
            addCustomTheme.FlatAppearance.BorderSize = 3;
            addCustomTheme.FlatStyle = FlatStyle.Flat;
            addCustomTheme.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            addCustomTheme.ForeColor = Color.FromArgb(167, 199, 231);
            addCustomTheme.Location = new Point(1153, 169);
            addCustomTheme.Name = "addCustomTheme";
            addCustomTheme.Size = new Size(85, 72);
            addCustomTheme.TabIndex = 11;
            addCustomTheme.Text = "+";
            addCustomTheme.UseVisualStyleBackColor = false;
            // 
            // musicManagementButton
            // 
            musicManagementButton.BackColor = Color.White;
            musicManagementButton.FlatAppearance.BorderColor = Color.White;
            musicManagementButton.FlatAppearance.BorderSize = 3;
            musicManagementButton.FlatStyle = FlatStyle.Flat;
            musicManagementButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            musicManagementButton.ForeColor = Color.FromArgb(167, 199, 231);
            musicManagementButton.Location = new Point(984, 341);
            musicManagementButton.Name = "musicManagementButton";
            musicManagementButton.Size = new Size(254, 72);
            musicManagementButton.TabIndex = 12;
            musicManagementButton.Text = "Manage";
            musicManagementButton.UseVisualStyleBackColor = false;
            musicManagementButton.Click += musicManagementButton_Click;
            // 
            // settingScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(167, 199, 231);
            Controls.Add(musicManagementButton);
            Controls.Add(addCustomTheme);
            Controls.Add(theme3Button);
            Controls.Add(theme2Button);
            Controls.Add(splitter1);
            Controls.Add(theme1Button);
            Controls.Add(ImportBreakLabel);
            Controls.Add(TimePresetLabel);
            Controls.Add(MusicManagementLabel);
            Controls.Add(themeLable);
            Controls.Add(backButton);
            Controls.Add(titleLable);
            ForeColor = Color.White;
            Name = "settingScreen";
            Size = new Size(1283, 789);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLable;
        private themeButton backButton;
        private Label themeLable;
        private Label MusicManagementLabel;
        private Label TimePresetLabel;
        private Label ImportBreakLabel;
        private themeButton theme1Button;
        private Splitter splitter1;
        private themeButton theme2Button;
        private themeButton theme3Button;
        private themeButton addCustomTheme;
        private themeButton musicManagementButton;
    }
}
