using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestChatWeb
{
    [TestFixture]

    class ChatRoom
    {
        ChromeDriver webDriver = new ChromeDriver();

        [OneTimeSetUp]
        public void FirstSetup()
        {
            webDriver.Navigate().GoToUrl(Constants.URL);
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

        [TestCase()]
        public void chatRoom()
        {
            var newRoomName = webDriver.FindElementById("roomname");
            newRoomName.SendKeys("Room1");
            var newRoom = webDriver.FindElementById("newroom");
            newRoom.Click();
            Thread.Sleep(3000);
            var Room1 = webDriver.FindElementById("Room1");
            Room1.Click();
            var connectRoom = webDriver.FindElementById("connectroom");
            connectRoom.Click();
            Thread.Sleep(3000);
            var roommsg = webDriver.FindElementById("roommsg");
            bool result = roommsg.Displayed;
            Assert.AreEqual(true, result);
            Thread.Sleep(3000);
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
