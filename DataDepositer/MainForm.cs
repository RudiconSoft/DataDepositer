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
        IniFile INI = new IniFile("config.ini");


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
            // TODO add INI file and settings read.

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Count() > 0)
            {
                string fn = files.First(); //
                Logger.Log.Info("Drag&Drop file : " + fn);
                setFileName(fn);
            }


            //if (true)
            //{
            //    foreach (string file in files)
            //    {
            //        Logger.Log.Info("Drag&Drop file : " + file);
            //        //new MainFormProcessing().

            //    }
            //}
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // log each exiting

            Logger.Log.Info("Quit application.");
        }


        // private section of methods.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"> File name for processing </param>
        private void setFileName(string filename)
        {
            if (filename.Length > 0)
            {
                file.SetFileName(filename);
                labelFileName.Text = filename;
            }
            else
            {
                Logger.Log.Error("Empty file name !!!");
                throw new Exception("Empty file name !!!");
            }
        }

        private void loadIni()
        {
            // if INI exists load data, else do nothing
            if (INI.KeyExists("SettingMainForm", "Width"))
            {
                this.Height = int.Parse(INI.Read("SettingMainForm", "Height"));
            }
            //else
            //    numericUpDown1.Value = this.MinimumSize.Height;

            if (INI.KeyExists("SettingMainForm", "Width"))
            {
                this.Width = int.Parse(INI.Read("SettingMainForm", "Width"));
            }
            //else
            //    numericUpDown2.Value = this.MinimumSize.Width;

            //if (INI.KeyExists("SettingMainForm", "Parts"))
                //textBox1.Text = INI.ReadINI("Other", "Text");

            //this.Height = int.Parse(numericUpDown1.Value.ToString());
            //this.Width = int.Parse(numericUpDown2.Value.ToString());
        }

    }
}
