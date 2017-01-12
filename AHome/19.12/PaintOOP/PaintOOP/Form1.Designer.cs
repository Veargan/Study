namespace PaintOOP
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelWidth1 = new PaintOOP.PanelWidth();
            this.panelPaint1 = new PaintOOP.PanelPaint();
            this.panelColor1 = new PaintOOP.PanelColor();
            this.panelType1 = new PaintOOP.PanelType();
            this.SuspendLayout();
            // 
            // panelWidth1
            // 
            this.panelWidth1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelWidth1.Location = new System.Drawing.Point(111, 189);
            this.panelWidth1.Name = "panelWidth1";
            this.panelWidth1.Size = new System.Drawing.Size(101, 191);
            this.panelWidth1.TabIndex = 3;
            // 
            // panelPaint1
            // 
            this.panelPaint1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPaint1.Location = new System.Drawing.Point(218, 12);
            this.panelPaint1.Name = "panelPaint1";
            this.panelPaint1.Size = new System.Drawing.Size(532, 368);
            this.panelPaint1.TabIndex = 2;
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelColor1.Location = new System.Drawing.Point(12, 12);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(200, 171);
            this.panelColor1.TabIndex = 0;
            // 
            // panelType1
            // 
            this.panelType1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelType1.Location = new System.Drawing.Point(12, 189);
            this.panelType1.Name = "panelType1";
            this.panelType1.Size = new System.Drawing.Size(93, 191);
            this.panelType1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 392);
            this.Controls.Add(this.panelType1);
            this.Controls.Add(this.panelWidth1);
            this.Controls.Add(this.panelPaint1);
            this.Controls.Add(this.panelColor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PanelColor panelColor1;
        private PanelPaint panelPaint1;
        private PanelWidth panelWidth1;
        private PanelType panelType1;
    }
}

