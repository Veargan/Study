using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Vector
{
    public interface IFigureIO
    {
        string PathToFile { get; set; }

        List<Control> Read();
        void Write(List<Control> controls);
    }
}
