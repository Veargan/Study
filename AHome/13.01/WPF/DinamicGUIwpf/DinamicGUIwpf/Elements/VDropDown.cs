using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DynamicGUI.Elements
{
    class VDropDown : IElement
    {
        public object Show(Velement el)
        {
       Menu m = new Menu();
            MenuItem mi = new MenuItem();
            
            mi.Header = el.value;
            m.Items.Add(mi);
         
            m.Name = el.id;
            if (el.list.Count != 0)
            {
               foreach (Velement e in el.list)
              {
                   mi.Items.Add(ElementImpl.GetI(e) as MenuItem);
                }
            }
            return m;
         
        }
    }
}
