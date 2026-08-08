using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PomTimeApp.view
{
    public partial class stickyNotes : Form
    {
        public stickyNotes()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormClosing += closeNotes;
        }


        public void openNotes()
        {
            if(WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Show();
        }

        public void closeNotes(object? sender, FormClosingEventArgs e) 
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
