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
    public partial class ColorSelectorVector : UserControl
    {
        public ColorSelectorVector()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return B_ColorSelector.Text;
            }
            set
            {
                B_ColorSelector.Text = value;
            }
        }
        public CanvasVector Canvas { get; set; }

        private void B_ColorSelector_Click(object sender, EventArgs e)
        {
            DrawingVector2DTool.ColorSelector(Canvas);
        }
    }
}
