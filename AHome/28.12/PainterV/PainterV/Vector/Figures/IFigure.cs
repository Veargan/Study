using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Vector
{
    public interface IFigure
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        float PenWidth { get; set; }
        Color Color { get; set; }
        ShapeType ShapeType { get; set; }
    }
}
