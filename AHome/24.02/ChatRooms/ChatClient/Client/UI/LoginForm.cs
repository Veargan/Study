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
        ClientManager cm;
        RoomsList rm;

        public LoginForm()
        {
            InitializeComponent();
            cm = new ClientManager();
            rm = new RoomsList();
            cm.roomsList = rm;
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "" || tbPass.Text == "")
            {
                MessageBox.Show("Don't forget to put your username and password into text area!");
                return;
            }
            cm.Connect(tbLogin.Text, tbPass.Text, this);
            rm.set_parameter(tbLogin.Text, cm.get_netStream());
            tbLogin.Text = "";
            tbPass.Text = "";
            this.Hide();
        }
    }
}
