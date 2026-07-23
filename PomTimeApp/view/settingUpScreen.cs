using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class settingUpScreen : UserControl
    {
        public EventHandler? userPressedStart;
        public settingUpScreen()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            userPressedStart?.Invoke(this, EventArgs.Empty);
        }

        public int getWorkMinutes()
        {
            int workMinutes = Convert.ToInt32(WorkTimeMinutesInput.Text);
            return workMinutes;
        }

        public int getWorkSeconds()
        {
            int workSeconds = Convert.ToInt32(WorkTimeSecondsInput.Text);
            return workSeconds;
        }

        public int getBreakMinutes()
        {
            int breakMinutes = Convert.ToInt32(BreakTimeMinutesInput.Text);
            return breakMinutes;
        }

        public int getBreakSeconds()
        {
            int breakSeconds = Convert.ToInt32(BreakTimeSecondsInput.Text);
            return breakSeconds;
        }

        public int getSession()
        {
            int session = Convert.ToInt32(SessionsInput.Text);
            return session;
        }

        public string getTitle()
        {
            return screenTitle.Text;
        }

        public String getDisplayed_timer()
        {
            return screenTitle.Text;
        }

        public void performClickWithInput(int workTimeMinutes, int workTimeSeconds, int breakTimeMinutes, int breakTimeSeconds, int sessions)
        {
            WorkTimeMinutesInput.Text = Convert.ToString(workTimeMinutes);
            WorkTimeSecondsInput.Text = Convert.ToString(workTimeSeconds);
            BreakTimeMinutesInput.Text = Convert.ToString(breakTimeMinutes);
            BreakTimeSecondsInput.Text = Convert.ToString(breakTimeSeconds);
            SessionsInput.Text = Convert.ToString(sessions);
            startBtn_Click(this, EventArgs.Empty);
        }
    }
}
