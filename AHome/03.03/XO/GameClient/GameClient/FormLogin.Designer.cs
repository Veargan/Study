namespace GameClient
{
    partial class FormLogin
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
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.lb_hint = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(23, 199);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(85, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Forgot password";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(23, 176);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(26, 79);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(196, 20);
            this.tbPassword.TabIndex = 9;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(26, 150);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(196, 23);
            this.btnReg.TabIndex = 12;
            this.btnReg.Tag = "reg";
            this.btnReg.Text = "Registration";
            this.btnReg.UseVisualStyleBackColor = true;
            // 
            // lb_hint
            // 
            this.lb_hint.AutoSize = true;
            this.lb_hint.Location = new System.Drawing.Point(79, 37);
            this.lb_hint.Name = "lb_hint";
            this.lb_hint.Size = new System.Drawing.Size(81, 13);
            this.lb_hint.TabIndex = 10;
            this.lb_hint.Text = "Enter username";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(26, 53);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(196, 20);
            this.tbLogin.TabIndex = 8;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(26, 121);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(196, 23);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Tag = "login";
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.lb_hint);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btnLogin);
            this.Name = "FormLogin";
            this.Size = new System.Drawing.Size(244, 249);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label lb_hint;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btnLogin;
    }
}
