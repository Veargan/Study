namespace GameClient
{
    partial class GameXO
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
            this.btn0 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.lb_turn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(61, 42);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(40, 36);
            this.btn0.TabIndex = 0;
            this.btn0.Tag = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(61, 84);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(40, 36);
            this.btn3.TabIndex = 3;
            this.btn3.Tag = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(107, 42);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(40, 36);
            this.btn1.TabIndex = 4;
            this.btn1.Tag = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(154, 42);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(40, 36);
            this.btn2.TabIndex = 5;
            this.btn2.Tag = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(107, 84);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(40, 36);
            this.btn4.TabIndex = 6;
            this.btn4.Tag = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(154, 84);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(40, 36);
            this.btn5.TabIndex = 7;
            this.btn5.Tag = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(61, 126);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(40, 36);
            this.btn6.TabIndex = 8;
            this.btn6.Tag = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(107, 126);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(40, 36);
            this.btn7.TabIndex = 9;
            this.btn7.Tag = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(153, 126);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(40, 36);
            this.btn8.TabIndex = 10;
            this.btn8.Tag = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btnXO_Click);
            // 
            // lb_turn
            // 
            this.lb_turn.AutoSize = true;
            this.lb_turn.Location = new System.Drawing.Point(92, 9);
            this.lb_turn.Name = "lb_turn";
            this.lb_turn.Size = new System.Drawing.Size(68, 13);
            this.lb_turn.TabIndex = 11;
            this.lb_turn.Text = "Not your turn";
            // 
            // GameXO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 227);
            this.Controls.Add(this.lb_turn);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameXO";
            this.Text = "GameXO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameXO_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Label lb_turn;
    }
}