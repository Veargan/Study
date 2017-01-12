using System.Windows.Forms;

namespace Paint.GUI
{
    public partial class Context : UserControl
    {
        public Context()
        {
            InitializeComponent();
        }

        public void ContextSelect(XCommand com)
        {
            this.cmWidth1.Click += com.ActWidth.Action;
            this.cmWidth2.Click += com.ActWidth.Action;
            this.cmWidth3.Click += com.ActWidth.Action;
            this.cmColor.Click += com.ActColor.Action;
            this.cmRect.Click += com.ActType.Action;
            this.cmEllipse.Click += com.ActType.Action;
            this.cmCRect.Click += com.ActType.Action;
            this.cmLine.Click += com.ActType.Action;
            this.cmCurve.Click += com.ActType.Action;
            this.cmSave.Click += com.ActSave.Action;
            this.cmLoad.Click += com.ActLoad.Action;
        }

        public void ShowContextMenu()
        {
            this.contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
        }
    }
}
