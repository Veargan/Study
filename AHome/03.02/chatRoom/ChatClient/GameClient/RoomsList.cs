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
        }
        
        public void NewNotification(string name)
        {
            lbRooms.Invoke(new Action(() => { lbRooms.Items[rm.GetIndex(name)] = name + ":" + rm.GetNotification(name); }));
        }

        public void AddList(string[] items)
        {
            lbRooms.Invoke(new Action(() => { lbRooms.Items.Clear(); }));
            for (int i = 1; i < items.Length; i++)
            {
                lbRooms.Invoke(new Action(() => { lbRooms.Items.Add(items[i]); }));
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
    }
}
