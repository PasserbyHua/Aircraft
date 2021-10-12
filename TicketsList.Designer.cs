namespace Aircraft
{
    partial class TicketsList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchbtn = new System.Windows.Forms.Button();
            this.IDNumBox = new System.Windows.Forms.TextBox();
            this.IDTypeList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ETicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDtypeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reschedule = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Refund = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchbtn);
            this.panel1.Controls.Add(this.IDNumBox);
            this.panel1.Controls.Add(this.IDTypeList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(17, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 86);
            this.panel1.TabIndex = 4;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(377, 42);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(75, 23);
            this.searchbtn.TabIndex = 4;
            this.searchbtn.Text = "Search";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // IDNumBox
            // 
            this.IDNumBox.Location = new System.Drawing.Point(162, 43);
            this.IDNumBox.Name = "IDNumBox";
            this.IDNumBox.Size = new System.Drawing.Size(198, 21);
            this.IDNumBox.TabIndex = 3;
            // 
            // IDTypeList
            // 
            this.IDTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDTypeList.FormattingEnabled = true;
            this.IDTypeList.Location = new System.Drawing.Point(28, 44);
            this.IDTypeList.Name = "IDTypeList";
            this.IDTypeList.Size = new System.Drawing.Size(121, 20);
            this.IDTypeList.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID Type Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(436, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tickets List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ETicketNumber,
            this._Name,
            this.IDtype,
            this.IDtypeNumber,
            this.FlightNumber,
            this.Route,
            this.Depar,
            this.Seat,
            this.Reschedule,
            this.Refund});
            this.dataGridView1.Location = new System.Drawing.Point(17, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(971, 388);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ETicketNumber
            // 
            this.ETicketNumber.DataPropertyName = "ETticketNumber";
            this.ETicketNumber.HeaderText = "ETicketNumber";
            this.ETicketNumber.Name = "ETicketNumber";
            this.ETicketNumber.ReadOnly = true;
            // 
            // _Name
            // 
            this._Name.DataPropertyName = "Name";
            this._Name.HeaderText = "_Name";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            // 
            // IDtype
            // 
            this.IDtype.DataPropertyName = "IDtype";
            this.IDtype.HeaderText = "IDtype";
            this.IDtype.Name = "IDtype";
            this.IDtype.ReadOnly = true;
            // 
            // IDtypeNumber
            // 
            this.IDtypeNumber.DataPropertyName = "IDtypeNum";
            this.IDtypeNumber.HeaderText = "IDtypeNumber";
            this.IDtypeNumber.Name = "IDtypeNumber";
            this.IDtypeNumber.ReadOnly = true;
            // 
            // FlightNumber
            // 
            this.FlightNumber.DataPropertyName = "FlightNum";
            this.FlightNumber.HeaderText = "FlightNumber";
            this.FlightNumber.Name = "FlightNumber";
            this.FlightNumber.ReadOnly = true;
            // 
            // Route
            // 
            this.Route.DataPropertyName = "RouteName";
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            this.Route.ReadOnly = true;
            // 
            // Depar
            // 
            this.Depar.DataPropertyName = "Depardatetime";
            this.Depar.HeaderText = "DateTime";
            this.Depar.Name = "Depar";
            this.Depar.ReadOnly = true;
            // 
            // Seat
            // 
            this.Seat.DataPropertyName = "Seat";
            this.Seat.HeaderText = "Seat";
            this.Seat.Name = "Seat";
            this.Seat.ReadOnly = true;
            // 
            // Reschedule
            // 
            this.Reschedule.DataPropertyName = "Reschedule";
            this.Reschedule.HeaderText = "Reschedule";
            this.Reschedule.Name = "Reschedule";
            this.Reschedule.ReadOnly = true;
            this.Reschedule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Reschedule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Reschedule.Text = "Reschedule";
            this.Reschedule.UseColumnTextForLinkValue = true;
            // 
            // Refund
            // 
            this.Refund.DataPropertyName = "Refund";
            this.Refund.HeaderText = "Refund";
            this.Refund.Name = "Refund";
            this.Refund.ReadOnly = true;
            this.Refund.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Refund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Refund.Text = "Refund";
            this.Refund.UseColumnTextForLinkValue = true;
            // 
            // TicketsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TicketsList";
            this.Text = "TicketsList";
            this.Load += new System.EventHandler(this.TicketsList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.TextBox IDNumBox;
        private System.Windows.Forms.ComboBox IDTypeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDtypeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewLinkColumn Reschedule;
        private System.Windows.Forms.DataGridViewLinkColumn Refund;
    }
}