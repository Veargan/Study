using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Paint
{
    public partial class Shape : UserControl
    {
        public List<Point> ListCoord = new List<Point>();
        public XData data = new XData();
        int x;
        int y;
        int top;
        public int type = 2;

        private int focus = 0;

        private int width;
        private string t;
        private Color c;
        private List<SizePanel> ListSize;

        public Shape(XData d, List<Point> ListC)
        {
            
            data = d;
            ListCoord = ListC;
            InitializeComponent();
            width = data.width;
            t = data.type;
            c = data.color;            
            ListSize = new List<SizePanel> { sizePanel1, sizePanel2, sizePanel3, sizePanel4, sizePanel5, sizePanel6, sizePanel7, sizePanel8 };
            x = ListCoord.First().X;
            y = ListCoord.First().Y;
            this.Width = ListCoord.Last().X - x;
            this.Height = ListCoord.Last().Y - y;           
            this.Top = y;
            this.Left = x;
        }

        private void Shape_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Shape_MouseDown(object sender, MouseEventArgs e)
        {
            top = this.Top;
            x = e.X;
            y = e.Y;
            type = 0;
        }

        private void Shape_MouseUp(object sender, MouseEventArgs e)
        {
            type = 2;
        }

        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            SizePanelReLoc();
            if (type == 0)
            {
                this.Top += e.Y - y;
                this.Left += e.X - x;
            }           
        }

        private void Shape_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Dispose();
                return;
            }
        }

        private void Shape_Paint(object sender, PaintEventArgs e)
        {
            paint();
        }

        private void paint()
        {
            SizePanelReLoc();
            
            Graphics gr = CreateGraphics();
            gr.Clear(BackColor);
            switch (t)
            {
                case "Rectangle":
                    gr.DrawRectangle(new Pen(c, width), 0, 0, this.Width, this.Height);
                    break;
                case "Ellipse":
                    gr.DrawEllipse(new Pen(c, width), 0, 0, this.Width, this.Height);
                    break;
                case "RoundRect":
                    gr.DrawRectangle(new Pen(c, width), 0, 0, this.Width, this.Height);
                    break;
                case "Line":
                    gr.DrawLine(new Pen(c, width), 0, 0, this.Width, this.Height);
                    break;
                case "Curve":        
                    
                    foreach (Point crd in ListCoord)
                    {
                        if (crd.X < x)
                            this.Left = crd.X;
                        if (crd.Y < y)
                            this.Top = crd.Y;
                        if (crd.X > this.Width)
                            this.Width = crd.X;
                        if (crd.Y > this.Height)
                            this.Height = crd.Y;
                    }

                    Point[] p = ListCoord.ToArray();
                    gr.DrawCurve(new Pen(c, width), p);
                    break;
            }
        }

        private void Shape_Leave(object sender, EventArgs e)
        {
            foreach (SizePanel p in ListSize)
            {
                p.Hide();
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void Shape_Enter(object sender, EventArgs e)
        {
            foreach (SizePanel p in ListSize)
            {
                p.Show();
            }
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;

            if (++focus == 2)
            {
                width = data.width;
                c = data.color;
                t = data.type;
                paint();
                focus = 0;
            }                
        }

        private void SizePanelReLoc()
        {
            int w = sizePanel1.Width;

            if (sizePanel1.Tag.Equals(1))
            {
                this.Top += sizePanel1.Top - sizePanel1.top;
                this.Left += sizePanel1.Left - sizePanel1.left;
                this.Width += sizePanel1.left - sizePanel1.Left;
                this.Height += sizePanel1.top - sizePanel1.Top;
            }
            else
            {
                sizePanel1.Top = 0;
                sizePanel1.Left = 0;
            }

            if (sizePanel2.Tag.Equals(1))
            {
                this.Top += sizePanel2.Top - sizePanel2.top;
                this.Height += sizePanel2.top - sizePanel2.Top;
            }
            else
            {                
                sizePanel2.Top = 0;
                sizePanel2.Left = (this.Width - w) / 2;
            }

            if (sizePanel3.Tag.Equals(1))
            {                
                this.Top += sizePanel3.Top - sizePanel3.top;
                this.Width = sizePanel3.Left + w;
                this.Height += sizePanel3.top - sizePanel3.Top;
            }
            else
            {                
                sizePanel3.Top = 0;
                sizePanel3.Left = this.Width - w;
            }

            if (sizePanel4.Tag.Equals(1))
            {                
                this.Left += sizePanel4.Left - sizePanel4.left;
                this.Width += sizePanel4.left - sizePanel4.Left;
            }
            else
            {
                sizePanel4.Top = (this.Height - w) / 2;
                sizePanel4.Left = 0;
            }

            if (sizePanel5.Tag.Equals(1))
            {
                this.Width = sizePanel5.Left + w;
            }
            else
            {
                sizePanel5.Top = (this.Height - w) / 2;
                sizePanel5.Left = this.Width - w;
            }

            if (sizePanel6.Tag.Equals(1))
            {
                this.Height = sizePanel6.Top + w;
                this.Left += sizePanel6.Left - sizePanel6.left;
                this.Width += sizePanel6.left - sizePanel6.Left;
            }
            else
            {
                sizePanel6.Top = this.Height - w;
                sizePanel6.Left = 0;
            }

            if (sizePanel7.Tag.Equals(1))
            {
                this.Height = sizePanel7.Top + w;
            }
            else
            {
                sizePanel7.Top = this.Height - w;
                sizePanel7.Left = (this.Width - w) / 2;
            }

            if (sizePanel8.Tag.Equals(1))
            {
                this.Height = sizePanel8.Top + w;
                this.Width = sizePanel8.Left + w;

            }
            else
            {
                sizePanel8.Top = this.Height - w;
                sizePanel8.Left = this.Width - w;
            }
        }
    }
}
