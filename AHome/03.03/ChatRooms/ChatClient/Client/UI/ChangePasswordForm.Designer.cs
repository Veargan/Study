namespace Client.UI
{
    partial class ChangePasswordForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChange = new System.Windows.Forms.Button();
            this.tbnewPas = new System.Windows.Forms.TextBox();
            this.tboldPas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "New password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Old password:";
            // 
            // tbChange
            // 
            this.tbChange.Location = new System.Drawing.Point(99, 67);
            this.tbChange.Name = "tbChange";
            this.tbChange.Size = new System.Drawing.Size(127, 23);
            this.tbChange.TabIndex = 22;
            this.tbChange.Text = "Change";
            this.tbChange.UseVisualStyleBackColor = true;
            this.tbChange.Click += new System.EventHandler(this.tbChange_Click);
            // 
            // tbnewPas
            // 
            this.tbnewPas.Location = new System.Drawing.Point(99, 41);
            this.tbnewPas.Name = "tbnewPas";
            this.tbnewPas.Size = new System.Drawing.Size(127, 20);
            this.tbnewPas.TabIndex = 21;
            // 
            // tboldPas
            // 
            this.tboldPas.Location = new System.Drawing.Point(99, 15);
            this.tboldPas.Name = "tboldPas";
            this.tboldPas.Size = new System.Drawing.Size(127, 20);
            this.tboldPas.TabIndex = 20;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 132);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbChange);
            this.Controls.Add(this.tbnewPas);
            this.Controls.Add(this.tboldPas);
            this.Name = "ChangePasswordForm";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tbChange;
        private System.Windows.Forms.TextBox tbnewPas;
        private System.Windows.Forms.TextBox tboldPas;
    }
}