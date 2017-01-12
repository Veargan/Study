using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace DynamicGUI.Elements
{
    class VMenuButton : IElement
    {
        public object Show(Velement el)
        {
           MenuItem t = new MenuItem();
            t.Name = el.id;
            t.Header = el.value;
            return t;
        }
    }
}
