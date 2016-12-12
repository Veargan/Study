namespace PaintWF.Core
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ChangeColor = new System.Windows.Forms.Button();
            this.brushSize = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ListOfFigures = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 250);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ChangeColor
            // 
            this.ChangeColor.Location = new System.Drawing.Point(12, 256);
            this.ChangeColor.Name = "ChangeColor";
            this.ChangeColor.Size = new System.Drawing.Size(75, 23);
            this.ChangeColor.TabIndex = 1;
            this.ChangeColor.Text = "Pick a color";
            this.ChangeColor.UseVisualStyleBackColor = true;
            this.ChangeColor.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // brushSize
            // 
            this.brushSize.Location = new System.Drawing.Point(93, 256);
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(100, 20);
            this.brushSize.TabIndex = 2;
            this.brushSize.TextChanged += new System.EventHandler(this.brushSize_TextChanged);
            // 
            // ListOfFigures
            // 
            this.ListOfFigures.FormattingEnabled = true;
            this.ListOfFigures.Items.AddRange(new object[] {
            "Rectangle",
            "Ellipse",
            "Round Rectangle",
            "Line",
            "Curved Line"});
            this.ListOfFigures.Location = new System.Drawing.Point(199, 256);
            this.ListOfFigures.Name = "ListOfFigures";
            this.ListOfFigures.Size = new System.Drawing.Size(121, 21);
            this.ListOfFigures.TabIndex = 7;
            this.ListOfFigures.Text = "Pick a figure";
            this.ListOfFigures.SelectedIndexChanged += new System.EventHandler(this.ListOfFigures_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 285);
            this.Controls.Add(this.ListOfFigures);
            this.Controls.Add(this.brushSize);
            this.Controls.Add(this.ChangeColor);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ChangeColor;
        private System.Windows.Forms.TextBox brushSize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox ListOfFigures;
    }
}

