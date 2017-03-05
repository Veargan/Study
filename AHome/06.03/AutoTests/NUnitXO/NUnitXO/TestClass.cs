using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace NUnitXO
{
    [TestFixture]
    public class TestClass
    {


        [Test]
        public void a_LoginUsers_Invite_Game()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "file:///D:/DOWNLOADS/XOGameNew/XOGame/xoClient.html";

            driver.FindElement(By.Id("txt_login1")).SendKeys("first");
            driver.FindElement(By.Id("txt_password")).SendKeys("123");
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("#btn_login")).Click();

           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lbl_name")));


            IWebDriver driver2 = new ChromeDriver();
            driver2.Url = "file:///D:/DOWNLOADS/XOGameNew/XOGame/xoClient.html";
            driver2.FindElement(By.Id("txt_login1")).SendKeys("second");
            driver2.FindElement(By.Id("txt_password")).SendKeys("123");
            Thread.Sleep(500);
            driver2.FindElement(By.Id("btn_login")).Click();


            Thread.Sleep(500);
            driver2.FindElement(By.Id("first")).Click();
            Thread.Sleep(500);
            driver2.FindElement(By.Id("invite")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();

            //var res = driver.FindElement(By.Id("0")).Enabled;
            //Assert.AreEqual(res, true);

            /*
            var go = driver.FindElement(By.CssSelector("#lbl_turn[value = 'Your turn']")).Displayed;
            var wait = driver.FindElement(By.CssSelector("#lbl_turn[value = 'Not Your turn']")).Displayed;
            if (go == true)
            {
                driver.FindElement(By.Id("0")).Click();
            }
            else
            {
                driver2.FindElement(By.Id("0")).Click();
            }   */


            Thread.Sleep(500);
            driver.FindElement(By.Id("1")).Click();
            Thread.Sleep(500);
            driver2.FindElement(By.Id("5")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.Id("4")).Click();
            Thread.Sleep(500);
            driver2.FindElement(By.Id("2")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.Id("7")).Click();

            driver.SwitchTo().Alert().Accept();
            driver2.SwitchTo().Alert().Accept();
              
        }




        [Test]
        public void c_Registration()
        {
            IWebDriver driver3 = new ChromeDriver();
            driver3.Url = "file:///D:/DOWNLOADS/XOGameNew/XOGame/xoClient.html";
            driver3.FindElement(By.Id("btn_reg")).Click();
            driver3.FindElement(By.Id("txt_login2")).SendKeys("shark11");
            driver3.FindElement(By.Id("txt_password1")).SendKeys("111");
            driver3.FindElement(By.Id("txt_password2")).SendKeys("111");
            Thread.Sleep(500);
            driver3.FindElement(By.CssSelector("#btn_reg[value = 'Register']")).Click();

            Thread.Sleep(500);
            driver3.SwitchTo().Alert().Accept();

            Thread.Sleep(700);
            driver3.FindElement(By.Id("logout")).Click();
            driver3.Close();

        }

        [Test]
        public void d_ChangePassword()
        {
            IWebDriver driver4 = new ChromeDriver();
            driver4.Url = "file:///D:/DOWNLOADS/XOGameNew/XOGame/xoClient.html";
            driver4.FindElement(By.Id("lbl_change")).Click();
            driver4.FindElement(By.Id("txt_login3")).SendKeys("shark8");
            driver4.FindElement(By.Id("txt_oldPas")).SendKeys("111");
            driver4.FindElement(By.Id("txt_newPas")).SendKeys("123");
            Thread.Sleep(500);
            driver4.FindElement(By.Id("btn_change")).Click();

            WebDriverWait wait = new WebDriverWait(driver4, TimeSpan.FromSeconds(10));
            IAlert element = wait.Until(ExpectedConditions.AlertIsPresent());
            element.Accept();
            

            //driver4.Close();
        }
        [Test]
        public void e_ForgotPassword()
        {
            IWebDriver driver5 = new ChromeDriver();
            driver5.Url = "file:///D:/DOWNLOADS/XOGameNew/XOGame/xoClient.html";
            Thread.Sleep(500);
            driver5.FindElement(By.Id("lbl_forgot")).Click();
            driver5.FindElement(By.Id("txt_login4")).SendKeys("shark7");
            driver5.FindElement(By.Id("txt_email")).SendKeys("pass123@gmail.com");
            Thread.Sleep(500);
            driver5.FindElement(By.Id("btn_send")).Click();

            WebDriverWait wait = new WebDriverWait(driver5, TimeSpan.FromSeconds(10));
            IAlert element = wait.Until(ExpectedConditions.AlertIsPresent());
            element.Accept();
            
            //driver5.Close();

        }

        [Test]
        public void f_()
        {
            
            

        }

    }

}