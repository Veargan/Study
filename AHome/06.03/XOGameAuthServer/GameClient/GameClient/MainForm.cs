using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class MainForm : Form
    {
        ClientManager cm;
        PlayersList pl;
        public MainForm()
        {         
            InitializeComponent();
            cm = new ClientManager();
            pl = new PlayersList();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    LoginClick();
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Checkinput(tbLogin) && Checkinput(tbPassword))
                    {
                        //cm.Connect(tbLogin.Text, tbPassword.Text, pl, );
                        cm.Connect(pl);
                        Thread.Sleep(500);
                        cm.SendLogin(tbLogin.Text, tbPassword.Text, (sender as Button).Tag.ToString());
                        Thread.Sleep(500);
                        if (!(pl.lb_name.Text == "label1"))
                        {
                            pl.Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Invalid Login or pass or you are already in the game");
                    }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        public bool Checkinput(TextBox text)
        {
           
            if (text.Text == "")
            {
                MessageBox.Show("Empty field!");
                return false;
            }
            if (!(Regex.IsMatch(text.Text, @"^[a-zA-Z0-9]+$")))
            {
                if (text.Name == "tbEmail")
                    return true;
                MessageBox.Show("Incorrect symbols!");
                text.Clear();
                return false;
            }
            else if (text.Text.Length > 20)
            {
                if (text.Name == "tbEmail")
                    return true;
                MessageBox.Show("Login and password must be shorter than 20 symbols1");
                text.Clear();
                return false;
            }
            else return true;
        }

        private void tbChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (Checkinput(tbLogin1) && Checkinput(tboldPas) && Checkinput(tbnewPas))
                {
                    cm.Connect(pl);
                    cm.ChangePas(tbLogin1.Text, tboldPas.Text, tbnewPas.Text);
                }                  
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (Checkinput(tbLogin2) && Checkinput(tbEmail))
                {
                    cm.Connect(pl);
                    cm.Restore(tbLogin2.Text, tbEmail.Text);
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        private void btlogout_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void btn_externalAuth_Click(object sender, EventArgs e)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Auth((sender as Button).Tag.ToString());
            string name = auth.Tr(info[0]);

            cm.Connect(pl);
            Thread.Sleep(500);
            cm.SendLogin(info[0], info[1], (sender as Button).Tag.ToString());
            Thread.Sleep(500);
        }
    }
}
