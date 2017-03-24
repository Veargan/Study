using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public class API_Auth
    {
        private ClientManager cm;
        private PlayersList pl;
        private FormLogin FL;
        private FormRestorePassword RP;
        private FormChangePass CP;
        public API_Auth()
        {
            cm = new ClientManager();
            pl = new PlayersList();
            FL = new FormLogin(this);
            Application.Run(FL);
        }

        #region Login/Auth
        public bool btnLogin(string login, string password, string oper)
        {
            try
            {
                if (Checkinput(login) && Checkinput(password))
                {
                    cm.Connect(pl);
                    Thread.Sleep(500);
                    cm.SendLogin(login, password, oper);
                    Thread.Sleep(500);
                    if (!(pl.lb_name.Text == "label1"))
                    {
                        pl.Show();
                        return true;
                    }
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
            return false;
        }        

        public void btnExternalAuth(string type)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Auth(type);
            if (info[0] == null)
                return;

            string name = auth.Tr(info[0]);

            cm.Connect(pl);
            Thread.Sleep(500);
            cm.SendLogin(name, info[1], type);
            Thread.Sleep(500);
        }
        #endregion

        #region Change Pass
        public void bntChangePass()
        {
            CP = new FormChangePass(this);
            CP.Show();
        }
        public void ChangePass(string login, string password, string newpassword)
        {
            try
            {
                if (Checkinput(login) && Checkinput(password) && Checkinput(newpassword))
                {
                    cm.Connect(pl);
                    cm.ChangePas(login, password, newpassword);
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }
        #endregion

        #region Restore Pass
        public void bntRestorePass()
        {
            RP = new FormRestorePassword(this);
            RP.Show();
        }

        public void RestorePass(string login, string email)
        {
            try
            {
                if (Checkinput(login) && Regex.IsMatch(email, @"^[a-zA-Z0-9]+$"))
                {
                    cm.Connect(pl);
                    cm.Restore(login, email);
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
        }
        #endregion
        private bool Checkinput(string text)
        {
            if (text == "")
            {
                MessageBox.Show("Empty field!");
                return false;
            }

            if (!(Regex.IsMatch(text, @"^[a-zA-Z0-9]+$")))
            {
                MessageBox.Show("Incorrect symbols!");
                return false;
            }
            else if (text.Length > 20)
            {
                MessageBox.Show("Login and password must be shorter than 20 symbols!");
                return false;
            }
            else return true;
        }
    }
}
