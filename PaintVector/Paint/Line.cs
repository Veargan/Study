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
    public partial class Line : UserControl
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public XData data = null;
        public Point loc;
        private bool onFocused = false;
        public Line()
        {
            InitializeComponent();
        }
        public Line(int xx1, int yy1, int xx2, int yy2, XData d)
        {
            InitializeComponent();

            data = d;
            x1 = xx1;
            y1 = yy1;
            x2 = xx2;
            y2 = yy2;
            
            if (y1 < y2 && x1 < x2)
            {
                Height = y2 - y1;
                Width = x2 - x1;
                loc = new Point(x1, y1);
            }
            else if(y1 < y2 && x1 > x2)
            {
                Height = y2 - y1;
                Width = x1 - x2;
                loc = new Point(x2, y1);
            }
            else if (y1 > y2 && x1 > x2)
            {
                Height = y1 - y2;
                Width = x1 - x2;
                loc = new Point(x2, y2);
            }
            else if (y1 > y2 && x1 < x2)
            {
                Height = y1 - y2;
                Width = x2 - x1;
                loc = new Point(x2 - Width, y1 - Height);
            }
            Location = loc;
        }
        public void Draw()
        {
            Pen pen = new Pen(data.color, data.width);
            Graphics gr = CreateGraphics();
            if (y1 < y2 && x1 < x2)
            {
                gr.DrawLine(pen, data.width / 2, data.width / 2, Width, Height);
            }
            else if (y1 < y2 && x1 > x2)
            {
                gr.DrawLine(pen, Width, data.width / 2, data.width / 2, Height);
            }
            else if (y1 > y2 && x1 > x2)
            {
                gr.DrawLine(pen, data.width / 2, data.width / 2, Width, Height);
            }
            else if (y1 > y2 && x1 < x2)
            {
                gr.DrawLine(pen, Width, data.width / 2, data.width / 2, Height);
            }
            
        }

        private void Line_MouseDown(object sender, MouseEventArgs e)
        {
            onFocused = true;
        }

        private void Line_MouseMove(object sender, MouseEventArgs e)
        {
            if (!onFocused)
            {
                return;
            }

            Control c = sender as Control;
            c.Location = this.PointToClient(Control.MousePosition);
            Draw();
        }

        private void Line_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
