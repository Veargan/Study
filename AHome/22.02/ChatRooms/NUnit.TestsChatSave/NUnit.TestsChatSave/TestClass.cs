using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NUnit.TestsChatSave
{
    [TestFixture]
    public class NUnitAutoTestsChat

    {
        private static RemoteWebDriver driverServer;
        private static RemoteWebDriver driverClient1;
        private static RemoteWebDriver driverClient2;
        private static RemoteWebDriver driverAdmin;

       [Test]        
        public void a_server()
        {
            Thread.Sleep(500);
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Server.exe");
            driverServer = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }
        

        [Test]
        public void b_LaunchClient1()
        {
            var dc = new DesiredCapabilities();

            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Client.exe");
            driverClient1 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Thread.Sleep(500);
            var tb = driverClient1.FindElement(By.Id("tbLogin"));
            tb.SendKeys("Us1");

            Thread.Sleep(500);
            driverClient1.FindElement(By.Id("lbLog")).Click();


        }

        [Test]
        public void c_LaunchClient2()
        {
            var dc = new DesiredCapabilities();

            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Client.exe");
            driverClient2 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Thread.Sleep(500);
            var tb = driverClient2.FindElement(By.Id("tbLogin"));
            tb.SendKeys("Us2");

            Thread.Sleep(500);
            driverClient2.FindElement(By.Id("lbLog")).Click();


            //driverClient1.Close();
        }

        [Test]
        public void d_PrivateMsg()
        {
            Thread.Sleep(500);
            var listBox = driverClient2.FindElement(By.Id("lbClients"));
            listBox.FindElement(By.Name("Us1")).Click();

            Thread.Sleep(500);
            var privMsg = driverClient2.FindElement(By.Id("tbPrivateMsg"));
            privMsg.SendKeys("Hello!");

            Thread.Sleep(500);
            driverClient2.FindElement(By.Id("btnPmsg")).Click();
          
            driverClient1.FindElement(By.Name("OK")).Click();

        }

        [Test]
        public void e_NewRoomAndConnect()
        {
            Thread.Sleep(500);
            var newR = driverClient1.FindElement(By.Id("tbRoomName"));
            newR.SendKeys("room1");

            driverClient1.FindElement(By.Id("btnNew")).Click();

            var roomBox = driverClient1.FindElement(By.Id("lbRooms"));
            roomBox.FindElement(By.Name("room1")).Click();

            driverClient1.FindElement(By.Id("btnConnect")).Click();


        }

        [Test]
        public void f_RoomMsg()
        {
            Thread.Sleep(500);
            var form = driverClient2.FindElement(By.Id("RoomForm"));
            var msg = form.FindElement(By.Id("tbMessage"));
            msg.SendKeys("Hello, Us2!");

            Thread.Sleep(500);
            driverClient1.FindElement(By.Id("btnSend")).Click();

        }

        [Test]
        public void g_Unsub()
        {
            var chat = driverClient1.FindElement(By.Id("RoomForm"));
            Thread.Sleep(500);
            chat.FindElement(By.Id("btnExit")).Click();

            var roomsList = driverClient1.FindElement(By.Id("RoomsList"));
            roomsList.FindElement(By.Id("btnUnsubscribe")).Click();           
            
        }

        [Test]
        public void h_ChatLogOut()
        {
            Thread.Sleep(500);
            var chatName= driverClient2.FindElement(By.Name("RoomList: Us2"));
            chatName.FindElement(By.Id("btnLogout")).Click();
            
            driverClient1.Close();
        }

        [Test]
        [TestCase("admin","RoomList: admin")]
        public void i_LaunchClientAdmin(string name, string exp)
        {
            var dc = new DesiredCapabilities();

            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Client.exe");
            driverAdmin = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Thread.Sleep(500);
            var tb = driverAdmin.FindElement(By.Id("tbLogin"));
            tb.SendKeys(name);

            Thread.Sleep(500);
            driverAdmin.FindElement(By.Id("lbLog")).Click();

            var res = driverAdmin.FindElement(By.Id("RoomsList")).GetAttribute("Name");
            Assert.That(res == exp);


            //driverClient1.Close();
        }
        [Test]
        [TestCase("122", "You have been banned for 122 minutes")]
        public void j_ban(string time, string exp)
        {
            Thread.Sleep(500);
            var listBox = driverAdmin.FindElement(By.Id("lbClients"));
            listBox.FindElement(By.Name("Us1")).Click();

            var banTime = driverAdmin.FindElement(By.Id("tb_banTime"));
            banTime.SendKeys(time);

            Thread.Sleep(500);
            driverAdmin.FindElement(By.Id("btnBan")).Click();

            var res = driverAdmin.FindElement(By.Id("65535")).GetAttribute("Name");
            driverAdmin.FindElement(By.Name("OK")).Click();
            Assert.That(exp == res);

            //driverClient1.Close();
        }
        [Test]
        [TestCase("Us1", "You have been unbanned!")]
        public void k_unban(string name, string exp)
        {
            Thread.Sleep(500);
            var listBox = driverAdmin.FindElement(By.Id("lbClients"));
            listBox.FindElement(By.Name(name)).Click();

            Thread.Sleep(500);
            driverAdmin.FindElement(By.Id("btnUnban")).Click();
            

            var res = driverAdmin.FindElement(By.Id("65535")).GetAttribute("Name");
            driverAdmin.FindElement(By.Name("OK")).Click();
            Assert.That(exp == res);
            driverAdmin.Close();
        }

        [Test]
        [TestCase("", "Don't forget to put your username into text area!")]
        [TestCase("user12user12user12use", "RoomList: user12user12user12us")]
        public void l_Exeption(string login, string exp)
        {
            var dc = new DesiredCapabilities();

            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Client.exe");
            driverClient1 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Thread.Sleep(500);
            var name = driverClient1.FindElement(By.Id("tbLogin"));
            name.SendKeys(login); 
            driverClient1.FindElement(By.Id("lbLog")).Click();

            string res = "";
            bool logForm = driverClient1.FindElement(By.Id("LoginForm")).Enabled;
            if (!logForm)
            {
                res = driverClient1.FindElement(By.Id("65535")).GetAttribute("Name");
                driverClient1.FindElement(By.Name("OK")).Click();
            }
            else
                res = driverClient1.FindElement(By.Id("RoomsList")).GetAttribute("Name");
            driverClient1.FindElement(By.Id("btnLogout")).Click();

            Assert.That(res == exp);
            driverClient1.Close();
            
        }
    }
}






