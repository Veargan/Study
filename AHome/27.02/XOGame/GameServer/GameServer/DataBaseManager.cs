using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                string newpass = (String)cmd.ExecuteScalar();
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

            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            MailAddress from = new MailAddress("polarpenguin413@gmail.com");
            MailAddress to = new MailAddress(mail);
            MailMessage Message = new MailMessage(from, to);
            Smtp.Credentials = new NetworkCredential("polarpenguin413@gmail.com", "polarpenguin");
            Smtp.EnableSsl = true;
            Message.Subject = "PASSWORD RESTORE";
            Message.Body = "XOGame: Your password is: " + newpass + "\n\rTake care and try to not forget your password again.";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try
            {
                Smtp.Send(Message);                
            }
            catch (SmtpException)
            {
                Console.Write("Ошибка! Всё по пизде пошло!");
                result = false;
            }
            return result;
        }
    }
}
