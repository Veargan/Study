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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        xData data;
        public XCommand cmd = new XCommand();
        ColorData dt;
        PaintPanel pp;
        WidthPanel wp;
        TypePanel tp;
        SaveLoadPanel sl;
        MenuPanel mp;
        ToolBarP tbp;
        TabPanel tc;
        SatusBarPanel sbp;
        public MainWindow()
        {
            dt = new ColorData(cmd);
            pp = new PaintPanel(cmd);
            wp = new WidthPanel(cmd);
            tp = new TypePanel(cmd);
            sl = new SaveLoadPanel(cmd);
            mp = new MenuPanel(cmd);
            tbp = new ToolBarP(cmd);
            sbp = new SatusBarPanel(cmd);
            tc = new TabPanel(cmd);
            InitializeComponent();

            dt.Margin = new Thickness(10, 10, 0, 0);
            dt.Height = 200;
            dt.Width = 200;
            dt.HorizontalAlignment = HorizontalAlignment.Left;
            dt.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(dt);

            wp.Margin = new Thickness(10, 150, 0, 0);
            wp.Height = 200;
            wp.Width = 200;
            wp.HorizontalAlignment = HorizontalAlignment.Left;
            wp.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(wp);

            tp.Margin = new Thickness(140, 50, 0, 0);
            tp.Height = 200;
            tp.Width = 200;
            tp.HorizontalAlignment = HorizontalAlignment.Left;
            tp.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(tp);

            sl.Margin = new Thickness(140, 230, 0, 0);
            sl.Height = 150;
            sl.Width = 200;
            sl.HorizontalAlignment = HorizontalAlignment.Left;
            sl.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(sl);

            mp.Margin = new Thickness(0, 0, 0, 0);
            mp.Height = 25;
            mp.HorizontalAlignment = HorizontalAlignment.Left;
            mp.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(mp);

            tbp.Margin = new Thickness(240, 20, 0, 0);
            tbp.Height = 25;
            tbp.HorizontalAlignment = HorizontalAlignment.Left;
            tbp.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(tbp);

            sbp.Margin = new Thickness(278, 320, 0, 0);
            sbp.Height = 200;
            sbp.Width = 400;
            gr.Children.Add(sbp);

            //pp.Margin = new Thickness(278, 48, 0, 0);
            //pp.Height = 250;
            //pp.Width = 400;
            //gr.Children.Add(pp);

            tc.Margin = new Thickness(278, 48, 0, 0);
            tc.Height = 270;
            tc.Width = 300;
            tc.HorizontalAlignment = HorizontalAlignment.Left;
            tc.VerticalAlignment = VerticalAlignment.Top;
            gr.Children.Add(tc);

            data = new xData();
            cmd.data = data;
            cmd.pp = PaintPanel.SelfRef;
        }
    }
}
