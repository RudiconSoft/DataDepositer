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
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace DataDepositer
{
    public partial class MainForm : Form
    {
        SetUserForm formSetUser = new SetUserForm();
        StorageForm formStorage = new StorageForm();
        SettingsForm formSettings = new SettingsForm();

        UserData user = new UserData();
        FileData file = new FileData();
        bool isFileSelected = false;
        bool isUserDefined = false;
        IniFile INI = new IniFile("config.ini");
        Config config = new Config();

        // empty lists
        List<FileInfo> StorageList = new List<FileInfo>();
        List<FileInfo> SendList = new List<FileInfo>();
        List<FileInfo> AssembleList = new List<FileInfo>();


        public MainForm()
        {
            InitializeComponent();
            InitConfig();

            // init internal storages with
            InitLists();
        }

        // init lists with data.
        private void InitLists()
        {
            //InitStorageList();
            //InitSendList();
            //InitAssembleList();
        }

        private void InitAssembleList()
        {
            throw new NotImplementedException();
        }

        private void InitSendList()
        {
            throw new NotImplementedException();
        }

        private void InitStorageList()
        {

            throw new NotImplementedException();
        }

        private void InitConfig()
        {
            if (INI.Exists())
            {
                // read data from INI
                config.FromINI(INI);
            }
            else
            {
                // create INI file or use settings ?
                config.ToINI(INI);
            }
            
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

            // Get file name
            if (res == DialogResult.OK)
            {
                setFileName(openFileDialog.FileName);
            }
        }

        private void buttonSetUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult res = formSetUser.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                user.SetUserData(formSetUser.userName, formSetUser.password);
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
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            if (isFileSelected && user.IsSet)
            {
                STORED_FILE_HEADER sh = new STORED_FILE_HEADER();
                Helper helper = new Helper();
                FileManipulator fm = new FileManipulator();
                
                // pack file
                Directory.CreateDirectory(config.TempFolder);
                var fileInputName = file.GetFileName();
                byte[] buffer = File.ReadAllBytes(fileInputName);

                FileInfo fi = new FileInfo(fileInputName);
                sh.cb = (uint)Marshal.SizeOf(sh); // header size
                sh.OriginSize = (ulong) fi.Length;
                sh.MD5Origin = new Helper().GetFileMD5(fileInputName);

                var fileOutputName = config.TempFolder + "\\" + Path.GetFileName(file.GetFileName());
                using (var file = File.Open(fileOutputName, FileMode.Create))
                using (var stream = new DeflateStream(file, CompressionMode.Compress))
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(buffer);
                }

                // encrypt file
                byte[] buff = File.ReadAllBytes(fileOutputName);
//                var fileOutputNameEncrypted = config.TempFolder + "\\" + Path.GetFileName(file.GetFileName()) + @".enc";
//                new AESEnDecryption().BinarySaveObjectWithAes(buff, fileOutputNameEncrypted, user.GetName(), user.GetPassword());
                new AESEnDecryption().BinarySaveObjectWithAes(buff, fileOutputName, user.GetName(), user.GetPassword());

                // split file 
//                fm.SplitFile(fileOutputNameEncrypted, config.SendFolder, config.Chunks, sh);
                fm.SplitFile(fileOutputName, config.SendFolder, config.Chunks, sh);

                // @TODO Add SendList filling
                DirectoryInfo di = new DirectoryInfo(config.SendFolder);


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
                isFileSelected = true;
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult res = formSettings.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                // save settings

            }
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult res = formStorage.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                // @TODO implementation

            }
            this.Visible = true;

        }
    }
}
