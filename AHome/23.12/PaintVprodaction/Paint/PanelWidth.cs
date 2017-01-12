using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class PanelWidth : UserControl
    {
        public XData data = null;
        public PanelWidth()
        {
            InitializeComponent();
        }

        private void SetWidth(object sender, EventArgs e)
        {
            data.width = Convert.ToInt32((string)((Button)sender).Tag);
        }
    }
}
