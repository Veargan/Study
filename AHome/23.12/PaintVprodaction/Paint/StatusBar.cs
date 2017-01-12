using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class StatusBar : UserControl
    {
        public XData data;
        Timer t;
        PanelPaint pp;
        public StatusBar()
        {
            InitializeComponent();
            InitializeAndStartTimer();
            data = new XData();
            pp = new PanelPaint();
            
        }
        private void InitializeAndStartTimer()
        {
            //t = new Timer();
            //t.Tick += Timer_Tick;
            //t.Interval = 1;
            ////t.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labCol.Text = data.color.ToString();
            labWid.Text  = "Width : " + data.width.ToString();
            labType.Text = "Type : "  + data.type.ToString();
        }

        public void GetCord(int x, int y)
        {
            labX.Text = "X: " + x;
            labY.Text = "Y: " + y;
        }
    }
}
