using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisovalkaTrue
{
    public partial class StatusBar : UserControl
    {
        public xData data = new xData();
        public StatusBar(XCommand cmd)
        {
            InitializeComponent();
            SelfRef = this;
            cmd.CoordsChanged += coordsListener;
            cmd.dataChange += UpdateColorWidthType;
        }

        public static StatusBar SelfRef
        {
            get; set;
        }

        void coordsListener(Point p)
        {
            lX.Text = p.X.ToString();
            lY.Text = p.Y.ToString();
        }

        void UpdateColorWidthType(xData data)
        {
            lColor.Text = data.color.ToString();
            lWidth.Text = data.width.ToString();
            switch (data.type.ToString())
            {
                case "1":
                    lType.Text = "Rect";
                    break;
                case "2":
                    lType.Text = "Oval";
                    break;
                case "3":
                    lType.Text = "RoundRec";
                    break;
                case "4":
                    lType.Text = "Line";
                    break;
                case "5":
                    lType.Text = "Curve";
                    break;
            }
        }
    }
}
