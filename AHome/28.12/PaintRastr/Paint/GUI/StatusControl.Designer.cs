namespace Paint.GUI
{
    partial class StatusControl
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.labColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.labWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.labType = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labCoord,
            this.labColor,
            this.labWidth,
            this.labType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(789, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labCoord
            // 
            this.labCoord.Name = "labCoord";
            this.labCoord.Size = new System.Drawing.Size(71, 22);
            this.labCoord.Text = "Coordinates";
            // 
            // labColor
            // 
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(36, 22);
            this.labColor.Text = "Color";
            // 
            // labWidth
            // 
            this.labWidth.Name = "labWidth";
            this.labWidth.Size = new System.Drawing.Size(39, 22);
            this.labWidth.Text = "Width";
            // 
            // labType
            // 
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(68, 22);
            this.labType.Text = "Shape Type";
            // 
            // StatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "StatusControl";
            this.Size = new System.Drawing.Size(789, 27);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labCoord;
        private System.Windows.Forms.ToolStripStatusLabel labColor;
        private System.Windows.Forms.ToolStripStatusLabel labWidth;
        private System.Windows.Forms.ToolStripStatusLabel labType;
    }
}
