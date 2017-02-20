using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class LoginForm : Form
    {
        ClientManager cm;
        PlayersList pl;
        public LoginForm()
        {
            InitializeComponent();
            cm = new ClientManager();
            pl = new PlayersList();
            tbLogin.MaxLength = 10;

        }

        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Please, enter your name."); 
            }
            else
            {
                cm.Connect(tbLogin.Text, pl);
                pl.Show();
                this.Hide();
            }            
        }
    }
}
