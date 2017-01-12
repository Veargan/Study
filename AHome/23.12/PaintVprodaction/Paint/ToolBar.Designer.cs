namespace Paint
{
    partial class ToolBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolSave = new System.Windows.Forms.Button();
            this.toolLoad = new System.Windows.Forms.Button();
            this.toolCol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolSave
            // 
            this.toolSave.BackColor = System.Drawing.SystemColors.Menu;
            this.toolSave.ForeColor = System.Drawing.SystemColors.InfoText;
            this.toolSave.Location = new System.Drawing.Point(3, 3);
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(30, 30);
            this.toolSave.TabIndex = 0;
            this.toolSave.Text = "S";
            this.toolSave.UseVisualStyleBackColor = false;
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolLoad
            // 
            this.toolLoad.BackColor = System.Drawing.SystemColors.Menu;
            this.toolLoad.ForeColor = System.Drawing.SystemColors.InfoText;
            this.toolLoad.Location = new System.Drawing.Point(39, 3);
            this.toolLoad.Name = "toolLoad";
            this.toolLoad.Size = new System.Drawing.Size(30, 30);
            this.toolLoad.TabIndex = 1;
            this.toolLoad.Text = "L";
            this.toolLoad.UseVisualStyleBackColor = false;
            this.toolLoad.Click += new System.EventHandler(this.toolLoad_Click);
            // 
            // toolCol
            // 
            this.toolCol.BackColor = System.Drawing.SystemColors.Menu;
            this.toolCol.ForeColor = System.Drawing.SystemColors.InfoText;
            this.toolCol.Location = new System.Drawing.Point(75, 3);
            this.toolCol.Name = "toolCol";
            this.toolCol.Size = new System.Drawing.Size(30, 30);
            this.toolCol.TabIndex = 2;
            this.toolCol.Text = "C";
            this.toolCol.UseVisualStyleBackColor = false;
            this.toolCol.Click += new System.EventHandler(this.toolCol_Click);
            // 
            // ToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.toolCol);
            this.Controls.Add(this.toolLoad);
            this.Controls.Add(this.toolSave);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Name = "ToolBar";
            this.Size = new System.Drawing.Size(458, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toolSave;
        private System.Windows.Forms.Button toolLoad;
        private System.Windows.Forms.Button toolCol;
    }
}
