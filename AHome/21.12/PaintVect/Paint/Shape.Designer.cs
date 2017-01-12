namespace Paint
{
    partial class Shape
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sizePanel4 = new Paint.SizePanel();
            this.sizePanel8 = new Paint.SizePanel();
            this.sizePanel7 = new Paint.SizePanel();
            this.sizePanel6 = new Paint.SizePanel();
            this.sizePanel5 = new Paint.SizePanel();
            this.sizePanel3 = new Paint.SizePanel();
            this.sizePanel2 = new Paint.SizePanel();
            this.sizePanel1 = new Paint.SizePanel();
            this.SuspendLayout();
            // 
            // sizePanel4
            // 
            this.sizePanel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel4.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizePanel4.Location = new System.Drawing.Point(-2, 70);
            this.sizePanel4.Name = "sizePanel4";
            this.sizePanel4.Size = new System.Drawing.Size(10, 10);
            this.sizePanel4.TabIndex = 0;
            this.sizePanel4.Tag = 0;
            this.sizePanel4.Visible = false;
            // 
            // sizePanel8
            // 
            this.sizePanel8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel8.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizePanel8.Location = new System.Drawing.Point(140, 140);
            this.sizePanel8.Name = "sizePanel8";
            this.sizePanel8.Size = new System.Drawing.Size(10, 10);
            this.sizePanel8.TabIndex = 0;
            this.sizePanel8.Tag = 0;
            this.sizePanel8.Visible = false;
            // 
            // sizePanel7
            // 
            this.sizePanel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel7.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.sizePanel7.Location = new System.Drawing.Point(70, 140);
            this.sizePanel7.Name = "sizePanel7";
            this.sizePanel7.Size = new System.Drawing.Size(10, 10);
            this.sizePanel7.TabIndex = 0;
            this.sizePanel7.Tag = 0;
            this.sizePanel7.Visible = false;
            // 
            // sizePanel6
            // 
            this.sizePanel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel6.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.sizePanel6.Location = new System.Drawing.Point(0, 140);
            this.sizePanel6.Name = "sizePanel6";
            this.sizePanel6.Size = new System.Drawing.Size(10, 10);
            this.sizePanel6.TabIndex = 0;
            this.sizePanel6.Tag = 0;
            this.sizePanel6.Visible = false;
            // 
            // sizePanel5
            // 
            this.sizePanel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel5.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizePanel5.Location = new System.Drawing.Point(140, 70);
            this.sizePanel5.Name = "sizePanel5";
            this.sizePanel5.Size = new System.Drawing.Size(10, 10);
            this.sizePanel5.TabIndex = 0;
            this.sizePanel5.Tag = 0;
            this.sizePanel5.Visible = false;
            // 
            // sizePanel3
            // 
            this.sizePanel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel3.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.sizePanel3.Location = new System.Drawing.Point(140, 0);
            this.sizePanel3.Name = "sizePanel3";
            this.sizePanel3.Size = new System.Drawing.Size(10, 10);
            this.sizePanel3.TabIndex = 0;
            this.sizePanel3.Tag = 0;
            this.sizePanel3.Visible = false;
            // 
            // sizePanel2
            // 
            this.sizePanel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.sizePanel2.Location = new System.Drawing.Point(70, 0);
            this.sizePanel2.Name = "sizePanel2";
            this.sizePanel2.Size = new System.Drawing.Size(10, 10);
            this.sizePanel2.TabIndex = 0;
            this.sizePanel2.Tag = 0;
            this.sizePanel2.Visible = false;
            // 
            // sizePanel1
            // 
            this.sizePanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sizePanel1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizePanel1.Location = new System.Drawing.Point(0, 0);
            this.sizePanel1.Name = "sizePanel1";
            this.sizePanel1.Size = new System.Drawing.Size(10, 10);
            this.sizePanel1.TabIndex = 0;
            this.sizePanel1.Tag = 0;
            this.sizePanel1.Visible = false;
            // 
            // Shape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sizePanel4);
            this.Controls.Add(this.sizePanel8);
            this.Controls.Add(this.sizePanel7);
            this.Controls.Add(this.sizePanel6);
            this.Controls.Add(this.sizePanel5);
            this.Controls.Add(this.sizePanel3);
            this.Controls.Add(this.sizePanel2);
            this.Controls.Add(this.sizePanel1);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Name = "Shape";
            this.SizeChanged += new System.EventHandler(this.Shape_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Shape_Paint);
            this.Enter += new System.EventHandler(this.Shape_Enter);
            this.Leave += new System.EventHandler(this.Shape_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private SizePanel sizePanel1;
        private SizePanel sizePanel2;
        private SizePanel sizePanel3;
        private SizePanel sizePanel5;
        private SizePanel sizePanel6;
        private SizePanel sizePanel7;
        private SizePanel sizePanel8;
        private SizePanel sizePanel4;
    }
}
