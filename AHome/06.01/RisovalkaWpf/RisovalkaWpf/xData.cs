using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RisovalkaWpf
{
    public class xData
    {
        public SolidColorBrush color;
        public int width;
        public int type;

        public xData()
        {
            color = new SolidColorBrush(Colors.Black);
            width = 3;
            type = 5;
        }
    }
}
