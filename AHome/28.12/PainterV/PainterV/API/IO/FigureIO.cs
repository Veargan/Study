using Painter.UserControls.VectorElements.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        protected List<Figure> GetListOfFigures(List<Control> controls)
        {
            List<Figure> figures = new List<Figure>();

            foreach (var item in controls)
            {
                using (SimpleFigures sf = (SimpleFigures)item)
                {
                    Figure f = new Figure();
                    f.Bounds = item.Bounds;
                    f.PenWidth = sf.data.LineWidth;
                    f.Color = sf.data.LineColor.ToArgb();
                    f.Path = sf.data.Path.ToArray();
                    f.ShapeType = sf.data.Type;
                    figures.Add(f);
                }
            }

            return figures;
        }
        #endregion

        #region Set list of controls
        protected List<Control> CreateControlList(List<Figure> figure)
        {
            List<Control> controls = new List<Control>();
            if (figure != null)
            {
                foreach (var item in figure)
                {
                    XData data = new XData();
                    data.LineColor = Color.FromArgb(item.Color);
                    data.LineWidth = item.PenWidth;
                    data.Type = item.ShapeType;
                    if (item.Path != null)
                    {
                        data.Path = item.Path.ToList();
                    }
                    controls.Add(new SimpleFigures(item.Bounds, data));
                }
            }
            return controls;
        }
        #endregion

    }
}
