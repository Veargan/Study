﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class RoomManager
    {
        private List<string> roomList;
        private List<int> notifications;
        private string activeRoom;
        private NetworkStream stream;
        private RoomForm Rform;

        public RoomManager(NetworkStream stream)
        {
            this.stream = stream;
            roomList = new List<string>();
            notifications = new List<int>();
        }

        public void ToRoom(string name)
        {
            if (!IsRoomAdded(name))
            {
                roomList.Add(name);
                notifications.Add(0);
            }

            activeRoom = name;
            notifications[roomList.IndexOf(name)] = 0;
        }

        private bool IsRoomAdded(string roomName)
        {
            foreach (var room in roomList)
            {
                if (roomName.Equals(room))
                {
                    return true;
                }
            }
            return false;
        }

        public void NewMessage(string roomName, string message)
        {
            if (activeRoom == roomName)
                Rform.GetMessage(message);
        }

        public void NewNotification(string roomName)
        {
            for(int i = 0; i < roomList.Count; i++)
            { 
                if (roomList[i].Equals(roomName))
                {
                    notifications[i]++;
                }
            }
        }

        public string GetNotification(string roomName)
        {
            return notifications[roomList.IndexOf(roomName)].ToString();
        }

        public int GetIndex(string name)
        {
            return roomList.IndexOf(name);
        }
       
        public void SetHistory(string roomName, string history)
        {
            string[] hist = history.Split('~');
            for (int i = 0; i < hist.Length - 1; i++)
            {
                Rform.GetMessage(hist[i]);
            }
        }

        public void Send(string cmd, string roomName, string message)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(cmd + "^" +  roomName + "^" + message);
            sw.Flush();
        }

        public void Connect(string roomName, Button button)
        {
            Rform = new RoomForm(roomName, this, button);
            Rform.Show();
            ToRoom(roomName);
            this.Send("connect", roomName, "");
        }


        public void AddAdmin(string[] rooms)
        {
            for (int i = 1; i < rooms.Length; i++)
            {
                if (!roomList.Contains(rooms[i]))
                {
                    roomList.Add(rooms[i]);
                    notifications.Add(0);
                }
            }
        }
    }
}