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
    public partial class AskRequest : Form
    {
        string player1;
        string player2;
        string gameid;
        NetworkStream stream;
        public AskRequest()
        {
            InitializeComponent();
        }

        public AskRequest(string player1, string player2, string gameid, NetworkStream stream)
        {
            InitializeComponent();           
            this.player1 = player1;
            this.player2 = player2;
            this.gameid = gameid;
            lRequest.Text = "Invite from: " + player1 + " Game:" + gameid;
            this.stream = stream;
        }

        public void ShowForm()
        {
            this.ShowDialog();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Ask(player2, player1, gameid, "Yes");
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Ask(player2, player1, gameid, "No");
            this.Close();
        }

        public void Ask(string player1, string player2, string gameid, string ask)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("ask" + "," + ask + "," + player1 + "," + player2 + "," + gameid);
            sw.Flush();
        }
    }
}
