using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;
using PainterV;
using PainterV.UserControls.Menu;

namespace Painter.UserControls.VectorElements
{
    public partial class CanvasVector : UserControl
    {
        public CanvasVector()
        {
            InitializeComponent();
            data = new XData();
            DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea;
            g = Graphics.FromImage(DrawArea);
            DrawingVector2DTool.SetUp(g);
        }


        #region Defines
        private Bitmap DrawArea;
        private Graphics g;
        private bool isDrawing;
        public XData data;
        public SimpleFigures StackControl;
        public XCommand cmd;
        public event MouseEventHandler CanvasMouseMove;
        #endregion


        #region Focus Events
        public void OnGainFocus(object sender, EventArgs e)
        {
            SimpleFigures obj = sender as SimpleFigures;
            OnLostFocus(StackControl, null);
            StackControl = obj;
        }

        public void OnLostFocus(object sender, EventArgs e)
        {
            SimpleFigures obj = sender as SimpleFigures;
            if (obj != null)
            {
                obj.DeselectControl();
            }
        }
        #endregion

        #region Mementos
        public List<Control> GetMemento()
        {
            List<Control> collecton = new List<Control>();
            foreach (var item in DrawingVector2DTool.figures)
            {
                collecton.Add(item);
            }
            return collecton;
        }

        public void SetMemento(List<Control> collection)
        {
            for (int i = 1; i < this.Controls.Count; ++i)
            {
                this.Controls.RemoveAt(i);
            }

            this.Controls.AddRange(collection.ToArray());            
        }
        #endregion

        #region Mouse Actions
        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (data.Type == ShapeType.MULTILINE)
            {
                if (isDrawing)
                {
                    g.DrawLine(new Pen(data.LineColor, data.LineWidth), 
                        data.PrevPoint, e.Location);
                    data.AddPosition(e.Location);
                    data.Path.Add(e.Location);
                }
            }
            pictureBox.Invalidate();

            CanvasMouseMove(this, e);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                data.AddPosition(e.Location);
                if (data.Type == ShapeType.MULTILINE)
                {
                    data.Path.Add(data.PrevPoint);
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;

                SimpleFigures cntr = (SimpleFigures)DrawingVector2DTool.Render(this,
                    new Rectangle(data.PrevPoint, new Size(e.X - data.PrevPoint.X, e.Y - data.PrevPoint.Y)), (XData)data.Clone(), cmd);
                cntr.GainFocus += this.OnGainFocus;
                cntr.LostFocus += this.OnLostFocus;

                data.AddPosition(e.Location);
                if (data.Type == ShapeType.MULTILINE)
                {
                    g.Clear(this.BackColor);
                    data.Path = new List<PointF>();
                }

                this.Controls[Controls.Count - 1].BringToFront();
            }
        }
        #endregion

        private void Canvas_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                pictureBox.Image = DrawArea;
                g = Graphics.FromImage(DrawArea);
                DrawingVector2DTool.SetUp(g);
            }
            catch { }
        }

        public void SetCanvasMouseMoveEventHandler(StatusBarVector status)
        {
            CanvasMouseMove += status.Canvas_MouseMove;
        }

    }
}
