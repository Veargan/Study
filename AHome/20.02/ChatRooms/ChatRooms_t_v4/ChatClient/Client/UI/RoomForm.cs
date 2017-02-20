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
        RoomManager rm;
        string name;
        private Button btnActiveConnect; //

        public RoomForm(string name, RoomManager rm, Button btnActiveConnect) //
        {
            InitializeComponent();
            Text = name;
            this.name = name;
            this.rm = rm;
            this.btnActiveConnect = btnActiveConnect;
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
            /*HERE*/
            var delActive = new Action(() => { btnActiveConnect.Enabled = true; });
            if (btnActiveConnect.InvokeRequired)
            {
                btnActiveConnect.Invoke(delActive);
            }
            else
            {
                delActive();
            }
            this.Close();
            //this.Dispose();
            /*HERE*/
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*HERE*/
            var delActive = new Action(() => { btnActiveConnect.Enabled = true; });
            if (btnActiveConnect.InvokeRequired)
            {
                btnActiveConnect.Invoke(delActive);
            }
            else
            {
                delActive();
            }
            rm.Send("exit", name, "");
            this.Close();
            //this.Dispose();
            /*HERE*/
        }
    }
}