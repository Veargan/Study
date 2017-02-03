using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenesseyXO.Sessions;

namespace HenesseyXO.RealJope
{
    public static class GameCreator
    {
        public static IGame CreateInstance(GameType type)
        {
            IGame result = null;
            switch (type)
            {
                case GameType.XO:
                    {
                        result = new XOGame();
                        break;
                    }
            }
            return result;
        }
    }
}
