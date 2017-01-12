using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;

namespace Painter.Vector
{
    public class FigureIO_JSON : IFigureIO
    {
        public FigureIO_JSON()
        {
            PathToFile = "";
        }
        public FigureIO_JSON(string path)
        {
            PathToFile = path;
        }

        public string PathToFile { get; set; }

        public List<Control> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);
            string jsonString = fs.ReadToEnd();
            fs.Dispose();

            string[] figures = jsonString.Replace("][", "]^[").Split('^');
            List<FigureLine> lines = JsonConvert.DeserializeObject<List<FigureLine>>(figures[0]);
            List<FigureEllipse> ellipses = JsonConvert.DeserializeObject<List<FigureEllipse>>(figures[1]);
            List<FigureRectangle> rects = JsonConvert.DeserializeObject<List<FigureRectangle>>(figures[2]);
            List<FigureCurvedRectangle> cRects = JsonConvert.DeserializeObject<List<FigureCurvedRectangle>>(figures[3]);
            List<FigureMultiline> multilines = JsonConvert.DeserializeObject<List<FigureMultiline>>(figures[4]);

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

        public void Write(List<Control> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(JsonConvert.SerializeObject(GetListOfLines(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfEllipses(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfRects(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfCurvedRects(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfMultilines(controls)));
            fs.Dispose();
        }

        #region Get list of figures
        private List<FigureLine> GetListOfLines(List<Control> controls)
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

        private List<FigureEllipse> GetListOfEllipses(List<Control> controls)
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

        private List<FigureRectangle> GetListOfRects(List<Control> controls)
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

        private List<FigureCurvedRectangle> GetListOfCurvedRects(List<Control> controls)
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

        private List<FigureMultiline> GetListOfMultilines(List<Control> controls)
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

    }
}
