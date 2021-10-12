using LinqToSQLClass;
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

namespace Aircraft.Session3
{
    public partial class FlightScheduleManagement : Form
    {

        #region 数据加载
        GetInfo gi = new GetInfo();
        QueryCreate2 qc = new QueryCreate2();
        List<QueryResultS> listR = null;
        public FlightScheduleManagement()
        {
            InitializeComponent();
        }

        private void FlightScheduleManagement_Load(object sender, EventArgs e)
        {
            //加载城市
            List<City> lc = gi.GetCity2();
            comboBox1.DataSource = new List<City>(lc);
            comboBox1.DisplayMember = "CityName";
            comboBox1.ValueMember = "CityCode";
            comboBox1.SelectedIndex = -1;
            comboBox2.DataSource = new List<City>(lc);
            comboBox2.DisplayMember = "CityName";
            comboBox2.ValueMember = "CityCode";
            comboBox2.SelectedIndex = -1;
            dataGridView1.AutoGenerateColumns = false;
        }
        #endregion

        #region 查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<QueryResultS>();
            #region 查询航班
            if (radioButton1.Checked)
            {
                FlightIATAQuery query = new FlightIATAQuery()
                {
                    FromIATACode = comboBox1.SelectedValue.ToString(),
                    ToIATACode = comboBox2.SelectedValue.ToString(),
                    DT1 = dateTimePicker1.Value,
                    DT2 = dateTimePicker2.Value
                };
                listR = qc.SelectResult(query);
            }
            else
            {
                FlightCityQuery query = new FlightCityQuery()
                {
                    FromCityCode = comboBox1.SelectedValue.ToString(),
                    ToCityCode = comboBox2.SelectedValue.ToString(),
                    DT1 = dateTimePicker1.Value,
                    DT2 = dateTimePicker2.Value
                };
                listR = qc.SelectResult(query);
            }
            #endregion
            dataGridView1.DataSource = listR;
        }
        #endregion

        #region 调换城市
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int i = comboBox2.SelectedIndex;
                comboBox2.SelectedIndex = comboBox1.SelectedIndex;
                comboBox1.SelectedIndex = i;
            }
        }
        #endregion

        #region 更换搜索模式
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            if (radioButton1.Checked)
            {
                //加载城市
                List<City> lc = gi.GetCity2();
                comboBox1.DataSource = new List<City>(lc);
                comboBox1.DisplayMember = "CityName";
                comboBox1.ValueMember = "CityCode";
                comboBox1.SelectedIndex = -1;
                comboBox2.DataSource = new List<City>(lc);
                comboBox2.DisplayMember = "CityName";
                comboBox2.ValueMember = "CityCode";
                comboBox2.SelectedIndex = -1;
            }
            else
            {
                List<Airport> la = gi.GetAirports();
                comboBox1.DataSource = new List<Airport>(la);
                comboBox1.DisplayMember = "AirportName";
                comboBox1.ValueMember = "IATACode";
                comboBox1.SelectedIndex = -1;
                comboBox2.DataSource = new List<Airport>(la);
                comboBox2.DisplayMember = "AirportName";
                comboBox2.ValueMember = "IATACode";
                comboBox2.SelectedIndex = -1;
            }
        }
        #endregion

        #region 添加航班按钮
        private void button3_Click(object sender, EventArgs e)
        {
            CreateScheduleForm newform = new CreateScheduleForm();
            newform.ShowDialog();
        }
        #endregion

        #region 查看航班信息
        int i = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Detial"].Index && e.RowIndex > -1)
            {
                DetailForm newform = new DetailForm(listR[e.RowIndex]);
                newform.ShowDialog();
            }
            else
            {
                i = e.RowIndex;
            }
        }
        #endregion

        #region 打开EditaFlightSchedule
        private void button4_Click(object sender, EventArgs e)
        {
            if (i >-1)
            {
                EditaFlightSchedule newform = new EditaFlightSchedule(listR[i]);
                DialogResult result= newform.ShowDialog();
                if (result == DialogResult.OK)
                    button1_Click(null, null);
            }
        }
        #endregion

        #region 打开导入文件
        private void button5_Click(object sender, EventArgs e)
        {
            ImportSchedules newform = new ImportSchedules();
            newform.ShowDialog();
        }
        #endregion

        #region 改变航班状态
        private void button7_Click(object sender, EventArgs e)
        {
            if (listR != null && i > -1)
            {
                if (qc.updateConfid(Convert.ToInt32(listR[i].Schedule)))
                    button1_Click(null, null);
            }
        }
        #endregion

        #region 导出excel文件
        private void button6_Click(object sender, EventArgs e)
        {
            if (listR != null)
            {
                DataTable schedule = ExcelHelper.ToDataTable(listR);
                schedule.TableName = "schedule";
                string filepath = @"C:\Users\Cyzen\Desktop\学习文件\Session3\Test.csv";
                string path = @"C:\Users\Cyzen\Desktop\学习文件\Session3\Test.xls";
                ExcelHelper.DTToExcel(path, schedule);
                ExcelHelper.datatableToCSV(schedule, filepath);
                MessageBox.Show("ok");
            }

        } 
        #endregion
    }
}
