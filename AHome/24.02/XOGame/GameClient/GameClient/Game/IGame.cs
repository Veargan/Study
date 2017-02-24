using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    interface IGame
    {
        void SendInfo(string btnname);
        void ReceiveGameData(string output);
        void ShowForm();
    }
}
