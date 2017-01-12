namespace Painter.UserControls.VectorElements
{
    partial class PenWidthSelectorVector
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
            this.NUD_Width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TLP_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.NUD_Width, 0, 1);
            this.TLP_Main.Controls.Add(this.label1, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 2;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(150, 54);
            this.TLP_Main.TabIndex = 6;
            // 
            // NUD_Width
            // 
            this.NUD_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_Width.Location = new System.Drawing.Point(5, 25);
            this.NUD_Width.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_Width.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUD_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Width.Name = "NUD_Width";
            this.NUD_Width.Size = new System.Drawing.Size(140, 20);
            this.NUD_Width.TabIndex = 6;
            this.NUD_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Width.ValueChanged += new System.EventHandler(this.NUD_Width_ValueChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PenWidthSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.Name = "PenWidthSelector";
            this.Size = new System.Drawing.Size(150, 54);
            this.TLP_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.NumericUpDown NUD_Width;
        private System.Windows.Forms.Label label1;
    }
}
