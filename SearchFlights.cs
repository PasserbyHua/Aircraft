using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToSQLClass;
using Models;

namespace Aircraft
{
    public partial class SearchFlights : Form
    {
        #region 窗口数据加载
        public static string[] flighttypestr = new string[3] { "all", "Non-stop", "1-stop" };
        public SearchFlights()
        {
            InitializeComponent();
        }

        private void SearchFlights_Load(object sender, EventArgs e)
        {
            #region 填充航班类型数据（FlightType）
            FlightTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            FlightTxt.Items.AddRange(flighttypestr);
            #endregion

            #region 填充城市
            //设置列表属性
            FromCityTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            FromCityTxt.IntegralHeight = false;
            FromCityTxt.MaxDropDownItems = 10;
            ToCityTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            ToCityTxt.IntegralHeight = false;
            ToCityTxt.MaxDropDownItems = 10;

            FlightInquiry fi = new FlightInquiry();
            FromCityTxt.DataSource = fi.GetCity();
            FromCityTxt.DisplayMember = "CityName";
            FromCityTxt.ValueMember = "CityCode";
            FromCityTxt.SelectedIndex = -1;
            ToCityTxt.DataSource = fi.GetCity();
            ToCityTxt.DisplayMember = "CityName";
            ToCityTxt.ValueMember = "CityCode";
            ToCityTxt.SelectedIndex = -1;
            #endregion

            #region 填充仓位
            //设置列表属性
            CabinTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            CabinTxt.DataSource = fi.GetCabins();
            CabinTxt.DisplayMember = "CabinTypeName";
            CabinTxt.ValueMember = "CabinTypeId";
            CabinTxt.SelectedIndex = -1;
            #endregion
        }
        #endregion

        #region 返程选项显示方法
        private void RoundWaysRB_CheckedChanged(object sender, EventArgs e)
        {
            if (RoundWaysRB.Checked)
            {
                SearchPanel.Location = new Point(SearchPanel.Location.X + 100, SearchPanel.Location.Y);
                ReturnDatePanel.Visible = true;
                ReturnDate.MinDate = DepartureDate.Value.AddDays(1);
            }
            else
            {
                SearchPanel.Location = new Point(SearchPanel.Location.X - 100, SearchPanel.Location.Y);
                ReturnDatePanel.Visible = false;
            }
        }
        #endregion

        #region 查询按钮
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //条件检查
            if (FormatCheck())
            {
                DeparPanel.Controls.Clear();
                ReturnPanel.Controls.Clear();
                #region 创建查询实体类
                QueryCreate qc = new QueryCreate()
                {
                    FromCityCode = this.FromCityTxt.SelectedValue.ToString(),
                    ToCityCode = this.ToCityTxt.SelectedValue.ToString(),
                    DeparTime = this.DepartureDate.Value,
                    CanbingType = Convert.ToInt32(this.CabinTxt.SelectedValue),
                    FlightType = this.FlightTxt.SelectedIndex
                };
                #endregion
                FlightInquiry fi = new FlightInquiry();
                int i = 0;
                #region 直达查询
                if (FlightTxt.SelectedIndex != 2)
                {
                    List<QueryResult> qr = fi.Qresult(qc);
                    foreach (var item in qr)
                    {
                        ShowPlaneTick(new QueryResultForm(item), i);
                        i++;
                    }
                }
                #endregion
                #region 中转查询
                if (qc.FlightType == 0 || qc.FlightType == 2)
                {
                    List<TransferResult> ltr = fi.TranResult(qc);
                    if (ltr != null)
                    {
                        foreach (var item in ltr)
                        {
                            ShowTranTick(new QueryResultForm2(item), i);
                            i++;
                        }
                    }
                }
                #endregion
                #region 返程查询
                if (RoundWaysRB.Checked)
                {
                    int k = 0;
                    #region 创建查询实体类
                    QueryCreate qc2 = new QueryCreate()
                    {
                        FromCityCode = this.ToCityTxt.SelectedValue.ToString(),
                        ToCityCode = this.FromCityTxt.SelectedValue.ToString(),
                        DeparTime = this.ReturnDate.Value,
                        CanbingType = Convert.ToInt32(this.CabinTxt.SelectedValue),
                        FlightType = this.FlightTxt.SelectedIndex
                    };
                    #endregion
                    #region 直达查询
                    if (FlightTxt.SelectedIndex != 2)
                    {
                        List<QueryResult> qr2 = fi.Qresult(qc2);
                        foreach (var item in qr2)
                        {
                            ReturnTick(new QueryResultForm(item), k);
                            k++;
                        }
                    }
                    #endregion
                    #region 中转查询
                    if (qc2.FlightType == 0 || qc2.FlightType == 2)
                    {
                        List<TransferResult> ltr = fi.TranResult(qc2);
                        if (ltr == null)
                            return;
                        else
                        {
                            foreach (var item in ltr)
                            {
                                ReturnTranTick(new QueryResultForm2(item), k);
                                k++;
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }
        }
        #endregion

        #region 搜索条件检查方法
        private bool FormatCheck()
        {
            bool result = false;
            if (FromCityTxt.SelectedIndex == -1)
                MessageBox.Show("请选择出发城市", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (ToCityTxt.SelectedIndex == -1)
                MessageBox.Show("请选择目的城市", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (CabinTxt.SelectedIndex == -1)
                MessageBox.Show("请选择仓位类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (FlightTxt.SelectedIndex == -1)
                MessageBox.Show("请选择航班类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (FromCityTxt.SelectedIndex == ToCityTxt.SelectedIndex)
                MessageBox.Show("出发地和目的地不能相同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                result = true;
            return result;
        }
        #endregion

        #region 显示机票
        private void ShowPlaneTick(QueryResultForm newform, int k)
        {
            newform.index = k;
            newform.Parent = this.DeparPanel;
            newform.Location = new Point(0, (newform.Size.Height * k));
            newform.BringToFront();
            newform.Show();
        }

        private void ShowTranTick(QueryResultForm2 newform, int k)
        {
            newform.index = k;
            newform.Parent = this.DeparPanel;
            newform.Location = new Point(0, (newform.Size.Height * k));
            newform.BringToFront();
            newform.Show();
        }

        private void ReturnTick(QueryResultForm newform, int k)
        {
            newform.index = k;
            newform.Parent = this.ReturnPanel;
            newform.Location = new Point(0, (newform.Size.Height * k));
            newform.BringToFront();
            newform.Show();
        }

        private void ReturnTranTick(QueryResultForm2 newform, int k)
        {
            newform.index = k;
            newform.Parent = this.ReturnPanel;
            newform.Location = new Point(0, (newform.Size.Height * k));
            newform.BringToFront();
            newform.Show();
        }
        #endregion

        #region 订购按钮
        private void button1_Click(object sender, EventArgs e)
        {
            BookFlights bf = new BookFlights();

            #region 出发机票信息
            foreach (Control item in DeparPanel.Controls)
            {
                if (item is QueryResultForm)
                {
                    QueryResultForm qrf = (QueryResultForm)item;
                    if (qrf.radioButton1.Checked)
                    {
                        bf.DeparQR = qrf.qr;
                        break;
                    }
                }
                else if (item is QueryResultForm2)
                {
                    QueryResultForm2 qrf = (QueryResultForm2)item;
                    if (qrf.radioButton1.Checked)
                    {
                        bf.TDeparQR = qrf.qr;
                        break;
                    }
                }
            }
            #endregion

            #region 返回机票信息
            foreach (Control item in ReturnPanel.Controls)
            {
                if (item is QueryResultForm)
                {
                    QueryResultForm qrf = (QueryResultForm)item;
                    if (qrf.radioButton1.Checked)
                    {
                        bf.ReturnQR = qrf.qr;
                        break;
                    }
                }
                else if (item is QueryResultForm2)
                {
                    QueryResultForm2 qrf = (QueryResultForm2)item;
                    if (qrf.radioButton1.Checked)
                    {
                        bf.TReturnQR = qrf.qr;
                        break;
                    }
                }
            }
            #endregion

            bf.Show();
        }
        #endregion
    }
}
