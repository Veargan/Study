using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintWF.Core
{
    public partial class Form1 : Form
    {
        private bool draw;
        private int x;
        private int y;
        private Graphics g;
        private Pen p;
        private xData data;

        public Form1()
        {
            InitializeComponent();
            data = new xData();
            g = panel1.CreateGraphics();
            p = new Pen(data.color, data.size);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

            switch (data.type)
            {
                case 1:
                    if ((e.X > x) && (e.Y > y))
                        g.DrawRectangle(p, x, y, e.X - x, e.Y - y);
                    if ((e.X < x) && (e.Y < y))
                        g.DrawRectangle(p, x, y, x - e.X, y - e.Y);
                    break;
                case 2:
                    g.DrawEllipse(p, x, y, e.X - x, e.Y - y);
                    break;
                case 3:
                    if ((e.X > x) && (e.Y > y))
                    {
                        Rectangle roundRect = new Rectangle(x, y, e.X - x, e.Y - y);
                        GraphicsPath path = RoundedRectangle.RoundedRect(roundRect, 5);
                        g.DrawPath(p, path);
                    }
                    if ((e.X < x) && (e.Y < y))
                    {
                        Rectangle roundRect = new Rectangle(x, y, e.X, e.Y);
                        GraphicsPath path = RoundedRectangle.RoundedRect(roundRect, 1);
                        g.DrawPath(p, path);
                    }
                    break;
                case 4:
                    g.DrawLine(p, x, y, e.X, e.Y);
                    break;
                default:
                    break;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (data.type != 5)
                return;

            if (draw)
            {
                if ((x > 0) && (y > 0))
                {
                    g.DrawLine(p, x, y, e.X, e.Y);
                }
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            DialogResult colorResult = colorDialog1.ShowDialog();

            if (colorResult == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }

        private void brushSize_TextChanged(object sender, EventArgs e)
        {
            p.Width = float.Parse(brushSize.Text);
        }

        private void ListOfFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ListOfFigures.Text)
            {
                case "Rectangle":
                    data.type = 1;
                    break;
                case "Ellipse":
                    data.type = 2;
                    break;
                case "Round Rectangle":
                    data.type = 3;
                    break;
                case "Line":
                    data.type = 4;
                    break;
                case "Curved Line":
                    data.type = 5;
                    break;
                default:
                    break;
            }
        }
    }
}