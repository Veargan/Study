using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ImageMagick;

namespace Paint
{
    public partial class PanelSL : UserControl
    {
        int format = 0;

        public PanelSL()
        {
            InitializeComponent();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            PictureBox pb = PanelPaint.SelfRef.getPictureBox();

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            PictureBox pb = PanelPaint.SelfRef.getPictureBox();

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                dlg.FileName = "Default.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(dlg.FileName);

                    pb.Image.Save(dlg.FileName);
                }
            }
        }
    }
}
