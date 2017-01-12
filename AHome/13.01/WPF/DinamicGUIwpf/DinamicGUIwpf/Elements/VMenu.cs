using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;

namespace DynamicGUI.Elements
{
    class VMenu : IElement
    {
        public object Show(Velement el)
        {
            ToolBar m = new ToolBar();
         

            m.Name = el.id;
          
            
           
            if (el.list.Count != 0)
            {
                foreach (Velement e in el.list)
                {
                    m.Items.Add(ElementImpl.GetI(e) as Menu);
                }
            }
        
            return m;
        }
    }
}
