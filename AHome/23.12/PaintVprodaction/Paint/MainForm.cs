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
            this.panelColor2.data = data;
            this.panelWidth2.data = data;
            this.panelPaint2.data = data;
            this.panelFigure2.data = data;
            this.menu2.data = data;
            this.toolBar2.data = data;
            this.contextMenu1.data = data;
        }
    }
}
