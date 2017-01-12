using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_XML_Markup
{
    public partial class XMLGUIGenerator : Form
    {
        public XMLGUIGenerator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Generate GUI
            XMLInterpreter.GUIGenarator.PathToLayout = Resources.layout_painter;
            this.Controls.Add(XMLInterpreter.GUIGenarator.GetMemento());

            this.Width = this.Controls[1].Width + 16;
            this.Height = this.Controls[1].Height + 23 + 16;

            button.Hide();
        }
    }

    internal static class Resources
    {
        public const string layout_calculator = @"D:\Projects\CSharpPrograms\ORT\Resources\calculator.xml";
        public const string layout_painter = @"D:\Projects\CSharpPrograms\ORT\Resources\painter.xml";
    }
}
