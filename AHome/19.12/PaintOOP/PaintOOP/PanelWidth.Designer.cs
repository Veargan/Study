namespace PaintOOP
{
    partial class PanelWidth
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
            this.bt1 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.SystemColors.Menu;
            this.bt1.Location = new System.Drawing.Point(25, 37);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(50, 23);
            this.bt1.TabIndex = 0;
            this.bt1.Tag = "1";
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.Width);
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.SystemColors.Menu;
            this.bt2.Location = new System.Drawing.Point(25, 80);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(50, 23);
            this.bt2.TabIndex = 1;
            this.bt2.Tag = "2";
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = false;
            this.bt2.Click += new System.EventHandler(this.Width);
            // 
            // bt3
            // 
            this.bt3.BackColor = System.Drawing.SystemColors.Menu;
            this.bt3.Location = new System.Drawing.Point(25, 124);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(50, 23);
            this.bt3.TabIndex = 2;
            this.bt3.Tag = "3";
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = false;
            this.bt3.Click += new System.EventHandler(this.Width);
            // 
            // PanelWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt1);
            this.Name = "PanelWidth";
            this.Size = new System.Drawing.Size(105, 205);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
    }
}
