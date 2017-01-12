using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Paint
{                 
    public partial class PaintPanel : UserControl
    {
        bool pressed = false;
        int x = 0;
        int y = 0;
        public XData data = null;
        Button button = new Button();
        List<Shape> list = new List<Shape>();
        List<Point> ListCoord = new List<Point>();
     
        public PaintPanel()
        {
            InitializeComponent();
            data = new XData();            
        }

        private void PaintPanel_MouseDown(object sender, MouseEventArgs e)
        {
            pressed = true;
            x = e.X;
            y = e.Y;
            ListCoord.Clear();
        }

        private void PaintPanel_MouseMove(object sender, MouseEventArgs e)
        {
                x = e.X;
                y = e.Y;
                if (pressed == true)
                    ListCoord.Add(new Point(x, y));
        }

        private void PaintPanel_MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;

            if (ListCoord.Count > 0)
            {
                Shape shape = new Shape(data, ListCoord);
                this.Controls.Add(shape);
                shape.Focus();
                
                list.Add(shape);
            }
        }
        private void butSave_Click(object sender, EventArgs e)
        {           
            
        }

        private void butLoad_Click(object sender, EventArgs e)
        {
                        
        }
    }
}
