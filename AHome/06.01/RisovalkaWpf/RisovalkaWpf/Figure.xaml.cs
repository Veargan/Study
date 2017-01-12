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
    /// Interaction logic for Figure.xaml
    /// </summary>
    public partial class Figure : UserControl
    {
        public double x;
        public double y;
        public double width;
        public double height;
        public xData data = null;
        private Point prev;

        Point anchorPoint;
        Point currentPoint;
        bool isInDrag = false;

        private TranslateTransform transform = new TranslateTransform();


        public Figure()
        {
            InitializeComponent();
        }

        public Figures GetMemento()
        {
            string colorstr = string.Format("{0:X2}{1:X2}{2:X2}", data.color.Color.R, data.color.Color.G, data.color.Color.B);
            return new Figures(x, y, width, height, data.width, data.type, colorstr);
        }
        public void SetMemento(Figures f)
        {    
            this.Margin = new Thickness(f.x, f.y, 0, 0);
            this.Height = f.height;
            this.Width = f.width;     
            data = new xData();
            data.width = f.dwidth;
            data.type = f.dtype;
            string R = f.dcolor[0].ToString() + f.dcolor[1].ToString();
            string G = f.dcolor[2].ToString() + f.dcolor[3].ToString();
            string B = f.dcolor[4].ToString() + f.dcolor[5].ToString();
            int cr = Convert.ToInt32(R);
            int cg = Convert.ToInt32(G);
            int cb = Convert.ToInt32(B);
            data.color.Color = Color.FromRgb(Convert.ToByte(cr), Convert.ToByte(cg), Convert.ToByte(cb));
            for (int i = 1; i <= 8; i++)
            {
                SizePanel sz = new SizePanel(i, Height, Width);
                Loc(i, sz);
                canvas.Children.Add(sz);
            }
        }

        public Figure(double xx, double yy, double w, double h, xData d, XCommand cmd)
        {
            InitializeComponent();
            data = d;
            x = xx;
            y = yy;
            width = w;
            height = h;
            this.Margin = new Thickness(x - data.width, y - data.width, 0, 0);
            Height = height + data.width;
            Width = width + data.width;

            this.MouseMove += cmd.aStatus.Action;
            this.MouseDown += cmd.aDataStatus.Action;
            this.GotFocus += GotF;
            this.LostFocus += grfig_LostFocus;
            this.KeyDown += KeyEvents;
            SelfRef = this;
           
            
            for (int i = 1; i <= 8; i++)
            {
                SizePanel sz = new SizePanel(i, Height, Width);
                Loc(i, sz);
                canvas.Children.Add(sz);               
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += KeyEvents;
        }

        private void KeyEvents(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top - 5, this.Margin.Right, this.Margin.Bottom);
            }
            if (e.Key == Key.A)
            {
                this.Margin = new Thickness(this.Margin.Left - 5, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            }
            if (e.Key == Key.D)
            {
                this.Margin = new Thickness(this.Margin.Left + 5, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            }
            if (e.Key == Key.S)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + 5, this.Margin.Right, this.Margin.Bottom);
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.C)
            {
                PaintPanel.SelfRef.fig = new Figure(0, 0, width, height, data, PaintPanel.SelfRef.cmd);
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.V)
            {
                if (PaintPanel.SelfRef.fig != null)
                {
                    System.Windows.Controls.Canvas c = Parent as System.Windows.Controls.Canvas;
                    c.Children.Add(PaintPanel.SelfRef.fig);
                    FocusManager.SetFocusedElement(c, PaintPanel.SelfRef.fig);
                }
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.S)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + 5, this.Margin.Right, this.Margin.Bottom);
                this.Height = this.Height - 10;
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.W)
            {
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top - 5, this.Margin.Right, this.Margin.Bottom);
                this.Height = this.Height + 10;
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.A)
            {
                this.Margin = new Thickness(this.Margin.Left + 5, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
                this.Width = this.Width - 10;
            }

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.D)
            {
                this.Margin = new Thickness(this.Margin.Left - 5, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
                this.Width = this.Width + 10;
            }
        }

        public void Loc(int number, SizePanel s)
        {
            switch (number)
            {
                case 1:
                    s.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case 2:
                    s.Margin = new Thickness((int)(Width / 2 - s.Width / 2), 0, 0, 0);
                    break;
                case 3:
                    s.Margin = new Thickness((int)(Width - s.Width), 0, 0, 0);
                    break;
                case 4:
                    s.Margin = new Thickness(0, (int)(Height / 2 - s.Height / 2), 0, 0);
                    break;
                case 5:
                    s.Margin = new Thickness((int)(Width - s.Width), (int)(Height / 2 - s.Height / 2), 0, 0);
                    break;
                case 6:
                    s.Margin = new Thickness(0, (int)(Height - s.Height), 0, 0);
                    break;
                case 7:
                    s.Margin = new Thickness((int)(Width / 2 - s.Width / 2), (int)(Height - s.Height), 0, 0);
                    break;
                case 8:
                    s.Margin = new Thickness((int)(Width - s.Width), (int)(Height - s.Height), 0, 0);
                    break;
            }
        }


        public static Figure SelfRef
        {
            set; get;
        }


        protected override void OnRender(DrawingContext dc)
        {
            int i = 1;
            foreach (var f in this.canvas.Children.OfType<SizePanel>())
            {
                Loc(i,f);
                i++;
            }
            switch (data.type)
            {
                case 1:
                    Rectangle rect = new Rectangle
                    {
                        Stroke = data.color,
                        StrokeThickness = data.width,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = this.Height,
                        Width = this.Width
                    };
                    canvas.Children.Add(rect);
                    break;
                case 2:
                    Ellipse el = new Ellipse
                    {
                        Stroke = data.color,
                        StrokeThickness = data.width,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = this.Height,
                        Width = this.Width
                    };
                    canvas.Children.Add(el);
                    break;
                case 3:
                    Rectangle rectround = new Rectangle
                    {
                        Stroke = data.color,
                        StrokeThickness = data.width,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = this.Height,
                        Width = this.Width,
                        RadiusX = 15,
                        RadiusY = 15
                    };
                    canvas.Children.Add(rectround);
                    break;
                case 4:
                    Line line = new Line
                    {
                        Stroke = data.color,
                        StrokeThickness = data.width,
                        X1 = 0,
                        Y1 = 0,
                        X2 = Width,
                        Y2 = Height,
                        StrokeStartLineCap = PenLineCap.Round,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    canvas.Children.Add(line);
                    break;
            }                       
        }     

       
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {         
            if (isInDrag)
            {                
                currentPoint = e.GetPosition(null);
                transform.X += currentPoint.X - anchorPoint.X;
                transform.Y += (currentPoint.Y - anchorPoint.Y);
                this.RenderTransform = transform;
                anchorPoint = currentPoint;
            }

        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isInDrag)
            {
                isInDrag = false;
                e.Handled = true;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(Parent, this);
            prev = Mouse.GetPosition(grfig);
            anchorPoint = e.GetPosition(null);
            isInDrag = true;
            e.Handled = true;
        }

        private void GotF(object sender, RoutedEventArgs e)
        {
            foreach (var f in this.canvas.Children.OfType<SizePanel>())
            {
                f.Visibility = Visibility.Visible;
            }
            this.Cursor = Cursors.SizeAll;
        }

        private void grfig_LostFocus(object sender, RoutedEventArgs e)
        {          
            foreach (var f in this.canvas.Children.OfType<SizePanel>())
            {
                f.Visibility = Visibility.Hidden;
            }
            this.Cursor = Cursors.Arrow;
        }     
    }
}
