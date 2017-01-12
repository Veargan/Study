using System;
using System.Drawing;
using System.Windows.Forms;

namespace PaintOOP
{
    public partial class PanelWidth : UserControl
    {
        public XData d = null;
        public PanelWidth()
        {
            InitializeComponent();
            BackColor = Color.WhiteSmoke;
        }
        
        private void Width(object sender, EventArgs e)
        {
            string w = (string)((Button)sender).Tag;
            d.width = Convert.ToInt32(w);
        }
    }
}
