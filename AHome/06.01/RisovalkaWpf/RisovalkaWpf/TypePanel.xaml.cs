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
    /// Interaction logic for TypePanel.xaml
    /// </summary>
    public partial class TypePanel : UserControl
    {
        public TypePanel()
        {
            InitializeComponent();
        }

        public TypePanel(XCommand cmd)
        {
            InitializeComponent();
            this.btnrect.Click += new RoutedEventHandler(cmd.aType.Action);
            this.btnel.Click += new RoutedEventHandler(cmd.aType.Action);
            this.btnrrect.Click += new RoutedEventHandler(cmd.aType.Action);
            this.btnline.Click += new RoutedEventHandler(cmd.aType.Action);
            this.btncurve.Click += new RoutedEventHandler(cmd.aType.Action);
        }
    }
}
