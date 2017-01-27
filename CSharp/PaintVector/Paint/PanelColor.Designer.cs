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
            this.bRed = new System.Windows.Forms.Button();
            this.bBlue = new System.Windows.Forms.Button();
            this.bGreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bRed
            // 
            this.bRed.BackColor = System.Drawing.Color.Red;
            this.bRed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRed.Location = new System.Drawing.Point(53, 21);
            this.bRed.Name = "bRed";
            this.bRed.Size = new System.Drawing.Size(88, 33);
            this.bRed.TabIndex = 0;
            this.bRed.Text = "Red";
            this.bRed.UseVisualStyleBackColor = false;
            this.bRed.Click += new System.EventHandler(this.bRed_Click);
            // 
            // bBlue
            // 
            this.bBlue.BackColor = System.Drawing.Color.Blue;
            this.bBlue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bBlue.Location = new System.Drawing.Point(53, 69);
            this.bBlue.Name = "bBlue";
            this.bBlue.Size = new System.Drawing.Size(88, 34);
            this.bBlue.TabIndex = 1;
            this.bBlue.Text = "Blue";
            this.bBlue.UseVisualStyleBackColor = false;
            this.bBlue.Click += new System.EventHandler(this.bBlue_Click);
            // 
            // bGreen
            // 
            this.bGreen.BackColor = System.Drawing.Color.SpringGreen;
            this.bGreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bGreen.Location = new System.Drawing.Point(53, 118);
            this.bGreen.Name = "bGreen";
            this.bGreen.Size = new System.Drawing.Size(88, 33);
            this.bGreen.TabIndex = 2;
            this.bGreen.Text = "Green";
            this.bGreen.UseVisualStyleBackColor = false;
            this.bGreen.Click += new System.EventHandler(this.bGreen_Click);
            // 
            // PanelColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bGreen);
            this.Controls.Add(this.bBlue);
            this.Controls.Add(this.bRed);
            this.Name = "PanelColor";
            this.Size = new System.Drawing.Size(188, 185);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRed;
        private System.Windows.Forms.Button bBlue;
        private System.Windows.Forms.Button bGreen;
    }
}
