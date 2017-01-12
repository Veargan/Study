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
using Painter.Vector;

namespace Painter.UserControls.VectorElements
{
    public partial class SaveLoadVector : UserControl
    {
        public SaveLoadVector()
        {
            InitializeComponent();
        }


        public CanvasVector Canvas { get; set; }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            DrawingVector2DTool.SaveSelector(Canvas);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            DrawingVector2DTool.LoadSelector(Canvas);
        }

    }
}
