using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOClient.UI
{
    public partial class NameDialog : Form
    {
        public NameDialog()
        {
            InitializeComponent();
        }

        public string Nickname { get; private set; }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Nickname = TB_Nickname.Text;
        }
    }
}
