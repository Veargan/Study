namespace Painter.UserControls.VectorElements
{
    partial class ShapeTypeSelectorVector
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
            this.CB_ShapeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.CB_ShapeType, 0, 1);
            this.TLP_Main.Controls.Add(this.label2, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 2;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(150, 51);
            this.TLP_Main.TabIndex = 9;
            // 
            // CB_ShapeType
            // 
            this.CB_ShapeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_ShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ShapeType.FormattingEnabled = true;
            this.CB_ShapeType.Items.AddRange(new object[] {
            "Line",
            "Multiline",
            "Ellipse",
            "Rectangle",
            "Curved rect"});
            this.CB_ShapeType.Location = new System.Drawing.Point(3, 23);
            this.CB_ShapeType.Name = "CB_ShapeType";
            this.CB_ShapeType.Size = new System.Drawing.Size(144, 21);
            this.CB_ShapeType.TabIndex = 9;
            this.CB_ShapeType.SelectedIndexChanged += new System.EventHandler(this.CB_ShapeType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shape Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShapeTypeSelectorVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.Name = "ShapeTypeSelectorVector";
            this.Size = new System.Drawing.Size(150, 51);
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.ComboBox CB_ShapeType;
        private System.Windows.Forms.Label label2;
    }
}
