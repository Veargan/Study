using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
    public enum ShapeType : int
    {
        LINE = 0,
        MULTILINE = 1,
        ELLIPSE = 2,
        RECTANGLE = 3,
        CRECTANGLE = 4
    } 

    public sealed class XData : ICloneable
    {
        public XData()
        {
            LineColor = Color.Black;
            LineWidth = 1;
            PrevPoint = new Point();
            Type = ShapeType.MULTILINE;
            Path = new List<PointF>();
        }

        public XData(ShapeType type) : base()
        {
            Type = type;
        }

        public Color LineColor { set; get; }
        public float LineWidth { set; get; }
        public Point PrevPoint { set; get; }
        public ShapeType Type { set; get; }
        public List<PointF> Path { set; get; }

        public void AddPosition(Point position)
        {
            if (Type == ShapeType.MULTILINE)
            {
                Path.Add(position);
            }
            PrevPoint = position;
        }

        public object Clone()
        {
            XData data = new XData();
            data.LineColor = this.LineColor;
            data.LineWidth = this.LineWidth;
            data.Type = this.Type;
            data.Path = this.Path;
            return data;
        }
    }
}
