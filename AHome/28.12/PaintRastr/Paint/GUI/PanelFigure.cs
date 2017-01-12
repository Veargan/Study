using System.Windows.Forms;

namespace Paint
{
    public partial class PanelFigure : UserControl
    {
        public PanelFigure()
        {
            InitializeComponent();
        }

        public void FigureSelect(XCommand com)
        {
            this.bRect.Click += com.ActType.Action;
            this.bEll.Click += com.ActType.Action;
            this.bRound.Click += com.ActType.Action;
            this.bLine.Click += com.ActType.Action;
            this.bCurve.Click += com.ActType.Action;
        }
    }
}
