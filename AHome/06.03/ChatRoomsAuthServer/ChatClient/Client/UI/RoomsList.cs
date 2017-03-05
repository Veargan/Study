using Client.UI;
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

namespace Client
{
    public partial class RoomsList : Form
    {
        public RoomManager rm;
        public string name;
        private NetworkStream netStream;
        private bool closed;
        private ClientManager cm;

        public RoomsList(ClientManager cm)
        {
            InitializeComponent();
            this.cm = cm;
            closed = false;
            CheckForIllegalCrossThreadCalls = false;
            cm.get_netStream();
        }

        public void set_parameter(string name, NetworkStream netStream)
        {
            if (name == "admin")
            {
                labelRoomName.Visible = true;
                btnBan.Visible = true;
                btnUnban.Visible = true;
                tb_banTime.Visible = true;
            }
            this.name = name;
            lbName.Text = name;
            this.netStream = netStream;
            this.Text = "RoomList: " + name;
            
            rm = new RoomManager(netStream);
        }

        public void NewNotification(string name)
        {
            var notif = new Action(() => { lbRooms.Items[rm.GetIndex(name)] = name + ":" + rm.GetNotification(name); });
            if (lbRooms.InvokeRequired)
            {
                lbRooms.Invoke(notif);
            }
            else
            {
                notif();
            }
        }

        public void AddList(string[] items)
        {
            var clear = new Action(() => { lbRooms.Items.Clear(); });
            if (lbRooms.InvokeRequired)
            {
                lbRooms.Invoke(clear);
                for (int i = 1; i < items.Length; i++)
                {
                    rm.ToRoom(items[i]);
                    if (items[i] != "")
                        lbRooms.Invoke(new Action(() => { lbRooms.Items.Add(items[i]); }));
                }
            }
            else
            {
                clear();
            }
        }

        public void AddClient(string[] items)
        {
            var clear = new Action(() => { lbClients.Items.Clear(); });
            if (lbClients.InvokeRequired)
            {
                lbClients.Invoke(clear);
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i] != "admin")
                    {
                        lbClients.Invoke(new Action(() => { lbClients.Items.Add(items[i]); }));
                    }
                }
            }
            else
            {
                clear();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        { 
            if (tbRoomName.Text == "")
            {
                MessageBox.Show("Don't forget to put room name into text area!");
                return;
            }

            foreach (var item in lbRooms.Items)
            {
                string[] checkItem = item.ToString().Split(':');
                if (checkItem[0] == tbRoomName.Text)
                {
                    MessageBox.Show("Room with that name already exists. Choose another one!");
                    tbRoomName.Text = "";
                    return;
                }
            }
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("new" + "^" + tbRoomName.Text);
            sw.Flush();

            tbRoomName.Text = "";
        }

        private void RoomsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closed)
            {
                StreamWriter sw = new StreamWriter(netStream);
                sw.WriteLine("logout");
                sw.Flush();
                Thread.Sleep(100);
                Environment.Exit(0);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ClosedLobby();
        }

        private void ClosedLobby()
        {
            closed = true;
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("logout");
            sw.Flush();

            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {   
            if (lbRooms.SelectedItem == null)
            {
                MessageBox.Show("Select the room to which you would like to connect");
                return;
            }
            btnConnect.Enabled = false; 
            string[] items = lbRooms.SelectedItem.ToString().Split(':');
            rm.Connect(items[0], btnConnect); 
            
            lbRooms.Items[rm.GetIndex(items[0])] = items[0];
        }

        private void btnPmsg_Click(object sender, EventArgs e)
        {
            if (tbPrivateMsg.Text == "")
            {
                MessageBox.Show("Don't forget to put your message into text area!");
                return;
            }
            if (lbClients.SelectedItem == null)
            {
                MessageBox.Show("Select the user to whom you would like to send a private message");
                return;
            }
            StreamWriter sw = new StreamWriter(netStream);
            string whom = lbClients.SelectedItem.ToString();
            sw.WriteLine("pmessage^" + whom + "^" + tbPrivateMsg.Text);
            sw.Flush();

            string path = @"C:\Debug\Files\" + name + "." + whom + ".txt";

            using (StreamWriter file = File.AppendText(path))
            {
                file.Write(name + ":" + tbPrivateMsg.Text + "~");
                file.Flush();
                file.Close();
            }

            tbPrivateMsg.Text = "";
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (lbClients.SelectedItem == null)
            {
                MessageBox.Show("Select a user to ban!");
                return;
            }
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("ban^" + tb_banTime.Text + "^" + lbClients.SelectedItem.ToString());
            sw.Flush();

            tbPrivateMsg.Text = "";
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            if (lbClients.SelectedItem == null)
            {
                MessageBox.Show("Select a user to unban!");
                return;
            }
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("unban^" + lbClients.SelectedItem.ToString());
            sw.Flush();
        }

        private void tb_banTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            if (lbRooms.SelectedItem == null)
            {
                MessageBox.Show("Select a room from which you wish to unsubscribe!");
                return;
            }
            string[] roomName = lbRooms.SelectedItem.ToString().Split(':');
            rm.Send("unsubscribe", roomName[0], "");

            lbRooms.Items[lbRooms.SelectedIndex] = roomName[0];
        }

        private void bChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm(name, netStream, cm);
            cpf.Show();
        }
    }
}