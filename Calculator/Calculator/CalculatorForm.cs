using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private Calculation c;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = new Calculation();

            double a = Double.Parse(aInput.Text);
            double b = Double.Parse(bInput.Text);
            string op = this.op.Text;

            res.Text = c.Calculate(a, b, op);
        }
    }
}
