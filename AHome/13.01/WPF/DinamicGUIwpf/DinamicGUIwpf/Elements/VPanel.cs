using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows;
using DinamicGUIwpf;
using System.Windows.Media;

namespace DynamicGUI.Elements
{
    public class VPanel : IElement
    {
        public object Show(Velement el)
        {
            Canvas pp = new Canvas();
          
            pp.Margin = new Thickness(el.x, el.y, 0, 0);
          
            pp.Width = el.width;
            pp.Height = el.height;
            Random random = new Random();
            SolidColorBrush brush =
                new SolidColorBrush(
                    Color.FromRgb(
                    (byte)random.Next(255),
                    (byte)random.Next(255),
                    (byte)random.Next(255)
                    ));

            pp.Background = brush;

            if (el.list.Count > 0)
            {
                foreach (var elem in el.list)
                {
                    foreach (Velement e in el.list)
                    {
                        pp.Children.Add(ElementImpl.GetI(e) as FrameworkElement  );
                    }
                }
            }

            return pp;
        }
    }
}
