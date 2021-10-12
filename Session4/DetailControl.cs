using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToSQLClass;

namespace Aircraft.Session4
{
    public partial class DetailControl : UserControl
    {
        #region 加载内容
        List<SurveyInfo> lists = new List<SurveyInfo>();
        string QName = "";
        public DetailControl(List<SurveyInfo> list, string QueName)
        {
            InitializeComponent();
            this.lists = list;
            this.QName = QueName;
        }

        private void DetailControl_Load(object sender, EventArgs e)
        {
            ImageList newimage = new ImageList();
            newimage.ImageSize = new Size(1, 22);

            listView1.SmallImageList = newimage;
            dataGridView1.AutoGenerateColumns = false;
            label1.Text = QName;
            dataGridView1.DataSource = lists;
            DataTable dt = new DataTable();
            for (int i = 0; i < lists.First().ArrName.Length; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = lists.First().ArrName[i].Trim();
                dt.Columns.Add(dc);
            }
            int sum = 0;
            int X = 0;
            foreach (var si in lists)
            {
                sum += si.AllCount;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < si.ArrCount.Length; i++)
                {
                    dr[i] = si.ArrCount[i];
                }
                dt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt;

            #region 显示百分比
            Color[] colors = new Color[7] { Color.Silver, Color.Orange, Color.Purple, Color.Pink, Color.PaleGreen, Color.LawnGreen, Color.ForestGreen };
            for (int i = 0; i < 7; i++)
            {
                X += ShowPanel(6 - i, sum, X, colors[i]);
            }
            #endregion

            for (int i = 0; i < 7; i++)
            {
                listView1.Items.Add(lists[i].AllCount.ToString());
            }

            #region 显示目的地
            /*Panel newpanel1 = new Panel();
            newpanel1.BackColor = Color.Silver;
            newpanel1.Size = new Size((int)((float)(lists[6].AllCount) / (float)(sum) * 741f), 29);
            newpanel1.Location = new Point(0, 0);
            newpanel1.Parent = panel1;
            newpanel1.Show();
            Panel newpanel2 = new Panel();
            newpanel2.BackColor = Color.Orange;
            newpanel2.Size = new Size((int)((float)(lists[5].AllCount) / (float)(sum) * 741f), 29);
            newpanel2.Location = new Point(newpanel1.Size.Width + newpanel1.Location.X, 0);
            newpanel2.Parent = panel1;
            newpanel2.Show();
            Panel newpanel3 = new Panel();
            newpanel3.BackColor = Color.Purple;
            newpanel3.Size = new Size((int)((float)(lists[4].AllCount) / (float)(sum) * 741f), 29);
            newpanel3.Location = new Point(newpanel2.Size.Width + newpanel2.Location.X, 0);
            newpanel3.Parent = panel1;
            newpanel3.Show();
            Panel newpanel4 = new Panel();
            newpanel4.BackColor = Color.Pink;
            newpanel4.Size = new Size((int)((float)(lists[3].AllCount) / (float)(sum) * 741f), 29);
            newpanel4.Location = new Point(newpanel3.Size.Width + newpanel3.Location.X, 0);
            newpanel4.Parent = panel1;
            newpanel4.Show();
            Panel newpanel5 = new Panel();
            newpanel5.BackColor = Color.PaleGreen;
            newpanel5.Size = new Size((int)((float)(lists[2].AllCount) / (float)(sum) * 741f), 29);
            newpanel5.Location = new Point(newpanel4.Size.Width + newpanel4.Location.X, 0);
            newpanel5.Parent = panel1;
            newpanel5.Show();
            Panel newpanel6 = new Panel();
            newpanel6.BackColor = Color.LawnGreen;
            newpanel6.Size = new Size((int)((float)(lists[1].AllCount) / (float)(sum) * 741f), 29);
            newpanel6.Location = new Point(newpanel5.Size.Width + newpanel5.Location.X, 0);
            newpanel6.Parent = panel1;
            newpanel6.Show();
            Panel newpanel7 = new Panel();
            newpanel7.BackColor = Color.ForestGreen;
            newpanel7.Size = new Size((int)((float)(lists[0].AllCount) / (float)(sum) * 741f), 29);
            newpanel7.Location = new Point(newpanel6.Size.Width + newpanel6.Location.X, 0);
            newpanel7.Parent = panel1;
            newpanel7.Show();*/
            #endregion
        }
        #endregion

        #region 显示百分比
        public int ShowPanel(int i, int sum, int x, Color color)
        {
            int SizeX = (int)((float)(lists[i].AllCount) / (float)(sum) * 741f);
            Panel newpanel1 = new Panel();
            newpanel1.BackColor = color;
            newpanel1.Size = new Size(SizeX, 29);
            newpanel1.Location = new Point(x, 0);
            newpanel1.Parent = panel1;
            newpanel1.Show();
            return SizeX;
        }
        #endregion

        #region 修改背景色
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if ((i % 2) == 1)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PowderBlue;
                }
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                if ((i % 2) == 1)
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.PowderBlue;
                }
            }
        }
        #endregion

        #region 去除Gender或Age
        public void ReInfo(int i)
        {
            if (i == 0)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
            }
            else if (i == 1)
            {
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }
        #endregion

        #region 显示Gender或Age
        public void ShowInfo(int i)
        {
            if (i == 0)
            {
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
            }
            else if (i == 1)
            {
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
            }
        }
        #endregion

        #region 选择显示Gender
        public void GenderShowSelect(int i)
        {
            if (i == 0)
            {
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
            }
            else if (i == 1)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = true;
            }
            else if (i == 2)
            {
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = false;
            }
        }
        #endregion

        #region 选择显示Age
        public void AgeShowSelect(int i)
        {
            if (i == 0)
            {
                ShowInfo(1);
            }
            else if (i == 1)
            {
                ReInfo(1);
                dataGridView1.Columns[2].Visible = true;
            }
            else if (i == 2)
            {
                ReInfo(1);
                dataGridView1.Columns[3].Visible = true;
            }
            else if (i == 3)
            {
                ReInfo(1);
                dataGridView1.Columns[4].Visible = true;
            }
            else if (i == 4)
            {
                ReInfo(1);
                dataGridView1.Columns[5].Visible = true;
            }
        }
        #endregion

        #region 重新计算
        public void reSum()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++, sum = 0)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Columns[j].Visible)
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                }
                for (int k = 0; k < dataGridView2.Columns.Count; k++)
                {
                    if (dataGridView2.Columns[k].Visible)
                        sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[k].Value);
                }
                listView1.Items[i].Text = sum.ToString();
            }
            recolor();
        }
        #endregion

        #region 重新计算颜色
        private void recolor()
        {
            panel1.Controls.Clear();
            #region 显示百分比
            int sum = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sum += Convert.ToInt32(listView1.Items[i].Text);
            }
            int X = 0;
            Color[] colors = new Color[7] { Color.Silver, Color.Orange, Color.Purple, Color.Pink, Color.PaleGreen, Color.LawnGreen, Color.ForestGreen };
            for (int i = 0; i < 7; i++)
            {
                X += ShowPanel2(6 - i, sum, X, colors[i]);
            }
            #endregion
        }
        #endregion

        #region 显示百分比
        public int ShowPanel2(int i, int sum, int x, Color color)
        {
            int SizeX = (int)((float)(Convert.ToInt32(listView1.Items[i].Text)) / (float)(sum) * 741f);
            Panel newpanel1 = new Panel();
            newpanel1.BackColor = color;
            newpanel1.Size = new Size(SizeX, 29);
            newpanel1.Location = new Point(x, 0);
            newpanel1.Parent = panel1;
            newpanel1.Show();
            return SizeX;
        }
        #endregion
    }
}
