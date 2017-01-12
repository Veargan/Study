namespace PersonFormDialog
{
    partial class UpdateDialog
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
            this.tId = new System.Windows.Forms.TextBox();
            this.tFname = new System.Windows.Forms.TextBox();
            this.tLname = new System.Windows.Forms.TextBox();
            this.tAge = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tId
            // 
            this.tId.Location = new System.Drawing.Point(12, 42);
            this.tId.Name = "tId";
            this.tId.ReadOnly = true;
            this.tId.Size = new System.Drawing.Size(109, 20);
            this.tId.TabIndex = 0;
            // 
            // tFname
            // 
            this.tFname.Location = new System.Drawing.Point(146, 42);
            this.tFname.Name = "tFname";
            this.tFname.Size = new System.Drawing.Size(109, 20);
            this.tFname.TabIndex = 1;
            // 
            // tLname
            // 
            this.tLname.Location = new System.Drawing.Point(281, 42);
            this.tLname.Name = "tLname";
            this.tLname.Size = new System.Drawing.Size(109, 20);
            this.tLname.TabIndex = 2;
            // 
            // tAge
            // 
            this.tAge.Location = new System.Drawing.Point(418, 42);
            this.tAge.Name = "tAge";
            this.tAge.Size = new System.Drawing.Size(109, 20);
            this.tAge.TabIndex = 3;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(145, 89);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(110, 26);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(281, 89);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 26);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 134);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tAge);
            this.Controls.Add(this.tLname);
            this.Controls.Add(this.tFname);
            this.Controls.Add(this.tId);
            this.Name = "UpdateDialog";
            this.Text = "UpdateDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tId;
        private System.Windows.Forms.TextBox tFname;
        private System.Windows.Forms.TextBox tLname;
        private System.Windows.Forms.TextBox tAge;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
    }
}