using System.Windows.Forms;

namespace Paint
{
    public partial class PanelWidth : UserControl
    {
        public PanelWidth()
        {
            InitializeComponent();
        }

        public void WidthSelect(XCommand com)
        {
            this.bt1.Click += com.ActWidth.Action;
            this.bt2.Click += com.ActWidth.Action;
            this.bt3.Click += com.ActWidth.Action;
        }
    }
}
