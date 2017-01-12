using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class XData
    {
        public Color color;
        public int width;
        public string type;
        public string path;
        public Bitmap bmp;
        public int format;

        public XData()
        {
            color = Color.Black;
            width = 5;
            type = "Curve";
            format = 0;
        }
    }
}