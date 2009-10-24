using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoNBuildPlanner
{
    public partial class exceptionWindow : Form
    {
        private bool bContinue = false;

        public exceptionWindow()
        {
            InitializeComponent();
        }

        public exceptionWindow(string stackTrace)
        {
            InitializeComponent();
            rtbox_stack.Text = stackTrace;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            bContinue = true;
            this.Close();
        }

        private void exceptionWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!bContinue) Application.Exit();
        }


    }
}
