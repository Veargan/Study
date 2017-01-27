using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChatClietn.Api
{
    public class Message
    {
        public string MSG { set; get; }
        public bool Available { set; get; }

        public Message()
        {
            MSG = String.Empty;
            Available = false;
        }
    }
}
