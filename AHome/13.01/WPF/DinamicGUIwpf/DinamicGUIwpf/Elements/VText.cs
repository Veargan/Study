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
    public class VText : IElement
    {
        public object Show(Velement el)
        {
            TextBox pp = new TextBox();
            pp.Name = el.id;
            pp.Text = el.value;
           pp.Margin = new Thickness(el.x, el.y, 0, 0);
            pp.Width = el.width;
            pp.Height = el.height;
           
            return pp;
        }
    }
}
