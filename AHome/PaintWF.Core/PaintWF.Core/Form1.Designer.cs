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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rect = new System.Windows.Forms.Button();
            this.rectoval = new System.Windows.Forms.Button();
            this.oval = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Button();
            this.curve = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
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
            this.brushSize.Location = new System.Drawing.Point(93, 258);
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(100, 20);
            this.brushSize.TabIndex = 2;
            this.brushSize.TextChanged += new System.EventHandler(this.brushSize_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.curve);
            this.groupBox2.Controls.Add(this.line);
            this.groupBox2.Controls.Add(this.oval);
            this.groupBox2.Controls.Add(this.rectoval);
            this.groupBox2.Controls.Add(this.rect);
            this.groupBox2.Location = new System.Drawing.Point(488, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(78, 144);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rect
            // 
            this.rect.Location = new System.Drawing.Point(0, 0);
            this.rect.Name = "rect";
            this.rect.Size = new System.Drawing.Size(75, 23);
            this.rect.TabIndex = 0;
            this.rect.Text = "rect";
            this.rect.UseVisualStyleBackColor = true;
            // 
            // rectoval
            // 
            this.rectoval.Location = new System.Drawing.Point(0, 29);
            this.rectoval.Name = "rectoval";
            this.rectoval.Size = new System.Drawing.Size(75, 23);
            this.rectoval.TabIndex = 1;
            this.rectoval.Text = "rectoval";
            this.rectoval.UseVisualStyleBackColor = true;
            // 
            // oval
            // 
            this.oval.Location = new System.Drawing.Point(0, 58);
            this.oval.Name = "oval";
            this.oval.Size = new System.Drawing.Size(75, 23);
            this.oval.TabIndex = 2;
            this.oval.Text = "oval";
            this.oval.UseVisualStyleBackColor = true;
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(0, 87);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(75, 23);
            this.line.TabIndex = 3;
            this.line.Text = "line";
            this.line.UseVisualStyleBackColor = true;
            // 
            // curve
            // 
            this.curve.Location = new System.Drawing.Point(0, 116);
            this.curve.Name = "curve";
            this.curve.Size = new System.Drawing.Size(75, 23);
            this.curve.TabIndex = 4;
            this.curve.Text = "curve";
            this.curve.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "rect",
            "rectoval",
            "oval",
            "line",
            "curve"});
            this.comboBox1.Location = new System.Drawing.Point(214, 257);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 285);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.brushSize);
            this.Controls.Add(this.ChangeColor);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ChangeColor;
        private System.Windows.Forms.TextBox brushSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button curve;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button oval;
        private System.Windows.Forms.Button rectoval;
        private System.Windows.Forms.Button rect;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

