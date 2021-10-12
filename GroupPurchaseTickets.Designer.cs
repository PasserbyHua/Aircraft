namespace Aircraft
{
    partial class GroupPurchaseTickets
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
            this.ArrPanel = new System.Windows.Forms.Panel();
            this.FlightInfoView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DeparPanel = new System.Windows.Forms.Panel();
            this.FlightInfoView1 = new System.Windows.Forms.DataGridView();
            this.FlightNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Airport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ToCityTxt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FromCityTxt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ArrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlightInfoView2)).BeginInit();
            this.DeparPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlightInfoView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ArrPanel
            // 
            this.ArrPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrPanel.Controls.Add(this.FlightInfoView2);
            this.ArrPanel.Location = new System.Drawing.Point(528, 128);
            this.ArrPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ArrPanel.Name = "ArrPanel";
            this.ArrPanel.Size = new System.Drawing.Size(466, 412);
            this.ArrPanel.TabIndex = 46;
            // 
            // FlightInfoView2
            // 
            this.FlightInfoView2.AllowUserToAddRows = false;
            this.FlightInfoView2.BackgroundColor = System.Drawing.Color.White;
            this.FlightInfoView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlightInfoView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.FlightInfoView2.Location = new System.Drawing.Point(-1, 290);
            this.FlightInfoView2.Margin = new System.Windows.Forms.Padding(2);
            this.FlightInfoView2.Name = "FlightInfoView2";
            this.FlightInfoView2.RowHeadersVisible = false;
            this.FlightInfoView2.RowHeadersWidth = 51;
            this.FlightInfoView2.RowTemplate.Height = 27;
            this.FlightInfoView2.Size = new System.Drawing.Size(465, 126);
            this.FlightInfoView2.TabIndex = 38;
            this.FlightInfoView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlightInfoView2_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FlightNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "FlightNumber";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OnDateTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "Time";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn3.HeaderText = "Price";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Airport";
            this.dataGridViewTextBoxColumn4.HeaderText = "Airport";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AvailableTicket";
            this.dataGridViewTextBoxColumn5.HeaderText = "AvailableTicket";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 135;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(558, 545);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 24);
            this.button4.TabIndex = 45;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(414, 545);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 24);
            this.button3.TabIndex = 44;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 10F);
            this.label9.Location = new System.Drawing.Point(525, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 14);
            this.label9.TabIndex = 43;
            this.label9.Text = "Select return date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 10F);
            this.label8.Location = new System.Drawing.Point(51, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 14);
            this.label8.TabIndex = 42;
            this.label8.Text = "Select departure date";
            // 
            // DeparPanel
            // 
            this.DeparPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeparPanel.Controls.Add(this.FlightInfoView1);
            this.DeparPanel.Location = new System.Drawing.Point(47, 128);
            this.DeparPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DeparPanel.Name = "DeparPanel";
            this.DeparPanel.Size = new System.Drawing.Size(466, 412);
            this.DeparPanel.TabIndex = 41;
            // 
            // FlightInfoView1
            // 
            this.FlightInfoView1.AllowUserToAddRows = false;
            this.FlightInfoView1.BackgroundColor = System.Drawing.Color.White;
            this.FlightInfoView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlightInfoView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FlightNumber,
            this.dateTime,
            this.Price,
            this.Airport,
            this.AvailableTicket});
            this.FlightInfoView1.Location = new System.Drawing.Point(-1, 290);
            this.FlightInfoView1.Margin = new System.Windows.Forms.Padding(2);
            this.FlightInfoView1.Name = "FlightInfoView1";
            this.FlightInfoView1.RowHeadersVisible = false;
            this.FlightInfoView1.RowHeadersWidth = 51;
            this.FlightInfoView1.RowTemplate.Height = 27;
            this.FlightInfoView1.Size = new System.Drawing.Size(465, 126);
            this.FlightInfoView1.TabIndex = 31;
            this.FlightInfoView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlightInfoView1_CellClick);
            // 
            // FlightNumber
            // 
            this.FlightNumber.DataPropertyName = "FlightNumber";
            this.FlightNumber.HeaderText = "FlightNumber";
            this.FlightNumber.MinimumWidth = 6;
            this.FlightNumber.Name = "FlightNumber";
            this.FlightNumber.Width = 120;
            // 
            // dateTime
            // 
            this.dateTime.DataPropertyName = "OnDateTime";
            this.dateTime.HeaderText = "Time";
            this.dateTime.MinimumWidth = 6;
            this.dateTime.Name = "dateTime";
            this.dateTime.Width = 120;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 120;
            // 
            // Airport
            // 
            this.Airport.DataPropertyName = "Airport";
            this.Airport.HeaderText = "Airport";
            this.Airport.MinimumWidth = 6;
            this.Airport.Name = "Airport";
            this.Airport.Width = 120;
            // 
            // AvailableTicket
            // 
            this.AvailableTicket.DataPropertyName = "AvailableTicket";
            this.AvailableTicket.HeaderText = "AvailableTicket";
            this.AvailableTicket.MinimumWidth = 6;
            this.AvailableTicket.Name = "AvailableTicket";
            this.AvailableTicket.Width = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F);
            this.label4.Location = new System.Drawing.Point(45, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "Select departure date:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.SearchBtn);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ToCityTxt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.FromCityTxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(47, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 66);
            this.panel1.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Aircraft.Properties.Resources.exchange;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(130, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 42);
            this.button2.TabIndex = 34;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBtn.Location = new System.Drawing.Point(592, 30);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(56, 20);
            this.SearchBtn.TabIndex = 33;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(410, 32);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(90, 21);
            this.numericUpDown1.TabIndex = 32;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 10F);
            this.label7.Location = new System.Drawing.Point(408, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 14);
            this.label7.TabIndex = 31;
            this.label7.Text = "Passenger Number:";
            // 
            // ToCityTxt
            // 
            this.ToCityTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToCityTxt.FormattingEnabled = true;
            this.ToCityTxt.Location = new System.Drawing.Point(213, 34);
            this.ToCityTxt.Margin = new System.Windows.Forms.Padding(2);
            this.ToCityTxt.Name = "ToCityTxt";
            this.ToCityTxt.Size = new System.Drawing.Size(92, 20);
            this.ToCityTxt.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.Location = new System.Drawing.Point(211, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "To City:";
            // 
            // FromCityTxt
            // 
            this.FromCityTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromCityTxt.FormattingEnabled = true;
            this.FromCityTxt.Location = new System.Drawing.Point(11, 34);
            this.FromCityTxt.Margin = new System.Windows.Forms.Padding(2);
            this.FromCityTxt.Name = "FromCityTxt";
            this.FromCityTxt.Size = new System.Drawing.Size(92, 20);
            this.FromCityTxt.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F);
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "From City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.Location = new System.Drawing.Point(433, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 14);
            this.label3.TabIndex = 38;
            this.label3.Text = "Group Purchase Tickets";
            // 
            // GroupPurchaseTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 577);
            this.Controls.Add(this.ArrPanel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DeparPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GroupPurchaseTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupPurchaseTickets";
            this.Load += new System.EventHandler(this.GroupPurchaseTickets_Load);
            this.ArrPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlightInfoView2)).EndInit();
            this.DeparPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlightInfoView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ArrPanel;
        private System.Windows.Forms.DataGridView FlightInfoView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel DeparPanel;
        private System.Windows.Forms.DataGridView FlightInfoView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Airport;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableTicket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ToCityTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox FromCityTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}