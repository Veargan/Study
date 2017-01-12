using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGUI.Elements
{
    public interface IElement
    {
        object Show(Velement el);
    }
}
