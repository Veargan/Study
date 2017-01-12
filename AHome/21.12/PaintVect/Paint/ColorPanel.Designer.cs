namespace Paint
{
    partial class ColorPanel
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            this.butColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butColor
            // 
            this.butColor.Location = new System.Drawing.Point(36, 11);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(75, 23);
            this.butColor.TabIndex = 0;
            this.butColor.Text = "Color";
            this.butColor.UseVisualStyleBackColor = true;
            this.butColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butColor);
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(145, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butColor;

    }
}
