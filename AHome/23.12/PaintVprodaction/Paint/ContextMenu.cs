using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class ContextMenu : UserControl
    {
        public XData data;
        XSaveLoad xsl;
        public ContextMenu()
        {
            InitializeComponent();
            xsl = new XSaveLoad();
            data = new XData();
        }
        public void cmShow(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
        }

        private void cmSave_Click(object sender, EventArgs e)
        {
            xsl.Save();
        }

        private void cmLoad_Click(object sender, EventArgs e)
        {
            xsl.Load();
        }

        private void cmWidth(object sender, EventArgs e)
        {
            data.width = Convert.ToInt32((string)((ToolStripMenuItem)sender).Tag);
        }

        private void cmType(object sender, EventArgs e)
        {
            data.type = Convert.ToInt32((string)((ToolStripMenuItem)sender).Tag);
        }

        private void cmColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            data.color = cd.Color;
        }
    }
}
