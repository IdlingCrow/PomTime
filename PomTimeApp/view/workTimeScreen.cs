using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class workTimeScreen : UserControl
    {
        public workTimeScreen()
        {
            InitializeComponent();
        }

        public void changeDisplayedTime(string time)
        {
            timerOnWorkScreen.Text = time;
        }
    }
}
