using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestChatWeb
{
    [TestFixture]

    class PrivatMsg
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

        [OneTimeTearDown]
        public void Exit()
        {
            webDriver.Quit();
        }

        [TestCase("New private message from Ira1:  It's Privat message, baby")]
        public void privat_msg(string alert)
        {
            var user = webDriver.FindElementById("Ira1");
            user.Click();
            var privatemsg = webDriver.FindElementById("privatemsg");
            privatemsg.SendKeys("It's Privat message, baby");
            var sendprivatemsg = webDriver.FindElementById("sendprivatemsg");
            sendprivatemsg.Click();
            Thread.Sleep(3000);
            string result = webDriver.SwitchTo().Alert().Text;
            Thread.Sleep(3000);
            webDriver.SwitchTo().Alert().Accept();
            Assert.AreEqual(alert, result);
        }
    }
}
