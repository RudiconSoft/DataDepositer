using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDepositer
{
    public partial class MainForm : Form
    {
        SetUserForm setUserForm = new SetUserForm();
        String userName = "";
        String password = ""; // @need Refactor

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }

        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // Get file name
            string filename = openFileDialog.FileName;
            // @TODO Add functionality
           
        }

        private void buttonSetUser_Click(object sender, EventArgs e)
        {
            DialogResult res = setUserForm.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                userName = setUserForm.userName;
                labelName.Text = userName;
                password = setUserForm.password;
            }
        }
    }
}
