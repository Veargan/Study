using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RisovalkaTrue
{
    public partial class Figure : UserControl
    {

        public int x;
        public int y;
        public int width;
        public int height;
        public xData data = null;
        public Point loc;

        private bool onFocused = false;

        public Figure()
        {
            InitializeComponent();
        }

        public Figures GetMemento()
        {
            return new Figures(x,y,width,height,data.width,data.type, data.color.ToArgb());
        }
        public void SetMemento(Figures f)
        {
            this.Location = new Point(f.x - f.dwidth,f.y - f.dwidth);
            this.ClientSize = new Size(f.width + f.dwidth,f.height + f.dwidth);
            data = new xData();
            data.width = f.dwidth;
            data.type = f.dtype;
            data.color = Color.FromArgb(f.dcolor);
            for (int i = 1; i <= 8; i++)
            {
                Controls.Add(new SizePanel(i, Height, Width));
            }
        }

        public Figure(int xx, int yy, int w, int h, xData d,XCommand cmd)
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
            for(int i = 1; i <= 8;i++)
            {
                Controls.Add(new SizePanel(i, Height, Width));
            }
            this.MouseMove += cmd.aStatus.Action;
            this.MouseDown += cmd.aDataStatus.Action;
            this.GotFocus += GotF;
            this.LostFocus += LostF;
            this.KeyDown += KeyP;
            SelfRef = this;
        }

        public static Figure SelfRef
        {
            set;get;
        }


        public void KeyP(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
            {
                PaintPanel.SelfRef.fig = new Figure(0, 0, width, height, data, PaintPanel.SelfRef.cmd);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                if (PaintPanel.SelfRef.fig != null)
                {
                    Parent.Controls.Add(PaintPanel.SelfRef.fig);
                    foreach (Figure f in Parent.Controls.OfType<Figure>())
                    {
                        f.LostF(f, e);
                    }
                    PaintPanel.SelfRef.ActiveControl = PaintPanel.SelfRef.fig;
                }
            }

            if(e.KeyCode == Keys.S)
            {
                this.Location = new Point(this.Location.X, this.Location.Y + 5);
            }

            if (e.KeyCode == Keys.W)
            {
                this.Location = new Point(this.Location.X, this.Location.Y - 5);
            }

            if (e.KeyCode == Keys.D)
            {
                this.Location = new Point(this.Location.X + 5, this.Location.Y);
            }

            if (e.KeyCode == Keys.A)
            {
                this.Location = new Point(this.Location.X - 5, this.Location.Y);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Down)
            {
                this.Height = this.Height + 5;
                paint();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Up)
            {
                this.Height = this.Height - 5;
                paint();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Left)
            {
                this.Width = this.Width - 5;
                paint();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Right)
            {
                this.Width = this.Width + 5;
                paint();
            }
        }
        private void Figure_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            onFocused = true;
        }

        private void Figure_MouseUp(object sender, MouseEventArgs e)
        {
            onFocused = false;
        }

        private void Figure_MouseMove(object sender, MouseEventArgs e)
        {
            if (!onFocused)
            {
                return;
            }
            
            this.Top += e.Y - y;
            this.Left += e.X - x;
            
        }

        private void Figure_Paint(object sender, PaintEventArgs e)
        {
            paint();
        }

        private void paint()
        {
            foreach (var f in this.Controls.OfType<SizePanel>())
            {
                f.Loc(Height, Width);
            }
            Graphics gr = CreateGraphics();
            gr.Clear(BackColor);
            switch (data.type)
            {
                case 1:
                    gr.DrawRectangle(new Pen(data.color, data.width), 0, 0, this.Width, this.Height);
                    break;
                case 2:
                    gr.DrawEllipse(new Pen(data.color, data.width), 0, 0, this.Width, this.Height);
                    break;
                case 3:
                    Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
                    FillRoundedRectangle(gr, new Pen(data.color, data.width), bounds, 10);
                    break;
                case 4:
                    gr.DrawLine(new Pen(data.color, data.width), 0, 0, this.Width, this.Height);
                    break;
            }
        }

        public void GotF(object sender, EventArgs e)
        {
            foreach (SizePanel f in Controls.OfType<SizePanel>())
            {
                f.Show();
            }
            this.Cursor = Cursors.SizeAll;
            paint();
        }

        public void LostF(object sender, EventArgs e)
        {
            bool flag = true;
            foreach (SizePanel f in Controls.OfType<SizePanel>())
            {
                if (f.Focused == true)
                {
                    flag = false;
                    this.Focus();
                    break;
                }
            }
            if (flag)
            {
                foreach (SizePanel f in Controls.OfType<SizePanel>())
                {
                    f.Hide();
                }
            }
            flag = true;
            this.Cursor = Cursors.Default;
        }

        public GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public void FillRoundedRectangle(Graphics graphics, Pen p, Rectangle bounds, int cornerRadius)
        {
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(p, path);
            }
        }       
    }
}
