using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RisovalkaWpf
{
    public class XCommand
    {
        public abstract class ICmd
        {
            public XCommand cmd = null;
            public abstract void Action(object sender, EventArgs e);
        }

        public PaintPanel pp = null;

        public ActionColor aColor;
        public ActionWidth aWidth;
        public ActionType aType;
        public ActionSave aSave;
        public ActionLoad aLoad;
        public ActionStatus aStatus;
        public ActionDataStatus aDataStatus;
        public Point p;
        public xData d;

        public XCommand()
        {
            aColor = new ActionColor(this);
            aWidth = new ActionWidth(this);
            aType = new ActionType(this);
            aSave = new ActionSave(this);
            aLoad = new ActionLoad(this);
            aStatus = new ActionStatus(this);
            aDataStatus = new ActionDataStatus(this);
        }

        public xData data
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                dataChange(d);
            }
        }

        public Point current
        {
            get
            {
                return p;
            }
            private set
            {
                p = value;
                CoordsChanged(p);
            }
        }

        public delegate void coordDelegate(Point p);
        public event coordDelegate CoordsChanged;

        public delegate void dataChangeDel(xData d);
        public event dataChangeDel dataChange;


        public class ActionWidth : ICmd
        {
            public ActionWidth(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {
                string s = "";
                s = ((Control)sender).Tag.ToString();
                cmd.pp.data.width = Convert.ToInt32(s);
                cmd.data = cmd.pp.data;
            }
        }
        public class ActionColor : ICmd
        {
            public ActionColor(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {              
                switch (((Control)sender).Name)
                {
                    case "btnred":
                        cmd.pp.data.color = new SolidColorBrush(Colors.Red);
                        break;
                    case "btnblue":
                        cmd.pp.data.color = new SolidColorBrush(Colors.Blue);
                        break;
                    case "btngreen":
                        cmd.pp.data.color = new SolidColorBrush(Colors.Green);
                        break;
                }
                cmd.data = cmd.pp.data;
            }
        }
        public class ActionType : ICmd
        {
            public ActionType(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {                
                string s = "";
                s = ((Control)sender).Tag.ToString();
                cmd.pp.data.type = Convert.ToInt32(s);
                cmd.data = cmd.pp.data;
            }
        }
        public class ActionSave : ICmd
        {
            public ActionSave(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"E:\";
                sfd.Filter = "XML(.xml)|*.xml|CSV(.csv)|*.csv|JSON(.json)|*.json|YAML(.yaml)|*.yaml";
                if (sfd.ShowDialog() == true)
                {
                    PictureImpl.GetInstance(sfd.FileName).Save(cmd.pp.GetMemento());
                }
            }
        }
        public class ActionLoad : ICmd
        {
            public ActionLoad(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {
                FileDialog fd = new OpenFileDialog();
                fd.InitialDirectory = @"E:\";
                fd.Filter = "XML(.xml)|*.xml|CSV(.csv)|*.csv|JSON(.json)|*.json|YAML(.yml)|*.yml";
                if (fd.ShowDialog() == true)
                {
                    cmd.pp.SetMemento(PictureImpl.GetInstance(fd.FileName).Load());
                }
            }
        }

        public class ActionStatus : ICmd
        {
            public ActionStatus(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {
                if (sender is PaintPanel)
                {
                    cmd.current = Mouse.GetPosition((PaintPanel)sender);
                }
                else if (sender is Figure)
                {
                    Point location = Mouse.GetPosition((Figure)sender);
                    Point pp = new Point((sender as Figure).Margin.Left, (sender as Figure).Margin.Top);
                    cmd.current = new Point(location.X + pp.X, location.Y + pp.Y);
                }
            }
        }

        public class ActionDataStatus : ICmd
        {
            public ActionDataStatus(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public override void Action(object sender, EventArgs e)
            {
               // cmd.data = Figure.SelfRef.data;
            }
        }
    }
}
