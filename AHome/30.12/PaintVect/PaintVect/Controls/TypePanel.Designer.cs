namespace RisovalkaTrue
{
    partial class TypePanel
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
            this.btnrect = new System.Windows.Forms.Button();
            this.btnroundrect = new System.Windows.Forms.Button();
            this.btnoval = new System.Windows.Forms.Button();
            this.btnline = new System.Windows.Forms.Button();
            this.btncurve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnrect
            // 
            this.btnrect.Location = new System.Drawing.Point(38, 3);
            this.btnrect.Name = "btnrect";
            this.btnrect.Size = new System.Drawing.Size(75, 23);
            this.btnrect.TabIndex = 0;
            this.btnrect.Text = "Rect";
            this.btnrect.UseVisualStyleBackColor = true;
            // 
            // btnroundrect
            // 
            this.btnroundrect.Location = new System.Drawing.Point(38, 32);
            this.btnroundrect.Name = "btnroundrect";
            this.btnroundrect.Size = new System.Drawing.Size(75, 23);
            this.btnroundrect.TabIndex = 1;
            this.btnroundrect.Text = "RoundRect";
            this.btnroundrect.UseVisualStyleBackColor = true;
            // 
            // btnoval
            // 
            this.btnoval.Location = new System.Drawing.Point(38, 61);
            this.btnoval.Name = "btnoval";
            this.btnoval.Size = new System.Drawing.Size(75, 23);
            this.btnoval.TabIndex = 2;
            this.btnoval.Text = "Oval";
            this.btnoval.UseVisualStyleBackColor = true;
            // 
            // btnline
            // 
            this.btnline.Location = new System.Drawing.Point(38, 90);
            this.btnline.Name = "btnline";
            this.btnline.Size = new System.Drawing.Size(75, 23);
            this.btnline.TabIndex = 3;
            this.btnline.Text = "Line";
            this.btnline.UseVisualStyleBackColor = true;
            // 
            // btncurve
            // 
            this.btncurve.Location = new System.Drawing.Point(38, 119);
            this.btncurve.Name = "btncurve";
            this.btncurve.Size = new System.Drawing.Size(75, 23);
            this.btncurve.TabIndex = 4;
            this.btncurve.Text = "Curve";
            this.btncurve.UseVisualStyleBackColor = true;
            // 
            // TypePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btncurve);
            this.Controls.Add(this.btnline);
            this.Controls.Add(this.btnoval);
            this.Controls.Add(this.btnroundrect);
            this.Controls.Add(this.btnrect);
            this.Name = "TypePanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnrect;
        private System.Windows.Forms.Button btnroundrect;
        private System.Windows.Forms.Button btnoval;
        private System.Windows.Forms.Button btnline;
        private System.Windows.Forms.Button btncurve;
    }
}
