using DynamicGUI;
using DynamicGUI.Elements;
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

namespace DinamicGUIwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnSet.Visibility = Visibility.Hidden;

            Velement el = null;
            el = Deserialize.Load();
            Show(el);
        }
        private void Show(Velement el)
        {
            MainGrip.Children.Add((ElementImpl.GetI(el) as FrameworkElement ));
          

        }
    }
}
