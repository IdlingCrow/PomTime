using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace PomTimeApp.view
{
    public partial class settingUpScreen : UserControl
    {
        public EventHandler? userPressedStart;
        public EventHandler? userPressedSetting;

        InputState inputState;
        int breakMinutes;
        int breakSeconds;
        int workMinutes;
        int workSeconds;
        int session;
        public settingUpScreen()
        {
            InitializeComponent();
            breakMinutes = 5;
            breakSeconds = 0;
            workMinutes = 25;
            workSeconds = 0;
            session = 4;
            inputtingWork();

        }

        public void inputtingWork()
        {
            showTimeInput();
            inputState = InputState.Work;
            BreakTimeButton.Enabled = true;
            SessionButton.Enabled = true;
            workTimeButton.Enabled = false;
            changeSeconds(workSeconds);
            changeMinutes(workMinutes);
        }

        public void inputtingBreak()
        {
            showTimeInput();
            inputState = InputState.Break;
            BreakTimeButton.Enabled = false;
            SessionButton.Enabled = true;
            workTimeButton.Enabled = true;
            changeMinutes(breakMinutes);
            changeSeconds(breakSeconds);
        }

        public void inputtingSession()
        {
            inputState = InputState.Session;
            BreakTimeButton.Enabled = true;
            SessionButton.Enabled = false;
            workTimeButton.Enabled = true;
            MinutesLabel.Hide();
            secondsLabel.Hide();
            SessionLabel.Text = session.ToString();
            IncreaseMinutesBtn.Enabled = false;
            DecreaseMinutesBtn.Enabled = false;
            IncreaseSecondsBtn.Enabled = false;
            DecreaseSecondsBtn.Enabled = false;
            IncreaseMinutesBtn.Hide();
            DecreaseMinutesBtn.Hide();
            IncreaseSecondsBtn.Hide();
            DecreaseSecondsBtn.Hide();

            IncreaseSessionBtn.Enabled = true;
            DecreaseSessionBtn.Enabled = true;
            IncreaseSessionBtn.Show();
            DecreaseSessionBtn.Show();
        }




        private void showTimeInput()
        {
            MinutesLabel.Show();
            secondsLabel.Show();
            SessionLabel.Text = ":";
            IncreaseMinutesBtn.Enabled = true;
            DecreaseMinutesBtn.Enabled = true;
            IncreaseSecondsBtn.Enabled = true;
            DecreaseSecondsBtn.Enabled = true;
            IncreaseMinutesBtn.Show();
            DecreaseMinutesBtn.Show();
            IncreaseSecondsBtn.Show();
            DecreaseSecondsBtn.Show();

            IncreaseSessionBtn.Enabled = false;
            DecreaseSessionBtn.Enabled = false;
            IncreaseSessionBtn.Hide();
            DecreaseSessionBtn.Hide();
        }

        public enum InputState
        {
            Work,
            Break,
            Session
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            userPressedStart?.Invoke(this, EventArgs.Empty);
        }

        public int getWorkMinutes()
        {
            return workMinutes;
        }

        public int getWorkSeconds()
        {
            return workSeconds;
        }

        public int getBreakMinutes()
        {
            return breakMinutes;
        }

        public int getBreakSeconds()
        {
            return breakSeconds;
        }

        public int getSession()
        {
            return session;
        }

        public string getTitle()
        {
            return "Setting up";
        }

        public string getDisplayed_timer()
        {
            return $"{MinutesLabel.Text}:{secondsLabel.Text}";
        }

        public void performClickWithInput(int workTimeMinutes, int workTimeSeconds, int breakTimeMinutes, int breakTimeSeconds, int sessions)
        {
            workSeconds = workTimeSeconds;
            workSeconds = workTimeMinutes;
            breakSeconds = workTimeSeconds;
            breakMinutes = breakTimeMinutes;
            session = sessions;
            startBtn_Click(this, EventArgs.Empty);
        }

        private void workTimeButton_Click(object sender, EventArgs e)
        {
            inputtingWork();
        }

        private void BreakTimeButton_Click(object sender, EventArgs e)
        {
            inputtingBreak();
        }

        private void SessionButton_Click(object sender, EventArgs e)
        {
            inputtingSession();
        }

        private void IncreaseMinutesBtn_Click(object sender, EventArgs e)
        {
            if (inputState == InputState.Break)
            {
                breakMinutes = (breakMinutes + 1) % 100;
                changeMinutes(breakMinutes);
            }
            else
            {
                workMinutes = (workMinutes + 1) % 100;
                changeMinutes(workMinutes);
            }

        }

        private void DecreaseMinutesBtn_Click(object sender, EventArgs e)
        {
            if (inputState == InputState.Break)
            {
                breakMinutes = (breakMinutes - 1 + 100) % 100;
                changeMinutes(breakMinutes);
            }
            else
            {
                workMinutes = (workMinutes - 1 + 100) % 100;
                changeMinutes(workMinutes);
            }
        }

        private void IncreaseSecondsBtn_Click(object sender, EventArgs e)
        {
            if (inputState == InputState.Break)
            {
                breakSeconds = (breakSeconds + 1) % 60;
                changeSeconds(breakSeconds);
            }
            else
            {
                workSeconds = (workSeconds + 1) % 60;
                changeSeconds(workSeconds);
            }
        }

        private void DecreaseSecondsBtn_Click(object sender, EventArgs e)
        {
            if (inputState == InputState.Break)
            {
                breakSeconds = (breakSeconds - 1 + 60) % 60;
                changeSeconds(breakSeconds);
            }
            else
            {
                workSeconds = (workSeconds - 1 + 60) % 60;
                changeSeconds(workSeconds);
            }
        }

        private void IncreaseSessionBtn_Click(object sender, EventArgs e)
        {
            session++;
            SessionLabel.Text = session.ToString();
        }

        private void DecreaseSessionBtn_Click(object sender, EventArgs e)
        {
            if (session < 1)
            {
                session = 0;

            }
            else
            {
                session--;
            }
            SessionLabel.Text = session.ToString();
        }

        private void changeMinutes(int minutesInd)
        {
            MinutesLabel.Text = $"{minutesInd:D2}";
        }

        private void changeSeconds(int secondInd)
        {
            secondsLabel.Text = $"{secondInd:D2}";
        }

        public void setTheme(Color backgroundColor, Color foregroundColor)
        {
            //background
            this.ForeColor = foregroundColor;
            this.BackColor = backgroundColor;

            //input option button
            workTimeButton.BackColor = ForeColor;
            workTimeButton.ForeColor = BackColor;
            workTimeButton.FlatAppearance.BorderColor = ForeColor;

            BreakTimeButton.BackColor = ForeColor;
            BreakTimeButton.ForeColor = BackColor;
            BreakTimeButton.FlatAppearance.BorderColor = ForeColor;

            SessionButton.BackColor = ForeColor;
            SessionButton.ForeColor = BackColor;
            SessionButton.FlatAppearance.BorderColor = ForeColor;

            // incrementing input option
            IncreaseMinutesBtn.BackColor = BackColor;
            IncreaseMinutesBtn.ForeColor = ForeColor;

            DecreaseMinutesBtn.BackColor = BackColor;
            DecreaseMinutesBtn.ForeColor = ForeColor;

            IncreaseSessionBtn.BackColor = BackColor;
            IncreaseSessionBtn.ForeColor = ForeColor;

            DecreaseSessionBtn.BackColor = BackColor;
            DecreaseSessionBtn.ForeColor = ForeColor;

            IncreaseSecondsBtn.BackColor = BackColor;
            IncreaseSecondsBtn.ForeColor = ForeColor;

            DecreaseSecondsBtn.BackColor = BackColor;
            DecreaseSecondsBtn.ForeColor = ForeColor;

            //start button
            startBtn.BackColor = ForeColor;
            startBtn.ForeColor = BackColor;
            startBtn.FlatAppearance.BorderColor = ForeColor;

            //setting button 
            settingButton.BackColor = BackColor;
            settingButton.ForeColor = ForeColor;

            //input display
            MinutesLabel.BackColor = BackColor;
            MinutesLabel.ForeColor = ForeColor;

            SessionLabel.BackColor = BackColor;
            SessionLabel.ForeColor = ForeColor;

            secondsLabel.BackColor = BackColor;
            secondsLabel.ForeColor = ForeColor;

        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            userPressedSetting?.Invoke(sender, e);
        }
    }
}
