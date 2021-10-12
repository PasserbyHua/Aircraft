using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aircraft
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //创建登录窗口
        logout: Form NewLoginFrom = new LoginFrom();
            //获取登录窗口返回值
            DialogResult LoginResult = NewLoginFrom.ShowDialog();
            /*Application.Run(new LoginFrom());*/
            //判断登录是否成功
            if (LoginResult == DialogResult.OK)
            {
                Form newform = null;
                if (LoginFrom.LoginGrade == 1)
                {
                    newform = new OfficeUserMenuFrom(LoginFrom.Email);
                    Application.Run(newform);
                    if (newform.DialogResult == DialogResult.Retry)
                        goto logout;
                }
                else if (LoginFrom.LoginGrade == 2)
                {
                    newform = new AdministratorMenuFrom(LoginFrom.Email);
                    Application.Run(newform);
                    if (newform.DialogResult == DialogResult.Retry)
                        goto logout;
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
