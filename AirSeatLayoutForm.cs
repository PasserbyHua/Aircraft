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
    public partial class AirSeatLayoutForm : Form
    {

        string canbinname;
        int scheid;
        public AirSeatLayoutForm(string canbin, int id)
        {
            InitializeComponent();
            this.canbinname = canbin;
            this.scheid = id;
        }

        #region 按钮点击事件
        //相当于声明一个方法
        public delegate void Seatitem(string Btninfo);
        public event Seatitem Btnclick;
        //按的同时触发事件
        private void button_Click(object sender, EventArgs e)
        {
            Btnclick?.Invoke(((Button)sender).Tag.ToString());
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 数据加载
        private void AirSeatLayoutForm_Load(object sender, EventArgs e)
        {
            FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
            var seat = from q in db.SeatLayout
                       where q.AircraftId == 1
                       select q;
            foreach (var item in seat)
            {
                Button btn = new Button();
                #region 生成座位
                if (item.CabinTypeId == 3)
                {
                    btn.Parent = FirstPanel;
                    btn.Size = new Size((int)(FirstPanel.Width / 2), (int)(FirstPanel.Height / 5));
                    btn.BackColor = Color.Red;
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
                    btn.Click += button_Click;
                    int height = 0;
                    switch (item.ColumnName)
                    {
                        case "A": height = btn.Height * 4; break;
                        case "C": height = btn.Height * 3; break;
                        case "J": height = btn.Height * 1; break;
                        case "L": height = btn.Height * 0; break;
                        default:
                            break;
                    }
                    btn.Location = new Point((btn.Width) * (item.RowNumber - 1), height);
                }
                else if (item.CabinTypeId == 2)
                {
                    btn.Parent = BusinessPanel;
                    btn.Size = new Size((int)(BusinessPanel.Width / 10), (int)(BusinessPanel.Height / 7));
                    btn.BackColor = Color.Blue;
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
                    btn.Click += button_Click;
                    int height = 0;
                    switch (item.ColumnName)
                    {
                        case "A": height = btn.Height * 6; break;
                        case "B": height = btn.Height * 5; break;
                        case "C": height = btn.Height * 4; break;
                        case "J": height = btn.Height * 2; break;
                        case "K": height = btn.Height * 1; break;
                        case "L": height = btn.Height * 0; break;
                        default:
                            break;
                    }
                    btn.Location = new Point((btn.Width) * (item.RowNumber - 2 - 1), height);
                }
                else if (item.CabinTypeId == 1)
                {
                    btn.Parent = Economypanel;
                    btn.Size = new Size((int)(Economypanel.Width / 20), (int)(Economypanel.Height / 7));
                    btn.BackColor = Color.Green;
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
                    btn.Click += button_Click;
                    int height = 0;
                    switch (item.ColumnName)
                    {
                        case "A": height = btn.Height * 6; break;
                        case "B": height = btn.Height * 5; break;
                        case "C": height = btn.Height * 4; break;
                        case "J": height = btn.Height * 2; break;
                        case "K": height = btn.Height * 1; break;
                        case "L": height = btn.Height * 0; break;
                        default:
                            break;
                    }
                    btn.Location = new Point((btn.Width) * (item.RowNumber - 12 - 1), height);
                }
                #endregion
                var query = from q in db.FlightReservation
                            where q.ScheduleId == scheid && q.SeatLayoutId == item.Id
                            select q;
                if (query.Count() == 0)
                    btn.Enabled = true;
                else
                    btn.Enabled = false;
            }
            if (canbinname == "Economy")
            {
                FirstPanel.Enabled = false;
                BusinessPanel.Enabled = false;
            }
            else if (canbinname == "Business")
            {
                FirstPanel.Enabled = false;
                Economypanel.Enabled = false;
            }
            else if (canbinname == "First")
            {
                BusinessPanel.Enabled = false;
                Economypanel.Enabled = false;
            }
        }
        #endregion
    }
}
