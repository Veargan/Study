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
    /// Interaction logic for ToolBarP.xaml
    /// </summary>
    public partial class ToolBarP : UserControl
    {
        public ToolBarP()
        {
            InitializeComponent();
        }

        public ToolBarP(XCommand cmd)
        {
            InitializeComponent();
            ComboBox col = new ComboBox();
            col.Margin = new Thickness(0, 0, 0, 0);
            col.Width = 25;
            col.HorizontalAlignment = HorizontalAlignment.Left;
            col.VerticalAlignment = VerticalAlignment.Top;
            grtb.Children.Add(col);

            ComboBoxItem cbred = new ComboBoxItem();
            cbred.Content = "Red";
            cbred.Name = "btnred";
            cbred.Selected += new RoutedEventHandler(cmd.aColor.Action);
            col.Items.Add(cbred);

            ComboBoxItem cbblue = new ComboBoxItem();
            cbblue.Content = "Blue";
            cbblue.Name = "btnblue";
            cbblue.Selected += new RoutedEventHandler(cmd.aColor.Action);
            col.Items.Add(cbblue);

            ComboBoxItem cbgreen = new ComboBoxItem();
            cbgreen.Content = "Green";
            cbgreen.Name = "btngreen";
            cbgreen.Selected += new RoutedEventHandler(cmd.aColor.Action);
            col.Items.Add(cbgreen);

            ComboBox type = new ComboBox();
            type.Margin = new Thickness(35, 0, 0, 0);
            type.Width = 25;
            type.HorizontalAlignment = HorizontalAlignment.Left;
            type.VerticalAlignment = VerticalAlignment.Top;
            grtb.Children.Add(type);

            ComboBoxItem cbrect = new ComboBoxItem();
            cbrect.Content = "Rect";
            cbrect.Tag = 1;
            cbrect.Selected += new RoutedEventHandler(cmd.aType.Action);
            type.Items.Add(cbrect);

            ComboBoxItem cbrrect = new ComboBoxItem();
            cbrrect.Content = "RoundRect";
            cbrrect.Tag = 3;
            cbrrect.Selected += new RoutedEventHandler(cmd.aType.Action);
            type.Items.Add(cbrrect);

            ComboBoxItem cbel = new ComboBoxItem();
            cbel.Content = "Ellipse";
            cbel.Tag = 2;
            cbel.Selected += new RoutedEventHandler(cmd.aType.Action);
            type.Items.Add(cbel);

            ComboBoxItem cbline = new ComboBoxItem();
            cbline.Content = "Line";
            cbline.Tag = 4;
            cbline.Selected += new RoutedEventHandler(cmd.aType.Action);
            type.Items.Add(cbline);

            ComboBoxItem cbcurve = new ComboBoxItem();
            cbcurve.Content = "Curve";
            cbline.Tag = 5;
            cbcurve.Selected += new RoutedEventHandler(cmd.aType.Action);
            type.Items.Add(cbcurve);

            ComboBox width = new ComboBox();
            width.Margin = new Thickness(70, 0, 0, 0);
            width.Width = 25;
            width.HorizontalAlignment = HorizontalAlignment.Left;
            width.VerticalAlignment = VerticalAlignment.Top;
            grtb.Children.Add(width);

            ComboBoxItem cbw1= new ComboBoxItem();
            cbw1.Content = "1";
            cbw1.Tag = 1;
            cbw1.Selected += new RoutedEventHandler(cmd.aWidth.Action);
            width.Items.Add(cbw1);

            ComboBoxItem cbw5 = new ComboBoxItem();
            cbw5.Content = "5";
            cbw5.Tag = 5;
            cbw5.Selected += new RoutedEventHandler(cmd.aWidth.Action);
            width.Items.Add(cbw5);

            ComboBoxItem cbw10 = new ComboBoxItem();
            cbw10.Content = "10";
            cbw10.Tag = 10;
            cbw10.Selected += new RoutedEventHandler(cmd.aWidth.Action);
            width.Items.Add(cbw10);
        }
    }
}
