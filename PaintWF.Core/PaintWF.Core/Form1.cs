using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintWF.Core
{
    public partial class Form1 : Form
    {
        private bool draw;
        private int x;
        private int y;
        private Graphics g;


        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            x = 0;
            y = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if ((x > 0) && (y > 0))
                {
                    Pen p = new Pen(Brushes.Black);
                    g.DrawLine(p, x, y, e.X, e.Y);
                }

                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
        }
    }
}
