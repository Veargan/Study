using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisovalkaTrue
{
    public partial class MainForm : Form
    {
        xData data;
        XCommand cmd = new XCommand();
        public MainForm()
        {
            InitializeComponent();
            data = new xData();           
            cmd.data = data;
            cmd.pp = newPanel1;
        }
    }
}
