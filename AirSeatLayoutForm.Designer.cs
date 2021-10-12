namespace Aircraft
{
    partial class AirSeatLayoutForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BusinessPanel = new System.Windows.Forms.Panel();
            this.FirstPanel = new System.Windows.Forms.Panel();
            this.Economypanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Aircraft.Properties.Resources.AIR1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1371, 387);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // BusinessPanel
            // 
            this.BusinessPanel.Location = new System.Drawing.Point(440, 128);
            this.BusinessPanel.Name = "BusinessPanel";
            this.BusinessPanel.Size = new System.Drawing.Size(250, 130);
            this.BusinessPanel.TabIndex = 4;
            // 
            // FirstPanel
            // 
            this.FirstPanel.Location = new System.Drawing.Point(348, 128);
            this.FirstPanel.Name = "FirstPanel";
            this.FirstPanel.Size = new System.Drawing.Size(86, 130);
            this.FirstPanel.TabIndex = 5;
            // 
            // Economypanel
            // 
            this.Economypanel.Location = new System.Drawing.Point(696, 128);
            this.Economypanel.Name = "Economypanel";
            this.Economypanel.Size = new System.Drawing.Size(432, 130);
            this.Economypanel.TabIndex = 6;
            // 
            // AirSeatLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 387);
            this.Controls.Add(this.Economypanel);
            this.Controls.Add(this.FirstPanel);
            this.Controls.Add(this.BusinessPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AirSeatLayoutForm";
            this.Text = "AirSeatLayoutForm";
            this.Load += new System.EventHandler(this.AirSeatLayoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel BusinessPanel;
        private System.Windows.Forms.Panel FirstPanel;
        private System.Windows.Forms.Panel Economypanel;
    }
}