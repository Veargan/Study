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
    public partial class TypePanel : UserControl
    {
        public xData data;
        public TypePanel(XCommand cmd)
        {
            InitializeComponent();
            this.btnrect.Click += new System.EventHandler(cmd.aType.Action);
            this.btnoval.Click += new System.EventHandler(cmd.aType.Action);
            this.btnline.Click += new System.EventHandler(cmd.aType.Action);
            this.btncurve.Click += new System.EventHandler(cmd.aType.Action);
            this.btnroundrect.Click += new System.EventHandler(cmd.aType.Action);
        }     
    }
}
