namespace RisovalkaTrue
{
    partial class PaintPanel
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
            this.ctxMenu1 = new RisovalkaTrue.CtxMenu(cmd);
            this.SuspendLayout();
            // 
            // ctxMenu1
            // 
            this.ctxMenu1.Location = new System.Drawing.Point(358, 202);
            this.ctxMenu1.Name = "ctxMenu1";
            this.ctxMenu1.Size = new System.Drawing.Size(19, 18);
            this.ctxMenu1.TabIndex = 0;
            this.ctxMenu1.Visible = false;
            // 
            // NewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.ctxMenu1);
            this.Name = "NewPanel";
            this.Size = new System.Drawing.Size(380, 223);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewPanel_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private CtxMenu ctxMenu1;
    }
}
