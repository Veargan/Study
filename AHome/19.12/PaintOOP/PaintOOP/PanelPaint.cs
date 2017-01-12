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
    public partial class PanelPaint : UserControl
    {
        public XData d = null;
        int x;
        int y;

        public PanelPaint()
        {
            InitializeComponent();
            d = new XData();
            BackColor = Color.WhiteSmoke;
        }

        private void PanelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void PanelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (d.type != 0)
            {
                return;
            }
            if (e.Button > 0)
            {
                Graphics g = this.CreateGraphics();
                g.DrawLine(new Pen(d.col, d.width), x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
            }
        }

        private void PanelPaint_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Pen pen = new Pen(d.col, d.width);
            switch (d.type)
            {
                case 1:
                    gr.DrawRectangle(pen, x, y, e.X - x, e.Y - y);
                    break;
                case 2:
                    break;
                case 3:
                    gr.DrawEllipse(pen, x, y, e.X - x, e.Y - y);
                    break;
                case 4:
                    gr.DrawLine(pen, x, y, e.X, e.Y);
                    break;
                default:
                    break;
            }
        }
    }
}
