using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UI
{
    public partial class ChangePasswordForm : Form
    {
        private NetworkStream netStream;
        private ClientManager cm;
        private string name;

        public ChangePasswordForm(string name, NetworkStream netStream, ClientManager cm)
        {
            InitializeComponent();
            this.name = name;
            this.netStream = netStream;
            this.cm = cm;
        }

        private void tbChange_Click(object sender, EventArgs e)
        {

            if ((tboldPas.Text == "") || (tbnewPas.Text == ""))
            {
                MessageBox.Show("Don't forget to put your old pass and new pass into text area!");
                return;
            }

            cm.SendChangePass("changepass^" + name + "^" + tboldPas.Text + "^" + tbnewPas.Text);
            this.Hide();
        }
    }
}
