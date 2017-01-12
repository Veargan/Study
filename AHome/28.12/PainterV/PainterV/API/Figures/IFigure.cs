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
        Rectangle Bounds { get; set; }
        float PenWidth { get; set; }
        int Color { get; set; }
        ShapeType ShapeType { get; set; }
    }
}
