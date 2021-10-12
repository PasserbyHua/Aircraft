namespace Aircraft
{
    partial class MonthForm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DayPanel = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mouthPanel = new System.Windows.Forms.Panel();
            this.DateListBox = new System.Windows.Forms.DomainUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DayPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DayPanel
            // 
            this.DayPanel.BackColor = System.Drawing.Color.Silver;
            this.DayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DayPanel.Controls.Add(this.label26);
            this.DayPanel.Controls.Add(this.label25);
            this.DayPanel.Controls.Add(this.label24);
            this.DayPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DayPanel.Location = new System.Drawing.Point(136, 76);
            this.DayPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DayPanel.Name = "DayPanel";
            this.DayPanel.Size = new System.Drawing.Size(61, 36);
            this.DayPanel.TabIndex = 91;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("黑体", 9F);
            this.label26.Location = new System.Drawing.Point(42, 10);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 12);
            this.label26.TabIndex = 9;
            this.label26.Text = "88";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("黑体", 9F);
            this.label25.Location = new System.Drawing.Point(13, 22);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 8;
            this.label25.Text = "Tickets";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(2, 0);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 15);
            this.label24.TabIndex = 8;
            this.label24.Text = "1";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(7, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 22);
            this.panel4.TabIndex = 90;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Aircraft.Properties.Resources.selected;
            this.pictureBox1.Location = new System.Drawing.Point(428, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("黑体", 10F);
            this.label16.Location = new System.Drawing.Point(391, 4);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 14);
            this.label16.TabIndex = 6;
            this.label16.Text = "Sun";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("黑体", 10F);
            this.label15.Location = new System.Drawing.Point(328, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 14);
            this.label15.TabIndex = 5;
            this.label15.Text = "Sat";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("黑体", 10F);
            this.label14.Location = new System.Drawing.Point(268, 4);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 14);
            this.label14.TabIndex = 4;
            this.label14.Text = "Fri";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("黑体", 10F);
            this.label13.Location = new System.Drawing.Point(202, 4);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "Thur";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("黑体", 10F);
            this.label12.Location = new System.Drawing.Point(144, 4);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 14);
            this.label12.TabIndex = 2;
            this.label12.Text = "Wed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 10F);
            this.label11.Location = new System.Drawing.Point(79, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tues";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 10F);
            this.label10.Location = new System.Drawing.Point(17, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mon";
            // 
            // mouthPanel
            // 
            this.mouthPanel.Location = new System.Drawing.Point(8, 58);
            this.mouthPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mouthPanel.Name = "mouthPanel";
            this.mouthPanel.Size = new System.Drawing.Size(449, 221);
            this.mouthPanel.TabIndex = 93;
            // 
            // DateListBox
            // 
            this.DateListBox.Location = new System.Drawing.Point(7, 7);
            this.DateListBox.Margin = new System.Windows.Forms.Padding(2);
            this.DateListBox.Name = "DateListBox";
            this.DateListBox.ReadOnly = true;
            this.DateListBox.Size = new System.Drawing.Size(90, 21);
            this.DateListBox.TabIndex = 92;
            this.DateListBox.SelectedItemChanged += new System.EventHandler(this.DateListBox_SelectedItemChanged);
            // 
            // MonthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.mouthPanel);
            this.Controls.Add(this.DateListBox);
            this.Controls.Add(this.DayPanel);
            this.Name = "MonthForm";
            this.Size = new System.Drawing.Size(465, 286);
            this.Load += new System.EventHandler(this.MonthForm_Load);
            this.DayPanel.ResumeLayout(false);
            this.DayPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DayPanel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel mouthPanel;
        private System.Windows.Forms.DomainUpDown DateListBox;
        private System.Windows.Forms.Timer timer1;
    }
}
