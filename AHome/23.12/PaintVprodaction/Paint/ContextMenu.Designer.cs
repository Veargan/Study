namespace Paint
{
    partial class ContextMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmColor = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWid1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWid2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWid3 = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEllip = new System.Windows.Forms.ToolStripMenuItem();
            this.cmLine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCurv = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLoadToolStripMenuItem,
            this.cmColor,
            this.widthToolStripMenuItem,
            this.typeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // saveLoadToolStripMenuItem
            // 
            this.saveLoadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmSave,
            this.cmLoad});
            this.saveLoadToolStripMenuItem.Name = "saveLoadToolStripMenuItem";
            this.saveLoadToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveLoadToolStripMenuItem.Text = "Save\\Load";
            // 
            // cmSave
            // 
            this.cmSave.Name = "cmSave";
            this.cmSave.Size = new System.Drawing.Size(100, 22);
            this.cmSave.Text = "Save";
            this.cmSave.Click += new System.EventHandler(this.cmSave_Click);
            // 
            // cmLoad
            // 
            this.cmLoad.Name = "cmLoad";
            this.cmLoad.Size = new System.Drawing.Size(100, 22);
            this.cmLoad.Text = "Load";
            this.cmLoad.Click += new System.EventHandler(this.cmLoad_Click);
            // 
            // cmColor
            // 
            this.cmColor.Name = "cmColor";
            this.cmColor.Size = new System.Drawing.Size(129, 22);
            this.cmColor.Text = "Color";
            this.cmColor.Click += new System.EventHandler(this.cmColor_Click);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmWid1,
            this.cmWid2,
            this.cmWid3});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // cmWid1
            // 
            this.cmWid1.Name = "cmWid1";
            this.cmWid1.Size = new System.Drawing.Size(80, 22);
            this.cmWid1.Tag = "1";
            this.cmWid1.Text = "1";
            this.cmWid1.Click += new System.EventHandler(this.cmWidth);
            // 
            // cmWid2
            // 
            this.cmWid2.Name = "cmWid2";
            this.cmWid2.Size = new System.Drawing.Size(80, 22);
            this.cmWid2.Tag = "2";
            this.cmWid2.Text = "2";
            this.cmWid2.Click += new System.EventHandler(this.cmWidth);
            // 
            // cmWid3
            // 
            this.cmWid3.Name = "cmWid3";
            this.cmWid3.Size = new System.Drawing.Size(80, 22);
            this.cmWid3.Tag = "3";
            this.cmWid3.Text = "3";
            this.cmWid3.Click += new System.EventHandler(this.cmWidth);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmRect,
            this.cmEllip,
            this.cmLine,
            this.cmCurv});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // cmRect
            // 
            this.cmRect.Name = "cmRect";
            this.cmRect.Size = new System.Drawing.Size(152, 22);
            this.cmRect.Tag = "1";
            this.cmRect.Text = "Rect";
            this.cmRect.Click += new System.EventHandler(this.cmType);
            // 
            // cmEllip
            // 
            this.cmEllip.Name = "cmEllip";
            this.cmEllip.Size = new System.Drawing.Size(152, 22);
            this.cmEllip.Tag = "2";
            this.cmEllip.Text = "Ellipse";
            this.cmEllip.Click += new System.EventHandler(this.cmType);
            // 
            // cmLine
            // 
            this.cmLine.Name = "cmLine";
            this.cmLine.Size = new System.Drawing.Size(152, 22);
            this.cmLine.Tag = "4";
            this.cmLine.Text = "Line";
            this.cmLine.Click += new System.EventHandler(this.cmType);
            // 
            // cmCurv
            // 
            this.cmCurv.Name = "cmCurv";
            this.cmCurv.Size = new System.Drawing.Size(152, 22);
            this.cmCurv.Tag = "0";
            this.cmCurv.Text = "Curve";
            this.cmCurv.Click += new System.EventHandler(this.cmType);
            // 
            // ContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Name = "ContextMenu";
            this.Size = new System.Drawing.Size(192, 60);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmShow);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmSave;
        private System.Windows.Forms.ToolStripMenuItem cmLoad;
        private System.Windows.Forms.ToolStripMenuItem cmColor;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmWid1;
        private System.Windows.Forms.ToolStripMenuItem cmWid2;
        private System.Windows.Forms.ToolStripMenuItem cmWid3;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmRect;
        private System.Windows.Forms.ToolStripMenuItem cmEllip;
        private System.Windows.Forms.ToolStripMenuItem cmLine;
        private System.Windows.Forms.ToolStripMenuItem cmCurv;
    }
}
