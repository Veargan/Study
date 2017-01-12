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
    public partial class FormatPanel : UserControl
    {
        XData data = new XData();
        public FormatPanel()
        {
            InitializeComponent();
            combFormat.Items.Add("PNG");
            combFormat.Items.Add("Jpeg");
            combFormat.Items.Add("Gif");
            combFormat.Items.Add("Bmp");
            combFormat.Items.Add("Tiff");
            combFormat.Items.Add("Emf");
        }

        private void combFormat_SelectedIndexChanged(object sender, EventArgs e)
        {         
            data.format = combFormat.SelectedIndex;            
        }

    }
}
