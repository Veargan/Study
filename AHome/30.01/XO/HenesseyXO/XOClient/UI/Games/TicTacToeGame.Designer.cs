namespace XOClient.UI.Games
{
    partial class TicTacToeGame
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_9 = new System.Windows.Forms.Button();
            this.B_8 = new System.Windows.Forms.Button();
            this.B_7 = new System.Windows.Forms.Button();
            this.B_6 = new System.Windows.Forms.Button();
            this.B_5 = new System.Windows.Forms.Button();
            this.B_4 = new System.Windows.Forms.Button();
            this.B_3 = new System.Windows.Forms.Button();
            this.B_2 = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.B_1 = new System.Windows.Forms.Button();
            this.toolStripShape = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTurn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.B_9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.B_8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.B_7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.B_6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatusBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.B_1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // B_9
            // 
            this.B_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_9.Location = new System.Drawing.Point(306, 250);
            this.B_9.Margin = new System.Windows.Forms.Padding(0);
            this.B_9.Name = "B_9";
            this.B_9.Size = new System.Drawing.Size(154, 125);
            this.B_9.TabIndex = 9;
            this.B_9.UseVisualStyleBackColor = true;
            this.B_9.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_8
            // 
            this.B_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_8.Location = new System.Drawing.Point(153, 250);
            this.B_8.Margin = new System.Windows.Forms.Padding(0);
            this.B_8.Name = "B_8";
            this.B_8.Size = new System.Drawing.Size(153, 125);
            this.B_8.TabIndex = 8;
            this.B_8.UseVisualStyleBackColor = true;
            this.B_8.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_7
            // 
            this.B_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_7.Location = new System.Drawing.Point(0, 250);
            this.B_7.Margin = new System.Windows.Forms.Padding(0);
            this.B_7.Name = "B_7";
            this.B_7.Size = new System.Drawing.Size(153, 125);
            this.B_7.TabIndex = 7;
            this.B_7.UseVisualStyleBackColor = true;
            this.B_7.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_6
            // 
            this.B_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_6.Location = new System.Drawing.Point(306, 125);
            this.B_6.Margin = new System.Windows.Forms.Padding(0);
            this.B_6.Name = "B_6";
            this.B_6.Size = new System.Drawing.Size(154, 125);
            this.B_6.TabIndex = 6;
            this.B_6.UseVisualStyleBackColor = true;
            this.B_6.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_5
            // 
            this.B_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_5.Location = new System.Drawing.Point(153, 125);
            this.B_5.Margin = new System.Windows.Forms.Padding(0);
            this.B_5.Name = "B_5";
            this.B_5.Size = new System.Drawing.Size(153, 125);
            this.B_5.TabIndex = 5;
            this.B_5.UseVisualStyleBackColor = true;
            this.B_5.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_4
            // 
            this.B_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_4.Location = new System.Drawing.Point(0, 125);
            this.B_4.Margin = new System.Windows.Forms.Padding(0);
            this.B_4.Name = "B_4";
            this.B_4.Size = new System.Drawing.Size(153, 125);
            this.B_4.TabIndex = 4;
            this.B_4.UseVisualStyleBackColor = true;
            this.B_4.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_3
            // 
            this.B_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_3.Location = new System.Drawing.Point(306, 0);
            this.B_3.Margin = new System.Windows.Forms.Padding(0);
            this.B_3.Name = "B_3";
            this.B_3.Size = new System.Drawing.Size(154, 125);
            this.B_3.TabIndex = 3;
            this.B_3.UseVisualStyleBackColor = true;
            this.B_3.Click += new System.EventHandler(this.OnTileClick);
            // 
            // B_2
            // 
            this.B_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_2.Location = new System.Drawing.Point(153, 0);
            this.B_2.Margin = new System.Windows.Forms.Padding(0);
            this.B_2.Name = "B_2";
            this.B_2.Size = new System.Drawing.Size(153, 125);
            this.B_2.TabIndex = 2;
            this.B_2.UseVisualStyleBackColor = true;
            this.B_2.Click += new System.EventHandler(this.OnTileClick);
            // 
            // StatusBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.StatusBar, 3);
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShape,
            this.toolStripSeparator,
            this.toolStripTurn});
            this.StatusBar.Location = new System.Drawing.Point(0, 375);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(460, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "StatusBar";
            // 
            // B_1
            // 
            this.B_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_1.Location = new System.Drawing.Point(0, 0);
            this.B_1.Margin = new System.Windows.Forms.Padding(0);
            this.B_1.Name = "B_1";
            this.B_1.Size = new System.Drawing.Size(153, 125);
            this.B_1.TabIndex = 1;
            this.B_1.UseVisualStyleBackColor = true;
            this.B_1.Click += new System.EventHandler(this.OnTileClick);
            // 
            // toolStripShape
            // 
            this.toolStripShape.Name = "toolStripShape";
            this.toolStripShape.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripTurn
            // 
            this.toolStripTurn.Name = "toolStripTurn";
            this.toolStripTurn.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(10, 17);
            this.toolStripSeparator.Text = "|";
            // 
            // TicTacToeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 397);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "TicTacToeGame";
            this.Text = "Tic-Tac-Toe Game";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Button B_9;
        private System.Windows.Forms.Button B_8;
        private System.Windows.Forms.Button B_7;
        private System.Windows.Forms.Button B_6;
        private System.Windows.Forms.Button B_5;
        private System.Windows.Forms.Button B_4;
        private System.Windows.Forms.Button B_3;
        private System.Windows.Forms.Button B_2;
        private System.Windows.Forms.Button B_1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripShape;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTurn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSeparator;
    }
}