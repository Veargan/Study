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
    public partial class GameXO : Form
    {
        NetworkStream stream;
        string name;
        public GameXO(NetworkStream stream, string name)
        {
            InitializeComponent();
            this.stream = stream;
            this.Text = name;
            this.name = name;

            DelFromList(name);

        }

        public void DelFromList(string name)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("del," + name);
            sw.Flush();
        }

        public void ShowForm()
        {
            this.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SendInfo("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SendInfo("0");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SendInfo("1");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SendInfo("2");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SendInfo("3");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SendInfo("4");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SendInfo("5");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SendInfo("7");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SendInfo("8");
        }

        public void SendInfo(string btnname)
        {
            if (BtnChek(btnname))
            {
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine("gamexo," + name + "," + btnname);
                sw.Flush();
            }
        }

        private bool BtnChek(string btnname)
        {
            var controls = this.Controls.Find("btn" + btnname, true);
            var btn = controls[0] as Button;
            if (btn.Text == "")
            {
                return true;
            }
            return false;
        }

        public void ReceiveGameData(string output)
        {
            string[] msg = output.Split(',');

            if (msg[1] == "turn")
            {
                if (msg[2] == "victory" || msg[2] == "fail" || msg[2] == "standoff")
                {
                    DialogResult dialogResult = MessageBox.Show(msg[2], name, MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Invoke(new Action(() => { this.Close(); }));
                    }
                    return;
                }

                string message = "btn" + msg[2];
                var controls = this.Controls.Find(message, true);
                var btn = controls[0] as Button;
                if (msg[2] != null)
                {
                    btn.Invoke(new Action(() => { btn.Text = msg[3]; }));
                }
            }

            if (msg[1] == "turnlabel")
            {
                if (msg[2] == "1")
                {
                    if (lb1_turner.IsHandleCreated)
                    {
                        lb1_turner.Invoke(new Action(() => { lb1_turner.Text = "Your Turn!"; }));
                    }
                }
                else if (msg[2] == "0")
                {
                    if (lb1_turner.IsHandleCreated)
                    {
                        lb1_turner.Invoke(new Action(() => { lb1_turner.Text = "Oppnents Turn!"; }));
                    }
                }
            }

        }

        private void GameXO_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("add," + name);
            sw.Flush();
        }
    }
}
