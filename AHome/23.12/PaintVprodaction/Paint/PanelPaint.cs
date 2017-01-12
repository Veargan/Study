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
        //StatusBar sb;
        //ContextMenu cm;
        private Bitmap drawArea;
        int x;
        int y;
        public PanelPaint()
        {
            InitializeComponent();
            //sb = new StatusBar();
            //cm = new Paint.ContextMenu();
            //cm.data = data;
            BackColor = Color.White;
            drawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = drawArea;

            SelfRef = this;
        }

        public static PanelPaint SelfRef
        {
            get; set;
        }

        public PictureBox getPictureBox()
        {
            return this.pictureBox1;
        }

        public void setPictureBox(PictureBox p)
        {
            pictureBox1 = p;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //sb.GetCord(e.X, e.Y);

            if (data.type != 0)
            {
                return;
            }

            Pen pen = new Pen(data.color, data.width);
            if (e.Button == MouseButtons.Left)
            {
                Graphics gr = Graphics.FromImage(pictureBox1.Image);

                gr.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;

            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(data.color, data.width);

            Graphics gr = Graphics.FromImage(pictureBox1.Image);

            switch (data.type)
            {
                case 1:
                    gr.DrawRectangle(pen, x, y, e.X - x, e.Y - y);
                    break;
                case 2:
                    gr.DrawEllipse(pen, x, y, e.X - x, e.Y - y);
                    break;
                case 3:
                    gr.DrawRectangle(pen, x, y, e.X - x, e.Y - y);
                    break;
                case 4:
                    gr.DrawLine(pen, x, y, e.X, e.Y);
                    break;
                default:
                    break;
            }

            //if (e.Button == MouseButtons.Right)
            //{
            //    cm.cmShow();
            //}

            pictureBox1.Invalidate();
        }
    }
}
