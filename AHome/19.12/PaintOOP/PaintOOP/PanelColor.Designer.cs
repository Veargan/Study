namespace PaintOOP
{
    partial class PanelColor
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
            this.btColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btColor
            // 
            this.btColor.BackColor = System.Drawing.SystemColors.Menu;
            this.btColor.Location = new System.Drawing.Point(25, 32);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(144, 100);
            this.btColor.TabIndex = 0;
            this.btColor.Text = "Color";
            this.btColor.UseVisualStyleBackColor = false;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // PanelColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btColor);
            this.Name = "PanelColor";
            this.Size = new System.Drawing.Size(200, 296);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btColor;
    }
}
