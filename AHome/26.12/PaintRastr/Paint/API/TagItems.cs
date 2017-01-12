using System.Windows.Forms;

namespace Paint.API
{
    class TagItems
    {
        public static string TagIdentity(object sender)
        {
            string str = "";
            switch (sender.GetType().Name)
            {
                case "Button":
                    str = (string)((Button)sender).Tag;
                    break;
                case "ToolStripMenuItem":
                    str = (string)((ToolStripMenuItem)sender).Tag;
                    break;
                case "ToolStripButton":
                    str = (string)((ToolStripButton)sender).Tag;
                    break;
                case "ToolStripSplitButton":
                    str = (string)((ToolStripSplitButton)sender).Tag;
                    break;
            }
            return str;
        }
    }
}
