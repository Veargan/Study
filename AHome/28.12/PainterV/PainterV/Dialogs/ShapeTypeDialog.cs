using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter;
using Painter.UserControls.VectorElements;

namespace Paint.Dialogs
{
    public partial class ShapeTypeDialog : Form
    {
        public ShapeTypeDialog()
        {
            InitializeComponent();
            type = ShapeType.MULTILINE;
        }

        private ShapeType type;

        private void CB_ShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_ShapeType.SelectedIndex)
            {
                case 0:
                    type = ShapeType.LINE;
                    break;

                case 1:
                    type = ShapeType.MULTILINE;
                    break;

                case 2:
                    type = ShapeType.ELLIPSE;
                    break;

                case 3:
                    type = ShapeType.RECTANGLE;
                    break;

                case 4:
                    type = ShapeType.CRECTANGLE;
                    break;
            }
        }

        public ShapeType GetShapeType()
        {
            return type;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
