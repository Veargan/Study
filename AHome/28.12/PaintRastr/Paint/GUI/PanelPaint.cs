using System;
using System.Drawing;
using System.Windows.Forms;
using Paint.API;
using Paint.GUI;

namespace Paint
{
    public partial class PanelPaint : UserControl
    {
        private StatusControl sb { set; get; }
        private Bitmap drawArea;
        private Graphics gr;
        private bool isDrawing;
        private Context context;
        private event MouseEventHandler meh;

        public PanelPaint()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            sb = new StatusControl();
            context = new Context();
            Drawing.data = new XData();
            Drawing.SetUp(gr);
            BackColor = Color.White;
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

        public void SetEventHandler(StatusControl status)
        {
            this.meh += status.EHandler;
            //meh += new MouseEventHandler(status.EHandler);
        }

        public void ContextSelect(XCommand com)
        {
            context.ContextSelect(com);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                Drawing.data.addPosition(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                context.ShowContextMenu();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing.data.type == ShapeType.MULTILINE)
            {
                if (isDrawing)
                {
                    Drawing.Draw(gr, Drawing.data.PrevPoint, new Point(e.X, e.Y));
                    Drawing.data.addPosition(e.Location);
                }
            }
            Canvas_UpdateCanvas();

            sb.EHandler(this, e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (Drawing.data.type != ShapeType.MULTILINE)
            {
                Drawing.Draw(gr, Drawing.data.PrevPoint, new Point(e.X, e.Y));
                Drawing.data.addPosition(e.Location);
            }
        }

        private void Canvas_UpdateCanvas()
        {
            pictureBox1.Invalidate();
        }

        private void Canvas_SizeChanged(object sender, EventArgs e)
        {
            drawArea = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = drawArea;
            gr = Graphics.FromImage(drawArea);
            Drawing.SetUp(gr);
        }
    }
}