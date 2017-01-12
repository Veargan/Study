using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Paint
{
    public partial class 
        
        Paintbox : Form
    {
        private XData data;
        
        public Paintbox()
        {
            InitializeComponent();
            data = new XData();
            data.path = "D:\\paint.png";
            this.widthPanel1.data = data;
            this.colorPanel1.data = data;
            this.figurePanel1.data = data;
            this.paintPanel1.data = data;
            
        }

        private void paintPanel1_Enter(object sender, EventArgs e)
        {

        }

        private void paintPanel1_Leave(object sender, EventArgs e)
        {

        }      
    }
}
