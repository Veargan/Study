using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintOOP
{
    public partial class Form1 : Form
    {
        private XData data;
        public Form1()
        {
            InitializeComponent();
            data = new XData();

            this.panelColor1.d = data;
            this.panelWidth1.d = data;
            this.panelPaint1.d = data;
            this.panelType1.d = data;
        }
    }
}
