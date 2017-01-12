using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaTrue
{
    public interface IPictureIO
    {
        void Save(List<Figures> fg);
        List<Figures> Load();
    }
}
