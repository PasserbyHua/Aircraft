namespace Aircraft
{
    partial class AirSeatLayoutForm2
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
            this.Economypanel = new System.Windows.Forms.Panel();
            this.FirstPanel = new System.Windows.Forms.Panel();
            this.BusinessPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Economypanel
            // 
            this.Economypanel.Location = new System.Drawing.Point(728, 117);
            this.Economypanel.Name = "Economypanel";
            this.Economypanel.Size = new System.Drawing.Size(398, 135);
            this.Economypanel.TabIndex = 10;
            // 
            // FirstPanel
            // 
            this.FirstPanel.Location = new System.Drawing.Point(345, 116);
            this.FirstPanel.Name = "FirstPanel";
            this.FirstPanel.Size = new System.Drawing.Size(123, 136);
            this.FirstPanel.TabIndex = 9;
            // 
            // BusinessPanel
            // 
            this.BusinessPanel.Location = new System.Drawing.Point(474, 117);
            this.BusinessPanel.Name = "BusinessPanel";
            this.BusinessPanel.Size = new System.Drawing.Size(250, 135);
            this.BusinessPanel.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Aircraft.Properties.Resources.AIR2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1371, 387);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // AirSeatLayoutForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 387);
            this.Controls.Add(this.Economypanel);
            this.Controls.Add(this.FirstPanel);
            this.Controls.Add(this.BusinessPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AirSeatLayoutForm2";
            this.Text = "AirSeatLayoutForm2";
            this.Load += new System.EventHandler(this.AirSeatLayoutForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Economypanel;
        private System.Windows.Forms.Panel FirstPanel;
        private System.Windows.Forms.Panel BusinessPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}