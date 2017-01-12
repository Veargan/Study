using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLInterpreter
{
    internal static class ControlSelector
    {
        public static Control ControlCreation(string type)
        {
            Control control = null;

            switch (type)
            {
                case "Panel":
                    control = new Panel();
                    break;
                case "Menu":
                    control = new Panel();
                    break;
                case "ToolBar":
                    control = new Panel();
                    break;
                case "ToolBox":
                    control = new Panel();
                    break;
                case "StatusBar":
                    control = new Panel();
                    break;
                case "TabControl":
                    control = new TabControl();
                    break;
                case "TabPage":
                    control = new TabPage();
                    break;
                case "TextBox":
                    control = new TextBox();
                    break;
                case "Button":
                    control = new Button();
                    break;
                case "Label":
                    control = new Label();
                    break;
                default:
                    throw new ArgumentException();
            }

            return control;
        }

    }
}
