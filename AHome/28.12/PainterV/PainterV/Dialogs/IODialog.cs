using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.UserControls.VectorElements;
using Painter;
using PainterV;

namespace Paint.Dialogs
{
    public partial class IODialog : Form
    {
        public IODialog(XCommand cmd)
        {
            InitializeComponent();
            this.buttonSave.Click += new EventHandler(cmd.aSave.Action);
            this.buttonLoad.Click += new EventHandler(cmd.aLoad.Action);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
