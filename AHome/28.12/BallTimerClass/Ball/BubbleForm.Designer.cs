namespace Ball
{
    partial class BubbleForm
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
            this.frame1 = new Frame();
            this.SuspendLayout();
            // 
            // frame1
            // 
            this.frame1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.frame1.Location = new System.Drawing.Point(12, 12);
            this.frame1.Name = "frame1";
            this.frame1.Size = new System.Drawing.Size(613, 322);
            this.frame1.TabIndex = 0;
            // 
            // BubbleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 348);
            this.Controls.Add(this.frame1);
            this.Name = "BubbleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bubbles";
            this.ResumeLayout(false);

        }

        #endregion

        private Frame frame1;
    }
}

