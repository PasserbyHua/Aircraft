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
    public partial class LoginFrom : Form
    {
        #region 窗口加载信息
        //用户级别信息保存
        static public int LoginGrade = -1;
        static public string Email;
        private SaveMod sm = new SaveMod();

        #region 验证码常用类

        //生成验证码方法
        ValidCode validCode = new ValidCode(4, ValidCode.CodeType.Numbers);
        //密码错误计数
        int i = 0;
        #endregion
        public LoginFrom()
        {
            InitializeComponent();
        }

        #region 尝试加载保存的密码
        private void Form1_Load(object sender, EventArgs e)
        {
            FlightInquiry fi = new FlightInquiry();
            fi.Test();
            //判断密码是否存在
            if (sm.PwdInspect())
            {
                //加载密码
                LoginMod loginMod = sm.ReadPwd();
                //将信息填充至文本框
                EmailText.Text = loginMod.Email.Trim();
                PassText.Text = loginMod.PassWord.Trim();
                AutoCheck.Checked = true;
            }
        }
        #endregion
        #endregion

        #region 登录按钮
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            //输入为空判断
            if (!IsNoInput()) return;
            //声明登录类
            LoginClass loginClass = new LoginClass();
            LoginMod loginMod = new LoginMod()
            {
                Email = this.EmailText.Text.Trim(),
                PassWord = this.PassText.Text.Trim(),
                DateTime = DateTime.Now
            };
            #region 验证码检查
            //验证码判断
            if (verCodepanel.Visible == true)
            {
                //判断验证码是否输入正确
                bool result = this.txtValidCode.Text.Equals(validCode.CheckCode);
                if (!result)
                {
                    MessageBox.Show("Please enter the correct verification code!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //生成新验证码
                    picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
                    this.txtValidCode.Focus();
                    return;
                }
            }
            #endregion
            //执行并判断登录结果
            if (loginClass.IsExist(loginMod))
            {
                //初始密码验证
                if (IsIPwd()) return;
                //用户级别判断
                LoginGrade = loginClass.UserGradeQue(loginMod);
                //填充账号
                Email = loginMod.Email;
                //保存密码判断
                SavePwd();
                //登录验证全部成功，设置窗体登录结果为OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Account does not exist！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region 判断失败次数
                i++;
                if (i >= 3)
                {
                    //验证码开启
                    verCodepanel.Visible = true;
                    //生成验证码
                    picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
                }
                #endregion
            }
        }
        #endregion

        #region 判断是否为空
        private bool IsNoInput()
        {
            bool result = true;
            if (EmailText.Text == "")
            {
                MessageBox.Show("Please enter the account number！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            else if (PassText.Text == "")
            {
                MessageBox.Show("Please input a password！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            else if (verCodepanel.Visible == true)
            {
                if (txtValidCode.Text == "")
                {
                    MessageBox.Show("Please enter the verification code！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region 关闭按钮
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 单击更新验证码
        private void picValidCode_Click(object sender, EventArgs e)
        {
            //生成新验证码
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }
        #endregion

        #region 是否保存判断
        public void SavePwd()
        {
            //判断是否选中
            if (AutoCheck.Checked)
            {
                //判断是否存在保存的密码
                if (sm.PwdInspect())
                {
                    //读取账号密码
                    LoginMod sa = sm.ReadPwd();
                    //判断账号密码是否相同
                    if (sa.Email == EmailText.Text && sa.PassWord == PassText.Text)
                    {
                        //相同则不保存
                        return;
                    }
                    else
                    {
                        //不相同则保存新密码
                        sm.SavePwd(EmailText.Text, PassText.Text);
                    }
                }
                else
                {
                    //保存新密码
                    sm.SavePwd(EmailText.Text, PassText.Text);
                }

            }
            else
            {
                //删除已保存的密码
                sm.DelPwd();
            }
        }
        #endregion

        #region 初始密码检测
        /// <summary>
        /// 判断是否是初始密码
        /// </summary>
        /// <returns>返回布尔值确定有没有修改密码</returns>
        private bool IsIPwd()
        {
            bool result=false;
            #region 初始密码判断
            bool IsInitialPwd(string email, string pwd)
            {
                string[] estr = email.Split('@');
                if (estr[0] == pwd)
                    return true;
                else
                    return false;
            }
            #endregion
            //判断是否是初始密码
            if (IsInitialPwd(this.EmailText.Text, this.PassText.Text))
            {
                //Tips修改密码
                Tips tip = new Tips();
                DialogResult TipResult = tip.ShowDialog();

                //判断用户是否修改密码
                if (TipResult == DialogResult.OK)
                {
                    //打开修改密码窗体
                    ModifyPassword mp = new ModifyPassword(this.EmailText.Text, this.PassText.Text);
                    mp.ShowDialog();
                    result = true;
                }
            }
            return result;
        }
        #endregion

        #region 修改密码链接
        private void ModPassLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //输入为空判断
            if (!IsNoInput()) return;
            //声明登录类
            LoginClass loginClass = new LoginClass();
            LoginMod loginMod = new LoginMod()
            {
                Email = this.EmailText.Text.Trim(),
                PassWord = this.PassText.Text.Trim(),
                DateTime = DateTime.Now
            };
            #region 验证码检查
            //验证码判断
            if (verCodepanel.Visible == true)
            {
                //判断验证码是否输入正确
                bool result = this.txtValidCode.Text.Equals(validCode.CheckCode);
                if (!result)
                {
                    MessageBox.Show("Please enter the correct verification code!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //生成新验证码
                    picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
                    this.txtValidCode.Focus();
                    return;
                }
            }
            #endregion
            //执行并判断登录结果
            if (loginClass.IsExist(loginMod))
            {
                //打开修改密码窗体
                ModifyPassword mp = new ModifyPassword(this.EmailText.Text, this.PassText.Text);
                mp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account does not exist！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region 判断失败次数
                i++;
                if (i >= 3)
                {
                    //验证码开启
                    verCodepanel.Visible = true;
                    //生成验证码
                    picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
                }
                #endregion
            }
        } 
        #endregion
    }
}
