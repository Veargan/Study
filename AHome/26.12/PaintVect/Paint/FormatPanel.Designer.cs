namespace Paint
{
    partial class FormatPanel
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
            this.combFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combFormat
            // 
            this.combFormat.FormattingEnabled = true;
            this.combFormat.Location = new System.Drawing.Point(12, 3);
            this.combFormat.Name = "combFormat";
            this.combFormat.Size = new System.Drawing.Size(121, 21);
            this.combFormat.TabIndex = 0;
            this.combFormat.Text = "Format";
            this.combFormat.SelectedIndexChanged += new System.EventHandler(this.combFormat_SelectedIndexChanged);
            // 
            // FormatPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combFormat);
            this.Name = "FormatPanel";
            this.Size = new System.Drawing.Size(145, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combFormat;
    }
}
