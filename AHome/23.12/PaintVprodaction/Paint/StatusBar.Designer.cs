namespace Paint
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
            this.labX = new System.Windows.Forms.Label();
            this.labY = new System.Windows.Forms.Label();
            this.labCol = new System.Windows.Forms.Label();
            this.labWid = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Location = new System.Drawing.Point(119, 25);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(20, 13);
            this.labX.TabIndex = 0;
            this.labX.Text = "X :";
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Location = new System.Drawing.Point(176, 25);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(20, 13);
            this.labY.TabIndex = 1;
            this.labY.Text = "Y :";
            // 
            // labCol
            // 
            this.labCol.AutoSize = true;
            this.labCol.Location = new System.Drawing.Point(245, 25);
            this.labCol.Name = "labCol";
            this.labCol.Size = new System.Drawing.Size(31, 13);
            this.labCol.TabIndex = 2;
            this.labCol.Text = "Color";
            // 
            // labWid
            // 
            this.labWid.AutoSize = true;
            this.labWid.Location = new System.Drawing.Point(327, 25);
            this.labWid.Name = "labWid";
            this.labWid.Size = new System.Drawing.Size(35, 13);
            this.labWid.TabIndex = 3;
            this.labWid.Text = "Width";
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Location = new System.Drawing.Point(420, 25);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(31, 13);
            this.labType.TabIndex = 4;
            this.labType.Text = "Type";
            // 
            // StatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.labType);
            this.Controls.Add(this.labWid);
            this.Controls.Add(this.labCol);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.labX);
            this.Name = "StatusBar";
            this.Size = new System.Drawing.Size(540, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.Label labCol;
        private System.Windows.Forms.Label labWid;
        private System.Windows.Forms.Label labType;
    }
}
