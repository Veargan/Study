using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisovalkaTrue
{
    public partial class WidthPanel : UserControl
    {
        public  xData data;
        public WidthPanel(XCommand cmd)
        {
            InitializeComponent();
            this.btn1.Click += new System.EventHandler(cmd.aWidth.Action);
            this.btn5.Click += new System.EventHandler(cmd.aWidth.Action);
            this.btn10.Click += new System.EventHandler(cmd.aWidth.Action);
        }     
    }
}
