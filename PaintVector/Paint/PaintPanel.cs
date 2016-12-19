using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class PaintPanel : Panel
    {
        public PaintPanel()
        {
            InitializeComponent();
            BackColor = Color.Aqua;
        }

        public PaintPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
