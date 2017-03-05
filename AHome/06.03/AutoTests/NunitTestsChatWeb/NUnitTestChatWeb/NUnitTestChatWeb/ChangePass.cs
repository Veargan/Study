using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestChatWeb
{
    [TestFixture]

    class ChangePass
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

        [TestCase("With God help. Password has been successfully changed")]
        public void change_pass(string alert)
        {
            var btn_Change = webDriver.FindElementById("changepassbtn");
            btn_Change.Click();
            var oldPass = webDriver.FindElementById("oldpassword");
            oldPass.SendKeys("1");
            var newPass = webDriver.FindElementById("newpassword");
            newPass.SendKeys("1");
            var confirmchangepass = webDriver.FindElementById("confirmchangepass");
            confirmchangepass.Click();
            Thread.Sleep(3000);
            string result = webDriver.SwitchTo().Alert().Text;
            Thread.Sleep(3000);
            webDriver.SwitchTo().Alert().Accept();
            Assert.AreEqual(alert, result);
        }
    }
}
