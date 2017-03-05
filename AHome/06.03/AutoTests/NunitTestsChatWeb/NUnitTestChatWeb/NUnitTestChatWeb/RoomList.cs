using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestChatWeb
{
    [TestFixture]
    public class RoomList
    {
        ChromeDriver webDriver = new ChromeDriver();
        //ChromeDriver webDriver1 = new ChromeDriver();

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

        [SetUp]
        public void NewSetup()
        {
            //Thread.Sleep(2000);
            //webDriver.Navigate().Refresh();

        }

        [OneTimeTearDown]
        public void Exit()
        {
            webDriver.Quit();
        }

        [TestCase("roomlist")]
        [TestCase("roomname")]
        [TestCase("newroom")]
        [TestCase("connectroom")]
        [TestCase("unsubscribe")]
        [TestCase("clientlist")]
        [TestCase("privatemsg")]
        [TestCase("sendprivatemsg")]
        [TestCase("logout")]
        [TestCase("changepassbtn")]
        public void ElementsDisplayed(string ElementId)
        {
            
            bool result = webDriver.FindElementById(ElementId).Displayed;
            Assert.AreEqual(true, result);
        }
    }

}
