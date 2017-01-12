namespace Paint
{
    partial class MainForm
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
            
            this.SuspendLayout();
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(819, 496);

            this.Name = "MainForm";
            this.Text = "Paint";
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSL panelSL2;
        private StatusBar statusBar11;
        private PanelPaint panelPaint2;
        private Menu menu2;
        private PanelColor panelColor2;
        private PanelFigure panelFigure2;
        private PanelWidth panelWidth2;
        private ToolBar toolBar2;
        private ContextMenu contextMenu1;
    }
}

