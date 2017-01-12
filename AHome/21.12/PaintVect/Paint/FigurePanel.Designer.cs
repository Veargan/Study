namespace Paint
{
    partial class FigurePanel
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
            this.combFigure = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combFigure
            // 
            this.combFigure.FormattingEnabled = true;
            this.combFigure.Location = new System.Drawing.Point(12, 3);
            this.combFigure.Name = "combFigure";
            this.combFigure.Size = new System.Drawing.Size(121, 21);
            this.combFigure.TabIndex = 0;
            this.combFigure.Text = "Figure";
            this.combFigure.SelectedIndexChanged += new System.EventHandler(this.combFigure_SelectedIndexChanged);
            // 
            // FigurePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combFigure);
            this.Name = "FigurePanel";
            this.Size = new System.Drawing.Size(145, 28);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox combFigure;

    }
}
