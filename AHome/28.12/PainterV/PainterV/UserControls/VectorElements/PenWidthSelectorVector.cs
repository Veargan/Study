using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.UserControls.VectorElements
{
    public partial class PenWidthSelectorVector : UserControl
    {
        public PenWidthSelectorVector()
        {
            InitializeComponent();
        }

        public CanvasVector Canvas { get; set; }

        private void NUD_Width_ValueChanged(object sender, EventArgs e)
        {
            DrawingVector2DTool.PenWidthSelector(Canvas, Convert.ToSingle(NUD_Width.Value));
        }
    }
}
