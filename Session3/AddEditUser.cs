using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Models;

namespace Aircraft.Session3
{
    public partial class AddEditUser : Form
    {
        #region 加载内容
        QueryCreate2 qc2 = new QueryCreate2();
        OpenFileDialog OpenPhoto = new OpenFileDialog();
        bool updateinfo = false;
        UserInfo ui = null;
        string photopath = "";
        FileStream fs = null;
        byte[] bt = new byte[100 * 1024];
        public AddEditUser(bool IsEdit, UserInfo ui)
        {
            InitializeComponent();
            if (IsEdit)
            {
                this.updateinfo = true;
                this.ui = ui;
            }
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            if (updateinfo)
            {
                textBox1.Enabled = false;
                textBox1.Text = ui.Email;
                if (ui.RoleName == "Office User")
                    office.Checked = true;
                else if (ui.RoleName == "Administrator")
                    radioButton2.Checked = true;
                else
                    MessageBox.Show("Error");
                if (ui.Gender == "M")
                    radioButton4.Checked = true;
                else if (ui.Gender == "F")
                    radioButton3.Checked = false;
                else
                    MessageBox.Show("Errror");
                textBox2.Text = ui.FirstName;
                textBox3.Text = ui.LastName;
                dateTimePicker1.Value = ui.DateOfBirth;
                textBox4.Text = ui.Phone;
                textBox5.Text = ui.Address;
                if (ui.PhotoByte.Length != 0)
                    pictureBox1.Image = BytesToImage(ui.PhotoByte);
            }
        }
        #endregion

        #region 提交信息
        private void button2_Click(object sender, EventArgs e)
        {
            ui = new UserInfo();
            if (!isempty()) MessageBox.Show("Incomplete information");
            if (textBox1.Text.Contains("@"))
                ui.Email = textBox1.Text;
            else
                MessageBox.Show("Email error");
            ui.FirstName = textBox2.Text;
            ui.LastName = textBox3.Text;
            if (radioButton4.Checked)
                ui.Gender = "M";
            else if (radioButton3.Checked)
                ui.Gender = "F";
            else
                MessageBox.Show("Gender is not select");
            if (office.Checked)
                ui.RoleName = "Office User";
            else if (radioButton2.Checked)
                ui.RoleName = "Administrator";
            else
                MessageBox.Show("Role is not select");
            ui.DateOfBirth = dateTimePicker1.Value;
            ui.Phone = textBox4.Text;
            ui.Address = textBox5.Text;
            
            if (updateinfo)
            {
                if (qc2.updateUser(ui))
                    MessageBox.Show("ok");
                else
                    MessageBox.Show("error");
            }
            else
            {
                if (qc2.InsertUser(ui))
                    MessageBox.Show("ok");
                else
                    MessageBox.Show("error");
            }
        }
        #endregion

        #region 添加图片
        private void button1_Click(object sender, EventArgs e)
        {
            OpenPhoto.Filter = ".jpg|*.jpg";
            if (OpenPhoto.ShowDialog() == DialogResult.OK)
            {
                if (OpenPhoto.OpenFile().Length < 100 * 1024)
                {
                    photopath = OpenPhoto.FileName;
                    pictureBox1.ImageLocation = photopath;
                    fs = new FileStream(photopath, FileMode.OpenOrCreate, FileAccess.Read);
                    fs.Read(bt, 0, bt.Length);
                    ui.PhotoByte = bt;
                }
                else
                    MessageBox.Show("The file is too large");
            }
        }
        #endregion

        #region 检查手机
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 判断是否输入完信息
        private bool isempty()
        {
            return true;
        }
        #endregion

        #region 图片加载
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        } 
        #endregion
    }
}
