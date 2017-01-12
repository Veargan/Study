namespace PaintOOP
{
    partial class PanelPaint
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
            this.SuspendLayout();
            // 
            // PanelPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PanelPaint";
            this.Size = new System.Drawing.Size(623, 404);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPaint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelPaint_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelPaint_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
