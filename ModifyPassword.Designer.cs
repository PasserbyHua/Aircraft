namespace Aircraft
{
    partial class ModifyPassword
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
            this.passagainerror = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SubBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newpasstxtagain = new System.Windows.Forms.TextBox();
            this.newpasstxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passagainerror
            // 
            this.passagainerror.AutoSize = true;
            this.passagainerror.Font = new System.Drawing.Font("黑体", 10F);
            this.passagainerror.ForeColor = System.Drawing.Color.Red;
            this.passagainerror.Location = new System.Drawing.Point(203, 218);
            this.passagainerror.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passagainerror.Name = "passagainerror";
            this.passagainerror.Size = new System.Drawing.Size(161, 14);
            this.passagainerror.TabIndex = 32;
            this.passagainerror.Text = "两次输入的密码不一致！";
            this.passagainerror.Visible = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.CancelBtn.Location = new System.Drawing.Point(345, 255);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(82, 30);
            this.CancelBtn.TabIndex = 31;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SubBtn
            // 
            this.SubBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.SubBtn.Location = new System.Drawing.Point(151, 255);
            this.SubBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SubBtn.Name = "SubBtn";
            this.SubBtn.Size = new System.Drawing.Size(82, 30);
            this.SubBtn.TabIndex = 30;
            this.SubBtn.Text = "Submit";
            this.SubBtn.UseVisualStyleBackColor = true;
            this.SubBtn.Click += new System.EventHandler(this.SubBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.Location = new System.Drawing.Point(66, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "New Password Again:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F);
            this.label5.Location = new System.Drawing.Point(107, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "New Password:";
            // 
            // newpasstxtagain
            // 
            this.newpasstxtagain.Location = new System.Drawing.Point(205, 196);
            this.newpasstxtagain.Margin = new System.Windows.Forms.Padding(2);
            this.newpasstxtagain.Name = "newpasstxtagain";
            this.newpasstxtagain.PasswordChar = '*';
            this.newpasstxtagain.Size = new System.Drawing.Size(200, 21);
            this.newpasstxtagain.TabIndex = 27;
            // 
            // newpasstxt
            // 
            this.newpasstxt.Location = new System.Drawing.Point(205, 163);
            this.newpasstxt.Margin = new System.Windows.Forms.Padding(2);
            this.newpasstxt.Name = "newpasstxt";
            this.newpasstxt.PasswordChar = '*';
            this.newpasstxt.Size = new System.Drawing.Size(200, 21);
            this.newpasstxt.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F);
            this.label4.Location = new System.Drawing.Point(161, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Name:";
            // 
            // NameText
            // 
            this.NameText.Enabled = false;
            this.NameText.Location = new System.Drawing.Point(205, 130);
            this.NameText.Margin = new System.Windows.Forms.Padding(2);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(200, 21);
            this.NameText.TabIndex = 24;
            // 
            // EmailText
            // 
            this.EmailText.Enabled = false;
            this.EmailText.Location = new System.Drawing.Point(205, 98);
            this.EmailText.Margin = new System.Windows.Forms.Padding(2);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(200, 21);
            this.EmailText.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.Location = new System.Drawing.Point(154, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 18F);
            this.label1.Location = new System.Drawing.Point(211, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Modify Password";
            // 
            // ModifyPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.newpasstxtagain);
            this.Controls.Add(this.passagainerror);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newpasstxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.EmailText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModifyPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModifyPassword";
            this.Load += new System.EventHandler(this.ModifyPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passagainerror;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SubBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newpasstxtagain;
        private System.Windows.Forms.TextBox newpasstxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}