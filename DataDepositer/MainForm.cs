using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataDepositer
{
    public partial class MainForm : Form
    {
        SetUserForm setUserForm = new SetUserForm();
        UserData user = new UserData();
        FileData file = new FileData();
        bool isFileSelected = false;
        bool isUserDefined = false;
        
        
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
            DialogResult res = openFileDialog.ShowDialog();
            //if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            //   return;
            // Get file name
            if (res == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                // Read file
                isFileSelected = true;
                labelFileName.Text = Path.GetFileName(filename);
            }
        }

        private void buttonSetUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult res = setUserForm.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                user.SetUserData(setUserForm.userName, setUserForm.password);
                labelName.Text = user.GetName();
                //isUserDefined = true;
            }
            this.Visible = true;

           

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            //e.Data.
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            if (isFileSelected && user.IsSet)
            {

            }
        }

        private void bgwNetwork_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
