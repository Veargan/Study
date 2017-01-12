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
    public partial class FigurePanel : UserControl
    {
        public XData data = new XData();
        public FigurePanel()
        {
            InitializeComponent();
            combFigure.Items.Add("Rectangle");
            combFigure.Items.Add("Ellipse");
            combFigure.Items.Add("RoundRect");
            combFigure.Items.Add("Line");
            combFigure.Items.Add("Curve");
        }

        private void combFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.type = Convert.ToString(combFigure.SelectedItem);
        }
    }
}
