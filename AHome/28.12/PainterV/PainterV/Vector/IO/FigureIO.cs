using Painter.UserControls.VectorElements.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Vector
{
    public abstract class FigureIO : IFigureIO
    {
        public string PathToFile { get; set; }

        public abstract List<Control> Read();
        public abstract void Write(List<Control> controls);

        #region Get list of figures
        protected List<FigureLine> GetListOfLines(List<Control> controls)
        {
            List<FigureLine> lines = new List<FigureLine>();

            foreach (var item in controls)
            {
                if (item.GetType() == typeof(SimpleFigures))
                {
                    using (SimpleFigures sf = (SimpleFigures)item)
                    {
                        if (sf.Type == ShapeType.LINE)
                        {
                            FigureLine l = new FigureLine();
                            l.X = item.Left;
                            l.Y = item.Top;
                            l.Width = item.Width;
                            l.Height = item.Height;
                            l.PenWidth = sf.PenWidth;
                            l.Color = sf.Color;
                            l.ShapeType = ShapeType.LINE;
                            lines.Add(l);
                        }
                    }
                }
            }

            return lines;
        }

        protected List<FigureEllipse> GetListOfEllipses(List<Control> controls)
        {
            List<FigureEllipse> ellipses = new List<FigureEllipse>();

            foreach (var item in controls)
            {
                if (item.GetType() == typeof(SimpleFigures))
                {
                    using (SimpleFigures sf = (SimpleFigures)item)
                    {
                        if (sf.Type == ShapeType.ELLIPSE)
                        {
                            FigureEllipse l = new FigureEllipse();
                            l.X = item.Left;
                            l.Y = item.Top;
                            l.Width = item.Width;
                            l.Height = item.Height;
                            l.PenWidth = sf.PenWidth;
                            l.Color = sf.Color;
                            l.ShapeType = ShapeType.ELLIPSE;
                            ellipses.Add(l);
                        }
                    }
                }
            }

            return ellipses;
        }

        protected List<FigureRectangle> GetListOfRects(List<Control> controls)
        {
            List<FigureRectangle> rects = new List<FigureRectangle>();

            foreach (var item in controls)
            {
                if (item.GetType() == typeof(SimpleFigures))
                {
                    using (SimpleFigures sf = (SimpleFigures)item)
                    {
                        if (sf.Type == ShapeType.RECTANGLE)
                        {
                            FigureRectangle l = new FigureRectangle();
                            l.X = item.Left;
                            l.Y = item.Top;
                            l.Width = item.Width;
                            l.Height = item.Height;
                            l.PenWidth = sf.PenWidth;
                            l.Color = sf.Color;
                            l.ShapeType = ShapeType.RECTANGLE;
                            rects.Add(l);
                        }
                    }
                }
            }

            return rects;
        }

        protected List<FigureCurvedRectangle> GetListOfCurvedRects(List<Control> controls)
        {
            List<FigureCurvedRectangle> cRects = new List<FigureCurvedRectangle>();

            foreach (var item in controls)
            {
                if (item.GetType() == typeof(CurvedRectangle))
                {
                    using (CurvedRectangle cr = (CurvedRectangle)item)
                    {
                        FigureCurvedRectangle l = new FigureCurvedRectangle();
                        l.X = item.Left;
                        l.Y = item.Top;
                        l.Width = item.Width;
                        l.Height = item.Height;
                        l.PenWidth = cr.PenWidth;
                        l.Color = cr.Color;
                        l.ShapeType = ShapeType.CRECTANGLE;
                        cRects.Add(l);
                    }
                }
            }

            return cRects;
        }

        protected List<FigureMultiline> GetListOfMultilines(List<Control> controls)
        {
            List<FigureMultiline> multilines = new List<FigureMultiline>();

            foreach (var item in controls)
            {
                if (item.GetType() == typeof(Multiline))
                {
                    using (Multiline ml = (Multiline)item)
                    {
                        FigureMultiline l = new FigureMultiline();
                        l.X = item.Left;
                        l.Y = item.Top;
                        l.Width = item.Width;
                        l.Height = item.Height;
                        l.PenWidth = ml.PenWidth;
                        l.Color = ml.Color;
                        l.Path = ml.Path;
                        l.ShapeType = ShapeType.MULTILINE;
                        multilines.Add(l);
                    }
                }
            }

            return multilines;
        }
        #endregion

        #region Set list of controls
        protected List<Control> CreateControlList(List<FigureLine> lines, List<FigureEllipse> ellipses,
            List<FigureRectangle> rects, List<FigureCurvedRectangle> cRects, List<FigureMultiline> multilines)
        {
            List<Control> controls = new List<Control>();
            if (lines != null)
            {
                foreach (var item in lines)
                {
                    controls.Add(new SimpleFigures(item.X, item.Y, item.X + item.Width, item.Y + item.Height, item.Color, item.PenWidth, item.ShapeType));
                }
            }
            if (ellipses != null)
            {
                foreach (var item in ellipses)
                {
                    controls.Add(new SimpleFigures(item.X, item.Y, item.X + item.Width, item.Y + item.Height, item.Color, item.PenWidth, item.ShapeType));
                }
            }
            if (rects != null)
            {
                foreach (var item in rects)
                {
                    controls.Add(new SimpleFigures(item.X, item.Y, item.X + item.Width, item.Y + item.Height, item.Color, item.PenWidth, item.ShapeType));
                }
            }
            if (cRects != null)
            {
                foreach (var item in cRects)
                {
                    controls.Add(new CurvedRectangle(item.X, item.Y, item.X + item.Width, item.Y + item.Height, item.Color, item.PenWidth));
                }
            }
            if (multilines != null)
            {
                foreach (var item in multilines)
                {
                    controls.Add(new Multiline(item.Path, item.Color, item.PenWidth));
                    controls[controls.Count - 1].Left = item.X;
                    controls[controls.Count - 1].Top = item.Y;
                    controls[controls.Count - 1].Width = item.Width;
                    controls[controls.Count - 1].Height = item.Height;
                }
            }

            return controls;
        }
        #endregion

    }
}
