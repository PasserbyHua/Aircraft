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
    public partial class CreateScheduleForm : Form
    {
        #region 常用类
        List<Route> lr = null;
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        QueryCreate2 qc2 = new QueryCreate2();
        #endregion

        #region 数据加载
        public CreateScheduleForm()
        {
            InitializeComponent();
        }

        private void CreateScheduleForm_Load(object sender, EventArgs e)
        {
            var query = from q in db.Route select q;
            lr = query.ToList();
            foreach (var item in lr)
            {
                string oneitem = item.DepartureAirportIATA.Trim() + " - " + item.ArrivalAirportIATA;
                comboBox1.Items.Add(oneitem);
            }
            var query2 = from q in db.Aircraft select q;
            foreach (var item in query2)
            {
                string oneitem = item.Name;
                comboBox2.Items.Add(oneitem);
            }
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.ShowUpDown = true;
        } 
        #endregion

        #region 飞机座位信息
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var query2 = from q in db.Aircraft select q;
            if (comboBox2.SelectedItem.ToString() == "Boeing 737-800")
            {
                pictureBox1.Image = Properties.Resources.Aircraft_Boeing_737_800;
                label9.Text = "It will generate " + query2.First(q => q.AircraftId == 1).EconomySeatsAmount + " economy tickets," + query2.First(q => q.AircraftId == 1).BusinessSeatsAmount + " business tickets and " + query2.First(q => q.AircraftId == 1).FirstSeatsAmount + " first tickets in the system.";
            }
            else if (comboBox2.SelectedItem.ToString() == "Airbus  319")
            {
                pictureBox1.Image = Properties.Resources.Aircraft_Airbus__319;
                label9.Text = "It will generate " + query2.First(q => q.AircraftId == 2).EconomySeatsAmount + " economy tickets," + query2.First(q => q.AircraftId == 2).BusinessSeatsAmount + " business tickets and " + query2.First(q => q.AircraftId == 2).FirstSeatsAmount + " first tickets in the system.";
            }
        }
        #endregion

        #region 添加航班按钮

        private void button1_Click(object sender, EventArgs e)
        {
            RouteInfo ri = new RouteInfo()
            {
                DeparDateTime = new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day, dateTimePicker2.Value.TimeOfDay.Hours, dateTimePicker2.Value.TimeOfDay.Minutes, dateTimePicker2.Value.TimeOfDay.Seconds),
                AircraftId = db.Aircraft.First(q => q.Name == comboBox2.SelectedItem.ToString()).AircraftId,
                RouteId = lr[comboBox1.SelectedIndex].RouteId,
                EconomyPrice = Convert.ToDecimal(textBox3.Text),
                FlightNumber = Convert.ToInt32(textBox1.Text),
                Gate = textBox2.Text,
                Status = "Confirmed"
            };
            if (
            qc2.intsetschedele(ri))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        #endregion

        #region 关闭按钮

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}
