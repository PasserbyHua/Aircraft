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
    public partial class DetailReport : Form
    {
        #region 加载数据
        SurveyHelper sh = new SurveyHelper();
        DateTime nowdt = new DateTime(2020, 3, 1);
        List<DateTime> listd;
        string[] Genderinfo = new string[3] { "All Genders", "Female", "Male" };
        string[] Ageinfo = new string[5] { "All Ages", "18-24", "25-39", "40-59", "60+" };
        bool Endload = false;


        public DetailReport()
        {
            InitializeComponent();
        }

        private void DetailReport_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            comboBox2.DataSource = Genderinfo;
            comboBox3.DataSource = Ageinfo;
            listd = sh.GetDate(2020);
            comboBox1.DataSource = listd;
            comboBox1.SelectedIndex = 0;
            SurveyInfo si = sh.getSurveyInfo();
            DataTable dt = new DataTable();
            for (int i = 0; i < si.ArrName.Length; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = si.ArrName[i].Trim();
                dt.Columns.Add(dc);
                dataGridView2.DataSource = dt;
            }
            for (int i = 0; i < 4; i++)
            {
                DetailControl newform = new DetailControl(sh.getDetailInfo(i + 1, nowdt), sh.getQueName(i + 1));
                newform.Parent = panel1;
                newform.Location = new Point(0, newform.Size.Height * i);
                newform.Show();
            }
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            Endload = true;
        }
        #endregion

        #region 切换月份
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nowdt = listd[comboBox1.SelectedIndex];
            panel1.Controls.Clear();
            for (int i = 0; i < 4; i++)
            {
                DetailControl newform = new DetailControl(sh.getDetailInfo(i + 1, nowdt), sh.getQueName(i + 1));
                newform.Parent = panel1;
                newform.Location = new Point(0, newform.Size.Height * i);
                newform.Show();
            }
        }
        #endregion

        #region 显示隐藏Gender
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Endload) return;
            if (checkBox1.Checked)
            {
                dataGridView1.Columns[0].Visible = true;
                dataGridView4.Columns[0].Visible = true;
                dataGridView4.Columns[1].Visible = true;
                comboBox2.SelectedIndex = 0;
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.ShowInfo(0);
                        dc.reSum();
                    }
                }
            }
            else
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Columns[1].Visible = false;
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.ReInfo(0);
                        dc.reSum();
                    }
                }
            }
        }

        #endregion

        #region 显示隐藏Age
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Endload) return;
            if (checkBox2.Checked)
            {
                dataGridView1.Columns[1].Visible = true;
                dataGridView4.Columns[2].Visible = true;
                dataGridView4.Columns[3].Visible = true;
                dataGridView4.Columns[4].Visible = true;
                dataGridView4.Columns[5].Visible = true;
                comboBox3.SelectedIndex = 0;
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.ShowInfo(1);
                        dc.reSum();
                    }
                }
            }
            else
            {
                dataGridView1.Columns[1].Visible = false;
                dataGridView4.Columns[2].Visible = false;
                dataGridView4.Columns[3].Visible = false;
                dataGridView4.Columns[4].Visible = false;
                dataGridView4.Columns[5].Visible = false;
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.ReInfo(1);
                        dc.reSum();
                    }
                }
            }
        }
        #endregion

        #region 选择显示Gender内容
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Endload) return;
            if (checkBox1.Checked)
            {
                int k = comboBox2.SelectedIndex;
                if (k == 0)
                {
                    dataGridView1.Columns[0].FillWeight = 20;
                    dataGridView4.Columns[0].Visible = true;
                    dataGridView4.Columns[1].Visible = true;
                }
                else
                {
                    if (dataGridView1.Columns[0].FillWeight == 20)
                        dataGridView1.Columns[0].FillWeight -= 10;
                    if (k == 1)
                    {
                        dataGridView4.Columns[0].Visible = false;
                        dataGridView4.Columns[1].Visible = true;
                    }
                    else if (k == 2)
                    {
                        dataGridView4.Columns[0].Visible = true;
                        dataGridView4.Columns[1].Visible = false;
                    }
                }
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.GenderShowSelect(k);
                        dc.reSum();
                    }
                }
            }
        }
        #endregion

        #region 选择显示Age
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Endload) return;
            if (checkBox2.Checked)
            {
                int k = comboBox3.SelectedIndex;
                if (k == 0)
                {
                    dataGridView1.Columns[1].FillWeight = 40;
                    dataGridView4.Columns[2].Visible = true;
                    dataGridView4.Columns[3].Visible = true;
                    dataGridView4.Columns[4].Visible = true;
                    dataGridView4.Columns[5].Visible = true;
                }
                else
                {
                    if (dataGridView1.Columns[1].FillWeight == 40)
                        dataGridView1.Columns[1].FillWeight -= 30;
                    if (k == 1)
                    {
                        dataGridView4.Columns[2].Visible = true;
                        dataGridView4.Columns[3].Visible = false;
                        dataGridView4.Columns[4].Visible = false;
                        dataGridView4.Columns[5].Visible = false;
                    }
                    else if (k == 2)
                    {
                        dataGridView4.Columns[2].Visible = false;
                        dataGridView4.Columns[3].Visible = true;
                        dataGridView4.Columns[4].Visible = false;
                        dataGridView4.Columns[5].Visible = false;
                    }
                    else if (k == 3)
                    {
                        dataGridView4.Columns[2].Visible = false;
                        dataGridView4.Columns[3].Visible = false;
                        dataGridView4.Columns[4].Visible = true;
                        dataGridView4.Columns[5].Visible = false;
                    }
                    else if (k == 4)
                    {
                        dataGridView4.Columns[2].Visible = false;
                        dataGridView4.Columns[3].Visible = false;
                        dataGridView4.Columns[4].Visible = false;
                        dataGridView4.Columns[5].Visible = true;
                    }
                }
                foreach (Control item in panel1.Controls)
                {
                    if (item is UserControl)
                    {
                        DetailControl dc = (DetailControl)item;
                        dc.AgeShowSelect(k);
                        dc.reSum();
                    }
                }
            }
        } 
        #endregion
    }
}
