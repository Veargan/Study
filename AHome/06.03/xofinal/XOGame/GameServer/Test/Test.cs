using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class Test
    {
        static List<String> CL = new List<String>() { "mike", "ilya", "oleg" };
        CommandManager CM = new CommandManager(CL);
        DataBaseManager DBM = new DataBaseManager();
        
        [SetUp]
        public void Init()
        {
            CL = new List<String>() { "mike", "ilya", "oleg" };
            DBM.Dafault();
        }

        [TestCase("login,mike,123", "login,Y,mike")]
        [TestCase("login,mike,1234", "login,N,mike,1")]
        [TestCase("login,mike123,1234", "login,N,mike123,1")]
        public void Test_Login(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("reg,vlad,123", "reg,Y,vlad")]
        [TestCase("reg,mike,1234", "reg,N,mike")]
        public void Test_Reg(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("games,ask,Yes,mike,ilya", "2")]
        [TestCase("games,ask,No,mike,ilya", "2")]
        public void Test_Ask(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("games,gamexo,mike,StopGame", "gamexo,mike,fail")]
        [TestCase("games,gamexo,ilya,StopGame", "gamexo,ilya,fail")]
        public void Test_Stop(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("games,gamexo,mike1,6", "gamexo,6,X")]
        [TestCase("games,gamexo,oleg,4", "gamexo,4,O")]
        public void Test_Turn(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("change,vlad,123,1234", "change,Y")]
        [TestCase("change,vlad,1234,123", "change,N")]
        public void Test_Change(string msg, string result)
        {
            CM.Dispatcher("reg,vlad,123");
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }

        [TestCase("forgot,mike,mike@mike", "send,Y")]
        [TestCase("forgot,vlad,vlad@vlad", "send,N")]
        public void Test_Forgot(string msg, string result)
        {
            string res = CM.Dispatcher(msg);
            Assert.AreEqual(result, res);
        }
    }
}
