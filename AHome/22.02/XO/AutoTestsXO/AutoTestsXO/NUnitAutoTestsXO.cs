using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AutoTestsXO
{
    [TestFixture]
    public class NUnitAutoTestsXO
    {
        private static RemoteWebDriver driverServer;
        private static RemoteWebDriver driverClient1;
        private static RemoteWebDriver driverClient2;

        private void LaunchServer()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"D:\JackHW\QC\XO\GameServer.exe");
            driverServer = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

        private void Close(RemoteWebDriver driver)
        {
            driver.Quit();
        }

        private void LaunchClient1()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"D:\JackHW\QC\XO\GameClient.exe");
            driverClient1 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

       
        public void Sleep()
        {
            Thread.Sleep(1000);
        }


        //Проверка открытия Сервера
        [Test]
        public void aOpenServer()
        {
            bool isopen = false;

            try
            {
                LaunchServer();
                isopen = true;
            }
            catch (Exception exception)
            {
                isopen = false;
            }

            Assert.AreEqual(true, isopen);

            Close(driverServer);

        }

        //Проверка открытия Клиента 1

        [Test]
        public void bOpenClient()
        {
            bool isopen = false;

            try
            {
                LaunchServer();
                Sleep();
                LaunchClient1();
                isopen = true;
            }
            catch (Exception exception)
            {
                isopen = false;
            }

            Assert.AreEqual(true, isopen);

            Close(driverClient1);
            Close(driverServer);
        }

        [Test]
        public void cBtnLogin_Display()
        {
            LaunchServer();
            Sleep();
            LaunchClient1();
            var btn = driverClient1.FindElement(By.Id("btnLogin"));

            Assert.AreNotEqual(null, btn);

            Close(driverClient1);
            Close(driverServer);
        }

        [Test]
        public void cBtnLogin_Click()
        {
            LaunchServer();
            Sleep();
            LaunchClient1();
            driverClient1.FindElement(By.Id("btnLogin")).Click();
            var newForm = driverClient1.FindElement(By.Name("LoginForm"));

            Assert.AreNotEqual(null, newForm);

            Close(driverClient1);
            Close(driverServer);
        }

        [Test]
        [TestCase("Jack", "Jack")]
        [TestCase("J", "J")]
        [TestCase("Jaaaaaaaak", "Jaaaaaaaak")]
        [TestCase("1", "1")]
        [TestCase("123", "123")] 
        [TestCase("1234567890", "1234567890")]
        [TestCase("Ja123ck", "Ja123ck")]
        [TestCase("ВАрВАР", "ВАрВАР")] 
        [TestCase(" РР рр РР", " РР рр РР")]
        [TestCase(",", "")]
        [TestCase(".", "")]
        [TestCase("@", "")]
        [TestCase("#", "")]
        [TestCase("%", "")]
        public void dWriteName(string login, string result)
        {
            LaunchServer();
            Sleep();
            LaunchClient1();

            driverClient1.FindElement(By.Id("btnLogin")).Click();
            var texBox = driverClient1.FindElement(By.Id("tbLogin"));
            texBox.SendKeys(login);
            Assert.AreEqual(result, texBox.GetAttribute("Name"));

            Close(driverClient1);
            Close(driverServer);
        }

        [Test]
        [TestCase("", "Please, enter your name.")]
        public void dWriteNameException(string login, string result)
        {
            LaunchServer();
            Sleep();
            LaunchClient1();

            driverClient1.FindElement(By.Id("btnLogin")).Click();
            var texBox = driverClient1.FindElement(By.Id("tbLogin"));
            texBox.SendKeys(login);
            driverClient1.FindElement(By.Id("lbLog")).Click();
            Sleep();
            var mb = driverClient1.FindElement(By.Name(result));
            Assert.AreNotEqual(null, mb);
            //driverClient1.FindElement(By.Name("OK")).Click();

            Close(driverClient1);
            Close(driverServer);
        }




        [Test]
        public void aLaunchClient2()
        {
            try
            {
                LaunchServer();
                Sleep();
                LaunchClient1();
                Thread.Sleep(500);
                driverClient1.FindElement(By.Id("btnLogin")).Click();

                Thread.Sleep(500);
                var tb = driverClient1.FindElement(By.Id("tbLogin"));
                tb.SendKeys("Jack");

                Thread.Sleep(500);
                driverClient1.FindElement(By.Id("lbLog")).Click();
                var dc = new DesiredCapabilities();
                dc.SetCapability("app", @"D:\JackHW\QC\XO\GameClient.exe");
                var driverClient2 = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

                Thread.Sleep(500);
                driverClient2.FindElement(By.Id("btnLogin")).Click();

                Thread.Sleep(500);
                tb = driverClient2.FindElement(By.Id("tbLogin"));
                tb.SendKeys("Vorobey");

                Thread.Sleep(500);
                driverClient2.FindElement(By.Id("lbLog")).Click();

                Thread.Sleep(500);
                var listBox = driverClient2.FindElement(By.Id("lbPlayers"));
                listBox.FindElement(By.Name("Jack")).Click();

                driverClient2.FindElement(By.Id("btnInvite")).Click();

                Thread.Sleep(500);
                var ask_request = driverClient2.FindElement(By.Name("AskRequest"));
                ask_request.Click();
                ask_request.FindElement(By.Id("btnYes")).Click();


                string[] btns = { "btn0", "btn1", "btn2", "btn3", "btn4", "btn5", "btn6", "btn7", "btn8" };
                for (int i = 0; i < btns.Length; i++)
                {
                    var client1 = driverClient1.FindElement(By.Name("Jack"));
                    client1.Click();
                    string turn = client1.FindElement(By.Id("lb1_turner")).GetAttribute("Name");
                    if (turn == "Your Turn!")
                    {
                        client1.FindElement(By.Id(btns[i])).Click();
                    }
                    else
                    {
                        var client2 = driverClient2.FindElement(By.Name("Vorobey"));
                        client2.Click();
                        client2.FindElement(By.Id(btns[i])).Click();
                    }

                }

                Assert.AreEqual(true, true);
            }
            catch (Exception ex)
            {

                Assert.AreEqual("", ex.Message);
            }
        }


    }
}
