namespace GameClient
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lb_hint = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tbLogin1 = new System.Windows.Forms.TextBox();
            this.tboldPas = new System.Windows.Forms.TextBox();
            this.tbnewPas = new System.Windows.Forms.TextBox();
            this.tbChange = new System.Windows.Forms.Button();
            this.tbLogin2 = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btRestore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_facebook = new System.Windows.Forms.Button();
            this.btn_google = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(32, 104);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(196, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Tag = "login";
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(32, 36);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(196, 20);
            this.tbLogin.TabIndex = 2;
            // 
            // lb_hint
            // 
            this.lb_hint.AutoSize = true;
            this.lb_hint.Location = new System.Drawing.Point(85, 20);
            this.lb_hint.Name = "lb_hint";
            this.lb_hint.Size = new System.Drawing.Size(81, 13);
            this.lb_hint.TabIndex = 3;
            this.lb_hint.Text = "Enter username";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(32, 168);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(196, 23);
            this.btnReg.TabIndex = 5;
            this.btnReg.Tag = "reg";
            this.btnReg.Text = "Registration";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(32, 62);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(196, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 194);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change password";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(29, 217);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(85, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Forgot password";
            // 
            // tbLogin1
            // 
            this.tbLogin1.Location = new System.Drawing.Point(257, 36);
            this.tbLogin1.Name = "tbLogin1";
            this.tbLogin1.Size = new System.Drawing.Size(127, 20);
            this.tbLogin1.TabIndex = 8;
            // 
            // tboldPas
            // 
            this.tboldPas.Location = new System.Drawing.Point(257, 62);
            this.tboldPas.Name = "tboldPas";
            this.tboldPas.Size = new System.Drawing.Size(127, 20);
            this.tboldPas.TabIndex = 9;
            // 
            // tbnewPas
            // 
            this.tbnewPas.Location = new System.Drawing.Point(257, 88);
            this.tbnewPas.Name = "tbnewPas";
            this.tbnewPas.Size = new System.Drawing.Size(127, 20);
            this.tbnewPas.TabIndex = 10;
            // 
            // tbChange
            // 
            this.tbChange.Location = new System.Drawing.Point(257, 114);
            this.tbChange.Name = "tbChange";
            this.tbChange.Size = new System.Drawing.Size(127, 23);
            this.tbChange.TabIndex = 11;
            this.tbChange.Text = "Change";
            this.tbChange.UseVisualStyleBackColor = true;
            this.tbChange.Click += new System.EventHandler(this.tbChange_Click);
            // 
            // tbLogin2
            // 
            this.tbLogin2.Location = new System.Drawing.Point(254, 197);
            this.tbLogin2.Name = "tbLogin2";
            this.tbLogin2.Size = new System.Drawing.Size(127, 20);
            this.tbLogin2.TabIndex = 12;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(254, 223);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(127, 20);
            this.tbEmail.TabIndex = 13;
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(254, 249);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(127, 23);
            this.btRestore.TabIndex = 14;
            this.btRestore.Text = "Restore Email";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "old password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "new password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "email";
            // 
            // btn_facebook
            // 
            this.btn_facebook.Location = new System.Drawing.Point(32, 139);
            this.btn_facebook.Name = "btn_facebook";
            this.btn_facebook.Size = new System.Drawing.Size(89, 23);
            this.btn_facebook.TabIndex = 21;
            this.btn_facebook.Tag = "g+_auth";
            this.btn_facebook.Text = "Facebook";
            this.btn_facebook.UseVisualStyleBackColor = true;
            this.btn_facebook.Click += new System.EventHandler(this.btn_externalAuth_Click);
            // 
            // btn_google
            // 
            this.btn_google.Location = new System.Drawing.Point(139, 139);
            this.btn_google.Name = "btn_google";
            this.btn_google.Size = new System.Drawing.Size(89, 23);
            this.btn_google.TabIndex = 22;
            this.btn_google.Text = "Google";
            this.btn_google.UseVisualStyleBackColor = true;
            this.btn_google.Click += new System.EventHandler(this.btn_externalAuth_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 494);
            this.Controls.Add(this.btn_google);
            this.Controls.Add(this.btn_facebook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbLogin2);
            this.Controls.Add(this.tbChange);
            this.Controls.Add(this.tbnewPas);
            this.Controls.Add(this.tboldPas);
            this.Controls.Add(this.tbLogin1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.lb_hint);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Authorize";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lb_hint;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox tbLogin1;
        private System.Windows.Forms.TextBox tboldPas;
        private System.Windows.Forms.TextBox tbnewPas;
        private System.Windows.Forms.Button tbChange;
        private System.Windows.Forms.TextBox tbLogin2;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_facebook;
        private System.Windows.Forms.Button btn_google;
    }
}

