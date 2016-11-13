using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WEB.NUnitTests
{
    public class HTMLTest
    {
        private IWebDriver driverGC;
        private string res;

        [SetUp]
        protected void SetUp()
        {
            driverGC = new ChromeDriver();
            res = "";
        }

        [TearDown]
        public void TearDown()
        {
            driverGC.Quit();
            driverGC = null;
        }

        [Test]
        public void HTMLShouldReturnCorrectValuePlus()
        {
            driverGC.Navigate().GoToUrl("file:///C:/Users/Svyatoslav/GitHub/Study/CalculatorJS/www/index.html");

            driverGC.FindElement(By.Id("a")).SendKeys("-4");
            driverGC.FindElement(By.Id("op")).SendKeys("+");
            driverGC.FindElement(By.Id("b")).SendKeys("6");
            driverGC.FindElement(By.Id("btn")).Click();

            res = driverGC.FindElement(By.Id("oc")).GetAttribute("value");

            Assert.AreEqual("2", res);
        }

        [Test]
        public void HTMLShouldReturnCorrectValueMinus()
        {
            driverGC.Navigate().GoToUrl("file:///C:/Users/Svyatoslav/GitHub/Study/CalculatorJS/www/index.html");

            driverGC.FindElement(By.Id("a")).SendKeys("3");
            driverGC.FindElement(By.Id("op")).SendKeys("-");
            driverGC.FindElement(By.Id("b")).SendKeys("5");
            driverGC.FindElement(By.Id("btn")).Click();

            res = driverGC.FindElement(By.Id("oc")).GetAttribute("value");

            Assert.AreEqual("-2", res);
        }

        [Test]
        public void HTMLShouldReturnCorrectValueMultiply()
        {
            driverGC.Navigate().GoToUrl("file:///C:/Users/Svyatoslav/GitHub/Study/CalculatorJS/www/index.html");

            driverGC.FindElement(By.Id("a")).SendKeys("5");
            driverGC.FindElement(By.Id("op")).SendKeys("*");
            driverGC.FindElement(By.Id("b")).SendKeys("3");
            driverGC.FindElement(By.Id("btn")).Click();

            res = driverGC.FindElement(By.Id("oc")).GetAttribute("value");

            Assert.AreEqual("15", res);
        }

        [Test]
        public void HTMLShouldReturnCorrectValueDivide()
        {
            driverGC.Navigate().GoToUrl("file:///C:/Users/Svyatoslav/GitHub/Study/CalculatorJS/www/index.html");

            driverGC.FindElement(By.Id("a")).SendKeys("1");
            driverGC.FindElement(By.Id("op")).SendKeys("/");
            driverGC.FindElement(By.Id("b")).SendKeys("2"); 
            driverGC.FindElement(By.Id("btn")).Click();

            res = driverGC.FindElement(By.Id("oc")).GetAttribute("value");

            Assert.AreEqual("0.5", res);
        }
    }
}