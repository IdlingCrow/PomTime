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
        public EventHandler? SkipMusic;
        public EventHandler? backMusic;
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
            backButton.Show();
            SkipButton.Show();
            pauseMusicButton.Show();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            UserPressedPause?.Invoke(this, EventArgs.Empty);
            ResetButton.Show();
            ResumeButton.Show();
            PauseButton.Hide();
            backButton.Hide();
            SkipButton.Hide();
            pauseMusicButton.Hide();

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UserPressedReset?.Invoke(this, EventArgs.Empty);
            ResetButton.Hide();
            ResumeButton.Hide();
            PauseButton.Show();
            PauseButton.Show();
            backButton.Show();
            SkipButton.Show();
            pauseMusicButton.Show();
        }

        private void pauseMusicButton_Click(object sender, EventArgs e)
        {
            if (MusicPlaying)
            {
                PauseMusic?.Invoke(this, EventArgs.Empty);
                setButtonToPlayMusic();
            }
            else
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

        private void SkipButton_Click(object sender, EventArgs e)
        {
            SkipMusic?.Invoke(this, EventArgs.Empty);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backMusic?.Invoke(this, EventArgs.Empty);
        }

        public void setTheme(Color backgroundColor, Color foregroundColor)
        {
            this.ForeColor = foregroundColor;
            this.BackColor = backgroundColor;

            // The "Work" text
            screenTitle.BackColor = backgroundColor;
            screenTitle.ForeColor = foregroundColor;

            // The timer
            timerOnWorkScreen.BackColor = backgroundColor;
            timerOnWorkScreen.ForeColor = foregroundColor;

            // The button for timer
            ResumeButton.BackColor = foregroundColor;
            ResumeButton.ForeColor = backgroundColor;
            ResumeButton.FlatAppearance.BorderColor = ForeColor;

            PauseButton.BackColor = foregroundColor;
            PauseButton.ForeColor = backgroundColor;
            PauseButton.FlatAppearance.BorderColor = ForeColor;

            ResetButton.BackColor = foregroundColor;
            ResetButton.ForeColor = backgroundColor;
            ResetButton.FlatAppearance.BorderColor = ForeColor;

            // the music button
            backButton.BackColor = foregroundColor;
            backButton.ForeColor = backgroundColor;
            backButton.FlatAppearance.BorderColor = ForeColor;

            pauseMusicButton.BackColor = foregroundColor;
            pauseMusicButton.ForeColor = backgroundColor;
            pauseMusicButton.FlatAppearance.BorderColor = ForeColor;

            SkipButton.BackColor = foregroundColor;
            SkipButton.ForeColor = backgroundColor;
            SkipButton.FlatAppearance.BorderColor = ForeColor;

        }
    }
}
