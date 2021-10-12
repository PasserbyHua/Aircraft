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
    public partial class QueryResultForm : UserControl
    {
        #region 常用类
        public QueryResult qr = new QueryResult();
        public QueryResultForm(QueryResult qr)
        {
            InitializeComponent();
            this.qr = qr;
        }
        public int index = -1;
        #endregion

        #region 加载内容
        private void QueryResultForm_Load(object sender, EventArgs e)
        {
            PriceLabel.Text = "$" + qr.Price.ToString();
            CanbinTypeLabel.Text = qr.CanbinType;
            if (qr.Punc <= 0)
                FlightNumLabel.Text = "Flight " + qr.FlightNumber.ToString();
            else
                FlightNumLabel.Text = "Flight " + qr.FlightNumber.ToString() + "(" + (1 - qr.Punc).ToString("P0") + ")";
            departurelabel.Text = qr.deparName + "/" + qr.DeparCode;
            departureTime.Text = qr.DeparTime.ToString();
            destinationLabel.Text = qr.destName + "/" + qr.DestCode;
            destinationTime.Text = qr.DestTime.ToString();
            FlightTypeLabel.Text = "Non-stop";
            TotalTimeLabel.Text = "Total Time:" + qr.FlightTime.ToString("t");
            //读取剩余票数
            if (qr.RemaTick <= 3)
                ReTicketsLabel.ForeColor = Color.Red;
            ReTicketsLabel.Text = qr.RemaTick + " available tickets";
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
                        if (qrf.index == this.index)
                            continue;
                        else
                            qrf.radioButton1.Checked = false;
                    }
                    else if (uc is QueryResultForm2)
                    {
                        QueryResultForm2 qrf2 = (QueryResultForm2)uc;
                        qrf2.radioButton1.Checked = false;
                    }
                }
            }
        }
        #endregion
    }
}
