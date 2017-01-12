namespace App1
{
    partial class Form1
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
            this.butColor = new System.Windows.Forms.Button();
            this.butFolder = new System.Windows.Forms.Button();
            this.butFont = new System.Windows.Forms.Button();
            this.butOpen = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butMessage = new System.Windows.Forms.Button();
            this.butPageSet = new System.Windows.Forms.Button();
            this.butPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butColor
            // 
            this.butColor.Location = new System.Drawing.Point(26, 12);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(75, 23);
            this.butColor.TabIndex = 0;
            this.butColor.Text = "Color";
            this.butColor.UseVisualStyleBackColor = true;
            this.butColor.Click += new System.EventHandler(this.but_Click);
            // 
            // butFolder
            // 
            this.butFolder.Location = new System.Drawing.Point(26, 41);
            this.butFolder.Name = "butFolder";
            this.butFolder.Size = new System.Drawing.Size(75, 23);
            this.butFolder.TabIndex = 1;
            this.butFolder.Text = "FolderBrows";
            this.butFolder.UseVisualStyleBackColor = true;
            this.butFolder.Click += new System.EventHandler(this.but_Click);
            // 
            // butFont
            // 
            this.butFont.Location = new System.Drawing.Point(26, 70);
            this.butFont.Name = "butFont";
            this.butFont.Size = new System.Drawing.Size(75, 23);
            this.butFont.TabIndex = 2;
            this.butFont.Text = "Font";
            this.butFont.UseVisualStyleBackColor = true;
            this.butFont.Click += new System.EventHandler(this.but_Click);
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(26, 99);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(75, 23);
            this.butOpen.TabIndex = 3;
            this.butOpen.Text = "OpenFile";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.but_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(26, 128);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "SaveFile";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.but_Click);
            // 
            // butMessage
            // 
            this.butMessage.Location = new System.Drawing.Point(26, 215);
            this.butMessage.Name = "butMessage";
            this.butMessage.Size = new System.Drawing.Size(75, 23);
            this.butMessage.TabIndex = 5;
            this.butMessage.Text = "MessBox";
            this.butMessage.UseVisualStyleBackColor = true;
            this.butMessage.Click += new System.EventHandler(this.but_Click);
            // 
            // butPageSet
            // 
            this.butPageSet.Location = new System.Drawing.Point(26, 157);
            this.butPageSet.Name = "butPageSet";
            this.butPageSet.Size = new System.Drawing.Size(75, 23);
            this.butPageSet.TabIndex = 6;
            this.butPageSet.Text = "PageSetup";
            this.butPageSet.UseVisualStyleBackColor = true;
            this.butPageSet.Click += new System.EventHandler(this.but_Click);
            // 
            // butPrint
            // 
            this.butPrint.Location = new System.Drawing.Point(26, 186);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(75, 23);
            this.butPrint.TabIndex = 7;
            this.butPrint.Text = "Print";
            this.butPrint.UseVisualStyleBackColor = true;
            this.butPrint.Click += new System.EventHandler(this.but_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(131, 248);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.butPageSet);
            this.Controls.Add(this.butMessage);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.butFont);
            this.Controls.Add(this.butFolder);
            this.Controls.Add(this.butColor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.Button butFolder;
        private System.Windows.Forms.Button butFont;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butMessage;
        private System.Windows.Forms.Button butPageSet;
        private System.Windows.Forms.Button butPrint;
    }
}

