using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintOOP
{
    public partial class PanelColor : UserControl
    {
        public XData d = null;
        public PanelColor()
        {
            InitializeComponent();
            BackColor = Color.WhiteSmoke;
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                d.col = cd.Color;
            }
        }
    }
}
