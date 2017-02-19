namespace GameClient
{
    partial class RoomsList
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
            this.components = new System.ComponentModel.Container();
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbClients = new System.Windows.Forms.ListBox();
            this.btnPmsg = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnUnban = new System.Windows.Forms.Button();
            this.tbPrivateMsg = new System.Windows.Forms.TextBox();
            this.tb_banTime = new System.Windows.Forms.TextBox();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // lbRooms
            // 
            this.lbRooms.FormattingEnabled = true;
            this.lbRooms.Location = new System.Drawing.Point(12, 12);
            this.lbRooms.Name = "lbRooms";
            this.lbRooms.Size = new System.Drawing.Size(178, 264);
            this.lbRooms.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(196, 48);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New room";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(196, 77);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(196, 22);
            this.tbRoomName.MaxLength = 20;
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(100, 20);
            this.tbRoomName.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(196, 253);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbClients
            // 
            this.lbClients.FormattingEnabled = true;
            this.lbClients.Location = new System.Drawing.Point(302, 12);
            this.lbClients.Name = "lbClients";
            this.lbClients.Size = new System.Drawing.Size(178, 264);
            this.lbClients.TabIndex = 6;
            // 
            // btnPmsg
            // 
            this.btnPmsg.Location = new System.Drawing.Point(380, 308);
            this.btnPmsg.Name = "btnPmsg";
            this.btnPmsg.Size = new System.Drawing.Size(100, 23);
            this.btnPmsg.TabIndex = 7;
            this.btnPmsg.Text = "Private msg";
            this.btnPmsg.UseVisualStyleBackColor = true;
            this.btnPmsg.Click += new System.EventHandler(this.btnPmsg_Click);
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(486, 48);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(100, 23);
            this.btnBan.TabIndex = 8;
            this.btnBan.Text = "Ban";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Visible = false;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnUnban
            // 
            this.btnUnban.Location = new System.Drawing.Point(486, 77);
            this.btnUnban.Name = "btnUnban";
            this.btnUnban.Size = new System.Drawing.Size(99, 22);
            this.btnUnban.TabIndex = 9;
            this.btnUnban.Text = "Unban";
            this.btnUnban.UseVisualStyleBackColor = true;
            this.btnUnban.Visible = false;
            this.btnUnban.Click += new System.EventHandler(this.btnUnban_Click);
            // 
            // tbPrivateMsg
            // 
            this.tbPrivateMsg.Location = new System.Drawing.Point(302, 282);
            this.tbPrivateMsg.MaxLength = 100;
            this.tbPrivateMsg.Name = "tbPrivateMsg";
            this.tbPrivateMsg.Size = new System.Drawing.Size(178, 20);
            this.tbPrivateMsg.TabIndex = 10;
            // 
            // tb_banTime
            // 
            this.tb_banTime.Location = new System.Drawing.Point(486, 22);
            this.tb_banTime.MaxLength = 4;
            this.tb_banTime.Name = "tb_banTime";
            this.tb_banTime.Size = new System.Drawing.Size(100, 20);
            this.tb_banTime.TabIndex = 11;
            this.tb_banTime.Visible = false;
            this.tb_banTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_banTime_KeyPress);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(196, 106);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(100, 23);
            this.btnUnsubscribe.TabIndex = 13;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // RoomsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 358);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.tb_banTime);
            this.Controls.Add(this.tbPrivateMsg);
            this.Controls.Add(this.btnUnban);
            this.Controls.Add(this.btnBan);
            this.Controls.Add(this.btnPmsg);
            this.Controls.Add(this.lbClients);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tbRoomName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbRooms);
            this.Name = "RoomsList";
            this.Text = "RoomList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomsList_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.Button btnPmsg;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Button btnUnban;
        private System.Windows.Forms.TextBox tbPrivateMsg;
        private System.Windows.Forms.TextBox tb_banTime;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}