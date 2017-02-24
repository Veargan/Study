namespace GameClient
{
    partial class PlayersList
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
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.btnInvite = new System.Windows.Forms.Button();
            this.lb_players = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.RefreshPlayers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPlayers
            // 
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.Location = new System.Drawing.Point(12, 48);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(178, 264);
            this.lbPlayers.TabIndex = 0;
            // 
            // cbGame
            // 
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Items.AddRange(new object[] {
            "XO"});
            this.cbGame.Location = new System.Drawing.Point(219, 12);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(121, 21);
            this.cbGame.TabIndex = 1;
            // 
            // btnInvite
            // 
            this.btnInvite.Location = new System.Drawing.Point(244, 48);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(75, 23);
            this.btnInvite.TabIndex = 2;
            this.btnInvite.Text = "Invite player";
            this.btnInvite.UseVisualStyleBackColor = true;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // lb_players
            // 
            this.lb_players.AutoSize = true;
            this.lb_players.Location = new System.Drawing.Point(12, 32);
            this.lb_players.Name = "lb_players";
            this.lb_players.Size = new System.Drawing.Size(41, 13);
            this.lb_players.TabIndex = 3;
            this.lb_players.Text = "Players";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(12, 9);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(35, 13);
            this.lb_name.TabIndex = 4;
            this.lb_name.Text = "label1";
            // 
            // RefreshPlayers
            // 
            this.RefreshPlayers.Location = new System.Drawing.Point(219, 93);
            this.RefreshPlayers.Name = "RefreshPlayers";
            this.RefreshPlayers.Size = new System.Drawing.Size(113, 23);
            this.RefreshPlayers.TabIndex = 5;
            this.RefreshPlayers.Text = "Refresh Players";
            this.RefreshPlayers.UseVisualStyleBackColor = true;
            this.RefreshPlayers.Click += new System.EventHandler(this.RefreshPlayers_Click);
            // 
            // PlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 319);
            this.Controls.Add(this.RefreshPlayers);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_players);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.cbGame);
            this.Controls.Add(this.lbPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PlayersList";
            this.Text = "PlayersList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayersList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayersList_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPlayers;
        private System.Windows.Forms.ComboBox cbGame;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Label lb_players;
        public System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Button RefreshPlayers;
    }
}