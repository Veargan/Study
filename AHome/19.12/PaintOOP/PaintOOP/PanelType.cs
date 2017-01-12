using System;
using System.Drawing;
using System.Windows.Forms;

namespace PaintOOP
{
    public partial class PanelType : UserControl
    {
        public XData d = null;
        public PanelType()
        {
            InitializeComponent();
            BackColor = Color.WhiteSmoke;
        }
 
        private void SetType(object sender, EventArgs e)
        {
            string t = (string)((Button)sender).Tag;
            d.type = Convert.ToInt32(t);
        }
    }
}
