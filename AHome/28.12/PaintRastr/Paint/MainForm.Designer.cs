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
            this.panelPaint1 = new Paint.PanelPaint();
            this.toolBar1 = new Paint.ToolBar();
            this.menu1 = new Paint.Menu();
            this.panelWidth1 = new Paint.PanelWidth();
            this.panelSL1 = new Paint.PanelSL();
            this.panelFigure1 = new Paint.PanelFigure();
            this.panelColor1 = new Paint.PanelColor();
            this.statusControl1 = new Paint.GUI.StatusControl();
            this.SuspendLayout();
            // 
            // panelPaint1
            // 
            this.panelPaint1.BackColor = System.Drawing.Color.White;
            this.panelPaint1.Location = new System.Drawing.Point(224, 102);
            this.panelPaint1.Name = "panelPaint1";
            this.panelPaint1.Size = new System.Drawing.Size(461, 312);
            this.panelPaint1.TabIndex = 7;
            // 
            // toolBar1
            // 
            this.toolBar1.BackColor = System.Drawing.SystemColors.Window;
            this.toolBar1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolBar1.Location = new System.Drawing.Point(12, 42);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(138, 35);
            this.toolBar1.TabIndex = 6;
            // 
            // menu1
            // 
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(821, 25);
            this.menu1.TabIndex = 5;
            // 
            // panelWidth1
            // 
            this.panelWidth1.BackColor = System.Drawing.SystemColors.Window;
            this.panelWidth1.Location = new System.Drawing.Point(118, 208);
            this.panelWidth1.Name = "panelWidth1";
            this.panelWidth1.Size = new System.Drawing.Size(100, 150);
            this.panelWidth1.TabIndex = 4;
            // 
            // panelSL1
            // 
            this.panelSL1.BackColor = System.Drawing.SystemColors.Window;
            this.panelSL1.Location = new System.Drawing.Point(12, 364);
            this.panelSL1.Name = "panelSL1";
            this.panelSL1.Size = new System.Drawing.Size(206, 50);
            this.panelSL1.TabIndex = 3;
            // 
            // panelFigure1
            // 
            this.panelFigure1.BackColor = System.Drawing.SystemColors.Window;
            this.panelFigure1.Location = new System.Drawing.Point(12, 102);
            this.panelFigure1.Name = "panelFigure1";
            this.panelFigure1.Size = new System.Drawing.Size(100, 256);
            this.panelFigure1.TabIndex = 2;
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.SystemColors.Window;
            this.panelColor1.Location = new System.Drawing.Point(118, 102);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(100, 100);
            this.panelColor1.TabIndex = 1;
            // 
            // statusControl1
            // 
            this.statusControl1.canvas = this.panelPaint1;
            this.statusControl1.Location = new System.Drawing.Point(12, 420);
            this.statusControl1.Name = "statusControl1";
            this.statusControl1.Size = new System.Drawing.Size(789, 27);
            this.statusControl1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(819, 496);
            this.Controls.Add(this.statusControl1);
            this.Controls.Add(this.panelPaint1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.panelWidth1);
            this.Controls.Add(this.panelSL1);
            this.Controls.Add(this.panelFigure1);
            this.Controls.Add(this.panelColor1);
            this.Name = "MainForm";
            this.Text = "Paint";
            this.ResumeLayout(false);

        }

        #endregion
        private PanelColor panelColor1;
        private PanelFigure panelFigure1;
        private PanelSL panelSL1;
        private PanelWidth panelWidth1;
        private Menu menu1;
        private ToolBar toolBar1;
        private PanelPaint panelPaint1;
        private GUI.StatusControl statusControl1;
    }
}

