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
    /// Interaction logic for SaveLoadPanel.xaml
    /// </summary>
    public partial class SaveLoadPanel : UserControl
    {
        public SaveLoadPanel()
        {
            InitializeComponent();
        }
        public SaveLoadPanel(XCommand cmd)
        {
            InitializeComponent();
            this.btnsave.Click += new RoutedEventHandler(cmd.aSave.Action);
            this.btnload.Click += new RoutedEventHandler(cmd.aLoad.Action);
        }
    }
}
