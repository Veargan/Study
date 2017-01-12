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
    public partial class ToolBarVector : UserControl
    {
        public ToolBarVector()
        {
            InitializeComponent();
        }

        public ToolBarVector(XCommand cmd) : this()
        {
            this.cmd = cmd;
            this.ToolBar_Color.Click += new EventHandler(cmd.aColor.Action);
            this.ToolBar_PenWidth.Click += new EventHandler(cmd.aWidth.Action);
            this.ToolBar_ShapeType.Click += new EventHandler(cmd.aType.Action);
        }

        private XCommand cmd;

        private void ToolBar_SaveLoad_Click(object sender, EventArgs e)
        {
            IODialog dlg = new IODialog(cmd);
            dlg.ShowDialog();
            dlg.Dispose();
        }
    }
}
