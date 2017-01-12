using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainterV.UserControls.Menu
{
    public partial class MainMenuVector : UserControl
    {
        public MainMenuVector()
        {
            InitializeComponent();
        }

        public MainMenuVector(XCommand cmd) : this()
        {
            this.MainMenu_Color.Click += new EventHandler(cmd.aColor.Action);
            this.MainMenu_PenWidth.Click += new EventHandler(cmd.aWidth.Action);
            this.MainMenu_ShapeType.Click += new EventHandler(cmd.aType.Action);
            this.MainMenu_FileSave.Click += new EventHandler(cmd.aSave.Action);
            this.MainMenu_FileOpen.Click += new EventHandler(cmd.aLoad.Action);
        }
    }
}
