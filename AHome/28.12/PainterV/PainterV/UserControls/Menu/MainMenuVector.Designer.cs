namespace PainterV.UserControls.Menu
{
    partial class MainMenuVector
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenu_FIle = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Color = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_PenWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_ShapeType = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_FIle,
            this.MainMenu_Color,
            this.MainMenu_PenWidth,
            this.MainMenu_ShapeType});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(291, 29);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // MainMenu_FIle
            // 
            this.MainMenu_FIle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_FileOpen,
            this.toolStripSeparator1,
            this.MainMenu_FileSave});
            this.MainMenu_FIle.Name = "MainMenu_FIle";
            this.MainMenu_FIle.Size = new System.Drawing.Size(37, 25);
            this.MainMenu_FIle.Text = "File";
            // 
            // MainMenu_Color
            // 
            this.MainMenu_Color.Name = "MainMenu_Color";
            this.MainMenu_Color.Size = new System.Drawing.Size(48, 25);
            this.MainMenu_Color.Text = "Color";
            // 
            // MainMenu_PenWidth
            // 
            this.MainMenu_PenWidth.Name = "MainMenu_PenWidth";
            this.MainMenu_PenWidth.Size = new System.Drawing.Size(74, 25);
            this.MainMenu_PenWidth.Text = "Pen Width";
            // 
            // MainMenu_ShapeType
            // 
            this.MainMenu_ShapeType.Name = "MainMenu_ShapeType";
            this.MainMenu_ShapeType.Size = new System.Drawing.Size(79, 25);
            this.MainMenu_ShapeType.Text = "Shape Type";
            // 
            // MainMenu_FileOpen
            // 
            this.MainMenu_FileOpen.Name = "MainMenu_FileOpen";
            this.MainMenu_FileOpen.Size = new System.Drawing.Size(152, 22);
            this.MainMenu_FileOpen.Text = "Open";
            // 
            // MainMenu_FileSave
            // 
            this.MainMenu_FileSave.Name = "MainMenu_FileSave";
            this.MainMenu_FileSave.Size = new System.Drawing.Size(152, 22);
            this.MainMenu_FileSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MainMenuVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainMenu);
            this.Name = "MainMenuVector";
            this.Size = new System.Drawing.Size(291, 29);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_FIle;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Color;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_PenWidth;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_ShapeType;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_FileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_FileSave;
    }
}
