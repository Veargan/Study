using Paint.API;
using System;
using System.Windows.Forms;

namespace Paint
{
    public class XCommand
    {
        public ActionColor ActColor { set; get; }
        public ActionWidth ActWidth { set; get; }
        public ActionType ActType { set; get; }
        public ActionSave ActSave { set; get; }
        public ActionLoad ActLoad { set; get; }

        public XCommand(PanelPaint canvas)
        {
            ActColor = new ActionColor();
            ActWidth = new ActionWidth();
            ActType = new ActionType();
            ActSave = new ActionSave(canvas);
            ActLoad = new ActionLoad(canvas);
        }

        public interface IAction
        {
            void Action(object sender, EventArgs e);
        }

        public class ActionColor : IAction
        {
            public void Action(object sender, EventArgs e)
            {
                ColorDialog cd = new ColorDialog();
                cd.ShowDialog();
                Drawing.data.color = cd.Color;
            }
        }
        public class ActionType : IAction
        {
            public void Action(object sender, EventArgs e)
            {
                Drawing.data.type = (ShapeType)Int32.Parse( TagItems.TagIdentity(sender) );
            }
        }
        public class ActionWidth : IAction
        {
            public void Action(object sender, EventArgs e)
            {
                Drawing.data.width = Int32.Parse( TagItems.TagIdentity(sender) );
            }
        }
    
        public class ActionSave : IAction
        {
            public PanelPaint canvas { set; get; }

            public ActionSave(PanelPaint canvas)
            {
                this.canvas = canvas;
            }

            public void Action(object sender, EventArgs e)
            {
                XSaveLoad xsl = new XSaveLoad();
                xsl.Save();
            }
        }

        public class ActionLoad : IAction
        {
            public PanelPaint canvas { set; get; }

            public ActionLoad(PanelPaint canvas)
            {
                this.canvas = canvas;
            }

            public void Action(object sender, EventArgs e)
            {
                XSaveLoad xsl = new XSaveLoad();
                xsl.Load();
            }
        }
    }
}
