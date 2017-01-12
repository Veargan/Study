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
    /// Interaction logic for ColorData.xaml
    /// </summary>
    public partial class ColorData : UserControl
    {
        public xData data;
        public ColorData()
        {
            InitializeComponent();
        }      
        public ColorData(XCommand cmd)
        {
            InitializeComponent();
            this.btnred.Click += new RoutedEventHandler(cmd.aColor.Action);
            this.btnblue.Click += new RoutedEventHandler(cmd.aColor.Action);
            this.btngreen.Click += new RoutedEventHandler(cmd.aColor.Action);
        }
    }
}
