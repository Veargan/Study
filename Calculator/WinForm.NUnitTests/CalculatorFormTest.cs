using NUnit.Framework;
using NUnit.Extensions.Forms;
using Calculator;

namespace WinForm.NUnitTests
{
    [TestFixture]
    public class CalculatorFormTest
    {
        private CalculatorForm cf;
        private TextBoxTester aInput;
        private TextBoxTester op;
        private TextBoxTester bInput;
        private TextBoxTester res;
        private ButtonTester button1;

        [SetUp]
        protected void SetUp()
        {
            cf = new CalculatorForm();
            aInput = new TextBoxTester("aInput", cf);
            op = new TextBoxTester("op", cf);
            bInput = new TextBoxTester("bInput", cf);
            button1 = new ButtonTester("button1", cf);
            res = new TextBoxTester("res", cf);
        }

        [TearDown]
        public void TearDown()
        {
            cf = null;
            aInput = null;
            op = null;
            bInput = null;
            button1 = null;
            res = null;
        }

        [Test]
        public void CalculatorFormShouldReturnCorrectValuePlus()
        {
            aInput["Text"] = "-6";
            op["Text"] = "+";
            bInput["Text"] = "4";
            button1.FireEvent("Click");

            Assert.AreEqual("-2", res.Text);
        }

        [Test]
        public void CalculatorFormShouldReturnCorrectValueMinus()
        {
            aInput["Text"] = "6";
            op["Text"] = "-";
            bInput["Text"] = "2";
            button1.FireEvent("Click");

            Assert.AreEqual("4", res.Text);
        }

        [Test]
        public void CalculatorFormShouldReturnCorrectValueMultiply()
        {
            aInput["Text"] = "3,5";
            op["Text"] = "*";
            bInput["Text"] = "5";
            button1.FireEvent("Click");

            Assert.AreEqual("17,5", res.Text);
        }

        [Test]
        public void CalculatorFormShouldReturnCorrectValueDivide()
        {
            aInput["Text"] = "3";
            op["Text"] = "/";
            bInput["Text"] = "4";
            button1.FireEvent("Click");

            Assert.AreEqual("0,75", res.Text);
        }
    }
}
