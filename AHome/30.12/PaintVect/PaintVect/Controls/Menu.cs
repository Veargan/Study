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
    public partial class Menu : UserControl
    {
        public Menu(XCommand cmd)
        {
            InitializeComponent();
            this.width1.Click += new System.EventHandler(cmd.aWidth.Action);
            this.width5.Click += new System.EventHandler(cmd.aWidth.Action);
            this.width10.Click += new System.EventHandler(cmd.aWidth.Action);
            this.rectType.Click += new System.EventHandler(cmd.aType.Action);
            this.roundRectType.Click += new System.EventHandler(cmd.aType.Action);
            this.ovalType.Click += new System.EventHandler(cmd.aType.Action);
            this.lineType.Click += new System.EventHandler(cmd.aType.Action);
            this.curveType.Click += new System.EventHandler(cmd.aType.Action);
            this.redColor.Click += new System.EventHandler(cmd.aColor.Action);
            this.blueColor.Click += new System.EventHandler(cmd.aColor.Action);
            this.greenColor.Click += new System.EventHandler(cmd.aColor.Action);
            this.saveItem.Click += new System.EventHandler(cmd.aSave.Action);
            this.loadItem.Click += new System.EventHandler(cmd.aLoad.Action);
        }
    }
}
