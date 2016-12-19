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
            this.b1 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.BackColor = System.Drawing.Color.Honeydew;
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b1.Location = new System.Drawing.Point(58, 17);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(47, 37);
            this.b1.TabIndex = 0;
            this.b1.Text = "1";
            this.b1.UseVisualStyleBackColor = false;
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b3
            // 
            this.b3.BackColor = System.Drawing.Color.Honeydew;
            this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b3.Location = new System.Drawing.Point(58, 60);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(47, 36);
            this.b3.TabIndex = 1;
            this.b3.Text = "3";
            this.b3.UseVisualStyleBackColor = false;
            this.b3.Click += new System.EventHandler(this.b3_Click);
            // 
            // b7
            // 
            this.b7.BackColor = System.Drawing.Color.Honeydew;
            this.b7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b7.Location = new System.Drawing.Point(58, 102);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(47, 36);
            this.b7.TabIndex = 2;
            this.b7.Text = "7";
            this.b7.UseVisualStyleBackColor = false;
            this.b7.Click += new System.EventHandler(this.b7_Click);
            // 
            // PanelWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.b7);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b1);
            this.Name = "PanelWidth";
            this.Load += new System.EventHandler(this.PanelWidth_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b7;
    }
}
