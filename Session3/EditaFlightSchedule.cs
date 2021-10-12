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
    public partial class EditaFlightSchedule : Form
    {
        QueryResultS qrs = null;
        public EditaFlightSchedule(QueryResultS resultS)
        {
            InitializeComponent();
            this.qrs = resultS;
        }

        #region 数据加载
        private void EditaFlightSchedule_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            string str = qrs.From.Substring(qrs.From.Length - 3, 3) + "-" + qrs.To.Substring(qrs.To.Length - 3, 3);
            comboBox1.Items.Add(str);
            comboBox1.SelectedIndex = 0;
            comboBox2.Enabled = false;
            comboBox2.Items.Add(qrs.Aircraft);
            comboBox2.SelectedIndex = 0;
            textBox1.Enabled = false;
            textBox1.Text = qrs.FlightNumber.Trim();
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.ShowUpDown = true;
        } 
        #endregion

        #region 关闭按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 提交按钮
        private void button1_Click(object sender, EventArgs e)
        {
            RouteInfo newr = new RouteInfo()
            {
                DeparDateTime = new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day, dateTimePicker2.Value.TimeOfDay.Hours, dateTimePicker2.Value.TimeOfDay.Minutes, dateTimePicker2.Value.TimeOfDay.Seconds),
                EconomyPrice = Convert.ToDecimal(textBox3.Text),
                Gate = textBox2.Text
            };
            QueryCreate2 qc2 = new QueryCreate2();
            qc2.updateschedule(Convert.ToInt32(qrs.Schedule), newr);
            MessageBox.Show("OK");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
