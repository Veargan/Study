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
    public partial class FormChangePass : Form
    {
        FormLogin FL;
        public FormChangePass(FormLogin FL)
        {
            InitializeComponent();
            this.FL = FL;
        }

        private void tbChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (FL.Checkinput(tbLogin1) && FL.Checkinput(tboldPas) && FL.Checkinput(tbnewPas))
                {
                    FL.cm.Connect(FL.pl);
                    FL.cm.ChangePas(tbLogin1.Text, tboldPas.Text, tbnewPas.Text);
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }        
    }
}
