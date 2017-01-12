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
    /// Interaction logic for PaintPanel.xaml
    /// </summary>
    public partial class PaintPanel : UserControl
    {
        int x;
        int y;
        public xData data = new xData();
        public XCommand cmd;
        public Figure fig = null;

        private Point prev;

        CtxMenu ctxm;
        public static PaintPanel SelfRef
        {
            get; set;
        }

        public PaintPanel()
        {          
            InitializeComponent();
        }
        public PaintPanel(XCommand cmd)
        {
            this.cmd = cmd;
            ctxm = new CtxMenu(cmd);
            InitializeComponent();
            this.cmd = cmd;
            SelfRef = this;
            this.ContextMenu = ctxm.ContextMenu;
            this.MouseMove += cmd.aStatus.Action;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            prev = Mouse.GetPosition(canvas);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (data.type != 5)
            {
                var point = Mouse.GetPosition(canvas);
                Figure r = new Figure(prev.X, prev.Y, point.X - prev.X, point.Y - prev.Y, data, cmd);
                canvas.Children.Add(r);
                FocusManager.SetFocusedElement(canvas, r);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (data.type != 5)
            {
                return;
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var point = Mouse.GetPosition(canvas);
                var line = new Line
                {
                    Stroke = data.color,
                    StrokeThickness = data.width,
                    X1 = prev.X,
                    Y1 = prev.Y,
                    X2 = point.X,
                    Y2 = point.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                };
                prev = point;
                canvas.Children.Add(line);
            }         
        }


        public List<Figures> GetMemento()
        {
            List<Figures> ff = new List<Figures>();

            foreach (Figure f in canvas.Children.OfType<Figure>())
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
                canvas.Children.Add(fg);
            }
        }       
   
    }
}
