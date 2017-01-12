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
    public partial class ShapeTypeSelectorVector : UserControl
    {
        public ShapeTypeSelectorVector()
        {
            InitializeComponent();
            CB_ShapeType.SelectedIndex = 1;
        }

        public CanvasVector Canvas { get; set; }


        private void CB_ShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawingVector2DTool.ShapeTypeSelector(Canvas, CB_ShapeType.SelectedIndex);
        }

    }
}
