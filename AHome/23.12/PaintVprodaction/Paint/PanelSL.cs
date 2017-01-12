using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ImageMagick;

namespace Paint
{
    public partial class PanelSL : UserControl
    {
        private XSaveLoad sl;
        public PanelSL()
        {
            InitializeComponent();
            sl = new XSaveLoad();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            sl.Load();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            sl.Save();
        }
    }
}
