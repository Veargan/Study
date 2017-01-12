using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.UserControls.VectorElements;

namespace PainterV.UserControls.Menu
{
    public partial class StatusBarVector : UserControl
    {
        public StatusBarVector()
        {
            InitializeComponent();
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            CanvasVector Canvas = sender as CanvasVector;
            StatusBar_X.Text = "X:" + e.X.ToString();
            StatusBar_Y.Text = "Y:" + e.Y.ToString();
            if (Canvas.StackControl != null)
            {
                StatusBar_Color.Text = Canvas.StackControl.data.LineColor.ToString();
                StatusBar_PenWidth.Text = Canvas.StackControl.data.LineWidth.ToString();
                StatusBar_ShapeType.Text = Canvas.StackControl.data.Type.ToString();
            }
        }
        
    }
}
