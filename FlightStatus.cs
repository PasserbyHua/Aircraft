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
using LinqToSQLClass;


namespace Aircraft
{
    public partial class FlightStatus : Form
    {
        List<FlightToDayInfo> listft = null;
        List<List<FlightToDayInfo>> llft = new List<List<FlightToDayInfo>>();
        int page = 1;
        int Maxpage = 1;
        public FlightStatus()
        {
            InitializeComponent();
        }

        #region 查询
        private void button1_Click(object sender, EventArgs e)
        {
            llft.Clear();
            dataGridView1.AutoGenerateColumns = false;
            DateTime nowdt = dateTimePicker1.Value;
            FlightInquiry fi = new FlightInquiry();
            List<FlightToDayInfo> newpage = new List<FlightToDayInfo>();
            listft = fi.GetTodayInfo(nowdt);
            page = 1;
            foreach (var item in listft)
            {
                newpage.Add(item);
                if (newpage.Count == 10)
                {
                    llft.Add(newpage);
                    newpage = new List<FlightToDayInfo>();
                    Maxpage++;
                }
            }
            if (newpage.Count > 0)
            {
                llft.Add(newpage);
            }
            else if (llft.Count == 0)
            {
                MessageBox.Show("Not Find!");
                return;
            }
            label3.Text = page.ToString() + "/" + Maxpage.ToString();
            List<FlightToDayInfo> nowlistft = llft[(page - 1)];
            dataGridView1.DataSource = nowlistft;
        } 
        #endregion

        #region 序列
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        #endregion

        #region 翻页按钮

        private void button2_Click(object sender, EventArgs e)
        {
            if (page <= 1) return;
            else
            {
                page--;
                label3.Text = page.ToString() + "/" + Maxpage.ToString();
                dataGridView1.DataSource = llft[page - 1];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (page >= Maxpage) return;
            else
            {
                page++;
                label3.Text = page.ToString() + "/" + Maxpage.ToString();
                dataGridView1.DataSource = llft[page - 1];
            }
        } 
        #endregion
    }
}
