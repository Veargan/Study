namespace GameClient
{
    partial class FormChangePass
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
            this.tbChange = new System.Windows.Forms.Button();
            this.tbnewPas = new System.Windows.Forms.TextBox();
            this.tboldPas = new System.Windows.Forms.TextBox();
            this.tbLogin1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbChange
            // 
            this.tbChange.Location = new System.Drawing.Point(40, 144);
            this.tbChange.Name = "tbChange";
            this.tbChange.Size = new System.Drawing.Size(152, 23);
            this.tbChange.TabIndex = 15;
            this.tbChange.Text = "Change";
            this.tbChange.UseVisualStyleBackColor = true;
            this.tbChange.Click += new System.EventHandler(this.tbChange_Click);
            // 
            // tbnewPas
            // 
            this.tbnewPas.Location = new System.Drawing.Point(40, 115);
            this.tbnewPas.Name = "tbnewPas";
            this.tbnewPas.Size = new System.Drawing.Size(152, 20);
            this.tbnewPas.TabIndex = 14;
            // 
            // tboldPas
            // 
            this.tboldPas.Location = new System.Drawing.Point(40, 80);
            this.tboldPas.Name = "tboldPas";
            this.tboldPas.Size = new System.Drawing.Size(152, 20);
            this.tboldPas.TabIndex = 13;
            // 
            // tbLogin1
            // 
            this.tbLogin1.Location = new System.Drawing.Point(40, 45);
            this.tbLogin1.Name = "tbLogin1";
            this.tbLogin1.Size = new System.Drawing.Size(152, 20);
            this.tbLogin1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "new password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "old password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "login";
            // 
            // FormChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 201);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbChange);
            this.Controls.Add(this.tbnewPas);
            this.Controls.Add(this.tboldPas);
            this.Controls.Add(this.tbLogin1);
            this.Name = "FormChangePass";
            this.Text = "FormChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tbChange;
        private System.Windows.Forms.TextBox tbnewPas;
        private System.Windows.Forms.TextBox tboldPas;
        private System.Windows.Forms.TextBox tbLogin1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}