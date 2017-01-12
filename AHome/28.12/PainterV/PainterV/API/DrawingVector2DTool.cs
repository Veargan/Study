using Painter.UserControls.VectorElements;
using Painter.UserControls.VectorElements.Figures;
using Painter.Vector;
using PainterV;
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
        public static List<Control> figures;

        static DrawingVector2DTool()
        {
            figures = new List<Control>();
        }

        public static void SetUp(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public static Control Render(Control ownerControl, Rectangle rect, XData data, XCommand cmd)
        {
            SimpleFigures result = new SimpleFigures(rect, data);
            result.ContextMenuSetUp(cmd);
            ownerControl.Controls.Add(result);
            figures.Add(result);
            
            return result;
        }

        #region Selectors
        public static void ColorSelector(CanvasVector Canvas)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            Canvas.data.LineColor = dlg.Color;
            if (Canvas.StackControl != null)
            {
                Canvas.StackControl.data.LineColor = dlg.Color;
                Canvas.StackControl.DrawFigure(Canvas.StackControl.data.Type);
            }
            dlg.Dispose();
        }

        public static void PenWidthSelector(CanvasVector Canvas, float value)
        {
            Canvas.data.LineWidth = value;
            if (Canvas.StackControl != null)
            {
                Canvas.StackControl.data.LineWidth = value;
                Canvas.StackControl.DrawFigure(Canvas.StackControl.data.Type);
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

            if (Canvas != null)
            {
                Canvas.data.Type = type;
                if (Canvas.StackControl != null)
                {
                    Canvas.StackControl.data.Type = type;
                    Canvas.StackControl.DrawFigure(type);
                }
            }
        }

        public static void SaveSelector(CanvasVector Canvas)
        {
            try
            {
                List<Control> controls = Canvas.GetMemento();

                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
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
                openFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                DialogResult res = openFD.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // TODO: Load file
                    IFigureIO f = FigureIO_Selector.GetInstance(openFD.FileName.Remove(0, openFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = openFD.FileName;
                    Canvas.Controls.AddRange(f.Read().ToArray());
                }
                openFD.Dispose();

                figures = new List<Control>();
                for (int i = 1; i < Canvas.Controls.Count; ++i)
                {
                    figures.Add(Canvas.Controls[i]);
                    Canvas.Controls[i].BringToFront();
                }
            }
            catch { }
        }
        #endregion

    }
}
