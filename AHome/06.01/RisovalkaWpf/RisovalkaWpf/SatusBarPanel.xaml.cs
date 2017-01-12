using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RisovalkaWpf
{
    /// <summary>
    /// Interaction logic for SatusBarPanel.xaml
    /// </summary>
    public partial class SatusBarPanel : UserControl
    {
        public SatusBarPanel()
        {
            InitializeComponent();
        }
        public SatusBarPanel(XCommand cmd)
        {
            InitializeComponent();
            cmd.CoordsChanged += coordsListener;
            cmd.dataChange += UpdateColorWidthType;
        }

        void coordsListener(Point p)
        {
            lX.Content = p.X.ToString();
            lY.Content = p.Y.ToString();
        }

        void UpdateColorWidthType(xData data)
        {
            lColor.Content = data.color.ToString();
            switch (data.color.ToString())
            {
                case "#FF000000":
                    lColor.Content = "Black";
                    break;
                case "#FFFF0000":
                    lColor.Content = "Red";
                    break;
                case "#FF0000FF":
                    lColor.Content = "Blue";
                    break;
                case "#FF008000":
                    lColor.Content = "Green";
                    break;
            }
            lWidth.Content = data.width.ToString();
            switch (data.type.ToString())
            {
                case "1":
                    lType.Content = "Rect";
                    break;
                case "2":
                    lType.Content = "Ellipse";
                    break;
                case "3":
                    lType.Content = "RoundRec";
                    break;
                case "4":
                    lType.Content = "Line";
                    break;
                case "5":
                    lType.Content = "Curve";
                    break;
            }
        }
    }
}
