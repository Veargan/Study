using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonFormDialog
{
    public partial class DeleteDialog : Form
    {
        public DeleteDialog()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            bOk.DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            bCancel.DialogResult = DialogResult.Cancel;
        }
    }
}