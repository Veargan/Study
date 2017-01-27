using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiChatClietn.Api
{
    public class ClientApi
    {
        private const int PORT = 11000;
        private TcpClient client;
        private NetworkStream netStream;
        private Message message;
        private Input input;

        // asynchronous threads
        private Thread threadListen;
        private Thread threadInput;
        private Thread threadSay;

        public ClientApi()
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            ThreadInit();
        }

        private void Init()
        {
            client = new TcpClient("localhost", PORT);
            netStream = client.GetStream();
            input = new Input();
            message = new Message();
        }

        private void ThreadInit()
        {
            threadListen = new Thread(new ThreadStart(Listen));
            threadInput = new Thread(new ParameterizedThreadStart(input.StartInput));
            threadSay = new Thread(new ThreadStart(Say));
            threadListen.Start();
            threadInput.Start(message);
            threadSay.Start();
        }

        private void Listen()
        {
            while (true)
            {
                StreamReader reader = new StreamReader(netStream);
                if (netStream.DataAvailable)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }

        public void Say()
        {
            StreamWriter writer = new StreamWriter(netStream);
            while (true)
            {
                if (message.Available)
                {
                    writer.WriteLine(message.MSG);
                    writer.Flush();
                    message.Available = false;
                }
            }
        }

    }
}
