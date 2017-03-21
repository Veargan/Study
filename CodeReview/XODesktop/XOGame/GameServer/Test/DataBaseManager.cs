using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class DataBaseManager
    {
        string databaseName = @"D:\XOACCOUNTDB.db";
        string tablename = "PersonalData";
        SQLiteConnection connection;
        public DataBaseManager() { }
        public void Conn()
        {
            connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }

        internal void Dafault()
        {
            Conn();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM '" + tablename + "' WHERE login!='mike' AND login!='ilya' AND login!='oleg';", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Insert(string login, string password)
        {
            Conn();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO '" + tablename + "' ('login', 'password') VALUES ('" + login + "','" + password + "');", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool Login(string login, string password)
        {
            if (CheckingPassword(login, password))
                return  true;
            else
                return  false;
        }

        public bool Register(string login, string password)
        {
            if (!CheckingIfExist(login))
            {
                Insert(login, password);
                return true;
            }
            else
                return false;
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
            if (CheckingPassword(login, password))
            {
                Conn();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE '" + tablename + "' SET password = '" + newpassword + "' WHERE login= '" + login + "';", connection);
                cmd.ExecuteScalar();
                connection.Close();
                            
                return CheckingPassword(login, newpassword);
            }
            return false;
        }

        public string SendPas(string login)
        {
            if (CheckingIfExist(login))
            {
                Conn();
                SQLiteCommand cmd = new SQLiteCommand("SELECT password FROM '" + tablename + "' WHERE login= '" + login + "';", connection);
                string newpass = (string)cmd.ExecuteScalar();
                connection.Close();
                return newpass;
            }
            return "fail";            
        }

        public bool SendPassword(string login, string mail)
        {
            bool result = true;

            string newpass = SendPas(login);
            if (newpass == "fail")
                return false;
                        
            return result;
        }
    }
}
