using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aircraft.Session4
{
    public partial class SummaryReport : Form
    {
        #region 数据加载
        SurveyHelper sh = new SurveyHelper();
        public SummaryReport()
        {
            InitializeComponent();
        }

        private void SummaryReport_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            SurveyInfo si = sh.getSurveyInfo();
            label3.Text = "Sample,Size:" + si.InfoCount.ToString() + " Adults";
            DataTable dt = new DataTable();
            for (int i = 0; i < si.ArrName.Length; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = si.ArrName[i].Trim();
                dt.Columns.Add(dc);
            }
            DataRow dr = dt.NewRow();
            for (int i = 0; i < si.ArrCount.Length; i++)
            {
                dr[i] = si.ArrCount[i];
            }
            dt.Rows.Add(dr);
            List<SurveyInfo> ls = new List<SurveyInfo>();
            ls.Add(si);
            dataGridView1.DataSource = ls;
            dataGridView2.DataSource = dt;/*
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = 38;
            }*/
        } 
        #endregion
    }
}
