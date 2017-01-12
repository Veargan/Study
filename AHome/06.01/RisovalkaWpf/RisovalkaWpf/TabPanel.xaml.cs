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
    /// Interaction logic for TabPanel.xaml
    /// </summary>
    public partial class TabPanel : UserControl
    {
        public XCommand cmd;
        public PaintPanel panelPaint;
        public TabPanel()
        {
            InitializeComponent();
        }

        public TabPanel(XCommand cmd)
        {
            InitializeComponent();
            this.cmd = cmd;
            SelfRef = this;

            AddTab();

            tabControl.SelectionChanged += SelectTab;
        }

        private void SelectTab(object sender, SelectionChangedEventArgs e)
        {
            TabItem ti = tabControl.SelectedItem as TabItem;
            cmd.pp = (PaintPanel)ti.Content;
            PaintPanel pl = (PaintPanel)ti.Content as PaintPanel;
            cmd.data = pl.data;
        }

        public static TabPanel SelfRef
        {
            get; set;
        }

        public TabPanel getPanelTab()
        {
            return this;
        }

        public void AddTab()
        {
            panelPaint = new PaintPanel(cmd);
            panelPaint.Margin = new Thickness(0, 0, 0, 0);
            tabControl.Items.Add(new TabItem
            {
                Header = "tab " + (tabControl.Items.Count + 1),
                Content = panelPaint
            });
        }
    }
}
