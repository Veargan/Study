using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace AuthServer
{
    public class DBmanager
    {
        private string databaseName = @"DBSQLITECH.db";
        private string tablename = "users";
        private SQLiteConnection connection;

        public DBmanager() { }

        public void Conn()
        {
            try
            {
                connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: Conn" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void Insert(string login, string password)
        {
            try
            {
                Conn();
                SQLiteCommand command = new SQLiteCommand("INSERT INTO '" + tablename + "' ('login', 'password') VALUES ('" + login + "','" + password + "');", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: Insert" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public bool CreateNewLogin(string login, string password, string command)
        {
            try
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
                            result = false;
                        break;

                    case "auth":
                        if (CheckingPassword(login, password))
                            result = true;
                        else
                            result = false;
                        break;

                    case "regfb":

                        if (!CheckingIfExist(login))
                        {
                            Insert(login, password);
                            result = true;
                        }
                        else
                            result = false;
                        break;

                    case "authfb":
                        if (CheckingPassword(login, password))
                            result = true;
                        else
                            result = false;

                        break;

                    case "reggl":
                        if (!CheckingIfExist(login))
                        {
                            Insert(login, password);
                            result = true;
                        }
                        else
                            result = false;
                        break;

                    case "authgl":
                        if (CheckingPassword(login, password))
                            result = true;
                        else
                            result = false;
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: CreateNewLogin" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public bool CheckingIfExist(string login)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("METHOD: CheckingIfExits" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public bool CheckingPassword(string login, string password)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("METHOD: CheckingPassword" + ex.StackTrace + ex.Message, ex.InnerException);
            }
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

        public string CheckingPassword(string login)
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
            string newpass = CheckingPassword(login);

            if (newpass == "fail")
                return false;

            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            MailAddress from = new MailAddress("tempuserscreen@gmail.com");
            MailAddress to = new MailAddress(mail);
            MailMessage Message = new MailMessage(from, to);
            Smtp.Credentials = new NetworkCredential("tempuserscreen@gmail.com", "4815162342qwerty");
            Smtp.EnableSsl = true;
            Message.Subject = "PASSWORD RESTORE";
            Message.Body = "ChatRooms: Your password is: " + newpass + "\n\rTake care and try to not forget your password again.";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try
            {
                Smtp.Send(Message);
            }
            catch (SmtpException)
            {
                Console.Write("Error. Something go wrong !");
                result = false;
            }
            return result;
        }
    }
}
