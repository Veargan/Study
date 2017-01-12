using System.Windows.Forms;

namespace Paint
{
    public partial class ToolBar : UserControl
    {
        public ToolBar()
        {
            InitializeComponent();
        }

        public void ToolBarSelect(XCommand com)
        {
            this.toolLoad.Click += com.ActLoad.Action;
            this.toolCol.Click += com.ActColor.Action;
            this.toolSave.Click += com.ActSave.Action;
        }
    }
}
