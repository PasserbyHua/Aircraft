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
    public partial class BookFlights : Form
    {

        #region 窗口加载
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        public QueryResult DeparQR = null;
        public QueryResult ReturnQR = null;
        public TransferResult TDeparQR = null;
        public TransferResult TReturnQR = null;
        public List<BookingInfo> list = new List<BookingInfo>();
        public List<BookingInfo> show = new List<BookingInfo>();
        public string[] IDTypeArr = new string[2] { "ID Card", "Passport" };
        public int peoplenum = -1;
        public float k = 1;

        public BookFlights()
        {
            InitializeComponent();
        }

        private void BookFlights_Load(object sender, EventArgs e)
        {
            //设置折扣
            if (peoplenum >= 5) k = (float)0.6;
            #region 机票信息
            if (DeparQR != null)
            {
                DeparDate.Text = DeparQR.DeparTime.ToShortDateString();
                DeparFlightNum.Text = "Flight " + DeparQR.FlightNumber;
                DeparTime1.Text = DeparQR.DeparTime.ToShortTimeString();
                DeparTime2.Text = DeparQR.DestTime.ToShortTimeString();
                DeparTotalTime.Text = (DeparQR.DestTime - DeparQR.DeparTime).Hours.ToString() + "h" + (DeparQR.DestTime - DeparQR.DeparTime).Minutes.ToString() + "m";
                DeparCanbin.Text = DeparQR.CanbinType;
                if (DeparQR.RemaTick <= 3)
                    DeparTickets.ForeColor = Color.Red;
                DeparTickets.Text = DeparQR.RemaTick.ToString() + " available tickets";
                DeparPrice.Text = "$" + (DeparQR.Price * Convert.ToDecimal(k)).ToString("#0.00");
                DeparInfoPanel.Visible = true;
            }
            else if (TDeparQR != null)
            {
                DeparDate.Text = TDeparQR.DepartureTime.ToShortDateString();
                DeparFlightNum.Text = "Flight" + TDeparQR.FlightNumber01 + "," + TDeparQR.FlightNumber02;
                DeparTime1.Text = TDeparQR.DepartureTime.ToShortTimeString();
                DeparTime2.Text = TDeparQR.ArrivalTime.ToShortTimeString();
                DeparTotalTime.Text = (TDeparQR.ArrivalTime - TDeparQR.DepartureTime).Hours.ToString() + "h" + (TDeparQR.ArrivalTime - TDeparQR.DepartureTime).Minutes.ToString();
                DeparCanbin.Text = TDeparQR.CanbinType;
                if (TDeparQR.AvailableTickets01 < TDeparQR.AvailableTickets02)
                {
                    if (TDeparQR.AvailableTickets01 <= 3)
                        DeparTickets.ForeColor = Color.Red;
                    DeparTickets.Text = TDeparQR.AvailableTickets01.ToString() + " available tickets";
                }
                else
                {
                    if (TDeparQR.AvailableTickets02 <= 3)
                        DeparTickets.ForeColor = Color.Red;
                    DeparTickets.Text = TDeparQR.AvailableTickets02.ToString() + " available tickets";
                }
                DeparPrice.Text = "$" + TDeparQR.TotalPrice.ToString("#0.00");
                DeparInfoPanel.Visible = true;
            }

            if (ReturnQR != null)
            {
                ReDate.Text = ReturnQR.DeparTime.ToShortDateString();
                ReFlightNum.Text = "Flight " + ReturnQR.FlightNumber;
                ReTime1.Text = ReturnQR.DeparTime.ToShortTimeString();
                ReTime2.Text = ReturnQR.DestTime.ToShortTimeString();
                ReTotalTime.Text = (ReturnQR.DestTime - ReturnQR.DeparTime).Hours.ToString() + "h" + (ReturnQR.DestTime - ReturnQR.DeparTime).Minutes.ToString() + "m";
                ReCanbin.Text = ReturnQR.CanbinType;
                if (ReturnQR.RemaTick <= 3)
                    ReTickets.ForeColor = Color.Red;
                ReTickets.Text = ReturnQR.RemaTick.ToString() + " available tickets";
                RePrice.Text = "$" + (ReturnQR.Price * Convert.ToDecimal(k)).ToString("#0.00");
                ReInfoPanel.Visible = true;
            }
            else if (TReturnQR != null)
            {
                ReDate.Text = TReturnQR.DepartureTime.ToShortDateString();
                ReFlightNum.Text = "Flight" + TReturnQR.FlightNumber01 + "," + TReturnQR.FlightNumber02;
                ReTime1.Text = TReturnQR.DepartureTime.ToShortTimeString();
                ReTime2.Text = TReturnQR.ArrivalTime.ToShortTimeString();
                ReTotalTime.Text = (TReturnQR.ArrivalTime - TReturnQR.DepartureTime).Hours.ToString() + "h" + (TReturnQR.ArrivalTime - TReturnQR.DepartureTime).Minutes.ToString();
                ReCanbin.Text = TReturnQR.CanbinType;
                if (TReturnQR.AvailableTickets01 < TReturnQR.AvailableTickets02)
                {
                    if (TReturnQR.AvailableTickets01 <= 3)
                        ReTickets.ForeColor = Color.Red;
                    ReTickets.Text = TReturnQR.AvailableTickets01.ToString() + " available tickets";
                }
                else
                {
                    if (TReturnQR.AvailableTickets02 <= 3)
                        ReTickets.ForeColor = Color.Red;
                    ReTickets.Text = TReturnQR.AvailableTickets02.ToString() + " available tickets";
                }
                RePrice.Text = "$" + TReturnQR.TotalPrice.ToString("#0.00");
                ReInfoPanel.Visible = true;
            }
            #endregion

            #region 设置身份证类型信息
            //设置列表属性
            IDtypeTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            IDtypeTxt.IntegralHeight = false;
            IDtypeTxt.MaxDropDownItems = 10;
            //设置身份证类型
            IDtypeTxt.Items.AddRange(IDTypeArr);
            #endregion

            #region 填充国家信息
            //设置列表属性
            CountryTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            CountryTxt.IntegralHeight = false;
            CountryTxt.MaxDropDownItems = 10;
            var query = from q in db.Country
                        select q;
            List<Country> lc = query.ToList();
            CountryTxt.DataSource = lc;
            CountryTxt.DisplayMember = "CountryName";
            CountryTxt.ValueMember = "CountryCode";
            CountryTxt.SelectedIndex = -1;
            #endregion
        }
        #endregion

        #region 添加乘客
        private void button1_Click(object sender, EventArgs e)
        {
            if (FormatCheck())
            {
                char fm;
                if (MaliRadio.Checked)
                    fm = 'M';
                else
                    fm = 'F';


                #region 添加出发信息
                if (DeparQR != null)
                {
                    /*#region 获取座位编号
                    int j = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == DeparQR.Sid
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == DeparQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == DeparQR.Sid
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    #endregion*/

                    #region 添加乘客信息
                    BookingInfo bki = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.Text.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = DeparQR.Price,
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == DeparQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = DeparQR.Sid
                    };
                    #endregion
                    show.Add(bki);
                    list.Add(bki);
                }
                else if (TDeparQR != null)
                {
                    #region 获取座位编号
                    int j = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == TDeparQR.Sid
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == TDeparQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == TDeparQR.Sid
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    int i = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == TDeparQR.Sid2
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == TDeparQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == TDeparQR.Sid2
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    #endregion

                    #region 添加信息
                    BookingInfo bki = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.Text.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = Convert.ToDecimal(TDeparQR.TotalPrice),
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == TDeparQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = TDeparQR.Sid
                    };
                    BookingInfo bki2 = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.Text.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = Convert.ToDecimal(TDeparQR.TotalPrice),
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == TDeparQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = TDeparQR.Sid2
                    };
                    #endregion

                    show.Add(bki); 
                    list.Add(bki);
                    list.Add(bki2);
                }
                #endregion


                #region 添加返回信息
                if (ReturnQR != null)
                {
                    #region 获取座位编号
                    int j = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == ReturnQR.Sid
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == ReturnQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == ReturnQR.Sid
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    #endregion

                    #region 添加乘客信息
                    BookingInfo bki = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.Text.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = ReturnQR.Price,
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == ReturnQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = ReturnQR.Sid
                    };
                    #endregion
                    list.Add(bki);
                }
                else if (TReturnQR != null)
                {
                    #region 获取座位编号
                    int j = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == TReturnQR.Sid
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == TReturnQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == TReturnQR.Sid
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    int i = (from q in db.SeatLayout
                             join p in db.FlightReservation on q.Id equals p.SeatLayoutId
                             where p.ScheduleId == TReturnQR.Sid2
                             && p.CabinTypeId == (from q in db.CabinType
                                                  where q.CabinTypeName == TReturnQR.CanbinType
                                                  select q.CabinTypeId).First()
                             && q.AircraftId == (from q in db.Schedule
                                                 where q.ScheduleId == TReturnQR.Sid2
                                                 select q.AircraftId).First()
                             select q.Id).First();
                    #endregion

                    #region 添加信息
                    BookingInfo bki = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.Text.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = Convert.ToDecimal(TReturnQR.TotalPrice),
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == TReturnQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = TReturnQR.Sid
                    };
                    BookingInfo bki2 = new BookingInfo()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Birthdate = BirthDateTxt.Value,
                        Gender = fm,
                        IDType = IDtypeTxt.SelectedItem.ToString(),
                        IDTypeNumber = IDTypeNumTxt.Text,
                        CountryCode = CountryTxt.SelectedValue.ToString(),
                        Country = CountryTxt.SelectedItem.ToString(),
                        Telephone = PhoneTxt.Text,
                        UserID = OfficeUserMenuFrom.UserInfo.UserId1,
                        Discount = k,
                        Pay = Convert.ToDecimal(TReturnQR.TotalPrice),
                        Canid = (from q in db.CabinType
                                 where q.CabinTypeName == TReturnQR.CanbinType
                                 select q.CabinTypeId).First(),
                        Sid = TReturnQR.Sid2
                    };
                    #endregion
                    list.Add(bki);
                    list.Add(bki2);
                }
                #endregion

                dataGridView1.DataSource = new BindingList<BookingInfo>(show);
            }
        }
        #endregion

        #region 格式检查
        private bool FormatCheck()
        {
            bool result = false;
            if (FirstNameTxt.Text == "")
                MessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (LastNameTxt.Text == "")
                MessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (MaliRadio.Checked && FemaleRadio.Checked)
                MessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (IDtypeTxt.SelectedIndex == -1)
                MessageBox.Show("请选择身份证类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (IDTypeNumTxt.Text == "")
                MessageBox.Show("请输入身份证号码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (CountryTxt.Text == "")
                MessageBox.Show("请选择国家", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (PhoneTxt.Text == "")
                MessageBox.Show("请输入手机号码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                result = true;
            return result;
        }
        #endregion

        #region 删除乘客
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Remove"].Index && e.RowIndex > -1)
            {
                list.Remove(list[e.RowIndex]);
                dataGridView1.DataSource = new BindingList<BookingInfo>(list);
            }
        }
        #endregion

        #region 订购按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (peoplenum != -1)
            {
                if (show.Count < peoplenum)
                {
                    MessageBox.Show("人数不能小于组团人数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            FlightInquiry fi = new FlightInquiry();

            if (fi.Addplane(list))
            {
                MessageBox.Show("订购成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("订购失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion
    }
}
