using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFreeze
{
    public partial class PanelLocks : UserControl
    {
        Button[,] locks = null;
        Locks l;
        public PanelLocks()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 300;

            locks = new Button[4,4];

            l = new Locks();

            for (int i = 0; i < Math.Sqrt(locks.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                {
                    locks[i, j] = new Button();
                    locks[i, j].Location = new Point(i*75, j*75);
                    locks[i, j].Height = 75;
                    locks[i, j].Width = 75;
                    locks[i, j].BackColor = Color.LightCoral;
                    locks[i, j].Tag = i.ToString() + "_" + j.ToString();
                    if(l.Get(i, j))
                        locks[i, j].Text = "-";
                    else
                        locks[i, j].Text = "|";
                    Controls.Add( locks[i,j] );
                    locks[i, j].Click += Change;
                }
            } 
        }

        private void Change(object sender, EventArgs e)
        {
            var button = sender as Button;
            string[] s = button.Tag.ToString().Split('_');
            l.ChangeRC(Int32.Parse(s[0]), Int32.Parse(s[1]));
            
            ChangeLocks();

        }

        private void ChangeLocks()
        {
            for (int i = 0; i < Math.Sqrt(locks.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                {
                    if (l.Get(i, j))
                        locks[i, j].Text = "-";
                    else
                        locks[i, j].Text = "|";
                }
            }
        }
    }
}
