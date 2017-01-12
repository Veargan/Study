using System.Windows.Forms;

namespace Paint
{
    public partial class PanelColor : UserControl
    {
        public PanelColor()
        {
            InitializeComponent();
        }

        public void ColorSelect(XCommand com)
        {
            this.btColor.Click += com.ActColor.Action;
        }
    }
}
