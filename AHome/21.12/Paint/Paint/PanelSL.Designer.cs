namespace Paint
{
    partial class PanelSL
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
            this.bLoad = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bLoad
            // 
            this.bLoad.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLoad.Location = new System.Drawing.Point(18, 15);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(104, 35);
            this.bLoad.TabIndex = 0;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = false;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSave.Location = new System.Drawing.Point(128, 15);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(104, 35);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // PanelSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bLoad);
            this.Name = "PanelSL";
            this.Size = new System.Drawing.Size(253, 72);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bSave;
    }
}
