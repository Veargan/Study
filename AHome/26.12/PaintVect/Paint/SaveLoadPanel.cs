using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class SaveLoadPanel : UserControl
    {
        public XData data = null;
        public SaveLoadPanel()
        {
            InitializeComponent();
            data = new XData();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            data.bmp.Save(data.path, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void butLoad_Click(object sender, EventArgs e)
        {
            data.bmp = new Bitmap(Image.FromFile(data.path));
        }
    }
}
