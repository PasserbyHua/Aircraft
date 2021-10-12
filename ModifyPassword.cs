using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using LinqToSQLClass;

namespace Aircraft
{
    public partial class ModifyPassword : Form
    {
        #region 修改密码相关信息
        private string UserEmail;
        private string UserName;
        private string UserPwd;

        public string UserEmail1 { get => UserEmail; set => UserEmail = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public string UserPwd1 { get => UserPwd; set => UserPwd = value; }
        ModifyInfo modify = new ModifyInfo();
        #endregion

        #region 窗口加载信息
        public ModifyPassword(string email, string pwd)
        {
            InitializeComponent();
            this.UserEmail1 = email;
            this.UserPwd1 = pwd;
        }
        #endregion

        #region 窗口加载事件
        private void ModifyPassword_Load(object sender, EventArgs e)
        {
            this.UserName1 = modify.GetName(new LoginMod() { Email = UserEmail, PassWord = UserPwd1 });
            EmailText.Text = UserEmail1;
            NameText.Text = UserName1;
        }
        #endregion

        #region 提交修改的密码
        private void SubBtn_Click(object sender, EventArgs e)
        {
            newpasstxtagain_KeyUp(null, null);
            if (passagainerror.Visible)
            {
                MessageBox.Show("Please enter the correct password twice！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (UserPwd == newpasstxt.Text)
            {
                MessageBox.Show("The modified password cannot be the same as the original password！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //修改密码
                bool result = modify.ChangePwd(new LoginMod() { Email = UserEmail, PassWord = UserPwd1 }, newpasstxt.Text);
                if (result)
                {
                    MessageBox.Show("Modification successful! Please log in again.", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Modification failed! Please try again.", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        #endregion

        #region 密码检测
        private void newpasstxtagain_KeyUp(object sender, KeyEventArgs e)
        {
            if (newpasstxt.Text == "" || newpasstxtagain.Text == "")
            {
                passagainerror.Text = "Password box cannot be empty！";
                passagainerror.Visible = true;
            }
            else if (newpasstxt.Text != newpasstxtagain.Text)
            {
                passagainerror.Text = "The two passwords are not the same！";
                passagainerror.Visible = true;
            }
            else
                passagainerror.Visible = false;
        }
        #endregion

        #region 关闭窗口
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
