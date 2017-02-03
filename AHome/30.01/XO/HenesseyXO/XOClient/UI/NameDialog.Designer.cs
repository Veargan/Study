namespace XOClient.UI
{
    partial class NameDialog
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
            this.OK = new System.Windows.Forms.Button();
            this.L_EnterNickname = new System.Windows.Forms.Label();
            this.TB_Nickname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(180, 56);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "&OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // L_EnterNickname
            // 
            this.L_EnterNickname.Dock = System.Windows.Forms.DockStyle.Top;
            this.L_EnterNickname.Location = new System.Drawing.Point(0, 0);
            this.L_EnterNickname.Margin = new System.Windows.Forms.Padding(3);
            this.L_EnterNickname.Name = "L_EnterNickname";
            this.L_EnterNickname.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.L_EnterNickname.Size = new System.Drawing.Size(267, 23);
            this.L_EnterNickname.TabIndex = 1;
            this.L_EnterNickname.Text = "Enter your nickname:";
            // 
            // TB_Nickname
            // 
            this.TB_Nickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Nickname.Location = new System.Drawing.Point(13, 30);
            this.TB_Nickname.Name = "TB_Nickname";
            this.TB_Nickname.Size = new System.Drawing.Size(242, 20);
            this.TB_Nickname.TabIndex = 2;
            // 
            // NameDialog
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 91);
            this.Controls.Add(this.TB_Nickname);
            this.Controls.Add(this.L_EnterNickname);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nickname Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label L_EnterNickname;
        private System.Windows.Forms.TextBox TB_Nickname;
    }
}