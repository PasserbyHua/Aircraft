using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Aircraft.Session3
{
    public partial class TicketStatistics : Form
    {
        #region 加载数据
        QueryCreate2 qc2 = new QueryCreate2();
        List<StatisticsView> listSV = new List<StatisticsView>();
        string[] str = new string[3] { "FlightsAmount", "TicketsAmount", "TicketsRevenue" };
        public TicketStatistics()
        {
            InitializeComponent();
        }

        private void TicketStatistics_Load(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            comboBox1.Items.AddRange(str);
            int k = 5;
            int year = 2018;
            int month = 3;
            for (int i = 0; i < k; i++, month++)
            {
                domainUpDown1.Items.Add((year.ToString() + "-" + month.ToString()));
                domainUpDown2.Items.Add((year.ToString() + "-" + month.ToString()));
            }
            domainUpDown1.SelectedIndex = 0;
            domainUpDown2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }
        #endregion

        #region 查询数据
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime star = Convert.ToDateTime(domainUpDown1.SelectedItem.ToString());
            DateTime end = Convert.ToDateTime(domainUpDown2.SelectedItem.ToString());
            listSV = qc2.listSV(star, end);
            dataGridView1.DataSource = listSV;
            chart1.DataSource = listSV;
            chart1.Series[0].XValueMember = "Mouthdate";
            chart1.Series[0].YValueMembers = comboBox1.SelectedItem.ToString();
            chart1.Series[0].Name = comboBox1.SelectedItem.ToString();
            chart1.DataBind();
        }
        #endregion

        #region 显示数值
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart1.Series[0].IsValueShownAsLabel = true;
            }
            else
            {
                chart1.Series[0].IsValueShownAsLabel = false;
            }
        }
        #endregion

        #region 改变显示的值
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].YValueMembers = comboBox1.SelectedItem.ToString();
            chart1.Series[0].Name = comboBox1.SelectedItem.ToString();
            chart1.DataBind();
        }
        #endregion
    }
}
