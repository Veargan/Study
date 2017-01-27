using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChatClietn.Api
{
    public class Input
    {
        private KeyboardIO io;

        public Input()
        {
            io = new KeyboardIO();
        }

        public void StartInput(object message)
        {
            Message msg = message as Message;
            while (true)
            {
                msg.MSG = io.GetInput();
                msg.Available = true;
            }
        }

    }
}
