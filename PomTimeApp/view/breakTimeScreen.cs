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
        public breakTimeScreen()
        {
            InitializeComponent();
            activityModel = new activityModel();
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();

        }

        public void changeDisplayedTime(string time)
        {
            timerOnBreakScreen.Text = time;
        }

        public string getTitle()
        {
            return screenTitle.Text;
        }

        public string getDisplayed_timer()
        {
            return timerOnBreakScreen.Text;
        }

        public void startAnActivity()
        {
            changeBreakActvity(activityModel.getBreakActivity());
        }

        private void changeBreakActvity(Image newImage)
        {
            breakTimeActivity.Image = newImage;
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            UserPressedResume?.Invoke(this, EventArgs.Empty);
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            UserPressedPause?.Invoke(this, EventArgs.Empty);
            ResetButton.Show();
            ResumeButton.Show();
            PauseButton.Hide();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UserPressedReset?.Invoke(this, EventArgs.Empty);
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();
        }
    }
}
