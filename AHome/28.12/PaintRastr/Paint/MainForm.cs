using Paint.GUI;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        private XCommand command;

        public MainForm()
        {
            InitializeComponent();
            command = new XCommand(this.panelPaint1);
            panelPaint1.ContextSelect(command);
            panelPaint1.SetEventHandler(new StatusControl());
            panelColor1.ColorSelect(command);
            panelFigure1.FigureSelect(command);
            panelWidth1.WidthSelect(command);
            panelSL1.SaveLoadSelect(command);
            menu1.MenuSelect(command);
            toolBar1.ToolBarSelect(command);
        }
    }
}
