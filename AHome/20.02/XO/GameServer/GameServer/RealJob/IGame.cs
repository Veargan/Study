﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public interface IGame
    {
        bool Action(Client player, string input);
        bool ContainsPlayer(Client client);
    }
}
