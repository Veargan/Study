using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOClient.Api
{
    [Flags]
    public enum PlayerTurn : uint
    {
        WAIT = 0x00000000,
        TURN = 0xFFFFFFFF
    }
}
