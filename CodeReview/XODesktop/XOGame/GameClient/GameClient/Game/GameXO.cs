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
    public partial class GameXO : Form, IGame
    {
        NetworkStream stream;
        string name;
       
        public GameXO(NetworkStream stream, string name)
        {
            InitializeComponent();           
            this.stream = stream;
            this.Text = name;
            this.name = name;
            CheckForIllegalCrossThreadCalls = false;
            
        }

        public void ShowForm()
        {                   
                this.ShowDialog();
        }

        private void btnXO_Click(object sender, EventArgs e)
        {
            SendInfo((sender as Button).Tag.ToString());
        }       

        public void SendInfo(string btnname)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("games,gamexo," + name + "," + btnname);
            sw.Flush();
        }

        public void ReceiveGameData(string output)
        {
            string[] msg = output.Split(',');

            if (msg[1] == "victory")
            {
                MessageBox.Show( "Congratulations! " +name+" won!","Result");
                this.Close();
                return;
            }
            else if (msg[1] == "fail")
            {
                MessageBox.Show( "Sorry, " +name+" lost this game.", "Result");
                this.Close();
                return;
            }
            else if (msg[1] == "standoff")
            {
                MessageBox.Show("It's draw!", "Result");
                
                this.Close();
                return;
            }
            if(msg[1] == "yourturn")
            {               
                lb_turn.Text = "Choose the cell";
                return;
            }
            if (msg[1] == "notyourturn")
            {
                lb_turn.Invoke(new Action(() => { lb_turn.Text = "Not your turn"; }));
                return;
            }

            string message = "btn" + msg[1];
            var controls = this.Controls.Find(message, true);
            var btn = controls[0] as Button;
            if (msg[1] != null)
            {               
                btn.Text = msg[2];
                btn.Enabled = false;
            }
        }

        private void GameXO_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("games,gamexo," + name + "," +"StopGame");
            sw.Flush();
        }
    }
}
