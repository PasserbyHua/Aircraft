namespace Aircraft
{
    partial class SearchFlights
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
            this.button1 = new System.Windows.Forms.Button();
            this.planeticketBox2 = new System.Windows.Forms.GroupBox();
            this.ReturnPanel = new System.Windows.Forms.Panel();
            this.notplaneticket2 = new System.Windows.Forms.Label();
            this.planeticketBox1 = new System.Windows.Forms.GroupBox();
            this.DeparPanel = new System.Windows.Forms.Panel();
            this.notplaneticket = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.FlightTxt = new System.Windows.Forms.ComboBox();
            this.CabinTxt = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DepartureDate = new System.Windows.Forms.DateTimePicker();
            this.ToCityTxt = new System.Windows.Forms.ComboBox();
            this.FromCityTxt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RoundWaysRB = new System.Windows.Forms.RadioButton();
            this.OneWayRB = new System.Windows.Forms.RadioButton();
            this.ReturnDatePanel = new System.Windows.Forms.Panel();
            this.ReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.planeticketBox2.SuspendLayout();
            this.ReturnPanel.SuspendLayout();
            this.planeticketBox1.SuspendLayout();
            this.DeparPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.ReturnDatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("黑体", 10F);
            this.button1.Location = new System.Drawing.Point(680, 415);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 24);
            this.button1.TabIndex = 28;
            this.button1.Text = "Book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // planeticketBox2
            // 
            this.planeticketBox2.Controls.Add(this.ReturnPanel);
            this.planeticketBox2.Font = new System.Drawing.Font("黑体", 9F);
            this.planeticketBox2.Location = new System.Drawing.Point(20, 263);
            this.planeticketBox2.Margin = new System.Windows.Forms.Padding(2);
            this.planeticketBox2.Name = "planeticketBox2";
            this.planeticketBox2.Padding = new System.Windows.Forms.Padding(2);
            this.planeticketBox2.Size = new System.Drawing.Size(760, 144);
            this.planeticketBox2.TabIndex = 27;
            this.planeticketBox2.TabStop = false;
            this.planeticketBox2.Text = "Return Flights";
            // 
            // ReturnPanel
            // 
            this.ReturnPanel.AutoScroll = true;
            this.ReturnPanel.BackColor = System.Drawing.Color.White;
            this.ReturnPanel.Controls.Add(this.notplaneticket2);
            this.ReturnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReturnPanel.Location = new System.Drawing.Point(2, 16);
            this.ReturnPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnPanel.Name = "ReturnPanel";
            this.ReturnPanel.Size = new System.Drawing.Size(756, 126);
            this.ReturnPanel.TabIndex = 3;
            // 
            // notplaneticket2
            // 
            this.notplaneticket2.AutoSize = true;
            this.notplaneticket2.Location = new System.Drawing.Point(298, 48);
            this.notplaneticket2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.notplaneticket2.Name = "notplaneticket2";
            this.notplaneticket2.Size = new System.Drawing.Size(143, 12);
            this.notplaneticket2.TabIndex = 1;
            this.notplaneticket2.Text = "There is no such flight";
            this.notplaneticket2.Visible = false;
            // 
            // planeticketBox1
            // 
            this.planeticketBox1.BackColor = System.Drawing.Color.Transparent;
            this.planeticketBox1.Controls.Add(this.DeparPanel);
            this.planeticketBox1.Font = new System.Drawing.Font("黑体", 9F);
            this.planeticketBox1.Location = new System.Drawing.Point(20, 114);
            this.planeticketBox1.Margin = new System.Windows.Forms.Padding(2);
            this.planeticketBox1.Name = "planeticketBox1";
            this.planeticketBox1.Padding = new System.Windows.Forms.Padding(2);
            this.planeticketBox1.Size = new System.Drawing.Size(760, 144);
            this.planeticketBox1.TabIndex = 26;
            this.planeticketBox1.TabStop = false;
            this.planeticketBox1.Text = "Departure Flights";
            // 
            // DeparPanel
            // 
            this.DeparPanel.AutoScroll = true;
            this.DeparPanel.BackColor = System.Drawing.Color.White;
            this.DeparPanel.Controls.Add(this.notplaneticket);
            this.DeparPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeparPanel.Location = new System.Drawing.Point(2, 16);
            this.DeparPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DeparPanel.Name = "DeparPanel";
            this.DeparPanel.Size = new System.Drawing.Size(756, 126);
            this.DeparPanel.TabIndex = 2;
            // 
            // notplaneticket
            // 
            this.notplaneticket.AutoSize = true;
            this.notplaneticket.Location = new System.Drawing.Point(298, 52);
            this.notplaneticket.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.notplaneticket.Name = "notplaneticket";
            this.notplaneticket.Size = new System.Drawing.Size(143, 12);
            this.notplaneticket.TabIndex = 0;
            this.notplaneticket.Text = "There is no such flight";
            this.notplaneticket.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SearchPanel);
            this.panel1.Controls.Add(this.DepartureDate);
            this.panel1.Controls.Add(this.ToCityTxt);
            this.panel1.Controls.Add(this.FromCityTxt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RoundWaysRB);
            this.panel1.Controls.Add(this.OneWayRB);
            this.panel1.Controls.Add(this.ReturnDatePanel);
            this.panel1.Location = new System.Drawing.Point(20, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 64);
            this.panel1.TabIndex = 25;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.SearchBtn);
            this.SearchPanel.Controls.Add(this.FlightTxt);
            this.SearchPanel.Controls.Add(this.CabinTxt);
            this.SearchPanel.Controls.Add(this.label9);
            this.SearchPanel.Controls.Add(this.label8);
            this.SearchPanel.Location = new System.Drawing.Point(380, 9);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(238, 50);
            this.SearchPanel.TabIndex = 18;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(177, 22);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(56, 18);
            this.SearchBtn.TabIndex = 16;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // FlightTxt
            // 
            this.FlightTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlightTxt.FormattingEnabled = true;
            this.FlightTxt.Location = new System.Drawing.Point(94, 22);
            this.FlightTxt.Margin = new System.Windows.Forms.Padding(2);
            this.FlightTxt.Name = "FlightTxt";
            this.FlightTxt.Size = new System.Drawing.Size(66, 20);
            this.FlightTxt.TabIndex = 13;
            // 
            // CabinTxt
            // 
            this.CabinTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CabinTxt.FormattingEnabled = true;
            this.CabinTxt.Location = new System.Drawing.Point(7, 22);
            this.CabinTxt.Margin = new System.Windows.Forms.Padding(2);
            this.CabinTxt.Name = "CabinTxt";
            this.CabinTxt.Size = new System.Drawing.Size(70, 20);
            this.CabinTxt.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 9F);
            this.label9.Location = new System.Drawing.Point(92, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Flight Type: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 9F);
            this.label8.Location = new System.Drawing.Point(4, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cabin Type:";
            // 
            // DepartureDate
            // 
            this.DepartureDate.Location = new System.Drawing.Point(278, 29);
            this.DepartureDate.Margin = new System.Windows.Forms.Padding(2);
            this.DepartureDate.Name = "DepartureDate";
            this.DepartureDate.Size = new System.Drawing.Size(94, 21);
            this.DepartureDate.TabIndex = 14;
            this.DepartureDate.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // ToCityTxt
            // 
            this.ToCityTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToCityTxt.FormattingEnabled = true;
            this.ToCityTxt.Items.AddRange(new object[] {
            " "});
            this.ToCityTxt.Location = new System.Drawing.Point(196, 30);
            this.ToCityTxt.Margin = new System.Windows.Forms.Padding(2);
            this.ToCityTxt.Name = "ToCityTxt";
            this.ToCityTxt.Size = new System.Drawing.Size(76, 20);
            this.ToCityTxt.TabIndex = 9;
            // 
            // FromCityTxt
            // 
            this.FromCityTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromCityTxt.FormattingEnabled = true;
            this.FromCityTxt.Items.AddRange(new object[] {
            " "});
            this.FromCityTxt.Location = new System.Drawing.Point(111, 30);
            this.FromCityTxt.Margin = new System.Windows.Forms.Padding(2);
            this.FromCityTxt.Name = "FromCityTxt";
            this.FromCityTxt.Size = new System.Drawing.Size(76, 20);
            this.FromCityTxt.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 9F);
            this.label6.Location = new System.Drawing.Point(275, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Departure Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 9F);
            this.label5.Location = new System.Drawing.Point(202, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "To city:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F);
            this.label4.Location = new System.Drawing.Point(109, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "From City:";
            // 
            // RoundWaysRB
            // 
            this.RoundWaysRB.AutoSize = true;
            this.RoundWaysRB.Font = new System.Drawing.Font("黑体", 9F);
            this.RoundWaysRB.Location = new System.Drawing.Point(12, 32);
            this.RoundWaysRB.Margin = new System.Windows.Forms.Padding(2);
            this.RoundWaysRB.Name = "RoundWaysRB";
            this.RoundWaysRB.Size = new System.Drawing.Size(83, 16);
            this.RoundWaysRB.TabIndex = 1;
            this.RoundWaysRB.Text = "Round Ways";
            this.RoundWaysRB.UseVisualStyleBackColor = true;
            this.RoundWaysRB.CheckedChanged += new System.EventHandler(this.RoundWaysRB_CheckedChanged);
            // 
            // OneWayRB
            // 
            this.OneWayRB.AutoSize = true;
            this.OneWayRB.Checked = true;
            this.OneWayRB.Font = new System.Drawing.Font("黑体", 9F);
            this.OneWayRB.Location = new System.Drawing.Point(12, 12);
            this.OneWayRB.Margin = new System.Windows.Forms.Padding(2);
            this.OneWayRB.Name = "OneWayRB";
            this.OneWayRB.Size = new System.Drawing.Size(65, 16);
            this.OneWayRB.TabIndex = 0;
            this.OneWayRB.TabStop = true;
            this.OneWayRB.Text = "One Way";
            this.OneWayRB.UseVisualStyleBackColor = true;
            // 
            // ReturnDatePanel
            // 
            this.ReturnDatePanel.Controls.Add(this.ReturnDate);
            this.ReturnDatePanel.Controls.Add(this.label7);
            this.ReturnDatePanel.Location = new System.Drawing.Point(380, 9);
            this.ReturnDatePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnDatePanel.Name = "ReturnDatePanel";
            this.ReturnDatePanel.Size = new System.Drawing.Size(111, 50);
            this.ReturnDatePanel.TabIndex = 17;
            this.ReturnDatePanel.Visible = false;
            // 
            // ReturnDate
            // 
            this.ReturnDate.Location = new System.Drawing.Point(4, 20);
            this.ReturnDate.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnDate.Name = "ReturnDate";
            this.ReturnDate.Size = new System.Drawing.Size(94, 21);
            this.ReturnDate.TabIndex = 15;
            this.ReturnDate.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 9F);
            this.label7.Location = new System.Drawing.Point(5, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "Return Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.Location = new System.Drawing.Point(349, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Search Flights";
            // 
            // SearchFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.planeticketBox2);
            this.Controls.Add(this.planeticketBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchFlights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchFlights";
            this.Load += new System.EventHandler(this.SearchFlights_Load);
            this.planeticketBox2.ResumeLayout(false);
            this.ReturnPanel.ResumeLayout(false);
            this.ReturnPanel.PerformLayout();
            this.planeticketBox1.ResumeLayout(false);
            this.DeparPanel.ResumeLayout(false);
            this.DeparPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.ReturnDatePanel.ResumeLayout(false);
            this.ReturnDatePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox planeticketBox2;
        private System.Windows.Forms.Panel ReturnPanel;
        private System.Windows.Forms.Label notplaneticket2;
        private System.Windows.Forms.GroupBox planeticketBox1;
        private System.Windows.Forms.Panel DeparPanel;
        private System.Windows.Forms.Label notplaneticket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.ComboBox FlightTxt;
        private System.Windows.Forms.ComboBox CabinTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DepartureDate;
        private System.Windows.Forms.ComboBox ToCityTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RoundWaysRB;
        private System.Windows.Forms.RadioButton OneWayRB;
        private System.Windows.Forms.Panel ReturnDatePanel;
        private System.Windows.Forms.DateTimePicker ReturnDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox FromCityTxt;
    }
}