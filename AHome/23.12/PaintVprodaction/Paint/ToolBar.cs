using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class ToolBar : UserControl
    {
        XSaveLoad xsl;
        public XData data;
        public ToolBar()
        {
            InitializeComponent();
            xsl = new XSaveLoad();
            data = new XData();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            xsl.Save();
        }

        private void toolLoad_Click(object sender, EventArgs e)
        {
            xsl.Load();
        }

        private void toolCol_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            data.color = cd.Color;
        }
    }
}
