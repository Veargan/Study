using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace NUnitTestChatWeb
{
    [TestFixture]
    public class AuthTest
    {
        ChromeDriver webDriver = new ChromeDriver();

        [OneTimeSetUp]
        public void FirstSetup()
        {
            webDriver.Navigate().GoToUrl(Constants.URL);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [SetUp]
        public void SetUp()
        {
            //Thread.Sleep(2000);
            webDriver.Navigate().Refresh();
        }

        [OneTimeTearDown]
        public void Exit()
        {
            webDriver.Quit();
        }

        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("3", "3")]
        [TestCase("4", "4")]
        [TestCase("5", "5")]
        public void AuthCheck(string log, string pass)
        {
            
            var login = webDriver.FindElementById("login");
            login.SendKeys(log);
            var password = webDriver.FindElementById("password");
            password.SendKeys(pass);
            var auth  = webDriver.FindElementById("auth");
            auth.Click();
            Thread.Sleep(1000);
            var logout = webDriver.FindElementById("logout");
            bool result = logout.Displayed;
            Assert.AreEqual(true, result);
            logout.Click();
            Thread.Sleep(1000);
        }
    }
}
