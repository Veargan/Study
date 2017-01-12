using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace RisovalkaTrue
{
    public partial class SaveLoadPanel : UserControl
    {
        public SaveLoadPanel(XCommand cmd)
        {
            InitializeComponent();
            this.btnload.Click += new System.EventHandler(cmd.aLoad.Action);
            this.btnsave.Click += new System.EventHandler(cmd.aSave.Action);
        }     
    }
}
