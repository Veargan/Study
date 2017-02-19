using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class RoomForm : Form
    {
        RoomManager rm;
        string name;
        public RoomForm(string name, RoomManager rm)
        {
            InitializeComponent();
            Text = name;
            this.name = name;
            this.rm = rm;
        }

        public void GetMessage(string message)
        {
            tbChat.Invoke(new Action(() => { tbChat.Text += message + "\r\n"; }));
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbMessage.Text == "")
            {
                MessageBox.Show("Don't forget to put message into text area!");
                return;
            }
            rm.Send("message", name, tbMessage.Text);
            tbMessage.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            rm.Send("exit", name, "");
            this.Dispose();
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rm.Send("exit", name, "");
            this.Dispose();
        }
    }
}
