using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class Menu : UserControl
    {
        XSaveLoad xsl;
        public XData data;
        public Menu()
        {
            InitializeComponent();
            xsl = new XSaveLoad();
            data = new XData();
        }

        private void mItemSave_Click(object sender, EventArgs e)
        {
            xsl.Save();
        }

        private void mItemLoad_Click(object sender, EventArgs e)
        {
            xsl.Load();
        }

        private void mChooseType(object sender, EventArgs e)
        {
            data.type = Convert.ToInt32((string)((ToolStripMenuItem)sender).Tag);
        }

        private void mChooseWidth(object sender, EventArgs e)
        {
            data.width = Convert.ToInt32((string)((ToolStripMenuItem)sender).Tag);
        }

        private void mItemColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            data.color = cd.Color;
        }
    }
}
