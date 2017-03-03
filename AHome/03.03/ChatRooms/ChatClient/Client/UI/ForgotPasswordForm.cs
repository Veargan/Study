using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UI
{
    public partial class ForgotPasswordForm : Form
    {
        private LoginForm lf;

        public ForgotPasswordForm(LoginForm lf)
        {
            InitializeComponent();
            this.lf = lf;
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            if ((tbLogin.Text != "") && (tbEmail.Text != ""))
            {
                lf.cm.Send("restore^" + tbLogin.Text + "^" + tbEmail.Text);
                lf.Show();
                Dispose();
            }
        }
    }
}
