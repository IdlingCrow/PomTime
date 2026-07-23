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
        public WorkTimeScreen()
        {
            InitializeComponent();
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

    }
}
