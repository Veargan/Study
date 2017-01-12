namespace Paint
{
    partial class PanelColor
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
            this.btColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btColor
            // 
            this.btColor.BackColor = System.Drawing.SystemColors.Menu;
            this.btColor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btColor.Location = new System.Drawing.Point(10, 33);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(80, 30);
            this.btColor.TabIndex = 3;
            this.btColor.Text = "Color";
            this.btColor.UseVisualStyleBackColor = false;

            // 
            // PanelColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btColor);
            this.Name = "PanelColor";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btColor;
    }
}
