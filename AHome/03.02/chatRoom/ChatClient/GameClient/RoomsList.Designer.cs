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
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
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
            this.btnNew.Location = new System.Drawing.Point(244, 48);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New room";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(244, 77);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(244, 22);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(100, 20);
            this.tbRoomName.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(244, 253);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // RoomsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 319);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tbRoomName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbRooms);
            this.Name = "RoomsList";
            this.Text = "RoomList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RoomList_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.Button btnLogout;
    }
}