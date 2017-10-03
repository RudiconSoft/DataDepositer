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
    public partial class ShowPeersForm : Form
    {
        public ShowPeersForm()
        {
            InitializeComponent();
            InitPeers();
        }

        private void InitPeers()
        {
            foreach (var peer in Vault.Peers)
            {
                lbPeers.Items.Add(peer.Comment);
            }
            
        }

        private void lbPeers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
