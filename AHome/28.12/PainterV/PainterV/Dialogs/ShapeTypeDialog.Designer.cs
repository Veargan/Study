namespace Paint.Dialogs
{
    partial class ShapeTypeDialog
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
            this.CB_ShapeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
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
            this.CB_ShapeType.Size = new System.Drawing.Size(234, 21);
            this.CB_ShapeType.TabIndex = 9;
            this.CB_ShapeType.SelectedIndexChanged += new System.EventHandler(this.CB_ShapeType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shape Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.CB_ShapeType, 0, 1);
            this.TLP_Main.Controls.Add(this.label2, 0, 0);
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 2;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(240, 50);
            this.TLP_Main.TabIndex = 10;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(162, 56);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ShapeTypeDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 84);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.TLP_Main);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShapeTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShapeTypeDialog";
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_ShapeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.Button buttonOK;
    }
}