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
    public partial class TransactBoardingCard : Form
    {
        #region 数据加载
        BoardingCardinfo selebc = null;
        FlightInquiry fi = new FlightInquiry();
        List<BoardingCardinfo> listbc = null;
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        int Amount = 0;
        decimal Weight = 0;
        decimal fee = 0;
        string SelectSeat;
        public string[] IDTypeArr = new string[2] { "ID Card", "Passport" };
        public TransactBoardingCard()
        {
            InitializeComponent();
        }

        private void TransactBoardingCard_Load(object sender, EventArgs e)
        {
            IDTypeList.DropDownStyle = ComboBoxStyle.DropDownList;
            IDTypeList.IntegralHeight = false;
            IDTypeList.DataSource = IDTypeArr;
        }
        #endregion

        #region 查询机票
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime nowdt = MyDateTime.nowdate;
            string IDType = IDTypeList.SelectedItem.ToString().Trim();
            string IDNum = IDNumBox.Text.Trim();
            DateTime dt = datetimebox.Value;
            listbc = fi.getboardingflight(IDType, IDNum, dt);
            int i = 0;
            foreach (var item in listbc)
            {
                if ((item.DeparTime - nowdt) > new TimeSpan(48, 0, 0) || (item.DeparTime - nowdt) < new TimeSpan(1, 0, 0)) continue;
                TransactBoardingCardSelectForm1 newform = new TransactBoardingCardSelectForm1(item);
                newform.Parent = flightpanel;
                newform.Location = new Point(0, newform.Height * i);
                newform.eventinfo += joinbc;
                i++;
            }
        }
        #endregion

        #region 填充选中数据
        public void joinbc(BoardingCardinfo joininfo)
        {
            this.selebc = joininfo;
            gatetext.Text = selebc.Gate;
        }
        #endregion

        #region 是否托运
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                label10.Text = "$0.00";
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }
        #endregion

        #region 打开座位视图
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result;
            if (selebc.AirName == null)
                return;
            if (selebc.AirName == "Boeing 737-800")
            {
                AirSeatLayoutForm newform = new AirSeatLayoutForm(selebc.CanbinName,selebc.ScheduleId);
                newform.Btnclick += getSeat;
                result = newform.ShowDialog();
                if (result == DialogResult.OK)
                    label12.Text = SelectSeat;
            }
            else if (selebc.AirName == "Airbus  319")
            {
                AirSeatLayoutForm2 newform = new AirSeatLayoutForm2(selebc.CanbinName, selebc.ScheduleId);
                newform.Btnclick += getSeat;
                result = newform.ShowDialog();
                if (result == DialogResult.OK)
                    label12.Text = SelectSeat;
            }
        }
        #endregion

        #region 事件返回值
        private void getSeat(string Seat)
        {
            this.SelectSeat = Seat;
        }
        #endregion

        #region 托运价格计算
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && selebc != null)
            {
                decimal Maxwei = 0;
                if (selebc.CanbinName == "Economy")
                    Maxwei = 20;
                else if (selebc.CanbinName == "Business")
                    Maxwei = 30;
                else if (selebc.CanbinName == "First")
                    Maxwei = 40;
                if (Convert.ToDecimal(textBox4.Text) > Maxwei)
                {
                    Amount = Convert.ToInt32(textBox3.Text);
                    Weight = Convert.ToInt32(textBox4.Text);
                    fee = Math.Ceiling(db.Schedule.First(q => q.ScheduleId == selebc.ScheduleId).EconomyPrice * 0.015m) * (Convert.ToDecimal(textBox4.Text) - Maxwei);
                    label10.Text = "$" + fee.ToString("#0.00");
                }
                else
                {
                    label10.Text = "$0.00";
                }
            }
        }
        #endregion

        #region 提交数据
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SeatSubmitInfo info = new SeatSubmitInfo()
                {
                    ReservaID = selebc.RID,
                    SeatName = SelectSeat,
                    Amount = this.Amount,
                    Weight = this.Weight,
                    Fee = this.fee
                };
                if (fi.SubmitSeat(info))
                {
                    PrintTickInfo pt= fi.GetPrint(selebc.RID);
                    PrintBoardingCard pb = new PrintBoardingCard(pt);
                    pb.Show();
                }
            }
            else
            {
                SeatSubmitInfo info = new SeatSubmitInfo()
                {
                    ReservaID = selebc.RID,
                    SeatName = SelectSeat,
                    Amount = 0,
                    Weight = 0,
                    Fee = 0
                };
                if (fi.SubmitSeat(info))
                {
                    PrintTickInfo pt = fi.GetPrint(selebc.RID);
                    PrintBoardingCard pb = new PrintBoardingCard(pt);
                    pb.Show();
                }
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
