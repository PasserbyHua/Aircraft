using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using LinqToSQLClass;

namespace Aircraft
{
    public partial class MonthForm : UserControl
    {
        #region 设置双重缓冲
        protected override CreateParams CreateParams
        {
            get
            {
                //设置双重缓冲
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 常用类加载
        FlightInquiry fi = new FlightInquiry();
        GroupQuery gq = new GroupQuery();
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        public List<List<QueryResult>> selectlistqr = new List<List<QueryResult>>();
        public List<List<GroupBuying>> selectlistgb = new List<List<GroupBuying>>();
        public int index = -1;
        public MonthForm(GroupQuery g)
        {
            InitializeComponent();
            this.gq = g;
        }

        private void MonthForm_Load(object sender, EventArgs e)
        {
            DateTime dt = ShowYears();
            ShowDays(dt);
        }
        #endregion

        #region 显示年份
        public DateTime ShowYears()
        {
            #region 加载年月选择框
            //设置初始年份
            int year = 2020;
            //设置初始月份
            int mouth = 3;
            //设置初始年月日
            string dtstr = year.ToString() + "-" + mouth.ToString() + "-1";
            //设置datetime属性
            DateTime dt = Convert.ToDateTime(dtstr);
            //添加年月选项
            for (int i = 0; i < 12; i++)
            {
                string str = year.ToString() + "-" + mouth.ToString();
                DateListBox.Items.Add(str);
                if (mouth < 12)
                {
                    mouth++;
                }
                else
                {
                    year++;
                    mouth = 1;
                }
            }
            //设置初始选定项
            DateListBox.SelectedIndex = 0;
            #endregion
            return dt;
        }
        #endregion

        #region 显示日历信息
        public void ShowDays(DateTime dt)
        {
            //设置日期
            int day = 1;
            //设置当月天数
            int days = DateTime.DaysInMonth(dt.Year, dt.Month);
            //设置x初始坐标
            int x;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    x = 6;
                    break;
                case DayOfWeek.Monday:
                    x = 0;
                    break;
                case DayOfWeek.Tuesday:
                    x = 1;
                    break;
                case DayOfWeek.Wednesday:
                    x = 2;
                    break;
                case DayOfWeek.Thursday:
                    x = 3;
                    break;
                case DayOfWeek.Friday:
                    x = 4;
                    break;
                case DayOfWeek.Saturday:
                    x = 5;
                    break;
                default:
                    x = -1;
                    break;
            }
            //设置初始坐标
            int y = 0;
            //添加日历选项框
            for (int i = 0; i < days; i++)
            {
                //定义日历panel
                Panel NewPanel = new Panel();
                NewPanel.Parent = mouthPanel;
                NewPanel.Location = new Point(65 * x, 36 * y);
                NewPanel.Size = new Size(mouthPanel.Width / 7 - 5, mouthPanel.Height / 6 - 5);
                NewPanel.BorderStyle = BorderStyle.FixedSingle;
                NewPanel.BringToFront();
                NewPanel.Name = day.ToString();
                //定义日期号
                Label daylabel = new Label();
                daylabel.Parent = NewPanel;
                daylabel.Location = new Point(0, 0);
                daylabel.Font = new Font("黑体", 10.8f, FontStyle.Bold);
                daylabel.Text = day.ToString();
                //获取剩余机票
                int ticks = gettick(gq, new DateTime(dt.Year, dt.Month, day));
                //判断剩余机票
                if (ticks >= GroupPurchaseTickets.ticksnum)
                {
                    //设置panel鼠标效果
                    NewPanel.Cursor = Cursors.Hand;
                    //添加点击事件
                    NewPanel.MouseClick += new MouseEventHandler(dayPanel_MouseClick);
                    //添加剩余机票显示label
                    Label numlabel = new Label();
                    numlabel.Parent = NewPanel;
                    numlabel.Location = new Point(35, 5);
                    numlabel.Font = new Font("黑体", 9f);
                    numlabel.Text = ticks.ToString();
                    numlabel.BringToFront();
                    numlabel.MouseClick += new MouseEventHandler(dayPanel_MouseClick);
                    //添加单位label
                    Label tickelabel = new Label();
                    tickelabel.Parent = NewPanel;
                    tickelabel.Location = new Point(12, 18);
                    tickelabel.Font = new Font("黑体", 9f);
                    tickelabel.Text = "Tickets";
                    tickelabel.MouseClick += new MouseEventHandler(dayPanel_MouseClick);
                    tickelabel.BringToFront();
                }
                else
                {
                    NewPanel.BackColor = Color.Silver;
                }

                if (x == 6)
                {
                    x = 0;
                    y++;
                    day++;
                }
                else
                {
                    x++;
                    day++;
                }
            }
        }
        #endregion

        #region 切换月份
        private void DateListBox_SelectedItemChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Parent = panel4;
            //清除所有选项
            List<Control> lc = new List<Control>();
            //读取所有控件
            for (int i = 0; i < mouthPanel.Controls.Count; i++)
            {
                Control item = mouthPanel.Controls[i];
                lc.Add(item);
            }
            //删除所有控件并释放资源
            for (int i = 0; i < lc.Count; i++)
            {
                mouthPanel.Controls.Remove(lc[i]);
                lc[i].Dispose();
            }
            //定义初始年月日
            string dtstr = DateListBox.SelectedItem.ToString() + "-1";
            DateTime dt = Convert.ToDateTime(dtstr);
            //显示日历
            ShowDays(dt);
        }
        #endregion

        #region 日历单击事件
        private void dayPanel_MouseClick(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                //设置单击事件的控件
                Panel lb = (Panel)sender;
                pictureBox1.Parent = lb;
                pictureBox1.Location = new Point(25, 0);
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                //设置数据源
                foreach (Control item in Parent.Controls)
                {
                    if (item is DataGridView)
                    {
                        DataGridView dgv = (DataGridView)item;
                        index = Convert.ToInt32(lb.Name) - 1;
                        dgv.DataSource = selectlistgb[index];
                    }
                }
            }
            else
            {
                //设置单击事件的控件
                Label pb = (Label)sender;
                Panel lb = (Panel)pb.Parent;
                pictureBox1.Parent = lb;
                pictureBox1.Location = new Point(25, 0);
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                //设置数据源
                foreach (Control item in Parent.Controls)
                {
                    if (item is DataGridView)
                    {
                        DataGridView dgv = (DataGridView)item;
                        index = Convert.ToInt32(lb.Name) - 1;
                        dgv.DataSource = selectlistgb[index];
                    }
                }
            }
        }
        #endregion

        #region 获取余票
        private int gettick(GroupQuery gq, DateTime dt)
        {
            //定义返回类型
            int k = 0;
            //创建查询条件
            QueryCreate qc = new QueryCreate()
            {
                FromCityCode = gq.Fromcity,
                ToCityCode = gq.Tocity,
                DeparTime = dt,
                CanbingType = 1,
                FlightType = 1
            };
            //定义查询机票信息数组
            List<QueryResult> listqr = fi.Qresult(qc);
            //定义该天的航班数组
            List<GroupBuying> listgb = new List<GroupBuying>();
            //判断剩余机票数量
            if (listqr == null)
            {
                selectlistqr.Add(new List<QueryResult>());
                selectlistgb.Add(new List<GroupBuying>());
                return k;
            }
            else
            {
                //添加机票剩余数量
                for (int i = 0; i < listqr.Count; i++)
                {
                    k += listqr[i].RemaTick;
                }
                //将航班信息添加至list数组
                foreach (QueryResult item in listqr)
                {
                    GroupBuying gb = new GroupBuying()
                    {
                        FlightNumber = item.FlightNumber.ToString(),
                        OnDateTime = item.DeparTime.ToString("t") + "-" + item.DestTime.ToString("t"),
                        Price = item.Price.ToString("#0.00"),
                        Airport = item.DeparCode + "-" + item.DestCode,
                        AvailableTicket = item.RemaTick.ToString()
                    };
                    listgb.Add(gb);
                }
                //将返回信息填充至selectlistqr
                selectlistqr.Add(listqr);
                //将list添加至selectlistgb
                selectlistgb.Add(listgb);
                //返回结果
                return k;
            }
        } 
        #endregion
    }
}
