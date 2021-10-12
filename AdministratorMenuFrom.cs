using Aircraft.Session3;
using Aircraft.Session4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToSQLClass;
using Models;

namespace Aircraft
{
    public partial class AdministratorMenuFrom : Form
    {
        public AdministratorMenuFrom(string email)
        {
            InitializeComponent();
        }

        #region 打开FlightScheduleManagement
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "FlightScheduleManagement")
                    {
                        FlightScheduleManagement sf = (FlightScheduleManagement)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new FlightScheduleManagement());
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

        #region 打开UserManagement
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "UserManagement")
                    {
                        UserManagement sf = (UserManagement)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new UserManagement());
        }
        #endregion

        #region 打开TicketStatistics
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "TicketStatistics")
                    {
                        TicketStatistics sf = (TicketStatistics)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new TicketStatistics());
        }
        #endregion

        #region 打开SummaryReport
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Find Table!");
            return;
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "SummaryReport")
                    {
                        SummaryReport sf = (SummaryReport)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new SummaryReport());
        }
        #endregion

        #region 打开DetailReport
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Find Table!");
            return;
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "DetailReport")
                    {
                        DetailReport sf = (DetailReport)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new DetailReport());
        }
        #endregion

        #region 打开ShortSummary
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //判断窗口是否已经存在
            foreach (Control item in ToolPanel.Controls)
            {
                if (item is Form)
                {
                    if (item.Text == "ShortSummary")
                    {
                        ShortSummary sf = (ShortSummary)item;
                        if (sf.WindowState == FormWindowState.Minimized)
                            sf.WindowState = FormWindowState.Normal;
                        else
                            sf.WindowState = FormWindowState.Minimized;
                        return;
                    }
                }
            }
            //打开新的窗口
            OpenNewForm(new ShortSummary());
        }
        #endregion

        #region 调整大小
        private void AdministratorMenuFrom_SizeChanged(object sender, EventArgs e)
        {
            ToolPanel.Size = new Size(1024 + (this.Size.Width - 1038), 520 + (this.Size.Height - 610));
        } 
        #endregion

    }
}
