using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetFileManager
{
    public partial class MainForm : Form
    {
        NetworkP2P p2p = null;
        IniFile ini = new IniFile("config.ini");
        Config config = new Config();
        FileManager nfm = new FileManager();

        public MainForm()
        {
            InitializeComponent();
            InitConfig();
            InitLists();
            p2p = new NetworkP2P(Application.ProductName + Application.CompanyName, config);
            p2p.Init();
            p2p.Start();

        }

        private void InitLists()
        {
            InitRequestList();
            InitSendList();
        }

        private void InitConfig()
        {
            if (ini.Exists())
            {
                // read data from INI
                config.FromINI(ini);
            }
            else
            {
                // create INI file or use settings ?
                config.ToINI(ini);
            }

        }

        private void InitSendList()
        {
            string workdir = "d:\\test\\files\\";
            string sendpath = "d:\\test\\files\\send\\";
            string requestpath = "d:\\test\\files\\request\\";

            FileManager fm = new FileManager(workdir);
        }

        private void InitRequestList()
        {

        }

        private void lvRequestFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bgwP2PResolver.RunWorkerAsync();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            p2p.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start file send 
            //NetworkP2P.Peers.;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)config.Port);
            nfm.Send("d:\\test\\files\\s\\testfile2.txt", ep);

        }

        private void bgwP2PResolver_DoWork(object sender, DoWorkEventArgs e)
        {
            p2p.Resolve();
        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int) config.Port);
            nfm.Recieve("d:\\test\\files\\r\\testfile2.txt", ep);
        }
    }
}
