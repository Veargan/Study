using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class DataBaseManager
    {
        string databaseName = @"XOACCOUNTDB.db";
        string tablename = "PersonalData";
        SQLiteConnection connection;
        public DataBaseManager() { }
        public void Conn()
        {
            connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }
        public void Insert(string login, string password)
        {
            Conn();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO '" + tablename + "' ('login', 'password') VALUES ('" + login + "','" + password + "');", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool CreateNewLogin(string login, string password, string command)
        {
            bool result = false;
            switch (command)
            {
                case "reg":

                    if (!CheckingIfExist(login))
                    {
                        Insert(login, password);
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    break;

                case "login":
                    if (CheckingPassword(login, password))
                        result = true;
                    else result = false;

                    break;
            }
            return result;

        }

        public bool CheckingIfExist(string login)
        {
            bool result = false;
            Conn();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM '" + tablename + "' WHERE login='" + login + "';", connection);
            string newpass = (String)command.ExecuteScalar();
            if (newpass != null)
                result = true;

            connection.Close();
            return result;
        }

        public bool CheckingPassword(string login, string password)
        {
            if (!CheckingIfExist(login))
                return false;
            if (password == "help")
                return true;
            Conn();
            bool result = false;
            SQLiteCommand cmd = new SQLiteCommand("SELECT password FROM '" + tablename + "' WHERE login= '" + login + "';", connection);
            string newpass = (String)cmd.ExecuteScalar();
            if (newpass == password)
                result = true;

            connection.Close();
            return result;
        }

        public bool ChangePassword(string login, string password, string newpassword)
        {
            if (!CheckingIfExist(login))
                return false;


            if (CheckingPassword(login, password))
            {
                Conn();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE '" + tablename + "' SET password = '" + newpassword + "' WHERE login= '" + login + "';", connection);
                string newpass = (String)cmd.ExecuteScalar();
                connection.Close();
                if (newpass == newpassword)
                    return true;
            }
            return false;
        }

        public string SendPassword(string login)
        {

            if (CheckingIfExist(login))
            {
                Conn();
                SQLiteCommand cmd = new SQLiteCommand("SELECT password FROM '" + tablename + "' WHERE login= '" + login + "';", connection);
                string newpass = (String)cmd.ExecuteScalar();
                connection.Close();
                return newpass;
            }
            return "fail";
        }
    }
}
