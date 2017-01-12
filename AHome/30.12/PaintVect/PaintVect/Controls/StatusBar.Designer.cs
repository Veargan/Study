namespace RisovalkaTrue
{
    partial class StatusBar
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
            this.lX = new System.Windows.Forms.Label();
            this.lY = new System.Windows.Forms.Label();
            this.lColor = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.lWidth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lX
            // 
            this.lX.AutoSize = true;
            this.lX.Location = new System.Drawing.Point(3, 5);
            this.lX.Name = "lX";
            this.lX.Size = new System.Drawing.Size(35, 13);
            this.lX.TabIndex = 0;
            this.lX.Text = "label1";
            // 
            // lY
            // 
            this.lY.AutoSize = true;
            this.lY.Location = new System.Drawing.Point(44, 5);
            this.lY.Name = "lY";
            this.lY.Size = new System.Drawing.Size(35, 13);
            this.lY.TabIndex = 1;
            this.lY.Text = "label2";
            // 
            // lColor
            // 
            this.lColor.AutoSize = true;
            this.lColor.Location = new System.Drawing.Point(85, 5);
            this.lColor.Name = "lColor";
            this.lColor.Size = new System.Drawing.Size(35, 13);
            this.lColor.TabIndex = 2;
            this.lColor.Text = "label3";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(173, 5);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(35, 13);
            this.lType.TabIndex = 3;
            this.lType.Text = "label4";
            // 
            // lWidth
            // 
            this.lWidth.AutoSize = true;
            this.lWidth.Location = new System.Drawing.Point(262, 5);
            this.lWidth.Name = "lWidth";
            this.lWidth.Size = new System.Drawing.Size(35, 13);
            this.lWidth.TabIndex = 4;
            this.lWidth.Text = "label5";
            // 
            // StatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lWidth);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lColor);
            this.Controls.Add(this.lY);
            this.Controls.Add(this.lX);
            this.Name = "StatusBar";
            this.Size = new System.Drawing.Size(310, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lX;
        private System.Windows.Forms.Label lY;
        private System.Windows.Forms.Label lColor;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lWidth;
    }
}
