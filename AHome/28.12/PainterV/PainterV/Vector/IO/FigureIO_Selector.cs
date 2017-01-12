using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Vector
{
    public class FigureIO_Selector
    {
        public static IFigureIO GetInstance(string type)
        {
            IFigureIO f = null;

            switch (type)
            {
                case "CSV":
                    f = new FigureIO_CSV();
                    break;
                case "JSON":
                    f = new FigureIO_JSON();
                    break;
                case "XML":
                    f = new FigureIO_XML();
                    break;
                case "YML":
                    f = new FigureIO_YML();
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            return f;
        }
    }
}
