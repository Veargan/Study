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
        FormLogin FL;
        public FormRestorePassword(FormLogin FL)
        {
            InitializeComponent();
            this.FL = FL;
        }

        private void tbRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (FL.Checkinput(tbLogin2) && FL.Checkinput(tbEmail))
                {
                    FL.cm.Connect(FL.pl);
                    FL.cm.Restore(tbLogin2.Text, tbEmail.Text);
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }
    }
}
