using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class XSaveLoad
    {
        public void Save()
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

        public void Load()
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
    }
}
