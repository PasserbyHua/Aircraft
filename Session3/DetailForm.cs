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


namespace Aircraft.Session3
{
    public partial class DetailForm : Form
    {
        #region 数据加载
        QueryResultS QRS;
        public DetailForm(QueryResultS QRS)
        {
            InitializeComponent();
            this.QRS = QRS;
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            label2.Text = QRS.From.Substring(QRS.From.Length - 3, 3) + " to " + QRS.To.Substring(QRS.To.Length - 3, 3) + "," + QRS.Date + "," + QRS.Time + QRS.Aircraft;
            #region 判断并显示飞机类型
            if (QRS.Aircraft == "Boeing 737-800")
            {
                pictureBox1.Image = Properties.Resources.Aircraft_Boeing_737_800;
            }
            else if (QRS.Aircraft == "Airbus  319")
            {
                pictureBox1.Image = Properties.Resources.Aircraft_Airbus__319;
            }
            #endregion
            int F = 0, B = 0, E = 0;
            FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
            var Airid = from p in db.Aircraft where p.Name == QRS.Aircraft select p;
            var seat = from q in db.SeatLayout
                       where q.AircraftId == (Airid).First().AircraftId
                       select q;
            var selectseat = from q in db.FlightReservation
                             join s in db.Schedule on q.ScheduleId equals s.ScheduleId
                             where s.AircraftId == (Airid).First().AircraftId
                             && q.ScheduleId == Convert.ToInt32(QRS.Schedule)
                             group s by q.CabinTypeId into g
                             select new
                             {
                                 canid = g.Key,
                                 all = g.Count()
                             };
            var seatall = from q in db.SeatLayout
                          where q.AircraftId == (Airid).First().AircraftId
                          group q by q.CabinTypeId into g
                          select new
                          {
                              canid = g.Key,
                              all = g.Count()
                          };
            #region 查询座位
            foreach (var item in seat)
            {
                Button btn = new Button();
                #region 生成座位
                if (item.CabinTypeId == 3)
                {
                    btn.Parent = FirstPanel;
                    btn.Size = new Size((int)(FirstPanel.Width / 4), (int)(FirstPanel.Height / 6));
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
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
                    btn.Size = new Size((int)(BusinessPanel.Width / 7), (int)(BusinessPanel.Height / 8));
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
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
                    btn.Size = new Size((int)(Economypanel.Width / 10), (int)(Economypanel.Height / 8));
                    btn.Text = item.ColumnName;
                    btn.Tag = item.RowNumber.ToString() + item.ColumnName.ToString();
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
                            where q.ScheduleId == Convert.ToInt32(QRS.Schedule) && q.SeatLayoutId == item.Id
                            select q;
                if (query.Count() == 0)
                    btn.BackColor = Color.White;
                else
                {
                    switch (query.First().CabinTypeId)
                    {
                        case 1: E++; break;
                        case 2: B++; break;
                        case 3: F++; break;
                        default:
                            break;
                    }
                    btn.BackColor = Color.Orange;
                }
                btn.Enabled = false;
            }
            #endregion
            foreach (var item in selectseat)
            {
                if (item.canid == 1)
                {
                    label17.Text = item.all.ToString() + "/" + seatall.First(q => q.canid == 1).all.ToString() + " " + ((decimal)item.all / (decimal)seatall.First(q => q.canid == 1).all).ToString("P0");
                    label16.Text = "Total Tickets:" + seatall.First(q => q.canid == 1).all.ToString();
                    label15.Text = "Sold Tickets:" + item.all.ToString();
                    label14.Text = "Seats Selects:" + E.ToString();
                }
                else if (item.canid == 2)
                {
                    label13.Text = item.all.ToString() + "/" + seatall.First(q => q.canid == 2).all.ToString() + " " + ((decimal)item.all / (decimal)seatall.First(q => q.canid == 2).all).ToString("P0");
                    label12.Text = "Total Tickets:" + seatall.First(q => q.canid == 2).all.ToString();
                    label11.Text = "Sold Tickets:" + item.all.ToString();
                    label10.Text = "Seats Selects:" + B.ToString();
                }
                else if (item.canid == 3)
                {
                    label6.Text = item.all.ToString() + "/" + seatall.First(q => q.canid == 3).all.ToString() + " " + ((decimal)item.all / (decimal)seatall.First(q => q.canid == 3).all).ToString("P0");
                    label7.Text = "Total Tickets:" + seatall.First(q => q.canid == 3).all.ToString();
                    label8.Text = "Sold Tickets:" + item.all.ToString();
                    label9.Text = "Seats Selects:" + F.ToString();
                }
            }
            if ((from q in selectseat where q.canid == 1 select q).Count() == 0)
            {
                label17.Text = "0/" + seatall.First(q => q.canid == 1).all.ToString() + " 0%";
                label16.Text = "Total Tickets:" + seatall.First(q => q.canid == 1).all.ToString();
                label15.Text = "Sold Tickets:0";
                label14.Text = "Seats Selects:" + E.ToString();
            }
            if ((from q in selectseat where q.canid == 2 select q).Count() == 0)
            {
                label13.Text = "0/" + seatall.First(q => q.canid == 2).all.ToString() + " 0%";
                label12.Text = "Total Tickets:" + seatall.First(q => q.canid == 1).all.ToString();
                label11.Text = "Sold Tickets:0";
                label10.Text = "Seats Selects:" + B.ToString();
            }
            if ((from q in selectseat where q.canid == 3 select q).Count() == 0)
            {
                label6.Text = "0/" + seatall.First(q => q.canid == 3).all.ToString() + " 0%";
                label7.Text = "Total Tickets:" + seatall.First(q => q.canid == 1).all.ToString();
                label8.Text = "Sold Tickets:0";
                label9.Text = "Seats Selects:" + F.ToString();
            }

        }
        #endregion
    }
}
