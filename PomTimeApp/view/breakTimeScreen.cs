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
    public partial class breakTimeScreen : UserControl
    {
        activityModel activityModel;
        public EventHandler? UserPressedPause;
        public EventHandler? UserPressedResume;
        public EventHandler? UserPressedReset;

        //Purpose: Make it so only the pause button
        //is visible
        public breakTimeScreen()
        {
            InitializeComponent();
            activityModel = new activityModel();
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();

        }

        //Input: string that is two character that are
        //numbers
        //Output: None
        //Purpose: allows for startingUI which talk
        //to the controller to change the display time
        //to what the controller tells it to
        public void changeDisplayedTime(string time)
        {
            timerOnBreakScreen.Text = time;
        }

        //Purpose: allow user to get the displayed time
        //on the break screen
        public string getDisplayed_timer()
        {
            return timerOnBreakScreen.Text;
        }

        //Purpose: change the picture to a random picture
        //that is in the file of break activity
        public void startAnActivity()
        {
            changeBreakActvity(activityModel.getBreakActivity());
        }

        //Input: an image 
        //Purpose: change the picture that is displayed
        private void changeBreakActvity(Image newImage)
        {
            breakTimeActivity.Image = newImage;
        }

        //Purpose: use for when the user pressed the resume button
        //hopefully talked to the controller through the startingUI
        //with the EventHandler to resume the timer inside the controller
        //additional make it so only the pause button is visible
        private void ResumeButton_Click(object sender, EventArgs e)
        {
            UserPressedResume?.Invoke(this, EventArgs.Empty);
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();
        }

        //Purpose: use for when the user pressed the pause button
        //hopefully talked to the controller through the startingUI
        //with the EventHandler to pause the timer inside the controller
        //additional make it so only the reumse and reset button is visible
        private void PauseButton_Click(object sender, EventArgs e)
        {
            UserPressedPause?.Invoke(this, EventArgs.Empty);
            ResetButton.Show();
            ResumeButton.Show();
            PauseButton.Hide();
        }

        //Purpose: use for when the user pressed the reset button
        //hopefully talked to the controller through the startingUI
        //with the EventHandler to reset the timer inside the controller
        //and send the screen back to the setting up screen
        //additional make it so only pause button is visible
        private void ResetButton_Click(object sender, EventArgs e)
        {
            UserPressedReset?.Invoke(this, EventArgs.Empty);
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();
        }

        //Input: Two Color
        //OutPut: None
        //Purpose: switch the theme of this userControl
        //to that of the two inputted color
        public void setTheme(Color backgroundColor, Color foregroundColor)
        {
            this.ForeColor = foregroundColor;
            this.BackColor = backgroundColor;

            //The "Break" text
            screenTitle.ForeColor = ForeColor;
            screenTitle.BackColor = BackColor;

            //The buttons 
            PauseButton.ForeColor = BackColor;
            PauseButton.BackColor = ForeColor;
            PauseButton.FlatAppearance.BorderColor = ForeColor;

            ResumeButton.ForeColor = BackColor;
            ResumeButton.BackColor = ForeColor;
            ResumeButton.FlatAppearance.BorderColor = ForeColor;

            ResetButton.ForeColor = BackColor;
            ResetButton.BackColor = ForeColor;
            ResetButton.FlatAppearance.BorderColor = ForeColor;

            //The timer 
            timerOnBreakScreen.ForeColor = ForeColor;
            timerOnBreakScreen.BackColor = BackColor;
        }

        //for test use only
        internal PictureBox getBreakActivityImage()
        {
            return breakTimeActivity;
        }
        internal Button getPauseButton()
        {
            return PauseButton;
        }

        internal Button getResetButton()
        {
            return ResetButton;
        }

        internal Button getResumeButton()
        {
            return ResumeButton;
        }
        internal Color[] getBackgroundAndForeGroundTheme()
        {
            return [BackColor, ForeColor];
        }
    }
}
