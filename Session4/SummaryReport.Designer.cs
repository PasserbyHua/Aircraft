namespace Aircraft.Session4
{
    partial class SummaryReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Male = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Famale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Economy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Business = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 14F);
            this.label1.Location = new System.Drawing.Point(323, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "SummaryReport";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(26, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 2);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Field work January 2020-June 2020";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sample,Size:1727 Adults";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Male,
            this.Famale,
            this.Age18,
            this.Age25,
            this.Age40,
            this.Age60,
            this.Economy,
            this.Business,
            this.First});
            this.dataGridView1.Location = new System.Drawing.Point(27, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(545, 63);
            this.dataGridView1.TabIndex = 4;
            // 
            // Male
            // 
            this.Male.DataPropertyName = "MaleCount";
            this.Male.HeaderText = "Male";
            this.Male.Name = "Male";
            this.Male.ReadOnly = true;
            // 
            // Famale
            // 
            this.Famale.DataPropertyName = "FemaleCount";
            this.Famale.HeaderText = "Famale";
            this.Famale.Name = "Famale";
            this.Famale.ReadOnly = true;
            // 
            // Age18
            // 
            this.Age18.DataPropertyName = "Age18";
            this.Age18.HeaderText = "18-24";
            this.Age18.Name = "Age18";
            this.Age18.ReadOnly = true;
            // 
            // Age25
            // 
            this.Age25.DataPropertyName = "Age25";
            this.Age25.HeaderText = "25-39";
            this.Age25.Name = "Age25";
            this.Age25.ReadOnly = true;
            // 
            // Age40
            // 
            this.Age40.DataPropertyName = "Age40";
            this.Age40.HeaderText = "40-59";
            this.Age40.Name = "Age40";
            this.Age40.ReadOnly = true;
            // 
            // Age60
            // 
            this.Age60.DataPropertyName = "Age60";
            this.Age60.HeaderText = "60+";
            this.Age60.Name = "Age60";
            this.Age60.ReadOnly = true;
            // 
            // Economy
            // 
            this.Economy.DataPropertyName = "Economy1";
            this.Economy.HeaderText = "Economy";
            this.Economy.Name = "Economy";
            this.Economy.ReadOnly = true;
            // 
            // Business
            // 
            this.Business.DataPropertyName = "Business1";
            this.Business.HeaderText = "Business";
            this.Business.Name = "Business";
            this.Business.ReadOnly = true;
            // 
            // First
            // 
            this.First.DataPropertyName = "First1";
            this.First.HeaderText = "First";
            this.First.Name = "First";
            this.First.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(27, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Gender";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(148, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Age";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(390, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Canbin Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(572, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Destination Airport";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(572, 123);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(195, 63);
            this.dataGridView2.TabIndex = 9;
            // 
            // SummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 220);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "SummaryReport";
            this.Text = "SummaryReport";
            this.Load += new System.EventHandler(this.SummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Male;
        private System.Windows.Forms.DataGridViewTextBoxColumn Famale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age60;
        private System.Windows.Forms.DataGridViewTextBoxColumn Economy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Business;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
    }
}