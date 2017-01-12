using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaWpf
{
    public class Figures
    {
        public double x { get; set; }
        public double y { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public int dwidth { get; set; }
        public int dtype { get; set; }
        public string dcolor { get; set; }


        [Obsolete("Only needed for serialization and materialization", true)]
        public Figures()
        {

        }
        public Figures(double x, double y, double width, double height, int dwidth, int dtype, string dcolor)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.dwidth = dwidth;
            this.dtype = dtype;
            this.dcolor = dcolor;
        }
    }
}
