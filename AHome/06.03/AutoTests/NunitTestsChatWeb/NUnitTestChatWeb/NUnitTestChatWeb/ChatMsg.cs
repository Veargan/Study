using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestChatWeb
{
    [TestFixture]

    class ChatMsg
    {
        ChromeDriver webDriver = new ChromeDriver();

        [OneTimeSetUp]
        public void FirstSetup()
        {
            webDriver.Navigate().GoToUrl(Constants.URL); webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var login = webDriver.FindElementById("login");
            login.SendKeys("Ira1");
            var password = webDriver.FindElementById("password");
            password.SendKeys("1");
            var auth = webDriver.FindElementById("auth");
            auth.Click();
            Thread.Sleep(1000);
        }

        [OneTimeTearDown]
        public void Exit()
        {
            webDriver.Quit();
        }

        [Test]
        public void chatRoom()
        {
            var newRoomName = webDriver.FindElementById("roomname");
            newRoomName.SendKeys("Room2");
            var newRoom = webDriver.FindElementById("newroom");
            newRoom.Click();
            Thread.Sleep(3000);
            var Room = webDriver.FindElementById("Room2");
            Room.Click();
            var connectRoom = webDriver.FindElementById("connectroom");
            connectRoom.Click();
            Thread.Sleep(3000);
            var roommsg = webDriver.FindElementById("roommsg");
            roommsg.SendKeys("Hello,World!");
            Thread.Sleep(3000);
            var btn_send = webDriver.FindElementById("sendroommsg");
            btn_send.Click();
            var msg_txt = webDriver.FindElementById("txt_chat");
            var value = msg_txt.GetAttribute("value");
            Assert.AreEqual(true, value.Contains("Ira1: Hello,World!"));
        }

        [TestCase("txt_chat")]
        [TestCase("exit")]
        [TestCase("roommsg")]
        [TestCase("sendroommsg")]
        public void ElementsDisplayed(string ElementId)
        {

            bool result = webDriver.FindElementById(ElementId).Displayed;
            Assert.AreEqual(true, result);
        }
    }
}
