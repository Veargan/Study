using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonClient
{
    public partial class MainForm : Form
    {
        ConnectManager cm;
        public MainForm()
        {
            InitializeComponent();
            cm = new ConnectManager();
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            personGrid.DataSource = cm.SendData("Read", dbList.SelectedItem.ToString());
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            cm.SendData("Create", dbList.SelectedItem.ToString(), tbId.Text, tbName.Text, tbSurname.Text, tbAge.Text);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            cm.SendData("Update", dbList.SelectedItem.ToString(), tbId.Text, tbName.Text, tbSurname.Text, tbAge.Text);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            cm.SendData("Delete", dbList.SelectedItem.ToString(), tbId.Text, tbName.Text, tbSurname.Text, tbAge.Text);
        }
    }
}
