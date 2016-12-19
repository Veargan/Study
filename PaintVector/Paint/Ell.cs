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
    public partial class Ell : UserControl
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public XData data = null;
        public Point loc;
        public bool onFocused = false;

        public Ell()
        {
            InitializeComponent();
        }

        public Ell(int xx, int yy, int w, int h, XData d)
        {
            InitializeComponent();

            data = d;
            x = xx;
            y = yy;
            width = w;
            height = h;

            Height = height + data.width;
            Width = width + data.width;

            loc = new Point(x - data.width, y - data.width);
            Location = loc;
        }
        public void Draw()
        {
            Pen pen = new Pen(data.color, data.width);
            Graphics gr = CreateGraphics();
            gr.DrawEllipse(pen, data.width / 2, data.width / 2, width, height);
        }

        private void Ell_MouseDown(object sender, MouseEventArgs e)
        {
            onFocused = true;
        }

        private void Ell_MouseMove(object sender, MouseEventArgs e)
        {
            if (!onFocused)
            {
                return;
            }

            Control c = sender as Control;
            c.Location = this.PointToClient(Control.MousePosition);
            Draw();
        }

        private void Ell_MouseUp(object sender, MouseEventArgs e)
        {
            onFocused = false;
        }
    }
}
