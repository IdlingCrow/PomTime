using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class settingScreen : UserControl
    {
        public EventHandler? userPressedTheme1;
        public EventHandler? userPressedTheme2;
        public EventHandler? userPressedTheme3;
        public EventHandler? backButtonPressed;
        public EventHandler? userPressedManageMusic;
        public settingScreen()
        {
            InitializeComponent();
            int theme = Properties.Settings.Default.Theme;
            if (theme == 1)
            {
                Theme1Button_Click(this, EventArgs.Empty);
            }
            else if (theme == 2)
            {
                theme2Button_Click(this, EventArgs.Empty);
            }
            else
            {
                theme3Button_Click(this, EventArgs.Empty);
            }

        }

        private void Theme1Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = false;
            theme2Button.Enabled = true;
            theme3Button.Enabled = true;
            addCustomTheme.Enabled = true;
            userPressedTheme1?.Invoke(sender, e);
        }

        private void theme2Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = true;
            theme2Button.Enabled = false;
            theme3Button.Enabled = true;
            addCustomTheme.Enabled = true;
            userPressedTheme2?.Invoke(sender, e);
        }

        private void theme3Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = true;
            theme2Button.Enabled = true;
            theme3Button.Enabled = false;
            addCustomTheme.Enabled = true;
            userPressedTheme3?.Invoke(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backButtonPressed?.Invoke(sender, e);
        }

        public void setTheme(Color backgroundColor, Color foregroundColor)
        {
            ForeColor = foregroundColor;
            BackColor = backgroundColor;

            //buttons
            backButton.ForeColor = BackColor;
            backButton.BackColor = ForeColor;
            backButton.FlatAppearance.BorderColor = ForeColor;

            theme1Button.ForeColor = BackColor;
            theme1Button.BackColor = ForeColor;
            theme1Button.FlatAppearance.BorderColor = ForeColor;

            theme2Button.ForeColor = BackColor;
            theme2Button.BackColor = ForeColor;
            theme2Button.FlatAppearance.BorderColor = ForeColor;

            theme3Button.ForeColor = BackColor;
            theme3Button.BackColor = ForeColor;
            theme3Button.FlatAppearance.BorderColor = ForeColor;

            addCustomTheme.ForeColor = BackColor;
            addCustomTheme.BackColor = ForeColor;
            addCustomTheme.FlatAppearance.BorderColor = ForeColor;

            musicManagementButton.ForeColor = BackColor;
            musicManagementButton.BackColor = ForeColor;
            musicManagementButton.FlatAppearance.BorderColor = ForeColor;

            //text
            themeLable.ForeColor = ForeColor;
            themeLable.BackColor = BackColor;

            MusicManagementLabel.ForeColor = ForeColor;
            MusicManagementLabel.BackColor = BackColor;

            TimePresetLabel.ForeColor = ForeColor;
            TimePresetLabel.BackColor = BackColor;

            ImportBreakLabel.ForeColor = ForeColor;
            ImportBreakLabel.BackColor = BackColor;
        }

        private void musicManagementButton_Click(object sender, EventArgs e)
        {
            userPressedManageMusic?.Invoke(sender, e);
        }
    }
}
