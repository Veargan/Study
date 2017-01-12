using System.Windows.Forms;

namespace Paint
{
    public partial class PanelSL : UserControl
    {
        public PanelSL()
        {
            InitializeComponent();
        }

        public void SaveLoadSelect(XCommand com)
        {
            this.bLoad.Click += com.ActLoad.Action;
            this.bSave.Click += com.ActSave.Action;
        }
    }
}
