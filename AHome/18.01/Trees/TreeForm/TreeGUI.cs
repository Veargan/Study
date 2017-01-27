using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeForm
{
    class TreeGUI : Trees.BsTree
    {
        public void Show(Panel p)
        {
            ShowNode(root, p.CreateGraphics(), 0, p.Width, 0, p.Width / 2);
        }
        private void ShowNode(Node p, Graphics g, int left, int right, int lvl, int xp)
        {
            if (p == null)
                return;
            int x = (left + right) / 2;
            int y = ++lvl * 60;

            Pen pen = new Pen(Color.Blue, 1);

            g.DrawEllipse(pen, x, y, 20, 20);
            g.DrawString("" + p.val, new Font("Arial", 9), Brushes.Black, x, y);
            g.DrawLine(pen, x + 10, y, xp, y - 40);

            ShowNode(p.left, g, left, x, lvl, x + 10);
            ShowNode(p.right, g, x, right, lvl, x + 10);
        }
    }
}
