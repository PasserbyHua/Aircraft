using Models;
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

namespace Aircraft
{
    public partial class GroupPurchaseTickets : Form
    {
        #region 加载数据
        public static QueryResult deparqr = new QueryResult();
        public static QueryResult returnqr = new QueryResult();
        public static int ticksnum;
        public int selectrow1 = -1;
        public int selectrow2 = -1;
        public GroupPurchaseTickets()
        {
            InitializeComponent();
        }

        private void GroupPurchaseTickets_Load(object sender, EventArgs e)
        {
            //设置默认机票订购数
            ticksnum = 5;
            //设置城市
            FlightInquiry fi = new FlightInquiry();
            FromCityTxt.DataSource = fi.GetCity();
            FromCityTxt.DisplayMember = "CityName";
            FromCityTxt.ValueMember = "CityCode";
            FromCityTxt.SelectedIndex = -1;
            ToCityTxt.DataSource = fi.GetCity();
            ToCityTxt.DisplayMember = "CityName";
            ToCityTxt.ValueMember = "CityCode";
            ToCityTxt.SelectedIndex = -1;
            //设置点击整行
            this.FlightInfoView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FlightInfoView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //将视图设为只读
            FlightInfoView1.ReadOnly = true;
            FlightInfoView2.ReadOnly = true;
            //设置不自动生成列
            FlightInfoView1.AutoGenerateColumns = false;
            FlightInfoView2.AutoGenerateColumns = false;
            //设置高度固定
            FlightInfoView1.AllowUserToResizeRows = false;
            FlightInfoView2.AllowUserToResizeRows = false;
        }
        #endregion

        #region 调换城市
        private void button2_Click(object sender, EventArgs e)
        {
            if (FromCityTxt.SelectedIndex != -1 && ToCityTxt.SelectedIndex != -1)
            {
                int i = ToCityTxt.SelectedIndex;
                ToCityTxt.SelectedIndex = FromCityTxt.SelectedIndex;
                FromCityTxt.SelectedIndex = i;
            }
        }
        #endregion

        #region 选中整行效果
        private void FlightInfoView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectrow1 = e.RowIndex;
        }
        private void FlightInfoView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectrow2 = e.RowIndex;
        }
        #endregion

        #region 查询按钮
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (FromCityTxt.SelectedIndex == -1)
            {
                MessageBox.Show("请选择出发城市", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (ToCityTxt.SelectedIndex == -1)
            {
                MessageBox.Show("请选择到达城市", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (FromCityTxt.SelectedIndex == ToCityTxt.SelectedIndex)
            {
                MessageBox.Show("选择的城市不能相同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //出发月票
                foreach (Control item in DeparPanel.Controls)
                {
                    if(item is UserControl)
                    {
                        DeparPanel.Controls.Remove(item);
                    }
                }
                GroupQuery gq = new GroupQuery()
                {
                    Fromcity = FromCityTxt.SelectedValue.ToString(),
                    Tocity = ToCityTxt.SelectedValue.ToString()
                };
                MonthForm NewMonthFrom1 = new MonthForm(gq);
                NewMonthFrom1.Parent = this.DeparPanel;
                NewMonthFrom1.Location = new Point(0, 0);
                NewMonthFrom1.Show();
                NewMonthFrom1.BringToFront();
                //返回月票
                foreach (Control item in ArrPanel.Controls)
                {
                    if (item is UserControl)
                    {
                        ArrPanel.Controls.Remove(item);
                    }
                }
                GroupQuery gq2 = new GroupQuery()
                {
                    Fromcity = ToCityTxt.SelectedValue.ToString(),
                    Tocity = FromCityTxt.SelectedValue.ToString()
                };
                MonthForm NewMonthFrom2 = new MonthForm(gq2);
                NewMonthFrom2.Parent = this.ArrPanel;
                NewMonthFrom2.Location = new Point(0, 0);
                NewMonthFrom2.Show();
                NewMonthFrom2.BringToFront();

            }
        }
        #endregion

        #region 订购按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (selectrow1 == -1) return;
            MonthForm mf1 = null;
            MonthForm mf2 = null;
            foreach (Control item in DeparPanel.Controls)
            {
                if (item is UserControl)
                    mf1 = (MonthForm)item;
            }
            foreach (Control item in ArrPanel.Controls)
            {
                if (item is UserControl)
                    mf2 = (MonthForm)item;
            }
            BookFlights bk = new BookFlights();

            bk.DeparQR = mf1.selectlistqr[mf1.index][selectrow1];
            bk.TDeparQR = null;
            bk.ReturnQR = mf2.selectlistqr[mf2.index][selectrow2];
            bk.TReturnQR = null;
            bk.peoplenum = ticksnum;

            bk.Show();
        } 
        #endregion
    }
}
