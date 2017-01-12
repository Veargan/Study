namespace Painter.UserControls.VectorElements
{
    partial class ColorSelectorVector
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_ColorSelector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_ColorSelector
            // 
            this.B_ColorSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_ColorSelector.Location = new System.Drawing.Point(0, 0);
            this.B_ColorSelector.Name = "B_ColorSelector";
            this.B_ColorSelector.Size = new System.Drawing.Size(88, 33);
            this.B_ColorSelector.TabIndex = 0;
            this.B_ColorSelector.Text = "Color";
            this.B_ColorSelector.UseVisualStyleBackColor = true;
            this.B_ColorSelector.Click += new System.EventHandler(this.B_ColorSelector_Click);
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.B_ColorSelector);
            this.Name = "ColorSelector";
            this.Size = new System.Drawing.Size(88, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_ColorSelector;
    }
}
