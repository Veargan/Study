using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaTrue
{
    public class Figures
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int dwidth { get; set; }
        public int dtype { get; set; }
        public int dcolor { get; set; }


        [Obsolete("Only needed for serialization and materialization", true)]
        public Figures()
        {

        }
        public Figures(int x,int y, int width, int height, int dwidth, int dtype, int dcolor)
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
