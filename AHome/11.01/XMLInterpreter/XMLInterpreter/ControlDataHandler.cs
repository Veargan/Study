using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInterpreter
{
    public static class ControlDataHandler
    {
        public static void InsertData(string tag, string innerText)
        {
            if (innerText == "")
            {
                return;
            }

            switch (tag)
            {
                case "id":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Name = innerText;
                    break;
                case "value":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Text = innerText;
                    break;
                case "x":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Left = int.Parse(innerText);
                    break;
                case "y":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Top = int.Parse(innerText);
                    break;
                case "width":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Width = int.Parse(innerText);
                    break;
                case "height":
                    SAX_Parser.CurrentControl[SAX_Parser.depthLevel].Height = int.Parse(innerText);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

    }
}
