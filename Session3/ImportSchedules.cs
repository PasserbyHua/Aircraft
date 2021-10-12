using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Aircraft.Session3
{
    public partial class ImportSchedules : Form
    {
        QueryCreate2 qc2 = new QueryCreate2();
        ExcelHelper eh = new ExcelHelper();
        OpenFileDialog ofdWenJian = new OpenFileDialog();
        public ImportSchedules()
        {
            InitializeComponent();
        }

        private void ImportSchedules_Load(object sender, EventArgs e)
        {

        }

        #region 打开文件
        private void button3_Click(object sender, EventArgs e)
        {
            ofdWenJian.Filter = "All(.xls;.xlsx;.csv)|*.xls;*.xlsx;*.csv| .xls|*.xls|.xlsx|*.xlsx|.csv|*.csv";
            if (ofdWenJian.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofdWenJian.FileName;
            }
        } 
        #endregion

        #region 填充数据
        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdWenJian.FileName != "")
            {
                int importcount = 0;
                int count = 0;
                DataSet ds = ExcelHelper.ReadFile(System.IO.Path.GetDirectoryName(ofdWenJian.FileName), System.IO.Path.GetFileName(ofdWenJian.FileName));
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    DataTable dt = ds.Tables[i];
                    count += dt.Rows.Count;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DateTime Date = Convert.ToDateTime(dt.Rows[j]["Date"].ToString().Trim());
                        DateTime time = Convert.ToDateTime(dt.Rows[j]["Time"].ToString().Trim());
                        string a = String.Concat(Date.Date.ToString("yyyy/MM/dd").Trim(), " ", time.TimeOfDay.ToString().Trim());
                        int length1 = dt.Rows[j]["From"].ToString().Length;
                        int length2 = dt.Rows[j]["To"].ToString().Length;
                        ScheduleInfo si = new ScheduleInfo()
                        {
                            DeparDatetime = Convert.ToDateTime(a),
                            FromCode = dt.Rows[j]["From"].ToString().Substring(length1 - 3, 3),
                            ToCode = dt.Rows[j]["To"].ToString().Substring(length2 - 3, 3),
                            Aircraft = dt.Rows[j]["Aircraft"].ToString(),
                            EconomyPrice = Convert.ToDecimal(dt.Rows[j]["EconomyPrice"]),
                            FlightNumber = Convert.ToInt32(dt.Rows[j]["FlightNumber"]),
                            Gate = dt.Rows[j]["Gate"].ToString(),
                            Status = dt.Rows[j]["Status"].ToString(),
                        };
                        if (qc2.intsetschedele(si))
                        {
                            importcount++;
                        }
                        else
                        {
                            MessageBox.Show("Import Error!");
                            label5.Text = "[" + importcount.ToString() + "]";
                            label6.Text = "[" + (count - importcount).ToString() + "]";
                            return;
                        }
                    }
                }
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("FilePathIsNull!");
            } 
            #endregion
        }
    }
}
