namespace Paint
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFigure1 = new Paint.PanelFigure();
            this.panelWidth1 = new Paint.PanelWidth();
            this.panelColor1 = new Paint.PanelColor();
            this.panelPaint1 = new Paint.PanelPaint();
            this.SuspendLayout();
            // 
            // panelFigure1
            // 
            this.panelFigure1.Location = new System.Drawing.Point(2, 59);
            this.panelFigure1.Name = "panelFigure1";
            this.panelFigure1.Size = new System.Drawing.Size(110, 334);
            this.panelFigure1.TabIndex = 17;
            // 
            // panelWidth1
            // 
            this.panelWidth1.Location = new System.Drawing.Point(592, 217);
            this.panelWidth1.Name = "panelWidth1";
            this.panelWidth1.Size = new System.Drawing.Size(153, 188);
            this.panelWidth1.TabIndex = 16;
            // 
            // panelColor1
            // 
            this.panelColor1.Location = new System.Drawing.Point(577, 48);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(140, 185);
            this.panelColor1.TabIndex = 15;
            // 
            // panelPaint1
            // 
            this.panelPaint1.BackColor = System.Drawing.Color.White;
            this.panelPaint1.Location = new System.Drawing.Point(128, 43);
            this.panelPaint1.Name = "panelPaint1";
            this.panelPaint1.Size = new System.Drawing.Size(476, 385);
            this.panelPaint1.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(757, 497);
            this.Controls.Add(this.panelPaint1);
            this.Controls.Add(this.panelFigure1);
            this.Controls.Add(this.panelWidth1);
            this.Controls.Add(this.panelColor1);
            this.Name = "MainForm";
            this.Text = "Paint";
            this.ResumeLayout(false);

        }

        #endregion
        private PanelPaint panelPaint1;
        private PanelColor panelColor1;
        private PanelWidth panelWidth1;
        private PanelFigure panelFigure1;
    }
}

