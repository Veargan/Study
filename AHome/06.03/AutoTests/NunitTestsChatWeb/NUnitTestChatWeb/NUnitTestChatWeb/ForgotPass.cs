using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace NUnitTestChatWeb
{
    [TestFixture]
    public class ForgotPass
    {
        ChromeDriver webDriver = new ChromeDriver();

        [OneTimeSetUp]
        public void FirstSetup()
        {
            webDriver.Navigate().GoToUrl(Constants.URL);
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

        [TestCase("Ira1", "test1@test.com", "Password was sent to your email")]
        [TestCase("Ira1", "", "Empty username or password")]
        [TestCase("", "test3@test.com", "Empty username or password")]
        //[TestCase("Ira1", "test1@@test.com", "Password was sent to your email")]
        public void Forgot(string login, string email, string alert)
        {
            var forgot = webDriver.FindElementById("forgot");
            forgot.Click();
            var log = webDriver.FindElementById("loginforgot");
            log.SendKeys(login);
            var mail = webDriver.FindElementById("emailforgot");
            mail.SendKeys(email);
            var remind = webDriver.FindElementById("remind");
            remind.Click();
            Thread.Sleep(7000);
            string result = webDriver.SwitchTo().Alert().Text;
            Thread.Sleep(2000);
            webDriver.SwitchTo().Alert().Accept();
            Assert.AreEqual(alert, result);


        }
    }
}
