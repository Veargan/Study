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
    public partial class PanelColor : UserControl
    {
        public XData data = null;
        public PanelColor()
        {
            InitializeComponent();
        }

        private void bRed_Click(object sender, EventArgs e)
        {
            data.color = Color.OrangeRed;
        }

        private void bBlue_Click(object sender, EventArgs e)
        {
            data.color = Color.BlueViolet;
        }

        private void bGreen_Click(object sender, EventArgs e)
        {
            data.color = Color.ForestGreen;
        }
    }
}
