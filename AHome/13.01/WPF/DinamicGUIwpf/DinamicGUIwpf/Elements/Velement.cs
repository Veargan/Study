using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGUI
{
    public class Velement
    {
        public string type;
        public string value;
        public string id;
        public int x;
        public int y;
        public int width;
        public int height;
        public List<Velement> list;

        public Velement(string id, string value, string type, int x, int y, int width, int heigth, List<Velement> list)
        {
            this.id = id;
            this.value = value;
            this.type = type;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = heigth;
            this.list = list;
        }
        public Velement() { }
    }
}