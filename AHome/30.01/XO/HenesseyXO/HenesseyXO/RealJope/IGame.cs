using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenesseyXO.RealJope
{
    public interface IGame
    {
        string Result { set; get; }

        void Turn(int index, string unit);

        bool IsGameOver();

        string[] GetMatrix();
    }
}
