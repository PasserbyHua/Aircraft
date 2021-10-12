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
using Models;

namespace Aircraft
{
    public partial class FoodServices : Form
    {
        #region 数据加载
        DateTime dateTime = MyDateTime.nowdate;
        public string[] IDTypeArr = new string[2] { "ID Card", "Passport" };
        private FoodHelper fdhelp = new FoodHelper();
        private List<FoodFlightInfo> listinfo = null;
        private List<FoodInfo> fi = null;
        private FoodModels fm = null;
        public FoodServices()
        {
            InitializeComponent();
        }


        private void FoodServices_Load(object sender, EventArgs e)
        {
            IDTypeList.DropDownStyle = ComboBoxStyle.DropDownList;
            IDTypeList.IntegralHeight = false;
            IDTypeList.DataSource = IDTypeArr;
            FlightInfoList.DropDownStyle = ComboBoxStyle.DropDownList;
            FlightInfoList.IntegralHeight = false;
        }
        #endregion

        #region 查询航班
        private void Search_Click(object sender, EventArgs e)
        {
            string IDType = IDTypeList.SelectedItem.ToString().Trim();
            string IDNum = IDNumBox.Text.Trim();
            listinfo = fdhelp.GetFlightinfo(IDType, IDNum);
            foreach (var item in listinfo)
            {
                if (item.DeparDateTime - dateTime < new TimeSpan(0, 6, 0)) continue;
                string str = item.FlightNumber + "," + item.DeparCode + "-" + item.DestCode + "," + item.DeparDateTime.ToShortDateString() + "," + item.DeparDateTime.ToShortTimeString() + "," + item.CanbinTypeName;
                FlightInfoList.Items.Add(str);
            }

        }
        #endregion

        #region 加载食物
        private void LoadFoodBtn_Click(object sender, EventArgs e)
        {
            foodpanel.Controls.Clear();
            int i = FlightInfoList.SelectedIndex;
            fm = fdhelp.getpayfoods(listinfo[i].Reservationid);
            fi = fdhelp.GetFoodInfo();
            int j = 0, k = 0, count = 0;
            foreach (var item in fi)
            {
                FoodServicesControl fsc = new FoodServicesControl();
                fsc.pictureBox1.BackgroundImage = imageList1.Images[item.FoodId - 1];
                fsc.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                fsc.foodname.Text = item.FoodName;
                fsc.Tag = item.FoodId;
                fsc.Parent = foodpanel;
                fsc.timing += RefreshInfo;
                fsc.BringToFront();
                fsc.Location = new Point((fsc.Width + 5) * j + 5, (fsc.Height + 5) * k + 10);
                if (j == 3)
                {
                    j = 0;
                    k++;
                }
                else j++;
                if (fm.foodcount[count] > 0)
                {
                    fsc.foodcountlist.Value = fm.foodcount[count];
                    fsc.checkBox1.Checked = true;
                }
                count++;
            }

        }
        #endregion

        #region 事件触发方法
        public void RefreshInfo(bool check, int foodid, int foodcount)
        {
            if (check)
                fm.foodcount[foodid - 1] = foodcount;
            else
                fm.foodcount[foodid - 1] = -1;

            #region 计算点单信息
            int item = 0;
            int amount = 0;
            decimal price = 0;
            for (int i = 0; i < fm.foodcount.Length; i++)
            {
                if (fm.foodcount[i] > 0)
                {
                    item++;
                    amount += fm.foodcount[i];
                    price += fi[i].Price * fm.foodcount[i];
                }
            }
            selectcount.Text = item.ToString();
            selectallnum.Text = amount.ToString();
            selectallprice.Text = "$" + price.ToString();
            #endregion
        }
        #endregion

        #region 订购按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (fdhelp.submitfood(fm, listinfo[FlightInfoList.SelectedIndex].Reservationid))
                MessageBox.Show("ok");
            else
                MessageBox.Show("error");
        }
        #endregion
    }
}
