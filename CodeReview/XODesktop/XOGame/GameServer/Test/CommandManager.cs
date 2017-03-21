using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CommandManager
    {
        List<String> connectionList;
        DataBaseManager dbmanager;
        Games games;

        public CommandManager(List<String> connectionList)
        {
            this.connectionList = connectionList;
            games = new Games(this);
            dbmanager = new DataBaseManager();
            
        }

        public string Dispatcher(string message)
        {
            string[] input = message.Split(',');
            switch(input[0])
            {
                case "login":
                    if (!connectionList.Contains(input[0]))
                    {
                        if (dbmanager.Login(input[1], input[2]))
                        {                          
                            return("login,Y," + input[1]);
                        }
                        else
                            return("login,N," + input[1] + ",1");
                    }
                    else
                        return("login,N," + input[1] + ",2");

                case "reg":
                    if (dbmanager.Register(input[1], input[2]))
                    {
                        return("reg,Y," + input[1]);                      
                    }
                    else
                        return("reg,N," + input[1]);

                case "games":
                    return games.SetCommand(message);

                case "change":
                    if (dbmanager.ChangePassword(input[1], input[2], input[3]))                        
                        return("change,Y");
                    else
                        return("change,N");

                case "forgot":
                    if (dbmanager.SendPassword(input[1], input[2]))
                        return("send,Y");
                    else
                        return("send,N");
            }
            return "msg";
        }      
    }
}
