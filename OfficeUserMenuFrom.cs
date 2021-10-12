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
    public partial class OfficeUserMenuFrom : Form
    {

        #region 窗口加载
        //定义用户信息字段
        private static UserInfo userInfo = new UserInfo();
        public static UserInfo UserInfo { get => userInfo; set => userInfo = value; }
        public OfficeUserMenuFrom(string email)
        {
            InitializeComponent();
            UserInfo.Email = email;
        }

        private void OfficeUserMenuFrom_Load(object sender, EventArgs e)
        {
            UserClass uc = new UserClass();
            UserInfo = uc.GetUserInfo(UserInfo);
            UserNameLabel.Text = Convert.ToString("Welcome, " + UserInfo.FirstName + " " + UserInfo.LastName);
            DateTimeRefresh.Enabled = true;
        }
        #endregion

        #region 时间刷新定时器
        private void DateTimeRefresh_Tick(object sender, EventArgs e)
        {
            NowDateTimeLabel.Text = DateTime.Now.ToString();
        }
        #endregion

        #region 关闭按钮
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                Application.Exit();
        }
        #endregion

        #region 打开Search Flights
        private void SearchToolBtn_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "SearchFlights")
                    {
                        SearchFlights sf = (SearchFlights)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new SearchFlights());
        }
        #endregion

        #region 打开GroupPurchaseTickets
        private void GroupPurchaseTicketsBtn_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "GroupPurchaseTickets")
                    {
                        GroupPurchaseTickets sf = (GroupPurchaseTickets)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new GroupPurchaseTickets());
        }
        #endregion

        #region 打开新窗口
        private void OpenNewForm(Form NewForm)
        {
            //设置为非顶级控件
            NewForm.TopLevel = false;
            //设置父容器
            NewForm.Parent = this.ToolPanel;
            //打开
            NewForm.Show();
            //将窗口置于前面
            NewForm.BringToFront();
        }
        #endregion

        #region 窗口大小变化
        private void OfficeUserMenuFrom_SizeChanged(object sender, EventArgs e)
        {
            ToolPanel.Width = this.Width - 18;
            ToolPanel.Height = this.Height - 90;
        }
        #endregion

        #region 打开FoodServices
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "FoodServices")
                    {
                        FoodServices sf = (FoodServices)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new FoodServices());
        }
        #endregion

        #region 打开Reschedule/RefundTickets
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "TicketsList")
                    {
                        TicketsList sf = (TicketsList)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new TicketsList());
        }
        #endregion

        #region 打开TransactBoardingCard
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "TransactBoardingCard")
                    {
                        TransactBoardingCard sf = (TransactBoardingCard)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new TransactBoardingCard());
        } 
        #endregion

        #region 打开FlightStatus
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "FlightStatus")
                    {
                        FlightStatus sf = (FlightStatus)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new FlightStatus());
        }
        #endregion

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
