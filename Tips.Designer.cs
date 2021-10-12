namespace Aircraft
{
    partial class Tips
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
            this.SkipBtn = new System.Windows.Forms.Button();
            this.ModBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SkipBtn
            // 
            this.SkipBtn.BackColor = System.Drawing.Color.White;
            this.SkipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.SkipBtn.Location = new System.Drawing.Point(374, 85);
            this.SkipBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SkipBtn.Name = "SkipBtn";
            this.SkipBtn.Size = new System.Drawing.Size(112, 24);
            this.SkipBtn.TabIndex = 11;
            this.SkipBtn.Text = "Skip";
            this.SkipBtn.UseVisualStyleBackColor = false;
            this.SkipBtn.Click += new System.EventHandler(this.SkipBtn_Click);
            // 
            // ModBtn
            // 
            this.ModBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ModBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.ModBtn.Location = new System.Drawing.Point(173, 85);
            this.ModBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ModBtn.Name = "ModBtn";
            this.ModBtn.Size = new System.Drawing.Size(112, 24);
            this.ModBtn.TabIndex = 10;
            this.ModBtn.Text = "Modify Password";
            this.ModBtn.UseVisualStyleBackColor = false;
            this.ModBtn.Click += new System.EventHandler(this.ModBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.Location = new System.Drawing.Point(113, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "it is recommended that you change the original login password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 10F);
            this.label2.Location = new System.Drawing.Point(259, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "For security reasons,";
            // 
            // Tips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 128);
            this.Controls.Add(this.SkipBtn);
            this.Controls.Add(this.ModBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Tips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tips";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SkipBtn;
        private System.Windows.Forms.Button ModBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}