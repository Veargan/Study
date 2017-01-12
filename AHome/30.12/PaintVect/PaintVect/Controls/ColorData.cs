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
    public partial class ColorData : UserControl
    {
        public xData data;
        public ColorData(XCommand cmd)
        {
            InitializeComponent();
            this.btnred.Click += new System.EventHandler(cmd.aColor.Action);
            this.btnblue.Click += new System.EventHandler(cmd.aColor.Action);
            this.btngreen.Click += new System.EventHandler(cmd.aColor.Action);
        }
    }
}
