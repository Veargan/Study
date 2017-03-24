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
        API_Auth api;
        public FormChangePass(API_Auth api)
        {
            InitializeComponent();
            this.api = api;
        }

        private void tbChange_Click(object sender, EventArgs e)
        {
            api.ChangePass(tbLogin1.Text, tboldPas.Text, tbnewPas.Text);
        }        
    }
}
