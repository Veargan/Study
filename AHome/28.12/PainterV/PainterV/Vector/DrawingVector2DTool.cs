using Painter.UserControls.VectorElements;
using Painter.UserControls.VectorElements.Figures;
using Painter.Vector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public static class DrawingVector2DTool
    {
        public static XData xData;

        public static Dictionary<int, Control> figures;

        static DrawingVector2DTool()
        {
            xData = new XData();
            figures = new Dictionary<int, Control>();
        }

        public static void SetUp(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public static Control Render(Control ownerControl, Graphics g, Point p1, Point p2)
        {
            Control result = null;

            switch (xData.Type)
            {
                case ShapeType.LINE:
                    result = new SimpleFigures(p1.X, p1.Y, p2.X, p2.Y,
                        xData.LineColor, xData.LineWidth, ShapeType.LINE);
                    ownerControl.Controls.Add(result);
                    figures.Add(ownerControl.Controls.Count - 1, result);
                    break;

                case ShapeType.ELLIPSE:
                    result = new SimpleFigures(p1.X, p1.Y, p2.X, p2.Y,
                        xData.LineColor, xData.LineWidth, ShapeType.ELLIPSE);
                    ownerControl.Controls.Add(result);
                    figures.Add(ownerControl.Controls.Count - 1, result);
                    break;

                case ShapeType.RECTANGLE:
                    result = new SimpleFigures(p1.X, p1.Y, p2.X, p2.Y,
                        xData.LineColor, xData.LineWidth, ShapeType.RECTANGLE);
                    ownerControl.Controls.Add(result);
                    figures.Add(ownerControl.Controls.Count - 1, result);
                    break;

                case ShapeType.CRECTANGLE:
                    result = new SimpleFigures(p1.X, p1.Y, p2.X, p2.Y,
                        xData.LineColor, xData.LineWidth, ShapeType.CRECTANGLE);
                    ownerControl.Controls.Add(result);
                    figures.Add(ownerControl.Controls.Count - 1, result);
                    break;

                case ShapeType.MULTILINE:
                    result = new SimpleFigures(0, 0, 0, 0, xData.LineColor, xData.LineWidth, ShapeType.MULTILINE, xData.Path.ToArray());
                    ownerControl.Controls.Add(result);
                    figures.Add(ownerControl.Controls.Count - 1, result);
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return result;
        }

        #region Selectors
        public static void ColorSelector(CanvasVector Canvas)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            if (Canvas.StackControl != null)
            {
                Canvas.StackControl.Color = dlg.Color;
                Canvas.StackControl.DrawFigure(Canvas.StackControl.Type);
            }
            dlg.Dispose();
        }

        public static void PenWidthSelector(CanvasVector Canvas, float value)
        {
            if (Canvas.StackControl != null)
            {
                Canvas.StackControl.PenWidth = value;
                Canvas.StackControl.DrawFigure(Canvas.StackControl.Type);
            }
        }

        public static void ShapeTypeSelector(CanvasVector Canvas, int selectedIndex)
        {
            ShapeType type = 0;
            switch (selectedIndex)
            {
                case 0:
                    type = ShapeType.LINE;
                    break;

                case 1:
                    type = ShapeType.MULTILINE;
                    break;

                case 2:
                    type = ShapeType.ELLIPSE;
                    break;

                case 3:
                    type = ShapeType.RECTANGLE;
                    break;

                case 4:
                    type = ShapeType.CRECTANGLE;
                    break;
            }

            xData.Type = type;

            if (Canvas != null)
            {
                if (Canvas.StackControl != null)
                {
                    Canvas.StackControl.Type = type;
                    Canvas.StackControl.DrawFigure(type);
                }
            }
        }

        public static void SaveSelector(CanvasVector Canvas)
        {
            try
            {
                List<Control> controls = Canvas.GetImage().Values.ToList();

                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                DialogResult res = saveFD.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // TODO: save file
                    IFigureIO f = FigureIO_Selector.GetInstance(saveFD.FileName.Remove(0, saveFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = saveFD.FileName;
                    f.Write(controls);
                }
                saveFD.Dispose();
            }
            catch { }
        }

        public static void LoadSelector(CanvasVector Canvas)
        {
            try
            {
                OpenFileDialog openFD = new OpenFileDialog();
                openFD.Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                DialogResult res = openFD.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // TODO: Load file
                    IFigureIO f = FigureIO_Selector.GetInstance(openFD.FileName.Remove(0, openFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = openFD.FileName;
                    Canvas.Controls.AddRange(f.Read().ToArray());
                }
                openFD.Dispose();

                figures = new Dictionary<int, Control>();
                for (int i = 1; i < Canvas.Controls.Count; ++i)
                {
                    figures.Add(i, Canvas.Controls[i]);
                    Canvas.Controls[i].BringToFront();
                }
            }
            catch { }
        }
        #endregion

    }
}
