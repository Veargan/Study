using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGUI.Elements
{
    public class ElementImpl
    {
        public static object GetI(Velement el)
        {
            IElement element = null;
            switch (el.type)
            {
                case "button": element = new VButton(); break;
                case "panel": element = new VPanel(); break;
                case "text": element = new VText(); break;
                case "label": element = new VLabel(); break;
                case "menu": element = new VMenu(); break;
                case "drop": element = new VDropDown(); break;
                case "menubtn": element = new VMenuButton(); break;
                default: throw new NullReferenceException();
            }
            return element.Show(el);
        }
    }
}
