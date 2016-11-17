using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private Calculation c;
        private string op;
        private double a;
        private double b;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        #region initNumbers

        private void button1_Click(object sender, EventArgs e)
        {
            res.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            res.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            res.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            res.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            res.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            res.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            res.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            res.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            res.Text += "0";
        }

        #endregion

        private void calculate_Click(object sender, EventArgs e)
        {
            c = new Calculation();

            b = double.Parse(res.Text);
            res.Text = c.Calculate(a, b, op);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            op = "+";
            a = double.Parse(res.Text);
            res.Clear();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            op = "-";
            a = double.Parse(res.Text);
            res.Clear();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            op = "*";
            a = double.Parse(res.Text);
            res.Clear();
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            op = "/";
            a = double.Parse(res.Text);
            res.Clear();
        }
    }
}
