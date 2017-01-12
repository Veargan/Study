using System.Windows.Forms;

namespace Paint
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void MenuSelect(XCommand com)
        {
            this.mItemSave.Click += com.ActSave.Action;
            this.mItemLoad.Click += com.ActLoad.Action;
            this.mItemRect.Click += com.ActType.Action;
            this.mItemEllip.Click += com.ActType.Action;
            this.mItemLine.Click += com.ActType.Action;
            this.mItemCurve.Click += com.ActType.Action;
            this.toolStripMenuItem2.Click += com.ActWidth.Action;
            this.toolStripMenuItem3.Click += com.ActWidth.Action;
            this.toolStripMenuItem4.Click += com.ActWidth.Action;
            this.mItemColor.Click += com.ActColor.Action;
        }
    }
}
