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
using System.Xml.Serialization;
using System.Threading;

namespace DataDepositer
{
    public partial class MainForm : Form
    {
        SetUserForm formSetUser = new SetUserForm();
        StorageForm formStorage = new StorageForm();
        SettingsForm formSettings = new SettingsForm();

        BackgroundWorker bgwFileSender = new BackgroundWorker(); // Thread for File send
        BackgroundWorker bgwFileReciever = new BackgroundWorker(); // Thread for File recieve

        UserData user = new UserData();
        FileData file = new FileData();
        bool isFileSelected = false;
        bool isUserDefined = false;
        IniFile INI = new IniFile("config.ini");
        Config config = new Config();
        private NetworkP2P network;

        // empty lists
        //List<StorageItem> StorageList = new List<StorageItem>();
        //List<FileInfo> SendList = new List<FileInfo>();
        //List<FileInfo> AssembleList = new List<FileInfo>();


        public MainForm()
        {
            InitializeComponent();
            InitConfig();
            InitP2P();

            // init internal storages with
            InitLists();
            InitBackgroundWorkers();
            timerNetworkCheck.Start();
            //bgwNetwork.RunWorkerAsync();
        }

        private void InitBackgroundWorkers()
        {
            // Init file sender
            this.bgwFileSender.DoWork += new DoWorkEventHandler(this.bgwFileSender_DoWork);
            this.bgwFileSender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFileSender_RunWorkerCompleted);

            // Init file reciever

        }

        private void InitP2P()
        {
            network = new NetworkP2P(Application.ProductName, config);
            network.Init();
            Logger.Log.Info("Start P2P Network...");
            network.Start();
        }

        private void ResolveP2P()
        {
            network.Resolve();
        }

        // init lists with data.
        private void InitLists()
        {
            InitStorageList();
            InitSendList();
            //InitAssembleList();
        }

        private void InitAssembleList()
        {
            throw new NotImplementedException();
        }

        private void InitSendList()
        {
            //FileInfo fi 
            if (File.Exists(config.SendFolder + "List.xml"))
            {
                // Serialize list.xml
                ReadSendList();
            }
            else
            {
                // create new xml list from files in StorageFolder
                CreateNewSendList();
            }
        }

        private void CreateNewSendList()
        {
            DirectoryInfo di = new DirectoryInfo(config.SendFolder);
            if (di.Exists)
            {
                FileManipulator fm = new FileManipulator();
                foreach (var f in di.GetFiles())
                {
                    try
                    {
                        // get header from file
                        STORED_FILE_HEADER sfh = fm.GetHeaderFromFile(f.FullName);

                        // fill SendItem from header
                        string originname = f.Name.Substring(0, f.Name.IndexOf(".part") - 5); // if string not found file name ignored
                        SendItem si = new SendItem(sfh.FileName, originname, sfh.Description, sfh.OriginSize, 
                            (uint)sfh.ChunksQty, (uint)sfh.ChunkNum, sfh.MD5Chunk, sfh.MD5Origin, 0);

                        // add Send item into List
                        Vault.SendList.Add(si);

                    }
                    catch (Exception e)
                    {
                        Logger.Log.Error("Error in SendList creation process.");
                        Logger.Log.Error(e.Message);
                    }
                }

                // Serialize StorageList
                XmlSerializer formatter = new XmlSerializer(typeof(List<SendItem>));
                using (FileStream fs = new FileStream(config.SendFolder + "List.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Vault.SendList);
                }
            }
            else
            {
                di.Create(); // just create empty StoredFolder 
            }
        }

        private void ReadSendList()
        {
            // Deserialize SendList
            XmlSerializer formatter = new XmlSerializer(typeof(List<SendItem>));
            using (FileStream fs = new FileStream(config.SendFolder + "List.xml", FileMode.Open))
            {
                Vault.SendList = (List<SendItem>)formatter.Deserialize(fs);
            }
        }

        private void InitStorageList()
        {
            if (File.Exists(config.StorageFolder + "List.xml"))
            {
                // Serialize list.xml
                ReadStorageList();
            }
            else
            {
                // create new xml list from files in SendFolder
                CreateNewStorageList();
            }

        }

        private void ReadStorageList()
        {
            // Deserialize StorageList
            XmlSerializer formatter = new XmlSerializer(typeof(List<StorageItem>));
            using (FileStream fs = new FileStream(config.StorageFolder + "List.xml", FileMode.Open))
            {
                Vault.StorageList = (List<StorageItem>) formatter.Deserialize(fs); 
            }
        }

        private void CreateNewStorageList()
        {
            DirectoryInfo di = new DirectoryInfo(config.StorageFolder);
            if (di.Exists)
            {
                FileManipulator fm = new FileManipulator();
                foreach (var f in di.GetFiles())
                {
                    try
                    {
                        // get header from file
                        STORED_FILE_HEADER sfh = fm.GetHeaderFromFile(f.FullName);

                        // fill StorageItem from header
                        string originname = f.Name.Substring(0, f.Name.IndexOf(".part") - 5); // if string not found file name ignored
                        StorageItem si = new StorageItem(sfh.FileName, originname, sfh.Description, sfh.OriginSize, (uint) sfh.ChunksQty, (uint) sfh.ChunkNum, sfh.MD5Chunk, sfh.MD5Origin);

                        // add Storage item into List
                        Vault.StorageList.Add(si);

                    }
                    catch (Exception e )
                    {
                        Logger.Log.Error("Error in StoredList creation process.");
                        Logger.Log.Error(e.Message);
                        //throw;
                    }
                }

                // Serialize StorageList
                XmlSerializer formatter = new XmlSerializer(typeof(List<StorageItem>));
                using (FileStream fs = new FileStream(config.StorageFolder + "List.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Vault.StorageList);
                }
            }
            else
            {
                di.Create(); // just create empty StoredFolder 
            }
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
                sh.Description = tbFileDescription.Text;
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // log each exiting
            network.Stop();
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    //formStorage.InitLists(Vault.StorageList, Vault.SendList, Vault.AssembleList);
        //    DialogResult res = formStorage.ShowDialog();

        //    if (res != DialogResult.Cancel)
        //    {
        //        // @TODO implementation

        //    }
        //    this.Visible = true;

        //}

        private void btnViewStorage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //formStorage.InitLists(Vault.StorageList, Vault.SendList, Vault.AssembleList);
            DialogResult res = formStorage.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                // @TODO implementation

            }
            this.Visible = true;

        }

        private void bgwNetwork_DoWork(object sender, DoWorkEventArgs e)
        {
            //bgwNetwork.
            Command command = e.Argument as Command;
            //CommandQueue queue = sender as CommandQueue;

            //for (int i = 0; i < command.Counter; i++)
            //{
            //    Logger.Log.Info(" bgwNetwork_DoWork  Test  " + command.Message + "  " + Convert.ToString(i));
            //    Thread.Sleep(10000); // Sleep 10 sec
            //}

            ResolveP2P();
        }

        private void bgwNetwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logger.Log.Info(" bgwNetwork_DoWork  Test Complete ");
        }

        private void timerNetworkCheck_Tick(object sender, EventArgs e)
        {
            Command command = new Command("Start on Timer", new Random().Next() % 10 + 1);
            timerNetworkCheck.Interval = (new Random().Next() % 100 + 100) * 1000;
            if (!bgwNetwork.IsBusy)
            {
                bgwNetwork.RunWorkerAsync(command);
            }
            else
            {
                Logger.Log.Info(" BackgroundWorker - " + bgwNetwork.ToString() + " is busy !!");
            }
        }

        private void timerResolver_Tick(object sender, EventArgs e)
        {
            
        }


        #region BackgroundWorker for File Sender
        private void bgwFileSender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command command = e.Argument as Command;
            //CommandQueue queue = sender as CommandQueue;

        }

        private void bgwFileSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        #endregion

        #region BackgroundWorker for File Reciever
        private void bgwFileReciever_DoWork(object sender, DoWorkEventArgs e)
        {
            Command command = e.Argument as Command;
            //CommandQueue queue = sender as CommandQueue;

        }

        private void bgwFileReciever_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}
