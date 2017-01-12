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
    public partial class PaintPanel : UserControl
    {
        int x;
        int y;
        public xData data = new xData();
        public XCommand cmd = new XCommand();
        public Figure fig = null;

        public static PaintPanel SelfRef
        {
            get; set;
        }

        public PaintPanel(XCommand cmd)
        {
            this.cmd = cmd;
            InitializeComponent();
            this.ContextMenuStrip = ctxMenu1.contextMenuStrip1;
            SelfRef = this;
            this.MouseMove += cmd.aStatus.Action;
            this.KeyDown += KeyP;
        }
        
        public List<Figures> GetMemento()
        {
            List<Figures> ff = new List<Figures>();

            foreach (Figure f in Controls.OfType<Figure>())
            {
                ff.Add(f.GetMemento());
            }
            return ff;
        }
        public void SetMemento(List<Figures> ff)
        {
            foreach (var f in ff)
            {
                Figure fg = new Figure();
                fg.SetMemento(f);                           
                Controls.Add(fg);
            }
        }

        private void NewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            
        }

        private void NewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (data.type != 5)
            {
                return;
            }

            Pen pen = new Pen(data.color, data.width);
            if (e.Button == MouseButtons.Left)
            {
                Graphics gr = CreateGraphics();

                gr.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
            }            
        }

        private void NewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (data.type != 5)
            {
                Pen pen = new Pen(data.color, data.width);
                Graphics gr = CreateGraphics(); ;
                Figure r = new Figure(x, y, e.X - x, e.Y - y, data,cmd);                             
                Controls.Add(r);               
                foreach (Figure f in Controls.OfType<Figure>())
                {
                    f.LostF(f, e);
                }
                this.ActiveControl = r;
            }
        }

        public void KeyP(object sender, KeyEventArgs e)
        {           
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
            {

            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                if (fig != null)
                {
                    Controls.Add(fig);
                }
            }
        }
    }
}
