using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class PanelColor : UserControl
    {
        public XData data = null;
        public PanelColor()
        {
            InitializeComponent();
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            data.color = cd.Color;
        }
    }
}
