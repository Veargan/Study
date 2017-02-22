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
    public partial class PlayersList : Form
    {
        public string name;
        public NetworkStream stream;
        public delegate void listDel(string[] ps);
        public PlayersList()
        {
            InitializeComponent();
            cbGame.SelectedIndex = 0;
            CheckForIllegalCrossThreadCalls = false;
        }
        

        public void AddList(string[] items)
        {
           
            lbPlayers.Items.Clear();
            for (int i = 1; i < items.Length; i++)
            {
                string[] statuscont = items[i].Split('#');
                if(statuscont[1]!="1")
                lbPlayers.Items.Add(statuscont[0]); 
            }
        }
        public bool CheckGameStatus(string name)
        {
            if (lbPlayers.Items.Count != 0)
            {
                if (lbPlayers.Items.Contains(name))
                    return true;
                else return false;
            }
            else return false;
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            inviteClick();
        }  
        public void inviteClick()
        {
            if (lbPlayers.SelectedItem != null)
            {
                SendInvite(name, lbPlayers.SelectedItem.ToString(), cbGame.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please choose player firstly");
            }
        }    

        public void SendInvite(string player1, string player2, string gameid)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("lobby,invite" + "," + player1 + "," + player2 + "," + gameid);
            sw.Flush();
            Thread.Sleep(100);
        }

        private void PlayersList_FormClosed(object sender, FormClosedEventArgs e)
        {
         
            
          
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("lobby,exit" + "," + lb_name.Text);
            sw.Flush();
            Environment.Exit(0);         
        }
        

        private void RefreshPlayers_Click(object sender, EventArgs e)
        {
            RefreshPlayer();
        }
        public void RefreshPlayer()
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("list" + "," + "");
            sw.Flush();
            Thread.Sleep(100);
        }

        private void PlayersList_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("games,gamexo," + name + "," + "StopGame");
            sw.Flush();
        }
    }
}
