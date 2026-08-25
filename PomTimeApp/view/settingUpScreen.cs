using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

//Reminder: sessionLable is doubled and the Colon for the timer
namespace PomTimeApp.view
{
    public partial class settingUpScreen : UserControl
    {
        //used to indicate the that the user pressed start
        public EventHandler? userPressedStart;

        //used to indicate that the user pressed setting
        public EventHandler? userPressedSetting;
        Point ColonForTimerPosition;
        InputState inputState;
        int breakMinutes;
        int breakSeconds;
        int workMinutes;
        int workSeconds;
        int session;

        //get all of the time that the user have used
        //previously before closing the program
        public settingUpScreen()
        {
            InitializeComponent();
            breakMinutes = Properties.Settings.Default.breakMinutes;
            breakSeconds = Properties.Settings.Default.breakSeconds;
            workMinutes = Properties.Settings.Default.workMinutes;
            workSeconds = Properties.Settings.Default.workSeconds;
            session = Properties.Settings.Default.sessions;
            ColonForTimerPosition = SessionLabel.Location;
            inputtingWork();

        }

        //Tell the user control that the
        //user is now inputting for work
        //time and adjust the button
        //to make it look like the work
        //button is selected
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

        //Tell the user control that the
        //user is now inputting for break
        //time and adjust the button
        //to make it look like the break
        //button is selected
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

        //Tell the user control that the
        //user is now inputting for number
        //of session and adjust the button
        //to make it look like the session
        //button is selected
        public void inputtingSession()
        {
            inputState = InputState.Session;
            BreakTimeButton.Enabled = true;
            SessionButton.Enabled = false;
            workTimeButton.Enabled = true;
            MinutesLabel.Hide();
            secondsLabel.Hide();
            SessionLabel.Text = session.ToString();
            SessionLabel.Location = new Point(Size.Width / 2 - SessionLabel.Width / 2, SessionLabel.Location.Y);
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

        //Have the 4 incrementation of time
        //be shown, and have the 3 textbox
        //that in the middle of the screen
        //display the inputted time
        private void showTimeInput()
        {
            MinutesLabel.Show();
            secondsLabel.Show();
            SessionLabel.Text = ":";
            SessionLabel.Location = ColonForTimerPosition;
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

        //varible used to indicate what the user
        //is inputting for
        public enum InputState
        {
            Work,
            Break,
            Session
        }

        //sending this message from here to startingUI then to controller
        //after the user pressed the start button
        private void startBtn_Click(object sender, EventArgs e)
        {
            userPressedStart?.Invoke(this, EventArgs.Empty);
        }

        //get work minutes that the user inputted
        public int getWorkMinutes()
        {
            return workMinutes;
        }

        //get the work seconds the user inputted
        public int getWorkSeconds()
        {
            return workSeconds;
        }

        //get the break munites that user inputted
        public int getBreakMinutes()
        {
            return breakMinutes;
        }

        //get the break seconds the user inputted
        public int getBreakSeconds()
        {
            return breakSeconds;
        }

        //the the number of sessions the user inputted
        public int getSession()
        {
            return session;
        }

        //get what the userControl this is
        public string getTitle()
        {
            return "Setting up";
        }

        //get the time that is shown in the middle of the user control
        public string getDisplayed_timer()
        {
            return $"{MinutesLabel.Text}:{secondsLabel.Text}";
        }

        //change to inputting for work time after the user pressed
        //the work button
        private void workTimeButton_Click(object sender, EventArgs e)
        {
            inputtingWork();
        }

        //change to inputting for break time after the user pressed
        //the break button
        private void BreakTimeButton_Click(object sender, EventArgs e)
        {
            inputtingBreak();
        }

        //change to inputting for nubmer of sessions after the user
        //pressed the sessions button
        private void SessionButton_Click(object sender, EventArgs e)
        {
            inputtingSession();
        }

        //This makes it so the input loops around fromm 99 to 0 instead
        //of increasing to 100 and also increment the breakMinutes or
        //workMintutes input based on the inputState
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

        //This makes it so the input loops around fromm 0 to 99 instead
        //of decreasing to -1 also decrement the breakMinutes or
        //workMintutes input based on the inputState
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

        //This makes it so the input loops around fromm 59 to 0 instead
        //of increasing to 60 also increment the breakSeconds or
        //workSeconds input based on the inputState
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

        //This makes it so the input loops around fromm 0 to 59 instead
        //of decreasing to -1 also decrement the breakSeconds or
        //workSeconds input based on the inputState
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

        //allows the user to increase the number of sessions and display
        //the change
        private void IncreaseSessionBtn_Click(object sender, EventArgs e)
        {
            session++;
            SessionLabel.Text = session.ToString();
            SessionLabel.Location = new Point(Size.Width / 2 - SessionLabel.Width / 2, SessionLabel.Location.Y);
        }

        //this stops the number of sessions from going below 1 and also
        //displayed the number of session
        private void DecreaseSessionBtn_Click(object sender, EventArgs e)
        {
            if (session <= 1)
            {
                session = 1;

            }
            else
            {
                session--;
            }
            SessionLabel.Text = session.ToString();
            SessionLabel.Location = new Point(Size.Width / 2 - SessionLabel.Width / 2, SessionLabel.Location.Y);
        }

        //change the number of minutes displayed
        //on the user screen
        private void changeMinutes(int minutesInd)
        {
            MinutesLabel.Text = $"{minutesInd:D2}";
        }

        //change the number of seconds displayed
        //on the user screen
        private void changeSeconds(int secondInd)
        {
            secondsLabel.Text = $"{secondInd:D2}";
        }

        //Input: Two Color
        //OutPut: None
        //Purpose: switch the theme of this userControl
        //to that of the two inputted color
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

        //idnicate that the setting button has been clicked which
        //and signal to the startingUI that is should switch to
        //to the settingScreen usercontrol
        private void settingButton_Click(object sender, EventArgs e)
        {
            userPressedSetting?.Invoke(sender, e);
        }

        //function use for testing
        internal Label getMinutesLabel()
        {
            return MinutesLabel;
        }

        internal Label getSessionLabel()
        {
            return SessionLabel;
        }

        internal Label getSecondsLabel()
        {
            return secondsLabel;
        }

        internal int[] getDefaultBreakWorkAndSession()
        {
            return [Properties.Settings.Default.workMinutes, 
                    Properties.Settings.Default.workSeconds,
                    Properties.Settings.Default.breakMinutes,
                    Properties.Settings.Default.breakSeconds,
                    Properties.Settings.Default.sessions];
        }

        internal string getInputState()
        {
            if(inputState == InputState.Work)
            {
                return "work";
            } 
            else if(inputState == InputState.Break)
            {
                return "break";
            }
            else //inputState == InputState.Session
            {
                return "session";
            }
        }

        internal Button getBreakInputButton()
        {
            return BreakTimeButton;
        }

        internal Button getWorkInputButton()
        {
            return workTimeButton;
        }

        internal Button getSessionInputButton()
        {
            return SessionButton;
        }

        internal Button getIncreaseMinutesButton()
        {
            return IncreaseMinutesBtn;
        }

        internal Button getDecreaseMinutesBtn()
        {
            return DecreaseMinutesBtn;
        }

        internal Button getIncreaseSecondsButton()
        {
            return IncreaseSecondsBtn;
        }

        internal Button getDecreaseSecondsButton()
        {
            return DecreaseSecondsBtn;
        }

        internal Button getIncreaseSessionButton()
        {
            return IncreaseSessionBtn;
        }

        internal Button getDecreaseSessionButton()
        {
            return DecreaseSessionBtn;
        }

    }
}
