namespace TreeForm
{
    partial class MainForm
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
            this.treePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // treePanel
            // 
            this.treePanel.Location = new System.Drawing.Point(12, 12);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(520, 328);
            this.treePanel.TabIndex = 0;
            this.treePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.treePanel_Paint);
            this.treePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treePanel_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 352);
            this.Controls.Add(this.treePanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel treePanel;
    }
}

