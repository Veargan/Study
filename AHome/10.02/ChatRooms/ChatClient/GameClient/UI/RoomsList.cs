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

namespace GameClient
{
    public partial class RoomsList : Form
    {
        public string name;
        public NetworkStream stream;
        public RoomManager rm;
        public delegate void listDel(string[] ps);
        public RoomsList(string name, NetworkStream netStream)
        {
            InitializeComponent();
            rm = new RoomManager(netStream);
            this.name = name;
            this.stream = netStream;
            this.Show();
            this.Text = "RoomList: " + name;
            if (name == "admin")
            {
                btnBan.Visible = true;
                btnUnban.Visible = true;
                tb_banTime.Visible = true;
            }
        }
        
        public void NewNotification(string name)
        {
            lbRooms.Invoke(new Action(() => { lbRooms.Items[rm.GetIndex(name)] = name + ":" + rm.GetNotification(name); }));
        }

        public void AddList(string[] items)
        {
            if (name.Equals("admin"))
            {
                rm.AddAdmin(items);
            }

            lbRooms.Invoke(new Action(() => { lbRooms.Items.Clear(); }));
            for (int i = 1; i < items.Length; i++)
            {                
                rm.ToRoom(items[i]);
                if(items[i] != "")
                    lbRooms.Invoke(new Action(() => { lbRooms.Items.Add(items[i]); }));
            }
        }

        public void AddClient(string[] items)
        {
            lbClients.Invoke(new Action(() => { lbClients.Items.Clear(); }));
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i] != "admin")
                {
                    lbClients.Invoke(new Action(() => { lbClients.Items.Add(items[i]); }));
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        { 
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("new" + "," + tbRoomName.Text);
            sw.Flush();

            tbRoomName.Text = "";
        }
        

        private void RoomList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {   
            string[] items = lbRooms.SelectedItem.ToString().Split(':');
            rm.Connect(items[0]); 
            
            lbRooms.Items[rm.GetIndex(items[0])] = items[0];
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("logout");
            sw.Flush();

            Dispose();
            LoginForm lf = new LoginForm();
        }

        private void btnPmsg_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            string whom = lbClients.SelectedItem.ToString();
            sw.WriteLine("pmessage," + whom + "," + tbPrivateMsg.Text);
            sw.Flush();

            string path = @"F:\" + name + "." + whom + ".txt";

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
            StreamWriter sw = new StreamWriter(stream);
            try
            {
                sw.WriteLine("ban," + tb_banTime.Text + "," + lbClients.SelectedItem.ToString());
                sw.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Choose a user to ban");
                return;
            }
            
            string who = lbClients.SelectedItem.ToString();
            sw.WriteLine("pmessage," + who + "," + "you have been banned!");
            sw.Flush();

            tbPrivateMsg.Text = "";
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("unban," + lbClients.SelectedItem.ToString());
            sw.Flush();

            string who = lbClients.SelectedItem.ToString();
            sw.WriteLine("pmessage," + who + "," + "you have been unbanned!");
            sw.Flush();
        }

    }
}
