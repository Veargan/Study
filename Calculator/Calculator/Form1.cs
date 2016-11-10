using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculate()
        {
            int a = Int32.Parse(aInput.Text);
            int b = Int32.Parse(bInput.Text);
            
            switch (op.Text) {
                case "+":
                    res.Text = (a + b).ToString();
                    break;
                case "-":
                    res.Text = (a - b).ToString();
                    break;
                case "*":
                    res.Text = (a * b).ToString();
                    break;
                case "/":
                    res.Text = (a / b).ToString();
                    break;
                default:
                    res.Text = "Wrong input";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate();
        }
    }
}
