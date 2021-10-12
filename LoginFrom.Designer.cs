namespace Aircraft
{
    partial class LoginFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.verCodepanel = new System.Windows.Forms.Panel();
            this.txtValidCode = new System.Windows.Forms.TextBox();
            this.picValidCode = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ModPassLink = new System.Windows.Forms.LinkLabel();
            this.PassText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.AutoCheck = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.verCodepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).BeginInit();
            this.SuspendLayout();
            // 
            // verCodepanel
            // 
            this.verCodepanel.Controls.Add(this.txtValidCode);
            this.verCodepanel.Controls.Add(this.picValidCode);
            this.verCodepanel.Controls.Add(this.label5);
            this.verCodepanel.Location = new System.Drawing.Point(33, 168);
            this.verCodepanel.Margin = new System.Windows.Forms.Padding(2);
            this.verCodepanel.Name = "verCodepanel";
            this.verCodepanel.Size = new System.Drawing.Size(448, 28);
            this.verCodepanel.TabIndex = 26;
            this.verCodepanel.Visible = false;
            // 
            // txtValidCode
            // 
            this.txtValidCode.Location = new System.Drawing.Point(151, 4);
            this.txtValidCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtValidCode.Name = "txtValidCode";
            this.txtValidCode.Size = new System.Drawing.Size(200, 21);
            this.txtValidCode.TabIndex = 11;
            // 
            // picValidCode
            // 
            this.picValidCode.Location = new System.Drawing.Point(355, 4);
            this.picValidCode.Margin = new System.Windows.Forms.Padding(2);
            this.picValidCode.Name = "picValidCode";
            this.picValidCode.Size = new System.Drawing.Size(78, 20);
            this.picValidCode.TabIndex = 14;
            this.picValidCode.TabStop = false;
            this.picValidCode.Click += new System.EventHandler(this.picValidCode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F);
            this.label5.Location = new System.Drawing.Point(19, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "verification Code:";
            // 
            // ModPassLink
            // 
            this.ModPassLink.AutoSize = true;
            this.ModPassLink.Font = new System.Drawing.Font("黑体", 9F);
            this.ModPassLink.Location = new System.Drawing.Point(387, 145);
            this.ModPassLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ModPassLink.Name = "ModPassLink";
            this.ModPassLink.Size = new System.Drawing.Size(95, 12);
            this.ModPassLink.TabIndex = 25;
            this.ModPassLink.TabStop = true;
            this.ModPassLink.Text = "Modify Password";
            this.ModPassLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ModPassLink_LinkClicked);
            // 
            // PassText
            // 
            this.PassText.Location = new System.Drawing.Point(184, 138);
            this.PassText.Margin = new System.Windows.Forms.Padding(2);
            this.PassText.Name = "PassText";
            this.PassText.PasswordChar = '*';
            this.PassText.Size = new System.Drawing.Size(200, 21);
            this.PassText.TabIndex = 24;
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(184, 106);
            this.EmailText.Margin = new System.Windows.Forms.Padding(2);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(200, 21);
            this.EmailText.TabIndex = 23;
            // 
            // AutoCheck
            // 
            this.AutoCheck.AutoSize = true;
            this.AutoCheck.Font = new System.Drawing.Font("黑体", 9F);
            this.AutoCheck.Location = new System.Drawing.Point(184, 207);
            this.AutoCheck.Margin = new System.Windows.Forms.Padding(2);
            this.AutoCheck.Name = "AutoCheck";
            this.AutoCheck.Size = new System.Drawing.Size(144, 16);
            this.AutoCheck.TabIndex = 22;
            this.AutoCheck.Text = "Auto login in 7 days";
            this.AutoCheck.UseVisualStyleBackColor = true;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.CloseBtn.Location = new System.Drawing.Point(335, 259);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(60, 24);
            this.CloseBtn.TabIndex = 21;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.White;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("黑体", 9F);
            this.LoginBtn.Location = new System.Drawing.Point(155, 259);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(60, 24);
            this.LoginBtn.TabIndex = 20;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F);
            this.label4.Location = new System.Drawing.Point(113, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.Location = new System.Drawing.Point(133, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 10F);
            this.label2.Location = new System.Drawing.Point(88, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "The system can be logger in through email and password ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 18F);
            this.label1.Location = new System.Drawing.Point(237, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Login";
            // 
            // LoginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 300);
            this.Controls.Add(this.verCodepanel);
            this.Controls.Add(this.ModPassLink);
            this.Controls.Add(this.PassText);
            this.Controls.Add(this.EmailText);
            this.Controls.Add(this.AutoCheck);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.verCodepanel.ResumeLayout(false);
            this.verCodepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel verCodepanel;
        private System.Windows.Forms.TextBox txtValidCode;
        private System.Windows.Forms.PictureBox picValidCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel ModPassLink;
        private System.Windows.Forms.TextBox PassText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.CheckBox AutoCheck;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

