using PainterV;
using PainterV.UserControls.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class MiniPaintV : Form
    {
        public MiniPaintV()
        {
            InitializeComponent();
            cmd.canvas = canvasVector;
            canvasVector.cmd = cmd;
            canvasVector.SetCanvasMouseMoveEventHandler(statusBar);
        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control)
                        DrawingVector2DTool.SaveSelector(canvasVector);
                    break;
                case Keys.O:
                    if (e.Control)
                        DrawingVector2DTool.LoadSelector(canvasVector);
                    break;
                case Keys.C:
                    if (e.Control)
                        DrawingVector2DTool.ColorSelector(canvasVector);
                    break;
            }
        }

    }
}
