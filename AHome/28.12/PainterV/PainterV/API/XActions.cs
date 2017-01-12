using Paint.Dialogs;
using Painter;
using Painter.UserControls.VectorElements.Figures;
using Painter.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainterV
{
    public class ActionWidth : ICmd
    {
        public ActionWidth(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public override void Action(object sender, EventArgs e)
        {
            WidthDialog dlg = new WidthDialog();
            dlg.ShowDialog();
            float value = dlg.GetWidth();
            dlg.Dispose();

            cmd.canvas.data.LineWidth = value;
            if (cmd.canvas.StackControl != null)
            {
                cmd.canvas.StackControl.data.LineWidth = value;
                cmd.canvas.StackControl.DrawFigure(cmd.canvas.StackControl.data.Type);
            }
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
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            cmd.canvas.data.LineColor = dlg.Color;
            if (cmd.canvas.StackControl != null)
            {
                cmd.canvas.StackControl.data.LineColor = dlg.Color;
                cmd.canvas.StackControl.DrawFigure(cmd.canvas.StackControl.data.Type);
            }
            dlg.Dispose();
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
            ShapeTypeDialog dlg = new ShapeTypeDialog();
            dlg.ShowDialog();
            ShapeType type = dlg.GetShapeType();
            dlg.Dispose();

            if (cmd.canvas != null)
            {
                cmd.canvas.data.Type = type;
                if (cmd.canvas.StackControl != null)
                {
                    cmd.canvas.StackControl.data.Type = type;
                    cmd.canvas.StackControl.DrawFigure(type);
                }
            }
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
            try
            {
                List<Control> controls = cmd.canvas.GetMemento();

                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                DialogResult res = saveFD.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // TODO: save file
                    IFigureIO f = FigureIO_Selector.GetInstance(saveFD.FileName.Remove(0, saveFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = saveFD.FileName;
                    f.Write(controls);
                }
                saveFD.Dispose();
            }
            catch { }
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
            try
            {
                OpenFileDialog openFD = new OpenFileDialog();
                openFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                DialogResult res = openFD.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // TODO: Load file
                    IFigureIO f = FigureIO_Selector.GetInstance(openFD.FileName.Remove(0, openFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = openFD.FileName;
                    cmd.canvas.Controls.AddRange(f.Read().ToArray());
                }
                openFD.Dispose();

                DrawingVector2DTool.figures = new List<Control>();
                for (int i = 1; i < cmd.canvas.Controls.Count; ++i)
                {
                    SimpleFigures f = cmd.canvas.Controls[i] as SimpleFigures;
                    f.GainFocus += cmd.canvas.OnGainFocus;
                    f.LostFocus += cmd.canvas.OnLostFocus;

                    DrawingVector2DTool.figures.Add(cmd.canvas.Controls[i]);
                    cmd.canvas.Controls[i].BringToFront();
                }
            }
            catch { }
        }
    }
}
