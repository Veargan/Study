using Client.Api;
using Client.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        public ClientManager cm;
        public RoomsList rl;

        public LoginForm()
        {
            InitializeComponent();
            cm = new ClientManager();
            rl = new RoomsList(cm);
            cm.roomsList = rl;
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbLogin.Text == "" || tbPass.Text == "")
                {
                    MessageBox.Show("Don't forget to put your username and password into text area!");
                    return;
                }
           
                cm.Connect(tbLogin.Text, tbPass.Text, this, "auth");
                rl.set_parameter(tbLogin.Text, cm.get_netStream());
                rl.Show();

                tbLogin.Text = "";
                tbPass.Text = "";
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        private void bRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbLogin.Text == "" || tbPass.Text == "")
                {
                    MessageBox.Show("Don't forget to put your username and password into text area!");
                    return;
                }

                cm.Connect(tbLogin.Text, tbPass.Text, this, "reg");
                rl.set_parameter(tbLogin.Text, cm.get_netStream());
                rl.Show();

                tbLogin.Text = "";
                tbPass.Text = "";
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        private void bForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                ForgotPasswordForm fpf = new ForgotPasswordForm(this);
                fpf.Show();

                tbLogin.Text = "";
                tbPass.Text = "";
                this.Hide();
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }

        private void btn_facebook_Click(object sender, EventArgs e)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Facebook_Auth();
            string name = info[0];
            string userid = info[1];
            cm.Connect(name, userid, this, "authfb");
            rl.set_parameter(name, cm.get_netStream());
            rl.Show();
        }

        private void btn_google_Click(object sender, EventArgs e)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Google_Auth();
            string name = info[0];
            string userid = info[1];
            cm.Connect(name, userid, this, "authgl");
            rl.set_parameter(name, cm.get_netStream());
            rl.Show();
        }
    }
}
