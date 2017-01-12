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
    public partial class ColorPanel : UserControl
    {
        public XData data = new XData();
        public ColorPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog ColorD = new ColorDialog();
            ColorD.AllowFullOpen = true;
            if (ColorD.ShowDialog() == DialogResult.OK)
            {
                data.color = ColorD.Color;
            }  
        }
    }
}
