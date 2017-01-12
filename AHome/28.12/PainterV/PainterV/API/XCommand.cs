using Painter.UserControls.VectorElements;
using Painter.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainterV
{
    public abstract class ICmd
    {
        public XCommand cmd = null;
        public abstract void Action(object sender, EventArgs e);
    }

    public class XCommand
    {
        

        public CanvasVector canvas = null;

        public ActionColor aColor;
        public ActionWidth aWidth;
        public ActionType  aType;
        public ActionSave  aSave;
        public ActionLoad  aLoad;

        public XCommand()
        {
            aColor = new ActionColor(this);
            aWidth = new ActionWidth(this);
            aType = new ActionType(this);
            aSave = new ActionSave(this);
            aLoad = new ActionLoad(this);
        }

        public XCommand(CanvasVector canvas) : this()
        {
            this.canvas = canvas;   
        }
    }

}
