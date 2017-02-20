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

namespace Client
{
    public partial class RoomForm : Form
    {
        private RoomManager rm;
        private string name;
        private Button btnActiveConnect; 

        public RoomForm(string name, RoomManager rm, Button btnActiveConnect) 
        {
            InitializeComponent();
            Text = name;
            this.name = name;
            this.rm = rm;
            this.btnActiveConnect = btnActiveConnect;
        }

        public void GetMessage(string message)
        {
            var msg = new Action(() => { tbChat.Text += message + "\r\n"; });
            if (tbChat.InvokeRequired)
            {
                tbChat.Invoke(msg);
            }
            else
            {
                msg();
            }
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
            var active = new Action(() => { btnActiveConnect.Enabled = true; });
            if (btnActiveConnect.InvokeRequired)
            {
                btnActiveConnect.Invoke(active);
            }
            else
            {
                active();
            }
            rm.Send("exit", name, "");
            this.Close();
        }

        private void RoomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var active = new Action(() => { btnActiveConnect.Enabled = true; });
            if (btnActiveConnect.InvokeRequired)
            {
                btnActiveConnect.Invoke(active);
            }
            else
            {
                active();
            }
            rm.Send("exit", name, "");
        }
    }
}