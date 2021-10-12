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

namespace Aircraft
{
    public partial class QueryResultForm2 : UserControl
    {
        #region 常用类
        public TransferResult qr;
        public QueryResultForm2(TransferResult QR)
        {
            InitializeComponent();
            this.qr = QR;
        }
        public int index = -1;
        #endregion

        #region 显示信息
        private void QueryResultForm2_Load(object sender, EventArgs e)
        {
            //读取价格
            TotalPriceTXT.Text = qr.TotalPrice.ToString("#0.00");
            //读取仓位类型
            CanbinTypeTXT.Text = qr.CanbinType;
            //读取出发航班号和准点率
            if (qr.PunctualityRate01 != 0)
                FlightNum01.Text = "Flight " + qr.FlightNumber01 + " (" + (1 - qr.PunctualityRate01).ToString("P0") + ") ";
            else
                FlightNum01.Text = "Flight " + qr.FlightNumber01;
            //读取中转航班号和准点率
            if (qr.PunctualityRate02 != 0)
                FlightNum02.Text = "Flight " + qr.FlightNumber02 + " (" + (1 - qr.PunctualityRate02).ToString("P0") + ") ";
            else
                FlightNum02.Text = "Flight " + qr.FlightNumber02;
            //读取出发站出发信息
            departxt01.Text = qr.deparName + "/" + qr.DepartureATA;
            departime01.Text = qr.DepartureTime.ToString();
            //读取出发站到达信息
            arrtxt01.Text = qr.tranName + "/" + qr.TransferATA;
            arrtime01.Text = qr.TransferTime01.ToString();
            //读取中转站出发信息
            departxt02.Text = qr.tranName + "/" + qr.TransferATA;
            departime02.Text = qr.TransferTime02.ToString();
            //读取中转站到达信息
            arrtxt02.Text = qr.destName + "/" + qr.ArrivalATA;
            arrtime02.Text = qr.ArrivalTime.ToString();
            //读取航班属性
            FliTypetxt.Text = SearchFlights.flighttypestr[2];
            //读取历经时间
            TimeSpan ts = new TimeSpan(0, (qr.TotalTime01 + qr.TotalTime02), 0);
            ts += (qr.TransferTime02 - qr.TransferTime01);
            totaltimetxt.Text = "Total time: " + ts.ToString("t");
            //读取剩余票数
            int k;
            if (qr.AvailableTickets01 > qr.AvailableTickets02)
                k = qr.AvailableTickets02;
            else
                k = qr.AvailableTickets01;
            if (k <= 3)
                AvaNumTxt.ForeColor = Color.Red;
            AvaNumTxt.Text = k.ToString() + " available tickets";
            //读取转机时间
            transfertxt.Text = (qr.TransferTime02 - qr.TransferTime01).ToString() + " Transfer in " + arrtxt01.Text;
        }
        #endregion

        #region 选中按钮
        private void radioButton1_Click(object sender, EventArgs e)
        {
            foreach (Control item in Parent.Controls)
            {
                if (item is UserControl)
                {
                    UserControl uc = (UserControl)item;
                    if (uc is QueryResultForm)
                    {
                        QueryResultForm qrf = (QueryResultForm)uc;
                        qrf.radioButton1.Checked = false;
                    }
                    else if (uc is QueryResultForm2)
                    {
                        QueryResultForm2 qrf2 = (QueryResultForm2)uc;
                        if (qrf2.index == this.index)
                            continue;
                        else
                            qrf2.radioButton1.Checked = false;
                    }
                }
            }
        } 
        #endregion
    }
}
