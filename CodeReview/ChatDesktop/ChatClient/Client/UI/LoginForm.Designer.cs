namespace Client
{
    partial class LoginForm
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
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lbLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.bRegistration = new System.Windows.Forms.Button();
            this.bForgotPassword = new System.Windows.Forms.Button();
            this.btn_facebook = new System.Windows.Forms.Button();
            this.btn_google = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(60, 45);
            this.tbLogin.MaxLength = 20;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 0;
            // 
            // lbLog
            // 
            this.lbLog.Location = new System.Drawing.Point(60, 119);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(100, 23);
            this.lbLog.TabIndex = 2;
            this.lbLog.Text = "Log in";
            this.lbLog.UseVisualStyleBackColor = true;
            this.lbLog.Click += new System.EventHandler(this.lbLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter password:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(60, 89);
            this.tbPass.MaxLength = 20;
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 1;
            // 
            // bRegistration
            // 
            this.bRegistration.Location = new System.Drawing.Point(60, 177);
            this.bRegistration.Name = "bRegistration";
            this.bRegistration.Size = new System.Drawing.Size(100, 23);
            this.bRegistration.TabIndex = 3;
            this.bRegistration.Text = "Registration";
            this.bRegistration.UseVisualStyleBackColor = true;
            this.bRegistration.Click += new System.EventHandler(this.bRegistration_Click);
            // 
            // bForgotPassword
            // 
            this.bForgotPassword.Location = new System.Drawing.Point(60, 206);
            this.bForgotPassword.Name = "bForgotPassword";
            this.bForgotPassword.Size = new System.Drawing.Size(100, 23);
            this.bForgotPassword.TabIndex = 4;
            this.bForgotPassword.Text = "Forgot password";
            this.bForgotPassword.UseVisualStyleBackColor = true;
            this.bForgotPassword.Click += new System.EventHandler(this.bForgotPassword_Click);
            // 
            // btn_facebook
            // 
            this.btn_facebook.Location = new System.Drawing.Point(113, 148);
            this.btn_facebook.Name = "btn_facebook";
            this.btn_facebook.Size = new System.Drawing.Size(47, 23);
            this.btn_facebook.TabIndex = 8;
            this.btn_facebook.Text = "FB";
            this.btn_facebook.UseVisualStyleBackColor = true;
            this.btn_facebook.Click += new System.EventHandler(this.btn_facebook_Click);
            // 
            // btn_google
            // 
            this.btn_google.Location = new System.Drawing.Point(60, 148);
            this.btn_google.Name = "btn_google";
            this.btn_google.Size = new System.Drawing.Size(47, 23);
            this.btn_google.TabIndex = 7;
            this.btn_google.Text = "G+";
            this.btn_google.UseVisualStyleBackColor = true;
            this.btn_google.Click += new System.EventHandler(this.btn_google_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 258);
            this.Controls.Add(this.btn_facebook);
            this.Controls.Add(this.btn_google);
            this.Controls.Add(this.bForgotPassword);
            this.Controls.Add(this.bRegistration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.tbLogin);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button lbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button bRegistration;
        private System.Windows.Forms.Button bForgotPassword;
        private System.Windows.Forms.Button btn_facebook;
        private System.Windows.Forms.Button btn_google;
    }
}