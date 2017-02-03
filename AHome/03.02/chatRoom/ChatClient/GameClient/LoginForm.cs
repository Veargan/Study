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
        public LoginForm()
        {
            InitializeComponent();
            cm = new ClientManager();
            this.Show();
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            cm.Connect(tbLogin.Text);
            this.Dispose();
        }
    }
}
