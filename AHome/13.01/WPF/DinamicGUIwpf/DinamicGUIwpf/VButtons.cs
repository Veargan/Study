using DinamicGUIwpf;
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
    public class VButton : IElement
    {
        public object Show(Velement el)
        {
            Button pp = new Button();
            pp.Name = el.id;
            pp.Content = el.value;
         //  pp.Margin=new Thickness()
            pp.Margin = new Thickness(el.x,el.y,0,0);
            // pp.Location = new Point(el.x, el.y);
            pp.Width = el.width;
            pp.Height = el.height;
           
           
            return pp;
        }
    }
}
