namespace PaintOOP
{
    partial class PanelType
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
            this.btRectangle = new System.Windows.Forms.Button();
            this.btRound = new System.Windows.Forms.Button();
            this.btEllipse = new System.Windows.Forms.Button();
            this.btLine = new System.Windows.Forms.Button();
            this.btFreeLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRectangle
            // 
            this.btRectangle.BackColor = System.Drawing.SystemColors.Menu;
            this.btRectangle.Location = new System.Drawing.Point(11, 19);
            this.btRectangle.Name = "btRectangle";
            this.btRectangle.Size = new System.Drawing.Size(71, 23);
            this.btRectangle.TabIndex = 0;
            this.btRectangle.Tag = "1";
            this.btRectangle.Text = "Rectangle";
            this.btRectangle.UseVisualStyleBackColor = false;
            this.btRectangle.Click += new System.EventHandler(this.SetType);
            // 
            // btRound
            // 
            this.btRound.BackColor = System.Drawing.SystemColors.Menu;
            this.btRound.Location = new System.Drawing.Point(11, 48);
            this.btRound.Name = "btRound";
            this.btRound.Size = new System.Drawing.Size(71, 23);
            this.btRound.TabIndex = 1;
            this.btRound.Tag = "2";
            this.btRound.Text = "Round";
            this.btRound.UseVisualStyleBackColor = false;
            this.btRound.Click += new System.EventHandler(this.SetType);
            // 
            // btEllipse
            // 
            this.btEllipse.BackColor = System.Drawing.SystemColors.Menu;
            this.btEllipse.Location = new System.Drawing.Point(11, 77);
            this.btEllipse.Name = "btEllipse";
            this.btEllipse.Size = new System.Drawing.Size(71, 23);
            this.btEllipse.TabIndex = 2;
            this.btEllipse.Tag = "3";
            this.btEllipse.Text = "Ellipse";
            this.btEllipse.UseVisualStyleBackColor = false;
            this.btEllipse.Click += new System.EventHandler(this.SetType);
            // 
            // btLine
            // 
            this.btLine.BackColor = System.Drawing.SystemColors.Menu;
            this.btLine.Location = new System.Drawing.Point(11, 106);
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(71, 23);
            this.btLine.TabIndex = 3;
            this.btLine.Tag = "4";
            this.btLine.Text = "Line";
            this.btLine.UseVisualStyleBackColor = false;
            this.btLine.Click += new System.EventHandler(this.SetType);
            // 
            // btFreeLine
            // 
            this.btFreeLine.BackColor = System.Drawing.SystemColors.Menu;
            this.btFreeLine.Location = new System.Drawing.Point(11, 135);
            this.btFreeLine.Name = "btFreeLine";
            this.btFreeLine.Size = new System.Drawing.Size(71, 23);
            this.btFreeLine.TabIndex = 4;
            this.btFreeLine.Tag = "0";
            this.btFreeLine.Text = "FreeLine";
            this.btFreeLine.UseVisualStyleBackColor = false;
            this.btFreeLine.Click += new System.EventHandler(this.SetType);
            // 
            // PanelType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btFreeLine);
            this.Controls.Add(this.btLine);
            this.Controls.Add(this.btEllipse);
            this.Controls.Add(this.btRound);
            this.Controls.Add(this.btRectangle);
            this.Name = "PanelType";
            this.Size = new System.Drawing.Size(93, 190);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRectangle;
        private System.Windows.Forms.Button btRound;
        private System.Windows.Forms.Button btEllipse;
        private System.Windows.Forms.Button btLine;
        private System.Windows.Forms.Button btFreeLine;
    }
}
