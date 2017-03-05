using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
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
        [TestCase("user", "Log out")]
        [TestCase("", "Don't forget to put your username into text area!")]
        [TestCase("userruserruserruserru", "userruserruserruserr")]

        public void CheckRegistration(string login, string exp) 
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"D:\DOWNLOADS\ChatRooms_t_v3Safe\Client.exe");
            driverClient1 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var Login = driverClient1.FindElement(By.Id("tbLogin"));//ввод логина
            Login.SendKeys(login);


            driverClient1.FindElement(By.Id("lbLog")).Click();//нажатие кнопки Login

            string act = "";
            bool b = driverClient1.FindElementById("LoginForm").Enabled; //проверка что форма Authorize закрыта
            if (!b)
            {
                act = driverClient1.FindElement(By.Id("65535")).GetAttribute("Name");
                driverClient1.FindElement(By.Name("OK")).Click();
                driverClient1.Quit();

            }
            else if (b == true)
            {
                driverClient1.FindElement(By.Id("RoomsList"));
                act = driverClient1.FindElement(By.Id("btnLogout")).GetAttribute("Name");
                driverClient1.FindElement(By.Id("btnLogout")).Click();

                driverClient1.Quit();
            }
            driverClient1.Quit();
            Assert.That(act == exp);



        }        
    }
}