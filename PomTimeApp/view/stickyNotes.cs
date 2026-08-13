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
            int userScreenWidth = Screen.PrimaryScreen?.Bounds.Width ?? 0;
            int userScreenHeight = Screen.PrimaryScreen?.Bounds.Height ?? 0;

            Location = new Point(userScreenWidth / 6, userScreenHeight / 25);
            InitializeComponent();
            this.TopMost = true;
            this.FormClosing += closeNotes;
        }

        //Command used to pull up the notes winform
        public void openNotes()
        {
            if(WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Show();
        }

        //used to overide the action to close the notes and instead
        //hide to save the notes
        public void closeNotes(object? sender, FormClosingEventArgs e) 
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        //This is used for when all the sessions is done
        public void resetNotes()
        {
            Hide();
            reminderDescription.Text = string.Empty;
        }

    }
}
