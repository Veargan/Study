namespace Balls
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.frame1 = new Balls.Frame();
            this.SuspendLayout();
            // 
            // frame1
            // 
            this.frame1.BackColor = System.Drawing.SystemColors.Window;
            this.frame1.Location = new System.Drawing.Point(12, 12);
            this.frame1.Name = "frame1";
            this.frame1.Size = new System.Drawing.Size(674, 381);
            this.frame1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 402);
            this.Controls.Add(this.frame1);
            this.Name = "Form1";
            this.Text = "Balls";
            this.ResumeLayout(false);

        }

        #endregion

        private Frame frame1;
    }
}

