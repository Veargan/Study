using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        XData data = null;
        public MainForm()
        {
            InitializeComponent();
            data = new XData();
            this.panelColor1.data = data;
            this.panelWidth1.data = data;
            this.panelPaint1.data = data;
            this.panelFigure1.data = data;
        }
    }
}
