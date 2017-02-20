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
        private ClientManager cm;

        public LoginForm()
        {
            InitializeComponent();
            cm = new ClientManager();
            this.Show();
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Don't forget to put your username into text area!");
                return;
            }
            cm.Connect(tbLogin.Text);
            this.Hide();
        }
    }
}