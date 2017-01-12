namespace PainterV.UserControls.Menu
{
    partial class ToolBoxVector
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
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.B_SaveLoad = new System.Windows.Forms.Button();
            this.B_ShapeType = new System.Windows.Forms.Button();
            this.B_Width = new System.Windows.Forms.Button();
            this.B_Color = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.Controls.Add(this.B_SaveLoad, 0, 3);
            this.TLP_Main.Controls.Add(this.B_ShapeType, 0, 2);
            this.TLP_Main.Controls.Add(this.B_Width, 0, 1);
            this.TLP_Main.Controls.Add(this.B_Color, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 4;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Main.Size = new System.Drawing.Size(102, 133);
            this.TLP_Main.TabIndex = 0;
            // 
            // B_SaveLoad
            // 
            this.B_SaveLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_SaveLoad.Location = new System.Drawing.Point(3, 102);
            this.B_SaveLoad.Name = "B_SaveLoad";
            this.B_SaveLoad.Size = new System.Drawing.Size(96, 28);
            this.B_SaveLoad.TabIndex = 3;
            this.B_SaveLoad.Text = "Save / Load";
            this.B_SaveLoad.UseVisualStyleBackColor = true;
            this.B_SaveLoad.Click += new System.EventHandler(this.B_SaveLoad_Click);
            // 
            // B_ShapeType
            // 
            this.B_ShapeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_ShapeType.Location = new System.Drawing.Point(3, 69);
            this.B_ShapeType.Name = "B_ShapeType";
            this.B_ShapeType.Size = new System.Drawing.Size(96, 27);
            this.B_ShapeType.TabIndex = 2;
            this.B_ShapeType.Text = "Shape Type";
            this.B_ShapeType.UseVisualStyleBackColor = true;
            // 
            // B_Width
            // 
            this.B_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Width.Location = new System.Drawing.Point(3, 36);
            this.B_Width.Name = "B_Width";
            this.B_Width.Size = new System.Drawing.Size(96, 27);
            this.B_Width.TabIndex = 1;
            this.B_Width.Text = "Pen Width";
            this.B_Width.UseVisualStyleBackColor = true;
            // 
            // B_Color
            // 
            this.B_Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Color.Location = new System.Drawing.Point(3, 3);
            this.B_Color.Name = "B_Color";
            this.B_Color.Size = new System.Drawing.Size(96, 27);
            this.B_Color.TabIndex = 0;
            this.B_Color.Text = "Color";
            this.B_Color.UseVisualStyleBackColor = true;
            // 
            // ToolBoxVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.Name = "ToolBoxVector";
            this.Size = new System.Drawing.Size(102, 133);
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.Button B_SaveLoad;
        private System.Windows.Forms.Button B_ShapeType;
        private System.Windows.Forms.Button B_Width;
        private System.Windows.Forms.Button B_Color;
    }
}
