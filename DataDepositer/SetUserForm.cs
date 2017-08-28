/**
 * RuDiCon Soft (c) 2017
 * 
 * Set User Form - form for set up UserName and password (keys for AES256 encrypt/decrypt)
 * 
 */

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
    public partial class SetUserForm : Form
    {

        public String userName = "USER NOT DEFINE";
        public String password = "";

        public SetUserForm()
        {
            InitializeComponent();
        }

        private void setUserForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
