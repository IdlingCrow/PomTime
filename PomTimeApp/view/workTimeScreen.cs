using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class WorkTimeScreen : UserControl
    {

        public EventHandler? UserPressedPause;
        public EventHandler? UserPressedResume;
        public EventHandler? UserPressedReset;
        public EventHandler? PauseMusic;
        public EventHandler? PlayMusic;
        bool MusicPlaying;


        public WorkTimeScreen()
        {
            InitializeComponent();
            ResetButton.Hide();
            ResumeButton.Hide();
            MusicPlaying = true;
        }

        public void changeDisplayedTime(string time)
        {
            timerOnWorkScreen.Text = time;
        }

        public void enableOneminutesWarning()
        {
            oneMinutesWarner.Text = "One Minutes Warning";
        }

        public void disableOneminutesWarning()
        {
            oneMinutesWarner.Text = "";
        }
        public string getTitle()
        {
            return screenTitle.Text;
        }

        public string getOneMinutesWarner()
        {
            return oneMinutesWarner.Text;
        }

        public string getDisplayed_timer()
        {
            return timerOnWorkScreen.Text;
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

        private void pauseMusicButton_Click(object sender, EventArgs e)
        {
            if(MusicPlaying)
            {
                PauseMusic?.Invoke(this, EventArgs.Empty);
                setButtonToPlayMusic();
            } else
            {
                PlayMusic?.Invoke(this, EventArgs.Empty);
                setButtonToPauseMusic();
            }
            
        }

        public void setButtonToPlayMusic()
        {
            pauseMusicButton.Text = "⏸";
            MusicPlaying = false;
        }

        public void setButtonToPauseMusic()
        {
            pauseMusicButton.Text = "▶";
            MusicPlaying = true;
        }
    }
}
