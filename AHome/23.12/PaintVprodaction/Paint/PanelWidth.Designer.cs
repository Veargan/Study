namespace Paint
{
    partial class PanelWidth
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
            this.bt1 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.SystemColors.Menu;
            this.bt1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt1.Location = new System.Drawing.Point(10, 20);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(80, 30);
            this.bt1.TabIndex = 0;
            this.bt1.Tag = "1";
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.SetWidth);
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.SystemColors.Menu;
            this.bt2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt2.Location = new System.Drawing.Point(10, 56);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(80, 30);
            this.bt2.TabIndex = 1;
            this.bt2.Tag = "2";
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = false;
            this.bt2.Click += new System.EventHandler(this.SetWidth);
            // 
            // bt3
            // 
            this.bt3.BackColor = System.Drawing.SystemColors.Menu;
            this.bt3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt3.Location = new System.Drawing.Point(10, 92);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(80, 30);
            this.bt3.TabIndex = 2;
            this.bt3.Tag = "3";
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = false;
            this.bt3.Click += new System.EventHandler(this.SetWidth);
            // 
            // PanelWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt1);
            this.Name = "PanelWidth";
            this.Size = new System.Drawing.Size(100, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
    }
}
