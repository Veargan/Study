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
    /// Interaction logic for WidthPanel.xaml
    /// </summary>
    public partial class WidthPanel : UserControl
    {
        public WidthPanel()
        {
            InitializeComponent();
        }

        public WidthPanel(XCommand cmd)
        {
            InitializeComponent();
            this.btn1.Click += new RoutedEventHandler(cmd.aWidth.Action);
            this.btn5.Click += new RoutedEventHandler(cmd.aWidth.Action);
            this.btn10.Click += new RoutedEventHandler(cmd.aWidth.Action);
        }
    }
}
