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
    public partial class RefundTickets : Form
    {
        #region 常用类声明
        tickinfo info = null;
        FlightInquiry fi = new FlightInquiry();
        FoodHelper fh = new FoodHelper();
        Refundinfo rt = null;
        public RefundTickets(tickinfo ti)
        {
            InitializeComponent();
            this.info = ti;
        } 
        #endregion

        #region 数据加载
        private void RefundTickets_Load(object sender, EventArgs e)
        {
            DateTime nowdate = MyDateTime.nowdate;
            rt = fi.getRefundInfo(info);
            List<FoodInfo> listfi = fh.GetFoodInfo();
            FlightNumberLb.Text = rt.FlightNum;
            AircraftLb.Text = rt.Airinfo;
            DateLb.Text = rt.Departime.ToShortDateString();
            EticketNumberLb.Text = rt.ETicketNum;
            FromLb.Text = rt.DeparName + "(" + rt.Departime.ToShortTimeString() + ")";
            ToLb.Text = rt.DestName + "(" + rt.Desttime.ToShortTimeString() + ")";
            CustomerNameLb.Text = rt.CusName;
            IDTypeLb.Text = rt.IDtype;
            IDTypeNumberLb.Text = rt.IDtypenum;
            TicketPriceLb.Text = "$" + rt.tickPrice.ToString();
            FlightStatusLb.Text = rt.FlighStatus;
            //food
            string foodin = "";
            decimal foodprice = 0;
            for (int i = 0; i < rt.foodm.foodcount.Length; i++)
            {
                if (rt.foodm.foodcount[i] > 0)
                {
                    foodprice += listfi[i].Price;
                    foodin = String.Concat(foodin, ",", listfi[i].FoodName, "($", listfi[i].Price.ToString("#0.00"), "*", rt.foodm.foodcount[i], ")");
                }
            }
            if (foodin.Length > 0)
                foodin.Substring(1, foodin.Length - 1);
            ReservationFoodLb.Text = foodin;
            //luggage
            ConsignmentluggageLb.Text = rt.Amount.ToString() + " luggage,total weight " + rt.TotalWeight.ToString() + "Kg,$" + rt.Fee.ToString("#0.00") + " fee";
            PaymentLb.Text = "$" + (rt.tickPrice + foodprice + rt.Fee).ToString("#0.00");
            //servicescharge
            decimal services = 0;
            if (rt.FlighStatus == "Confirmed")
            {
                #region 机票服务费
                if (rt.Departime - nowdate > new TimeSpan(24, 0, 0))
                {
                    services += rt.tickPrice * 0.05m;
                }
                else if (rt.Departime - nowdate > new TimeSpan(0, 2, 0))
                {
                    services += rt.tickPrice * 0.1m;
                }
                else if (rt.Departime - nowdate > new TimeSpan(0, 0, 0))
                {
                    services += rt.tickPrice * 0.2m;
                }
                else
                {
                    services += (rt.tickPrice * 0.5m + rt.Fee);
                }
                #endregion
                #region 食物服务费
                if (rt.Departime - nowdate < new TimeSpan(0, 6, 0))
                {
                    services += foodprice;
                }
                #endregion
                ServiceChangeLb.Text = "$" + services.ToString("#0.00");
            }
            else
            {
                ServiceChangeLb.Text = "$0.00";
            }
            RefoundFeeLb.Text = "$" + ((rt.tickPrice + foodprice + rt.Fee) - services).ToString("#0.00");
        }
        #endregion

        #region 确定退款
        private void button1_Click(object sender, EventArgs e)
        {
            if (fi.conRefund(rt))
            {
                MessageBox.Show("OK");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        } 
        #endregion
    }
}
