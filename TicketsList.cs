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
    public partial class TicketsList : Form
    {
        List<tickinfo> listti = null;
        List<tickinfo> listtiResult = new List<tickinfo>();
        #region 信息加载
        public string[] IDTypeArr = new string[2] { "ID Card", "Passport" };
        public TicketsList()
        {
            InitializeComponent();
        }

        private void TicketsList_Load(object sender, EventArgs e)
        {
            IDTypeList.DropDownStyle = ComboBoxStyle.DropDownList;
            IDTypeList.IntegralHeight = false;
            IDTypeList.DataSource = IDTypeArr;
            dataGridView1.AutoGenerateColumns = false;
        }
        #endregion

        #region search按钮
        private void searchbtn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<tickinfo>();
            string IDType = IDTypeList.SelectedItem.ToString().Trim();
            string IDNum = IDNumBox.Text.Trim();
            FlightInquiry fi = new FlightInquiry();
            listti = fi.gettickinfo(IDType, IDNum);
            dataGridView1.DataSource = listti;

            /*for (int i = 0; i < listti.Count; i++)
            {
                this.dataGridView1.InvalidateRow(i);
            }*/
        }
        #endregion

        #region 点击事件
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Refund"].Index && e.RowIndex > -1)
            {
                RefundTickets refund = new RefundTickets(listti[e.RowIndex]);
                DialogResult result = refund.ShowDialog();
                if (result == DialogResult.OK)
                {
                    listti.Remove(listti[e.RowIndex]);
                    dataGridView1.DataSource = new List<tickinfo>();
                    dataGridView1.DataSource = listti;
                }
            }
        } 
        #endregion

    }
}
