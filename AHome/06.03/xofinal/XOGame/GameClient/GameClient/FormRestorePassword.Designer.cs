namespace GameClient
{
    partial class FormRestorePassword
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btRestore = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbLogin2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "login";
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(33, 111);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(161, 23);
            this.btRestore.TabIndex = 23;
            this.btRestore.Text = "Restore Password";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.tbRestore_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(33, 85);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(161, 20);
            this.tbEmail.TabIndex = 22;
            // 
            // tbLogin2
            // 
            this.tbLogin2.Location = new System.Drawing.Point(33, 48);
            this.tbLogin2.Name = "tbLogin2";
            this.tbLogin2.Size = new System.Drawing.Size(161, 20);
            this.tbLogin2.TabIndex = 21;
            // 
            // FormRestorePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 168);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbLogin2);
            this.Name = "FormRestorePassword";
            this.Text = "FormRestorePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbLogin2;
    }
}