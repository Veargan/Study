﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class Client
    {
        public string name;
        public TcpClient user;
        public bool isBanned;
        Timer TimerUnBan;

        public Client(string name, TcpClient user)
        {
            this.name = name;
            this.user = user;
            this.isBanned = false;
            TimerUnBan = new Timer((o) => { UnBan(); });
        }
        public string Read()
        {
            StreamReader sr = new StreamReader(user.GetStream());
            return sr.ReadLine();
        }
        public void Write(string message)
        {
            StreamWriter sw = new StreamWriter(user.GetStream());
            sw.WriteLine(message);
            sw.Flush();
        }

        public void SetBan(int banTime)
        {
            if (banTime != 0)
            {
                int time = banTime * 60 * 1000;
                TimerUnBan.Change(time, Timeout.Infinite);
            }
            isBanned = true;
        }

        void UnBan()
        {
            isBanned = false;
            Write("bannot");
            TimerUnBan.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
