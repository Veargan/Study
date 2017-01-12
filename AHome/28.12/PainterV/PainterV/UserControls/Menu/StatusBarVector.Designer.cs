namespace PainterV.UserControls.Menu
{
    partial class StatusBarVector
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
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBar_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_Separator_1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Color = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_Separator_3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_Separator_2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_PenWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.L_ShapeType = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_ShapeType = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_PenWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_X,
            this.StatusBar_Y,
            this.L_Separator_1,
            this.StatusBar_Color,
            this.L_Separator_2,
            this.L_PenWidth,
            this.StatusBar_PenWidth,
            this.L_Separator_3,
            this.L_ShapeType,
            this.StatusBar_ShapeType});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(397, 36);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "StatusBar";
            // 
            // StatusBar_X
            // 
            this.StatusBar_X.Name = "StatusBar_X";
            this.StatusBar_X.Size = new System.Drawing.Size(20, 31);
            this.StatusBar_X.Text = "X: ";
            // 
            // StatusBar_Y
            // 
            this.StatusBar_Y.Name = "StatusBar_Y";
            this.StatusBar_Y.Size = new System.Drawing.Size(20, 31);
            this.StatusBar_Y.Text = "Y: ";
            // 
            // L_Separator_1
            // 
            this.L_Separator_1.Name = "L_Separator_1";
            this.L_Separator_1.Size = new System.Drawing.Size(10, 31);
            this.L_Separator_1.Text = "|";
            // 
            // StatusBar_Color
            // 
            this.StatusBar_Color.Name = "StatusBar_Color";
            this.StatusBar_Color.Size = new System.Drawing.Size(42, 31);
            this.StatusBar_Color.Text = "Color: ";
            // 
            // L_Separator_3
            // 
            this.L_Separator_3.Name = "L_Separator_3";
            this.L_Separator_3.Size = new System.Drawing.Size(10, 31);
            this.L_Separator_3.Text = "|";
            // 
            // L_Separator_2
            // 
            this.L_Separator_2.Name = "L_Separator_2";
            this.L_Separator_2.Size = new System.Drawing.Size(10, 31);
            this.L_Separator_2.Text = "|";
            // 
            // L_PenWidth
            // 
            this.L_PenWidth.Name = "L_PenWidth";
            this.L_PenWidth.Size = new System.Drawing.Size(65, 31);
            this.L_PenWidth.Text = "Pen Width:";
            // 
            // L_ShapeType
            // 
            this.L_ShapeType.Name = "L_ShapeType";
            this.L_ShapeType.Size = new System.Drawing.Size(70, 31);
            this.L_ShapeType.Text = "Shape Type:";
            // 
            // StatusBar_ShapeType
            // 
            this.StatusBar_ShapeType.Name = "StatusBar_ShapeType";
            this.StatusBar_ShapeType.Size = new System.Drawing.Size(10, 31);
            this.StatusBar_ShapeType.Text = " ";
            // 
            // StatusBar_PenWidth
            // 
            this.StatusBar_PenWidth.Name = "StatusBar_PenWidth";
            this.StatusBar_PenWidth.Size = new System.Drawing.Size(10, 31);
            this.StatusBar_PenWidth.Text = " ";
            // 
            // StatusBarVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusBar);
            this.Name = "StatusBarVector";
            this.Size = new System.Drawing.Size(397, 36);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_X;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Y;
        private System.Windows.Forms.ToolStripStatusLabel L_Separator_1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Color;
        private System.Windows.Forms.ToolStripStatusLabel L_Separator_2;
        private System.Windows.Forms.ToolStripStatusLabel L_PenWidth;
        private System.Windows.Forms.ToolStripStatusLabel L_Separator_3;
        private System.Windows.Forms.ToolStripStatusLabel L_ShapeType;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_ShapeType;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_PenWidth;
    }
}
