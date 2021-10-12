namespace Aircraft
{
    partial class FoodServices
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodServices));
            this.button4 = new System.Windows.Forms.Button();
            this.selectallprice = new System.Windows.Forms.Label();
            this.selectallnum = new System.Windows.Forms.Label();
            this.selectcount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.foodpanel = new System.Windows.Forms.Panel();
            this.LoadFoodBtn = new System.Windows.Forms.Button();
            this.FlightInfoList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.Button();
            this.IDNumBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDTypeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(691, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 28);
            this.button4.TabIndex = 23;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // selectallprice
            // 
            this.selectallprice.AutoSize = true;
            this.selectallprice.Location = new System.Drawing.Point(113, 430);
            this.selectallprice.Name = "selectallprice";
            this.selectallprice.Size = new System.Drawing.Size(17, 12);
            this.selectallprice.TabIndex = 21;
            this.selectallprice.Text = "$0";
            // 
            // selectallnum
            // 
            this.selectallnum.AutoSize = true;
            this.selectallnum.Location = new System.Drawing.Point(113, 406);
            this.selectallnum.Name = "selectallnum";
            this.selectallnum.Size = new System.Drawing.Size(11, 12);
            this.selectallnum.TabIndex = 20;
            this.selectallnum.Text = "0";
            // 
            // selectcount
            // 
            this.selectcount.AutoSize = true;
            this.selectcount.Location = new System.Drawing.Point(113, 379);
            this.selectcount.Name = "selectcount";
            this.selectcount.Size = new System.Drawing.Size(11, 12);
            this.selectcount.TabIndex = 19;
            this.selectcount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Payment:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Select Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Selected Items:";
            // 
            // foodpanel
            // 
            this.foodpanel.AutoScroll = true;
            this.foodpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foodpanel.Location = new System.Drawing.Point(0, 150);
            this.foodpanel.Name = "foodpanel";
            this.foodpanel.Size = new System.Drawing.Size(800, 220);
            this.foodpanel.TabIndex = 15;
            // 
            // LoadFoodBtn
            // 
            this.LoadFoodBtn.Location = new System.Drawing.Point(357, 17);
            this.LoadFoodBtn.Name = "LoadFoodBtn";
            this.LoadFoodBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadFoodBtn.TabIndex = 5;
            this.LoadFoodBtn.Text = "Load";
            this.LoadFoodBtn.UseVisualStyleBackColor = true;
            this.LoadFoodBtn.Click += new System.EventHandler(this.LoadFoodBtn_Click);
            // 
            // FlightInfoList
            // 
            this.FlightInfoList.FormattingEnabled = true;
            this.FlightInfoList.Location = new System.Drawing.Point(77, 18);
            this.FlightInfoList.Name = "FlightInfoList";
            this.FlightInfoList.Size = new System.Drawing.Size(246, 20);
            this.FlightInfoList.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Flight:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LoadFoodBtn);
            this.panel2.Controls.Add(this.FlightInfoList);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 51);
            this.panel2.TabIndex = 14;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(357, 20);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // IDNumBox
            // 
            this.IDNumBox.Location = new System.Drawing.Point(203, 22);
            this.IDNumBox.Name = "IDNumBox";
            this.IDNumBox.Size = new System.Drawing.Size(120, 21);
            this.IDNumBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID Type Number:";
            // 
            // IDTypeList
            // 
            this.IDTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDTypeList.FormattingEnabled = true;
            this.IDTypeList.Location = new System.Drawing.Point(11, 22);
            this.IDTypeList.Name = "IDTypeList";
            this.IDTypeList.Size = new System.Drawing.Size(121, 20);
            this.IDTypeList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Type:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(586, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 28);
            this.button3.TabIndex = 22;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.IDNumBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.IDTypeList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 48);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(335, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Food Services";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "B01.jpg");
            this.imageList1.Images.SetKeyName(1, "B02.jpg");
            this.imageList1.Images.SetKeyName(2, "C01.jpg");
            this.imageList1.Images.SetKeyName(3, "C02.jpg");
            this.imageList1.Images.SetKeyName(4, "C03.jpg");
            this.imageList1.Images.SetKeyName(5, "D01.jpg");
            this.imageList1.Images.SetKeyName(6, "D02.jpg");
            this.imageList1.Images.SetKeyName(7, "N01.jpg");
            this.imageList1.Images.SetKeyName(8, "N02.jpg");
            this.imageList1.Images.SetKeyName(9, "P01.jpg");
            this.imageList1.Images.SetKeyName(10, "P02.jpg");
            this.imageList1.Images.SetKeyName(11, "S01.jpg");
            this.imageList1.Images.SetKeyName(12, "S02.jpg");
            this.imageList1.Images.SetKeyName(13, "S03.jpg");
            this.imageList1.Images.SetKeyName(14, "S04.jpg");
            this.imageList1.Images.SetKeyName(15, "V01.jpg");
            this.imageList1.Images.SetKeyName(16, "V02.jpg");
            this.imageList1.Images.SetKeyName(17, "V03.jpg");
            // 
            // FoodServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.selectallprice);
            this.Controls.Add(this.selectallnum);
            this.Controls.Add(this.selectcount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.foodpanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FoodServices";
            this.Text = "FoodServices";
            this.Load += new System.EventHandler(this.FoodServices_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label selectallprice;
        private System.Windows.Forms.Label selectallnum;
        private System.Windows.Forms.Label selectcount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel foodpanel;
        private System.Windows.Forms.Button LoadFoodBtn;
        private System.Windows.Forms.ComboBox FlightInfoList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox IDNumBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox IDTypeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
    }
}