namespace GameClient
{
    partial class RoomForm
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
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(13, 209);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(184, 20);
            this.tbMessage.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(203, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(203, 207);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbChat
            // 
            this.tbChat.Location = new System.Drawing.Point(12, 28);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ReadOnly = true;
            this.tbChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChat.Size = new System.Drawing.Size(185, 175);
            this.tbChat.TabIndex = 4;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbMessage);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbChat;
    }
}