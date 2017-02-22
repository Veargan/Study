using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Winium;
using System.IO;
using OpenQA.Selenium.Remote;

namespace AutoTestsXO
{
    class Program
    {
        static void Main(string[] args)
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"D:\JackHW\QC\XO\GameServer.exe");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }
    }
}
