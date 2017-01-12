namespace RisovalkaTrue
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu1 = new RisovalkaTrue.Menu(cmd);
            this.newPanel1 = new RisovalkaTrue.PaintPanel(cmd);
            this.picturePanel1 = new RisovalkaTrue.SaveLoadPanel(cmd);
            this.widthPanel1 = new RisovalkaTrue.WidthPanel(cmd);
            this.typePanel1 = new RisovalkaTrue.TypePanel(cmd);
            this.colorData1 = new RisovalkaTrue.ColorData(cmd);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueColor = new System.Windows.Forms.ToolStripMenuItem();
            this.greenColor = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectType = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalType = new System.Windows.Forms.ToolStripMenuItem();
            this.lineType = new System.Windows.Forms.ToolStripMenuItem();
            this.curveType = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.width1 = new System.Windows.Forms.ToolStripMenuItem();
            this.width5 = new System.Windows.Forms.ToolStripMenuItem();
            this.width10 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar1 = new RisovalkaTrue.StatusBar(cmd);
            this.toolBar1 = new RisovalkaTrue.ToolBar(cmd);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu1
            // 
            this.menu1.Location = new System.Drawing.Point(1, 3);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(87, 36);
            this.menu1.TabIndex = 6;
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.newPanel1.Location = new System.Drawing.Point(281, 48);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(380, 185);
            this.newPanel1.TabIndex = 5;
            // 
            // picturePanel1
            // 
            this.picturePanel1.Location = new System.Drawing.Point(292, 222);
            this.picturePanel1.Name = "picturePanel1";
            this.picturePanel1.Size = new System.Drawing.Size(150, 102);
            this.picturePanel1.TabIndex = 4;
            // 
            // widthPanel1
            // 
            this.widthPanel1.Location = new System.Drawing.Point(1, 183);
            this.widthPanel1.Name = "widthPanel1";
            this.widthPanel1.Size = new System.Drawing.Size(117, 150);
            this.widthPanel1.TabIndex = 3;
            // 
            // typePanel1
            // 
            this.typePanel1.Location = new System.Drawing.Point(131, 91);
            this.typePanel1.Name = "typePanel1";
            this.typePanel1.Size = new System.Drawing.Size(124, 150);
            this.typePanel1.TabIndex = 2;
            // 
            // colorData1
            // 
            this.colorData1.Location = new System.Drawing.Point(1, 34);
            this.colorData1.Name = "colorData1";
            this.colorData1.Size = new System.Drawing.Size(124, 143);
            this.colorData1.TabIndex = 1;
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectType,
            this.ovalType,
            this.lineType,
            this.curveType});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.typeToolStripMenuItem.Text = "Type";
           
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(345, 310);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(306, 25);
            this.statusBar1.TabIndex = 7;
            // 
            // toolBar1
            // 
            this.toolBar1.Location = new System.Drawing.Point(308, 9);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(317, 30);
            this.toolBar1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 332);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.picturePanel1);
            this.Controls.Add(this.widthPanel1);
            this.Controls.Add(this.typePanel1);
            this.Controls.Add(this.colorData1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ColorData colorData1;
        private TypePanel typePanel1;
        private WidthPanel widthPanel1;
        private SaveLoadPanel picturePanel1;
        private PaintPanel newPanel1;
        private Menu menu1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem loadItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueColor;
        private System.Windows.Forms.ToolStripMenuItem greenColor;
        private System.Windows.Forms.ToolStripMenuItem rectType;
        private System.Windows.Forms.ToolStripMenuItem ovalType;
        private System.Windows.Forms.ToolStripMenuItem lineType;
        private System.Windows.Forms.ToolStripMenuItem curveType;
        private System.Windows.Forms.ToolStripMenuItem width1;
        private System.Windows.Forms.ToolStripMenuItem width5;
        private System.Windows.Forms.ToolStripMenuItem width10;
        private StatusBar statusBar1;
        private ToolBar toolBar1;
    }
}

