namespace Paint.Dialogs
{
    partial class WidthDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.NUD_Width = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.NUD_Width, 0, 1);
            this.TLP_Main.Controls.Add(this.label1, 0, 0);
            this.TLP_Main.Location = new System.Drawing.Point(3, 5);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 2;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(323, 54);
            this.TLP_Main.TabIndex = 7;
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
            this.NUD_Width.Size = new System.Drawing.Size(313, 20);
            this.NUD_Width.TabIndex = 6;
            this.NUD_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(248, 65);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // WidthDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 93);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.TLP_Main);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WidthDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WidthDialog";
            this.TLP_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.NumericUpDown NUD_Width;
        private System.Windows.Forms.Button buttonOK;
    }
}