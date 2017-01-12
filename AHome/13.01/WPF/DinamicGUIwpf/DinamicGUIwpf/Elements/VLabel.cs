using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DynamicGUI.Elements
{
    class VLabel : IElement
    {
        public object Show(Velement el)
        {
            Label lbl = new Label();
            lbl.Width = el.width;
            lbl.Height = el.height;
            lbl.Margin = new Thickness(el.x, el.y, 0, 0);
            
            lbl.Content = el.value;
            lbl.Name = el.id;
            return lbl;
        }
    }
}
