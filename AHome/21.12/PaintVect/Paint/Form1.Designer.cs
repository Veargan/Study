namespace Paint
{
    partial class Paintbox
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.formatPanel1 = new Paint.FormatPanel();
            this.paintPanel1 = new Paint.PaintPanel();
            this.widthPanel1 = new Paint.WidthPanel();
            this.figurePanel1 = new Paint.FigurePanel();
            this.colorPanel1 = new Paint.ColorPanel();
            this.SuspendLayout();
            // 
            // formatPanel1
            // 
            this.formatPanel1.Location = new System.Drawing.Point(0, 83);
            this.formatPanel1.Name = "formatPanel1";
            this.formatPanel1.Size = new System.Drawing.Size(145, 30);
            this.formatPanel1.TabIndex = 6;
            // 
            // paintPanel1
            // 
            this.paintPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paintPanel1.Location = new System.Drawing.Point(151, 12);
            this.paintPanel1.Name = "paintPanel1";
            this.paintPanel1.Size = new System.Drawing.Size(494, 288);
            this.paintPanel1.TabIndex = 5;
            this.paintPanel1.Enter += new System.EventHandler(this.paintPanel1_Enter);
            this.paintPanel1.Leave += new System.EventHandler(this.paintPanel1_Leave);
            // 
            // widthPanel1
            // 
            this.widthPanel1.Location = new System.Drawing.Point(0, 12);
            this.widthPanel1.Name = "widthPanel1";
            this.widthPanel1.Size = new System.Drawing.Size(145, 29);
            this.widthPanel1.TabIndex = 3;
            // 
            // figurePanel1
            // 
            this.figurePanel1.Location = new System.Drawing.Point(0, 47);
            this.figurePanel1.Name = "figurePanel1";
            this.figurePanel1.Size = new System.Drawing.Size(145, 30);
            this.figurePanel1.TabIndex = 2;
            // 
            // colorPanel1
            // 
            this.colorPanel1.Location = new System.Drawing.Point(0, 119);
            this.colorPanel1.Name = "colorPanel1";
            this.colorPanel1.Size = new System.Drawing.Size(145, 45);
            this.colorPanel1.TabIndex = 0;
            // 
            // Paintbox
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(655, 312);
            this.Controls.Add(this.formatPanel1);
            this.Controls.Add(this.paintPanel1);
            this.Controls.Add(this.widthPanel1);
            this.Controls.Add(this.figurePanel1);
            this.Controls.Add(this.colorPanel1);
            this.Name = "Paintbox";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private ColorPanel colorPanel1;
        private FigurePanel figurePanel1;
        private WidthPanel widthPanel1;
        private PaintPanel paintPanel1;
        private FormatPanel formatPanel1;
    }
}

