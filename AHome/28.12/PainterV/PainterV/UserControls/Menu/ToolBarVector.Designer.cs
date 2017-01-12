namespace PainterV.UserControls.Menu
{
    partial class ToolBarVector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarVector));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.ToolBar_Color = new System.Windows.Forms.ToolStripButton();
            this.ToolBar_PenWidth = new System.Windows.Forms.ToolStripButton();
            this.ToolBar_ShapeType = new System.Windows.Forms.ToolStripButton();
            this.ToolBar_SaveLoad = new System.Windows.Forms.ToolStripButton();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBar_Color,
            this.ToolBar_PenWidth,
            this.ToolBar_ShapeType,
            this.ToolBar_SaveLoad});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(288, 30);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "ToolBar";
            // 
            // ToolBar_Color
            // 
            this.ToolBar_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolBar_Color.Image = ((System.Drawing.Image)(resources.GetObject("ToolBar_Color.Image")));
            this.ToolBar_Color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBar_Color.Name = "ToolBar_Color";
            this.ToolBar_Color.Size = new System.Drawing.Size(40, 27);
            this.ToolBar_Color.Text = "Color";
            // 
            // ToolBar_PenWidth
            // 
            this.ToolBar_PenWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolBar_PenWidth.Image = ((System.Drawing.Image)(resources.GetObject("ToolBar_PenWidth.Image")));
            this.ToolBar_PenWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBar_PenWidth.Name = "ToolBar_PenWidth";
            this.ToolBar_PenWidth.Size = new System.Drawing.Size(66, 27);
            this.ToolBar_PenWidth.Text = "Pen Width";
            // 
            // ToolBar_ShapeType
            // 
            this.ToolBar_ShapeType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolBar_ShapeType.Image = ((System.Drawing.Image)(resources.GetObject("ToolBar_ShapeType.Image")));
            this.ToolBar_ShapeType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBar_ShapeType.Name = "ToolBar_ShapeType";
            this.ToolBar_ShapeType.Size = new System.Drawing.Size(71, 27);
            this.ToolBar_ShapeType.Text = "Shape Type";
            // 
            // ToolBar_SaveLoad
            // 
            this.ToolBar_SaveLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolBar_SaveLoad.Image = ((System.Drawing.Image)(resources.GetObject("ToolBar_SaveLoad.Image")));
            this.ToolBar_SaveLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBar_SaveLoad.Name = "ToolBar_SaveLoad";
            this.ToolBar_SaveLoad.Size = new System.Drawing.Size(72, 27);
            this.ToolBar_SaveLoad.Text = "Save / Load";
            this.ToolBar_SaveLoad.Click += new System.EventHandler(this.ToolBar_SaveLoad_Click);
            // 
            // ToolBarVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolBar);
            this.Name = "ToolBarVector";
            this.Size = new System.Drawing.Size(288, 30);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton ToolBar_Color;
        private System.Windows.Forms.ToolStripButton ToolBar_PenWidth;
        private System.Windows.Forms.ToolStripButton ToolBar_ShapeType;
        private System.Windows.Forms.ToolStripButton ToolBar_SaveLoad;
    }
}
