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
    public partial class PanelPaint : UserControl
    {
        public XData data = null;
        int x;
        int y;
        public PanelPaint()
        {
            InitializeComponent();
            BackColor = Color.White;
        }

        private void PanelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void PanelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (data.type != 5)
            {
                return;
            }

            Pen pen = new Pen(data.color, data.width);
            if (e.Button == MouseButtons.Left)
            {
                Graphics gr = CreateGraphics();

                gr.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;

            }
        }

        private void PanelPaint_MouseUp(object sender, MouseEventArgs e)
        {
            switch (data.type)
            {
                case 1:
                    Rect r = new Rect(x, y, e.X - x, e.Y - y, data);
                    Controls.Add(r);
                    r.Draw();
                    break;
                case 2:
                    Ell el = new Ell(x, y, e.X - x, e.Y - y, data);
                    Controls.Add(el);
                    el.Draw();
                    break;
                //case 3:
                //    break;
                case 4:
                    Line l = new Line(x, y, e.X, e.Y, data);
                    Controls.Add(l);
                    l.Draw();
                    break;
                default:
                    break;
            }

            
        }
    }
}
