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
            this.FormClosing += closeNotes;
        }


        public void openNotes()
        {
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
