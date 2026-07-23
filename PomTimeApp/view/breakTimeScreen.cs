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
        public breakTimeScreen()
        {
            InitializeComponent();
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

    }
}
