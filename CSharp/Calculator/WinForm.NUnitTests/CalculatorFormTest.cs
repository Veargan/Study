using NUnit.Framework;
using NUnit.Extensions.Forms;
using Calculator;

namespace WinForm.NUnitTests
{
    [TestFixture]
    public class CalculatorFormTest
    {
        private CalculatorForm cf;
        private TextBoxTester res;
        private ButtonTester btn1;
        private ButtonTester btn2;
        private ButtonTester btn3;
        private ButtonTester btn4;
        private ButtonTester btn5;
        private ButtonTester btn6;
        private ButtonTester btn7;
        private ButtonTester btn8;
        private ButtonTester btn9;
        private ButtonTester btn0;
        private ButtonTester btnPlus;
        private ButtonTester btnMinus;
        private ButtonTester btnMultiply;
        private ButtonTester btnDivide;
        private ButtonTester calculate;

        [SetUp]
        protected void SetUp()
        {
            cf = new CalculatorForm();
            btn1 = new ButtonTester("button1", cf);
            btn2 = new ButtonTester("button2", cf);
            btn3 = new ButtonTester("button3", cf);
            btn4 = new ButtonTester("button4", cf);
            btn5 = new ButtonTester("button5", cf);
            btn6 = new ButtonTester("button6", cf);
            btn7 = new ButtonTester("button7", cf);
            btn8 = new ButtonTester("button8", cf);
            btn9 = new ButtonTester("button9", cf);
            btn0 = new ButtonTester("button0", cf);
            btnPlus = new ButtonTester("buttonPlus", cf);
            btnMinus = new ButtonTester("buttonMinus", cf);
            btnMultiply = new ButtonTester("buttonMultiply", cf);
            btnDivide = new ButtonTester("buttonDivide", cf);
            calculate = new ButtonTester("calculate", cf);
            res = new TextBoxTester("res", cf);
        }

        [TearDown]
        public void TearDown()
        {
            cf = null;
            btn1 = null;
            btn2 = null;
            btn3 = null;
            btn4 = null;
            btn5 = null;
            btn6 = null;
            btn7 = null;
            btn8 = null;
            btn9 = null;
            btn0 = null;
            btnPlus = null;
            btnMinus = null;
            btnMultiply = null;
            btnDivide = null;
            res = null;
        }

        [Test]
        public void CalculateFormShouldReturnCorrectValuePlus()
        {
            btn2.FireEvent("Click");
            btn5.FireEvent("Click");
            btnPlus.FireEvent("Click");
            btn5.FireEvent("Click");
            btn0.FireEvent("Click");
            calculate.FireEvent("Click");

            Assert.AreEqual("75", res.Text);
        }

        [Test]
        public void CalculateFormShouldReturnCorrectValueMinus()
        {
            btn1.FireEvent("Click");
            btn2.FireEvent("Click");
            btn3.FireEvent("Click");
            btn4.FireEvent("Click");
            btn5.FireEvent("Click");
            btn6.FireEvent("Click");
            btn7.FireEvent("Click");
            btn8.FireEvent("Click");
            btn9.FireEvent("Click");
            btnMinus.FireEvent("Click");
            btn1.FireEvent("Click");
            btn2.FireEvent("Click");
            btn3.FireEvent("Click");
            btn4.FireEvent("Click");
            btn5.FireEvent("Click");
            btn6.FireEvent("Click");
            btn7.FireEvent("Click");
            btn8.FireEvent("Click");
            btn9.FireEvent("Click");
            btn0.FireEvent("Click");
            calculate.FireEvent("Click");

            Assert.AreEqual("-1111111101", res.Text);
        }

        [Test]
        public void CalculateFormShouldReturnCorrectValueMultiply()
        {
            btn5.FireEvent("Click");
            btn0.FireEvent("Click");
            btnMultiply.FireEvent("Click");
            btn5.FireEvent("Click");
            calculate.FireEvent("Click");
            
            Assert.AreEqual("250", res.Text);
        }

        [Test]
        public void CalculateFormShouldReturnCorrectValueDivide()
        {
            btn3.FireEvent("Click");
            btnDivide.FireEvent("Click");
            btn4.FireEvent("Click");
            calculate.FireEvent("Click");

            Assert.AreEqual("0,75", res.Text);
        }
    }
}
