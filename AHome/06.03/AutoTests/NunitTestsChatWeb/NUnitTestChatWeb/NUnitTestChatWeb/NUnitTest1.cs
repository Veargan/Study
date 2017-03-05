using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace NUnitTestChatWeb
{
    [TestFixture]
    public class NUnitTest1
    {
        ChromeDriver webDriver = new ChromeDriver();

        [OneTimeSetUp]
        public void FirstSetup()
        {
            webDriver.Navigate().GoToUrl(Constants.URL);
        }

        [SetUp]
        public void NewSetup()
        {
            //Thread.Sleep(2000);
            webDriver.Navigate().Refresh();

        }

        [OneTimeTearDown]
        public void Exit()
        {
            webDriver.Quit();
        }

        [TestCase("authentication")]
        [TestCase("login")]
        [TestCase("password")]
        [TestCase("auth")]
        [TestCase("reg")]
        [TestCase("forgot")]
        public void ElementsDisplayed(string ElementId)
        {
            bool result = webDriver.FindElementById(ElementId).Displayed;
            Assert.AreEqual(true, result);
        }

        [TestCase("user1", "login")]
        [TestCase("1", "password")]
        public void Auth(string text, string elementId)
        {
            var element = webDriver.FindElementById(elementId);
            element.SendKeys(text);
            Assert.AreEqual(text, element.GetAttribute("value"));

        }

    }
}
