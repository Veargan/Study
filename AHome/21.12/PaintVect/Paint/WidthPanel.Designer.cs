namespace Paint
{
    partial class WidthPanel
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
            this.combWidth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combWidth
            // 
            this.combWidth.FormattingEnabled = true;
            this.combWidth.Location = new System.Drawing.Point(12, 3);
            this.combWidth.Name = "combWidth";
            this.combWidth.Size = new System.Drawing.Size(121, 21);
            this.combWidth.TabIndex = 0;
            this.combWidth.Text = "Width";
            this.combWidth.SelectionChangeCommitted += new System.EventHandler(this.combWidth_SelectionChangeCommitted);
            // 
            // WidthPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combWidth);
            this.Name = "WidthPanel";
            this.Size = new System.Drawing.Size(145, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combWidth;
    }
}
