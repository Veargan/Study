using System;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void but_Click(object sender, EventArgs e)
        {
            CommonDialog D;
            switch (sender.ToString())
            {
                case "System.Windows.Forms.Button, Text: Color":
                    D = new ColorDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: FolderBrows":
                    D = new FolderBrowserDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: Font":
                    D = new FontDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: OpenFile":
                    D = new OpenFileDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: SaveFile":
                    D = new SaveFileDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: PageSetup":
                    PageSetupDialog P = new PageSetupDialog();
                    P.PageSettings = new System.Drawing.Printing.PageSettings();
                    P.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: Print":
                    D = new PrintDialog();
                    D.ShowDialog();
                    break;
                case "System.Windows.Forms.Button, Text: MessBox":
                    MessageBox.Show("Sup, homie!", "Some Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
