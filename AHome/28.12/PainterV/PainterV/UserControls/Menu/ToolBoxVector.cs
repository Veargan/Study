using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.Dialogs;

namespace PainterV.UserControls.Menu
{
    public partial class ToolBoxVector : UserControl
    {
        public ToolBoxVector()
        {
            InitializeComponent();
        }

        public ToolBoxVector(XCommand cmd) : this()
        {
            this.cmd = cmd;
            this.B_Color.Click += new EventHandler(cmd.aColor.Action);
            this.B_Width.Click += new EventHandler(cmd.aWidth.Action);
            this.B_ShapeType.Click += new EventHandler(cmd.aType.Action);
        }

        private XCommand cmd;

        private void B_SaveLoad_Click(object sender, EventArgs e)
        {
            IODialog dlg = new IODialog(cmd);
            dlg.ShowDialog();
            dlg.Dispose();
        }
    }
}
