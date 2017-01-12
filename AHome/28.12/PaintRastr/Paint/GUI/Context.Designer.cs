namespace Paint.GUI
{
    partial class Context
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmColor = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWidth1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWidth2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWidth3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCRect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmLine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cmColor,
            this.widthToolStripMenuItem,
            this.typeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmSave,
            this.cmLoad});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // cmSave
            // 
            this.cmSave.Name = "cmSave";
            this.cmSave.Size = new System.Drawing.Size(152, 22);
            this.cmSave.Text = "Save";
            // 
            // cmLoad
            // 
            this.cmLoad.Name = "cmLoad";
            this.cmLoad.Size = new System.Drawing.Size(152, 22);
            this.cmLoad.Text = "Load";
            // 
            // cmColor
            // 
            this.cmColor.Name = "cmColor";
            this.cmColor.Size = new System.Drawing.Size(152, 22);
            this.cmColor.Text = "Color";
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmWidth1,
            this.cmWidth2,
            this.cmWidth3});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmRect,
            this.cmEllipse,
            this.cmCRect,
            this.cmLine,
            this.cmCurve});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // cmWidth1
            // 
            this.cmWidth1.Name = "cmWidth1";
            this.cmWidth1.Size = new System.Drawing.Size(152, 22);
            this.cmWidth1.Tag = "1";
            this.cmWidth1.Text = "1";
            // 
            // cmWidth2
            // 
            this.cmWidth2.Name = "cmWidth2";
            this.cmWidth2.Size = new System.Drawing.Size(152, 22);
            this.cmWidth2.Tag = "2";
            this.cmWidth2.Text = "2";
            // 
            // cmWidth3
            // 
            this.cmWidth3.Name = "cmWidth3";
            this.cmWidth3.Size = new System.Drawing.Size(152, 22);
            this.cmWidth3.Tag = "3";
            this.cmWidth3.Text = "3";
            // 
            // cmRect
            // 
            this.cmRect.Name = "cmRect";
            this.cmRect.Size = new System.Drawing.Size(152, 22);
            this.cmRect.Tag = "1";
            this.cmRect.Text = "Rectangle";
            // 
            // cmEllipse
            // 
            this.cmEllipse.Name = "cmEllipse";
            this.cmEllipse.Size = new System.Drawing.Size(152, 22);
            this.cmEllipse.Tag = "2";
            this.cmEllipse.Text = "Ellipse";
            // 
            // cmCRect
            // 
            this.cmCRect.Name = "cmCRect";
            this.cmCRect.Size = new System.Drawing.Size(152, 22);
            this.cmCRect.Tag = "3";
            this.cmCRect.Text = "CRectangle";
            // 
            // cmLine
            // 
            this.cmLine.Name = "cmLine";
            this.cmLine.Size = new System.Drawing.Size(152, 22);
            this.cmLine.Tag = "4";
            this.cmLine.Text = "Line";
            // 
            // cmCurve
            // 
            this.cmCurve.Name = "cmCurve";
            this.cmCurve.Size = new System.Drawing.Size(152, 22);
            this.cmCurve.Tag = "0";
            this.cmCurve.Text = "Curve";
            // 
            // ContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ContextMenu";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmSave;
        private System.Windows.Forms.ToolStripMenuItem cmLoad;
        private System.Windows.Forms.ToolStripMenuItem cmColor;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmWidth1;
        private System.Windows.Forms.ToolStripMenuItem cmWidth2;
        private System.Windows.Forms.ToolStripMenuItem cmWidth3;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmRect;
        private System.Windows.Forms.ToolStripMenuItem cmEllipse;
        private System.Windows.Forms.ToolStripMenuItem cmCRect;
        private System.Windows.Forms.ToolStripMenuItem cmLine;
        private System.Windows.Forms.ToolStripMenuItem cmCurve;
    }
}
