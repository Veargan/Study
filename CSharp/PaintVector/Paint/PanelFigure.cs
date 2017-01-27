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
    public partial class PanelFigure : UserControl
    {
        public XData data = null;
        public PanelFigure()
        {
            InitializeComponent();
        }

        private void bRect_Click(object sender, EventArgs e)
        {
            data.type = 1;
        }

        private void bEll_Click(object sender, EventArgs e)
        {
            data.type = 2;
        }

        private void bRound_Click(object sender, EventArgs e)
        {
            data.type = 3;
        }

        private void bLine_Click(object sender, EventArgs e)
        {
            data.type = 4;
        }

        private void bCurve_Click(object sender, EventArgs e)
        {
            data.type = 5;
        }
    }
}
