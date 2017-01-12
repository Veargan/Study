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
using PainterV;

namespace Painter.UserControls.VectorElements.Figures
{
    public partial class SimpleFigures : UserControl
    {
        public SimpleFigures(Rectangle rect, XData data)
        {
            InitializeComponent();
            this.data = data;
            InitializeComponentData(rect);
            DrawFigure(data.Type);
        }

        #region Defines
        public XData data;

        private Bitmap DrawArea;
        private Point prevPoint;
        private bool resizeLTRB = false;
        private bool resizeLBRT = false;
        private bool resizeBottom = false;
        private bool resizeV = false;
        private bool resizeH = false;
        
        public bool Selected { get; set; }
        public event EventHandler GainFocus;
        public new event EventHandler LostFocus;
        #endregion


        #region Common
        private void InitializeComponentData(Rectangle rect)
        {
            if (data.Path != null && data.Path.Count != 0)
            {
                MultilineSetUp();
            }
            else
            {
                this.Left = rect.X;
                this.Top = rect.Y;
                this.Width = rect.Width;
                this.Height = rect.Height;
            }
        }

        public void ContextMenuSetUp(XCommand cmd)
        {
            ContextMenu_Color.Click += new EventHandler(cmd.aColor.Action);
            ContextMenu_PenWidth.Click += new EventHandler(cmd.aWidth.Action);
            ContextMenu_ShapeType.Click += new EventHandler(cmd.aType.Action);
        }

        public void DeselectControl()
        {
            this.Selected = false;
            this.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Drawing
        public void DrawFigure(ShapeType type)
        {
            try
            {
                DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                pictureBox.Image = DrawArea;
                Graphics g = Graphics.FromImage(DrawArea);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Render(g, type);
                g.Dispose();
            }
            catch { }
        }

        private void Render(Graphics g, ShapeType type)
        {
            float offset = data.LineWidth / 2;
            switch (type)
            {
                case ShapeType.LINE:
                    g.DrawLine(new Pen(data.LineColor, data.LineWidth), 
                        0 + offset, 0 + offset, 
                        Width - offset, Height - offset);
                    break;

                case ShapeType.ELLIPSE:
                    g.DrawEllipse(new Pen(data.LineColor, data.LineWidth), 
                        0 + offset, 0 + offset, 
                        Width - data.LineWidth - 1, Height - data.LineWidth - 1);
                    break;

                case ShapeType.RECTANGLE:
                    this.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(new Pen(data.LineColor, 
                        data.LineWidth), 0 + offset, 0 + offset, 
                        Width - data.LineWidth - 1, Height - data.LineWidth - 1);
                    break;

                case ShapeType.CRECTANGLE:
                    this.BorderStyle = BorderStyle.None;
                    DrawCurvedRect(
                        g,
                        new Point((int)(0 + offset), (int)(0 + offset)),
                        new Point((int)(Width - offset - 1), (int)(Height - offset - 1))
                    );
                    break;

                case ShapeType.MULTILINE:
                    g.DrawLines(new Pen(data.LineColor, data.LineWidth), data.Path.ToArray());
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        #endregion
        
        #region Curved Rect
        private void DrawCurvedRect(Graphics g, Point p1, Point p2)
        {
            Point pStart = Point.Empty;
            Point pEnd = Point.Empty;
            if (p1.X < p2.X || p1.Y < p2.Y)
            {
                pStart = p1;
            }
            else
            {
                pStart = p2;
            }
            if (pStart == p1)
            {
                pEnd = p2;
            }
            else
            {
                pEnd = p1;
            }
            g.DrawPath(
                new Pen(data.LineColor, data.LineWidth),
                CurvedRect(new Rectangle(pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y), 10)
            );
        }

        private GraphicsPath CurvedRect(Rectangle bounds, int radius)
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
        #endregion

        #region Multiline
        private void MultilineSetUp()
        {
            List<float> xArray = new List<float>();
            List<float> yArray = new List<float>();

            foreach (var item in data.Path)
            {
                xArray.Add(item.X);
                yArray.Add(item.Y);
            }

            int x1 = (int)xArray.Min();
            int y1 = (int)yArray.Min();
            int x2 = (int)xArray.Max();
            int y2 = (int)yArray.Max();
            PointF[] path = data.Path.ToArray();

            for (int i = 0; i < data.Path.Count; i++)
            {
                path[i].X -= x1;
                path[i].Y -= y1;
            }
            data.Path = path.ToList();

            this.Left = x1;
            this.Top = y1;
            this.Width = x2 - x1;
            this.Height = y2 - y1;
        }
        #endregion

        #region Mouse Events
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Selected && e.Button == MouseButtons.Left)
            {
                if ((e.X <= Width / 10 && e.X >= 0) && (e.Y <= Height / 10 && e.Y >= 0))
                {
                    resizeLTRB = true;
                    resizeBottom = false;
                }
                else if ((e.X <= Width && e.X >= Width - Width / 10) && (e.Y <= Height && e.Y >= Height - Height / 10))
                {
                    resizeLTRB = true;
                    resizeBottom = true;
                }
                else if ((e.X <= Width && e.X >= Width - Width / 10) && (e.Y <= Height / 10 && e.Y >= 0))
                {
                    resizeLBRT = true;
                    resizeBottom = false;
                }
                else if ((e.X <= Width / 10 && e.X >= 0) && (e.Y <= Height && e.Y >= Height - Height / 10))
                {
                    resizeLBRT = true;
                    resizeBottom = true;
                }
                else if ((e.X <= Width / 2 + Width / 10 && e.X >= Width / 2 - Width / 10) && (e.Y <= Height / 10 && e.Y >= 0))
                {
                    resizeV = true;
                    resizeBottom = false;
                }
                else if ((e.X <= Width / 2 + Width / 10 && e.X >= Width / 2 - Width / 10) && (e.Y <= Height && e.Y >= Height - Height / 10))
                {
                    resizeV = true;
                    resizeBottom = true;
                }
                else if ((e.Y <= Height / 2 + Height / 10 && e.Y >= Height / 2 - Height / 10) && (e.X <= Width / 10 && e.X >= 0))
                {
                    resizeH = true;
                    resizeBottom = false;
                }
                else if ((e.Y <= Height / 2 + Height / 10 && e.Y >= Height / 2 - Height / 10) && (e.X <= Width && e.X >= Width - Width / 10))
                {
                    resizeH = true;
                    resizeBottom = true;
                }

                prevPoint = e.Location;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Selected && e.Button == MouseButtons.Left)
            {
                if (resizeLTRB && !resizeBottom)
                {
                    this.Width -= e.Location.X - prevPoint.X;
                    this.Height -= e.Location.Y - prevPoint.Y;
                    this.Left += e.Location.X - prevPoint.X;
                    this.Top += e.Location.Y - prevPoint.Y;
                }
                else if (resizeLTRB && resizeBottom)
                {
                    this.Width += e.Location.X - prevPoint.X;
                    this.Height += e.Location.Y - prevPoint.Y;
                }
                else if (resizeLBRT && !resizeBottom)
                {
                    this.Width += e.Location.X - prevPoint.X;
                    this.Height -= e.Location.Y - prevPoint.Y;
                    this.Top += e.Location.Y - prevPoint.Y;
                }
                else if (resizeLBRT && resizeBottom)
                {
                    this.Width -= e.Location.X - prevPoint.X;
                    this.Height += e.Location.Y - prevPoint.Y;
                    this.Left -= e.Location.Y - prevPoint.Y;
                }
                else if (resizeV && !resizeBottom)
                {
                    this.Height -= e.Location.Y - prevPoint.Y;
                    this.Top += e.Location.Y - prevPoint.Y;
                }
                else if (resizeV && resizeBottom)
                {
                    this.Height += e.Location.Y - prevPoint.Y;
                }
                else if (resizeH && !resizeBottom)
                {
                    this.Width -= e.Location.X - prevPoint.X;
                    this.Left += e.Location.X - prevPoint.X;
                }
                else if (resizeH && resizeBottom)
                {
                    this.Width += e.Location.X - prevPoint.X;
                }
                else
                {
                    this.Left += e.Location.X - prevPoint.X;
                    this.Top += e.Location.Y - prevPoint.Y;
                }

                resizeH = false;
                resizeV = false;
                resizeLTRB = false;
                resizeLBRT = false;
                resizeBottom = false;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                if (((e.X <= Width / 10 && e.X >= 0) && (e.Y <= Height / 10 && e.Y >= 0)) 
                    || ((e.X <= Width && e.X >= Width - Width / 10) && (e.Y <= Height && e.Y >= Height - Height / 10)))
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if (((e.X <= Width && e.X >= Width - Width / 10) && (e.Y <= Height / 10 && e.Y >= 0)) 
                    || ((e.X <= Width / 10 && e.X >= 0) && (e.Y <= Height && e.Y >= Height - Height / 10)))
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if ((e.X <= Width / 2 + Width / 10 && e.X >= Width / 2 - Width / 10) 
                    && ((e.Y <= Height / 10 && e.Y >= 0) || (e.Y <= Height && e.Y >= Height - Height / 10)))
                {
                    Cursor = Cursors.SizeNS;
                }
                else if ((e.Y <= Height / 2 + Height / 10 && e.Y >= Height / 2 - Height / 10)
                    && ((e.X <= Width / 10 && e.X >= 0) || (e.X <= Width && e.X >= Width - Width / 10)))
                {
                    Cursor = Cursors.SizeWE;
                }
                else
                {
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Selected = !Selected;

                if (Selected)
                {
                    if (data.Type != ShapeType.RECTANGLE && data.Type != ShapeType.CRECTANGLE)
                    {
                        this.BorderStyle = BorderStyle.FixedSingle;
                    }
                    this.GainFocus(this, null);
                }
                else
                {
                    this.LostFocus(this, null);
                }
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            // DEPRECATED
            //if (selected)
            //{
            //    if (Type != ShapeType.RECTANGLE)
            //    {
            //        this.BorderStyle = BorderStyle.FixedSingle;
            //    }
            //}
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            // DEPRECATED
            //if (selected)
            //{
            //    Cursor = Cursors.Arrow;
            //    this.BorderStyle = BorderStyle.None;
            //}
        }
        #endregion

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            DrawFigure(data.Type);
            pictureBox.Invalidate();
        }

    }
}
