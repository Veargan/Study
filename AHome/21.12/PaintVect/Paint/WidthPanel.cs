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
    public partial class WidthPanel : UserControl
    {
        public XData data = new XData();

        public WidthPanel()
        {
            InitializeComponent();
            combWidth.Items.Add("1");
            combWidth.Items.Add("10");
            combWidth.Items.Add("15");
            combWidth.Items.Add("20");
            combWidth.Items.Add("30");
        }

        private void combWidth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            data.width = Convert.ToInt32(combWidth.SelectedItem);
        }
    }
}
