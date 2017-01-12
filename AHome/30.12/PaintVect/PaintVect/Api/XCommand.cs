using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisovalkaTrue
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
                if (sender is ToolStripItem)
                {
                    s = ((ToolStripItem)sender).Text;
                }
                else
                {
                    s = ((Control)sender).Text;
                }
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
                if (sender is ToolStripItem)
                {
                    switch (((ToolStripItem)sender).Text)
                    {
                        case "Red":
                            cmd.pp.data.color = Color.Red;
                            break;
                        case "Blue":
                            cmd.pp.data.color = Color.Blue;
                            break;
                        case "Green":
                            cmd.pp.data.color = Color.Green;
                            break;
                    }
                }
                else
                {
                    switch (((Control)sender).Text)
                    {
                        case "Red":
                            cmd.pp.data.color = Color.Red;
                            break;
                        case "Blue":
                            cmd.pp.data.color = Color.Blue;
                            break;
                        case "Green":
                            cmd.pp.data.color = Color.Green;
                            break;
                    }
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
                if (sender is ToolStripItem)
                {
                    switch (((ToolStripItem)sender).Text)
                    {
                        case "Rect":
                            cmd.pp.data.type = 1;
                            break;
                        case "Oval":
                            cmd.pp.data.type = 2;
                            break;
                        case "RoundRect":
                            cmd.pp.data.type = 3;
                            break;
                        case "Line":
                            cmd.pp.data.type = 4;
                            break;
                        case "Curve":
                            cmd.pp.data.type = 5;
                            break;
                    }
                }
                else
                {
                    switch (((Control)sender).Text)
                    {
                        case "Rect":
                            cmd.pp.data.type = 1;
                            break;
                        case "Oval":
                            cmd.pp.data.type = 2;
                            break;
                        case "RoundRect":
                            cmd.pp.data.type = 3;
                            break;
                        case "Line":
                            cmd.pp.data.type = 4;
                            break;
                        case "Curve":
                            cmd.pp.data.type = 5;
                            break;
                    }
                }
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
                if (sfd.ShowDialog() == DialogResult.OK)
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
                if (fd.ShowDialog() == DialogResult.OK)
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
                    cmd.current = (e as MouseEventArgs).Location;
                }
                else if (sender is Figure)
                {
                    Point location = (e as MouseEventArgs).Location;
                    Point pp = (sender as Figure).Location;
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
                cmd.data = Figure.SelfRef.data;
            }
        }
    }
}
