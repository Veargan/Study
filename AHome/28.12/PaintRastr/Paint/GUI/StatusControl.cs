using Paint.API;
using System;
using System.Windows.Forms;

namespace Paint.GUI
{
    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        public PanelPaint canvas { set; get; }

        public void EHandler(object sender, MouseEventArgs e)
        {
            var coordinates = String.Format("X({0}), Y({1})", e.X, e.Y);
            var color = Drawing.data.color.ToString();
            var width = Drawing.data.width.ToString();
            var type = Drawing.data.type.ToString();
            this.labCoord.Text = coordinates;
            this.labColor.Text = color;
            this.labWidth.Text = width;
            this.labType.Text = type;
        }

        //private void StatusSelect(int x, int y)
        //{
        //    var coordinates = String.Format("X({0}), Y({1})", x, y);
        //    var color = Drawing.data.color.ToString();
        //    var width = Drawing.data.width.ToString();
        //    var type = Drawing.data.type.ToString();
        //    this.labCoord.Text = coordinates;
        //    this.labColor.Text = color;
        //    this.labWidth.Text = width;
        //    this.labType.Text = type;
        //}

        //public void UpdateStatus(int x, int y)
        //{
        //    StatusSelect(x, y);
        //}
    }
}