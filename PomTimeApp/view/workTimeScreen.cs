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

        //set up the screen so that 
        //the pause button, 
        //resume/pause button, skip
        //and play previous music
        //is visible, and assume music
        //is playing
        public WorkTimeScreen()
        {
            InitializeComponent();
            ResetButton.Hide();
            ResumeButton.Hide();
            MusicPlaying = true;
        }

        //allowed the startingUI which is being told
        //by the controller to change the time
        public void changeDisplayedTime(string time)
        {
            timerOnWorkScreen.Text = time;
        }

        //popped the word One Minutes Warning
        //usally used by the controller telling 
        //the startingUI to show this
        public void enableOneminutesWarning()
        {
            oneMinutesWarner.Text = "One Minutes Warning";
        }

        //hide word One Minutes Warning
        //usally used by the controller telling 
        //the startingUI to hide this
        public void disableOneminutesWarning()
        {
            oneMinutesWarner.Text = "";
        }

        //Get what this user control is used for
        public string getTitle()
        {
            return screenTitle.Text;
        }

        //get the displayed time on the usercontrol
        public string getDisplayed_timer()
        {
            return timerOnWorkScreen.Text;
        }

        //when the resume button is clicked, indicate to the controller
        // that time should be resume. and that only the music control
        // and the reset and pause button should be visible
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

        //when the pause button is clicked, indicate to the controller
        // that time should be pause. And the that only the button
        // resume and reset should be visible
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

        //when the reset button is clicked, make only the music control
        //and the pause button visible, cause exit and reset the session
        //timer and for this to go back to the the settingUp screen.
        //by going through the startingUI
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

        //When click if the music is playing the music will stop.
        //if the music is not playing the music will play
        //this mechanism is manipulate by the controller in which
        //pause music and play music is talking through startingUI
        //then to controller
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
