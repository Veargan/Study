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
    public partial class FormRestorePassword : Form
    {
        API_Auth api;
        public FormRestorePassword(API_Auth api)
        {
            InitializeComponent();
            this.api = api;
        }

        private void tbRestore_Click(object sender, EventArgs e)
        {
            api.RestorePass(tbLogin2.Text, tbEmail.Text);
        }
    }
}
