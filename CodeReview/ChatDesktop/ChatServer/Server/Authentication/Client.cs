using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        public string name { get; set; }
        public TcpClient user { get; set; }
        public bool isBanned { get; set; }
        public int type { get; set; }

        private Timer TimerUnBan;

        public Client(string name, TcpClient user, string status, int type)
        {
            this.name = name;
            this.user = user;
            this.type = type;
            this.isBanned = false;
            TimerUnBan = new Timer((o) => { UnBan(); });
        }

        public string Read()
        {
            try
            {
                if (type == 1)
                {
                    StreamReader sr = new StreamReader(user.GetStream());
                    return sr.ReadLine();
                }
                else
                {
                    Byte[] bytes1 = new Byte[user.Available];
                    user.GetStream().Read(bytes1, 0, bytes1.Length);
                    String inp = DecodeMessage(bytes1);
                    return inp;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: Read" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void Write(string message)
        {
            try
            {
                if (type == 1)
                {
                    StreamWriter sw = new StreamWriter(user.GetStream());
                    sw.WriteLine(message);
                    sw.Flush();
                }
                else
                {
                    Byte[] response = Encoding.UTF8.GetBytes("  " + message);
                    response[0] = 0x81; // denotes this is the final message and it is in text
                    response[1] = Convert.ToByte(response.Length - 2); // payload size = message - header size
                    user.GetStream().Write(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: Write" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        private String DecodeMessage(Byte[] bytes)
        {
            try
            {
                String incomingData = String.Empty;
                Byte secondByte = bytes[1];
                Int32 dataLength = secondByte & 127;
                Int32 indexFirstMask = 2;
                if (dataLength == 126)
                    indexFirstMask = 4;
                else if (dataLength == 127)
                    indexFirstMask = 10;

                IEnumerable<Byte> keys = bytes.Skip(indexFirstMask).Take(4);
                Int32 indexFirstDataByte = indexFirstMask + 4;

                Byte[] decoded = new Byte[bytes.Length - indexFirstDataByte];
                for (Int32 i = indexFirstDataByte, j = 0; i < bytes.Length; i++, j++)
                {
                    decoded[j] = (Byte)(bytes[i] ^ keys.ElementAt(j % 4));
                }

                return incomingData = Encoding.UTF8.GetString(decoded, 0, decoded.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: DecodeMessage" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void SetBan(int banTime)
        {
            try
            {
                if (banTime != 0)
                {
                    int time = banTime * 60 * 1000;
                    TimerUnBan.Change(time, Timeout.Infinite);
                }
                isBanned = true;
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: SetBan" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        private void UnBan()
        {
            try
            {
                isBanned = false;
                Write("banover");
                TimerUnBan.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: UnBan" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public bool IsClient(string name)
        {
            try
            {
                if (this.name == name)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: IsClient" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }
    }
}