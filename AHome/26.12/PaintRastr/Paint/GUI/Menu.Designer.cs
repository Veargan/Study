namespace Paint
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemRect = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEllip = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.widthToolStripMenuItem,
            this.mItemColor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemSave,
            this.mItemLoad});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mItemSave
            // 
            this.mItemSave.Name = "mItemSave";
            this.mItemSave.Size = new System.Drawing.Size(152, 22);
            this.mItemSave.Text = "Save";
            // 
            // mItemLoad
            // 
            this.mItemLoad.Name = "mItemLoad";
            this.mItemLoad.Size = new System.Drawing.Size(152, 22);
            this.mItemLoad.Text = "Load";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRect,
            this.mItemEllip,
            this.mItemLine,
            this.mItemCurve});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // mItemRect
            // 
            this.mItemRect.Name = "mItemRect";
            this.mItemRect.Size = new System.Drawing.Size(152, 22);
            this.mItemRect.Tag = "1";
            this.mItemRect.Text = "Rect";
            // 
            // mItemEllip
            // 
            this.mItemEllip.Name = "mItemEllip";
            this.mItemEllip.Size = new System.Drawing.Size(152, 22);
            this.mItemEllip.Tag = "2";
            this.mItemEllip.Text = "Ellipse";
            // 
            // mItemLine
            // 
            this.mItemLine.Name = "mItemLine";
            this.mItemLine.Size = new System.Drawing.Size(152, 22);
            this.mItemLine.Tag = "4";
            this.mItemLine.Text = "Line";
            // 
            // mItemCurve
            // 
            this.mItemCurve.Name = "mItemCurve";
            this.mItemCurve.Size = new System.Drawing.Size(152, 22);
            this.mItemCurve.Tag = "0";
            this.mItemCurve.Text = "Curve";
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Tag = "1";
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Tag = "2";
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Tag = "3";
            this.toolStripMenuItem4.Text = "3";
            // 
            // mItemColor
            // 
            this.mItemColor.Name = "mItemColor";
            this.mItemColor.Size = new System.Drawing.Size(48, 20);
            this.mItemColor.Text = "Color";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(493, 25);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemSave;
        private System.Windows.Forms.ToolStripMenuItem mItemLoad;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemRect;
        private System.Windows.Forms.ToolStripMenuItem mItemEllip;
        private System.Windows.Forms.ToolStripMenuItem mItemLine;
        private System.Windows.Forms.ToolStripMenuItem mItemCurve;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mItemColor;
    }
}
