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
    /// Interaction logic for MenuPanel.xaml
    /// </summary>
    public partial class MenuPanel : UserControl
    {
        Menu mm;
        public MenuPanel()
        {

        }
        public MenuPanel(XCommand cmd)
        {
            mm = new Menu();
            InitializeComponent();
            mm.Height = 25;
            mm.VerticalAlignment = VerticalAlignment.Top;
            grm.Children.Add(mm);

            MenuItem mt = new MenuItem();
            mt.Header = "Menu";
            mm.Items.Add(mt);

            MenuItem mc = new MenuItem();
            mc.Header = "Color";
            mt.Items.Add(mc);

            MenuItem mr = new MenuItem();
            mr.Header = "Red";
            mr.Name = "btnred";
            mr.Click += new RoutedEventHandler(cmd.aColor.Action);
            mc.Items.Add(mr);

            MenuItem mb = new MenuItem();
            mb.Header = "Blue";
            mb.Name = "btnblue";
            mb.Click += new RoutedEventHandler(cmd.aColor.Action);
            mc.Items.Add(mb);

            MenuItem mg = new MenuItem();
            mg.Header = "Green";
            mg.Name = "btngreen";
            mg.Click += new RoutedEventHandler(cmd.aColor.Action);
            mc.Items.Add(mg);

            MenuItem mtype = new MenuItem();
            mtype.Header = "Type";
            mt.Items.Add(mtype);

            MenuItem mrect = new MenuItem();
            mrect.Header = "Rect";
            mrect.Tag = 1;
            mrect.Click += new RoutedEventHandler(cmd.aType.Action);
            mtype.Items.Add(mrect);

            MenuItem mrrect = new MenuItem();
            mrrect.Header = "RoundRect";
            mrrect.Tag = 3;
            mrrect.Click += new RoutedEventHandler(cmd.aType.Action);
            mtype.Items.Add(mrrect);

            MenuItem mel = new MenuItem();
            mel.Header = "Ellipse";
            mel.Tag = 2;
            mel.Click += new RoutedEventHandler(cmd.aType.Action);
            mtype.Items.Add(mel);

            MenuItem mline = new MenuItem();
            mline.Header = "Line";
            mline.Tag = 4;
            mline.Click += new RoutedEventHandler(cmd.aType.Action);
            mtype.Items.Add(mline);

            MenuItem mcurve = new MenuItem();
            mcurve.Header = "Curve";
            mcurve.Tag = 5;
            mcurve.Click += new RoutedEventHandler(cmd.aType.Action);
            mtype.Items.Add(mcurve);

            MenuItem mwidth = new MenuItem();
            mwidth.Header = "Width";
            mt.Items.Add(mwidth);

            MenuItem m1 = new MenuItem();
            m1.Header = "1";
            m1.Tag = 1;
            m1.Click += new RoutedEventHandler(cmd.aWidth.Action);
            mwidth.Items.Add(m1);

            MenuItem m5 = new MenuItem();
            m5.Header = "5";
            m5.Tag = 5;
            m5.Click += new RoutedEventHandler(cmd.aWidth.Action);
            mwidth.Items.Add(m5);

            MenuItem m10 = new MenuItem();
            m10.Header = "10";
            m10.Tag = 10;
            m10.Click += new RoutedEventHandler(cmd.aWidth.Action);
            mwidth.Items.Add(m10);

            MenuItem mfile = new MenuItem();
            mfile.Header = "File";
            mt.Items.Add(mfile);

            MenuItem msave = new MenuItem();
            msave.Header = "Save";
            msave.Click += new RoutedEventHandler(cmd.aSave.Action);
            mfile.Items.Add(msave);

            MenuItem mload = new MenuItem();
            mload.Header = "Load";
            mload.Click += new RoutedEventHandler(cmd.aLoad.Action);
            mfile.Items.Add(mload);

            MenuItem mtab = new MenuItem();
            mtab.Header = "New tab";
            mtab.Click += new RoutedEventHandler(AddTab);
            mt.Items.Add(mtab);
        }

        public void AddTab(object sender, EventArgs e)
        {
            TabPanel.SelfRef.AddTab();
        }
    }
}
