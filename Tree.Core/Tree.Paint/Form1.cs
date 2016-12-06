using System;
using Tree.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tree.Core.BSTree;

namespace Tree.Paint
{
    public partial class Form1 : Form
    {
        Graphics graph;
        Pen pen;
        Font font;

        public Form1()
        {
            InitializeComponent();
            //bg arguments int
            //BufferedGraphics bg = new BufferedGraphics(100, 100, Type);
            graph = panel1.CreateGraphics();
            pen = new Pen(Color.Black, 1);
            //add FontStyle
            font = new Font(Font, new FontStyle());

            BSTree tree = new BSTree();
            tree.Init(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 });
            int x = panel1.Width / 2;
            int y = 10;
            PaintTree(tree.GetNode(), x, y);
        }

        private void PaintTree(Node p, int x, int y)
        {
            if (p == null)
                return;

            NodePaint(p.val, x, y);
            if (p.left != null)
            {
                graph.DrawLine(pen, x + 15, y + 10, x - 15, y + 50);
                graph.DrawLine(pen, x + 15, y + 10, x - 15, y + 50);
                PaintTree(p.left, x - 50, y + 50);
            }
            if (p.right != null)
            {
                graph.DrawLine(pen, x + 15, y + 30, x + 65, y + 50);
                PaintTree(p.right, x + 50, y + 50);
            }
        }

        private void NodePaint(int val, int x, int y)
        {
            //draw rectangleF
            //graph.DrawEllipse(pen, rect);
            //add brush arguments
            //graph.DrawString("" + val, font, new Brush(), x + 12, y + 20);
            //graph.Restore(graph);
        }

        //override public void Paint(Graphics g)
        //{
            
        //}
    }
}
