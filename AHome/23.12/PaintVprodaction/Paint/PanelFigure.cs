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
            data = new XData();
        }

        private void FigChoose(object sender, EventArgs e)
        {
            data.type = Convert.ToInt32((string)((Button)sender).Tag);
        }
    }
}
