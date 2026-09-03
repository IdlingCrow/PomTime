using PomTimeApp.model;
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
        //THEME: theme can be look at in ThemeModel.cs
        //user to indicate the user to wnat to
        //switch the theme number 1
        public EventHandler? userPressedTheme1;

        //user to indicate the user to wnat to
        //switch the theme number 2
        public EventHandler? userPressedTheme2;

        //user to indicate the user to wnat to
        //switch the theme number 3
        public EventHandler? userPressedTheme3;
        public EventHandler? backButtonPressed;
        public EventHandler? userPressedManageMusic;

        //use to allow user to quickly access the folder that
        //displayed the picture during break time
        activityModel activityManager = new activityModel();

        //basically get the theme that the user has pressed
        //previously before closing the app and apply that 
        //theme
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

        //When button 1 for the them session has been clicked
        //set the theme of the whole app to that theme assign
        //as theme 1 in ThemeModel.cs. Also indicate that
        // theme 1 was selected
        private void Theme1Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = false;
            theme2Button.Enabled = true;
            theme3Button.Enabled = true;
            addCustomTheme.Enabled = true;
            userPressedTheme1?.Invoke(sender, e);
        }

        //When button 2 for the them session has been clicked
        //set the theme of the whole app to that theme assign
        //as theme 2 in ThemeModel.cs. Also indicate that
        // theme 2 was selected
        private void theme2Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = true;
            theme2Button.Enabled = false;
            theme3Button.Enabled = true;
            addCustomTheme.Enabled = true;
            userPressedTheme2?.Invoke(sender, e);
        }

        //When button 3 for the them session has been clicked
        //set the theme of the whole app to that theme assign
        //as theme 3 in ThemeModel.cs. Also indicate that
        // theme 3 was selected
        private void theme3Button_Click(object sender, EventArgs e)
        {
            theme1Button.Enabled = true;
            theme2Button.Enabled = true;
            theme3Button.Enabled = false;
            addCustomTheme.Enabled = true;
            userPressedTheme3?.Invoke(sender, e);
        }

        //Indicate the back arrow button was clicked hopefully
        //also returning to the setting up screen
        private void backButton_Click(object sender, EventArgs e)
        {
            backButtonPressed?.Invoke(sender, e);
        }

        //set the theme of this user control to the two inputted color
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

            ImportBreakButton.ForeColor = BackColor;
            ImportBreakButton.BackColor = ForeColor;
            ImportBreakButton.FlatAppearance.BorderColor = ForeColor;

            //text
            themeLable.ForeColor = ForeColor;
            themeLable.BackColor = BackColor;

            MusicManagementLabel.ForeColor = ForeColor;
            MusicManagementLabel.BackColor = BackColor;

            ImportBreakLabel.ForeColor = ForeColor;
            ImportBreakLabel.BackColor = BackColor;
        }

        //clicked the manage button for the music section.
        //this should be listen for by startingUI. and 
        //it should open up the folder in file explorer
        //that store music file
        private void musicManagementButton_Click(object sender, EventArgs e)
        {
            userPressedManageMusic?.Invoke(sender, e);
        }

        //clicked the manage button for the break section.
        //this should be listen for by startingUI. and 
        //it should open up the folder in file explorer
        //that store break picture
        private void ImportBreakButton_Click(object sender, EventArgs e)
        {
            activityManager.manageActivity();
        }

        //internal use for testing
        internal Button getTheme1Button()
        {
            return theme1Button;
        }

        internal Button getTheme2Button()
        {
            return theme2Button;
        }

        internal Button getTheme3Button()
        {
            return theme3Button;
        }

        internal Button getMusicManagementButton()
        {
            return musicManagementButton;
        }

        internal Button getBackButton()
        {
            return backButton;
        }

        internal Color[] getBackgroundAndForeGroundTheme()
        {
            return [BackColor, ForeColor];
        }
    }
}
