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
    public partial class FormLogin : Form
    {
        API_Auth api;
        public FormLogin(API_Auth api)
        {         
            InitializeComponent();
            this.api = api;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            api.btnLogin(tbLogin.Text, tbPassword.Text, (sender as Button).Tag.ToString());
        }        

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void btn_externalAuth_Click(object sender, EventArgs e)
        {
            api.btnExternalAuth((sender as Button).Tag.ToString());
        }

        private void ChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            api.bntChangePass();
        }

        private void RestorePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            api.bntRestorePass();
        }
    }
}
