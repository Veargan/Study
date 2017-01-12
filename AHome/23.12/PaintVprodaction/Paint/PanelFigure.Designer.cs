namespace Paint
{
    partial class PanelFigure
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
            this.bRect = new System.Windows.Forms.Button();
            this.bEll = new System.Windows.Forms.Button();
            this.bRound = new System.Windows.Forms.Button();
            this.bLine = new System.Windows.Forms.Button();
            this.bCurve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bRect
            // 
            this.bRect.BackColor = System.Drawing.SystemColors.Menu;
            this.bRect.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRect.Location = new System.Drawing.Point(10, 29);
            this.bRect.Name = "bRect";
            this.bRect.Size = new System.Drawing.Size(80, 30);
            this.bRect.TabIndex = 0;
            this.bRect.Tag = "1";
            this.bRect.Text = "Rect";
            this.bRect.UseVisualStyleBackColor = false;
            this.bRect.Click += new System.EventHandler(this.FigChoose);
            // 
            // bEll
            // 
            this.bEll.BackColor = System.Drawing.SystemColors.Menu;
            this.bEll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEll.Location = new System.Drawing.Point(10, 65);
            this.bEll.Name = "bEll";
            this.bEll.Size = new System.Drawing.Size(80, 30);
            this.bEll.TabIndex = 1;
            this.bEll.Tag = "2";
            this.bEll.Text = "Ellipse";
            this.bEll.UseVisualStyleBackColor = false;
            this.bEll.Click += new System.EventHandler(this.FigChoose);
            // 
            // bRound
            // 
            this.bRound.BackColor = System.Drawing.SystemColors.Menu;
            this.bRound.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRound.Location = new System.Drawing.Point(10, 101);
            this.bRound.Name = "bRound";
            this.bRound.Size = new System.Drawing.Size(80, 30);
            this.bRound.TabIndex = 2;
            this.bRound.Tag = "3";
            this.bRound.Text = "Round rect";
            this.bRound.UseVisualStyleBackColor = false;
            this.bRound.Click += new System.EventHandler(this.FigChoose);
            // 
            // bLine
            // 
            this.bLine.BackColor = System.Drawing.SystemColors.Menu;
            this.bLine.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLine.Location = new System.Drawing.Point(10, 137);
            this.bLine.Name = "bLine";
            this.bLine.Size = new System.Drawing.Size(80, 30);
            this.bLine.TabIndex = 3;
            this.bLine.Tag = "4";
            this.bLine.Text = "Line";
            this.bLine.UseVisualStyleBackColor = false;
            this.bLine.Click += new System.EventHandler(this.FigChoose);
            // 
            // bCurve
            // 
            this.bCurve.BackColor = System.Drawing.SystemColors.Menu;
            this.bCurve.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCurve.Location = new System.Drawing.Point(10, 173);
            this.bCurve.Name = "bCurve";
            this.bCurve.Size = new System.Drawing.Size(80, 30);
            this.bCurve.TabIndex = 4;
            this.bCurve.Tag = "0";
            this.bCurve.Text = "Curve";
            this.bCurve.UseVisualStyleBackColor = false;
            this.bCurve.Click += new System.EventHandler(this.FigChoose);
            // 
            // PanelFigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.bCurve);
            this.Controls.Add(this.bLine);
            this.Controls.Add(this.bRound);
            this.Controls.Add(this.bEll);
            this.Controls.Add(this.bRect);
            this.Name = "PanelFigure";
            this.Size = new System.Drawing.Size(100, 237);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRect;
        private System.Windows.Forms.Button bEll;
        private System.Windows.Forms.Button bRound;
        private System.Windows.Forms.Button bLine;
        private System.Windows.Forms.Button bCurve;
    }
}
