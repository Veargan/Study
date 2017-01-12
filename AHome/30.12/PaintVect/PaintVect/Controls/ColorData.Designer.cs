namespace RisovalkaTrue
{
    partial class ColorData
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
            this.btnred = new System.Windows.Forms.Button();
            this.btnblue = new System.Windows.Forms.Button();
            this.btngreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnred
            // 
            this.btnred.Location = new System.Drawing.Point(34, 22);
            this.btnred.Name = "btnred";
            this.btnred.Size = new System.Drawing.Size(75, 23);
            this.btnred.TabIndex = 0;
            this.btnred.Text = "Red";
            this.btnred.UseVisualStyleBackColor = true;
            // 
            // btnblue
            // 
            this.btnblue.Location = new System.Drawing.Point(34, 65);
            this.btnblue.Name = "btnblue";
            this.btnblue.Size = new System.Drawing.Size(75, 23);
            this.btnblue.TabIndex = 1;
            this.btnblue.Text = "Blue";
            this.btnblue.UseVisualStyleBackColor = true;
            // 
            // btngreen
            // 
            this.btngreen.Location = new System.Drawing.Point(34, 107);
            this.btngreen.Name = "btngreen";
            this.btngreen.Size = new System.Drawing.Size(75, 23);
            this.btngreen.TabIndex = 2;
            this.btngreen.Text = "Green";
            this.btngreen.UseVisualStyleBackColor = true;
            // 
            // ColorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btngreen);
            this.Controls.Add(this.btnblue);
            this.Controls.Add(this.btnred);
            this.Name = "ColorData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnred;
        private System.Windows.Forms.Button btnblue;
        private System.Windows.Forms.Button btngreen;
    }
}
