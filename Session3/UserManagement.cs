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
using LinqToSQLClass;

namespace Aircraft.Session3
{
    public partial class UserManagement : Form
    {
        #region 加载数据
        QueryCreate2 qc2 = new QueryCreate2();
        List<UserInfo> listUser = null;
        List<List<UserInfo>> llistU = null;
        int page = 0;
        int select = -1;
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            List<string> userlist = qc2.GetRoleInfo();
            comboBox1.Items.Add("All");
            foreach (var item in userlist)
            {
                comboBox1.Items.Add(item);
            }
        }
        #endregion

        #region 查询用户按钮
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dataGridView1.DataSource = new UserInfo();
            int userid = comboBox1.SelectedIndex;
            string username = textBox1.Text;
            listUser = qc2.GetUserInfos(userid, username);
            if(listUser.Count==0)
            {
                MessageBox.Show("No Find User");
                return;
            }
            List<UserInfo> newPage = new List<UserInfo>();
            llistU = new List<List<UserInfo>>();
            foreach (var item in listUser)
            {
                newPage.Add(item);
                if (newPage.Count == 10)
                {
                    llistU.Add(newPage);
                    newPage = new List<UserInfo>();
                }
            }
            if (newPage.Count > 0)
            {
                llistU.Add(newPage);
            }
            dataGridView1.DataSource = llistU[page];
            for (int i = 0; i < llistU.Count; i++)
            {
                comboBox2.Items.Add(i + 1);
            }
            comboBox2.SelectedIndex = page;
            label4.Text = "Total Pages:" + llistU.Count.ToString();
            label5.Text = "Total Records:" + listUser.Count.ToString();
        }
        #endregion

        #region 翻页功能
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new UserInfo();
            page = comboBox2.SelectedIndex;
            dataGridView1.DataSource = llistU[page];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                dataGridView1.DataSource = new UserInfo();
                comboBox2.SelectedIndex = page;
                dataGridView1.DataSource = llistU[page];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (page < llistU.Count-1)
            {
                page++;
                dataGridView1.DataSource = new UserInfo();
                comboBox2.SelectedIndex = page;
                dataGridView1.DataSource = llistU[page];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            page = 0;
            dataGridView1.DataSource = new UserInfo();
            comboBox2.SelectedIndex = page;
            dataGridView1.DataSource = llistU[page];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            page = llistU.Count-1;
            dataGridView1.DataSource = new UserInfo();
            comboBox2.SelectedIndex = page;
            dataGridView1.DataSource = llistU[page];
        }
        #endregion

        #region 打开添加用户信息
        private void button2_Click(object sender, EventArgs e)
        {
            AddEditUser newform = new AddEditUser(false,null);
            newform.ShowDialog();
        }
        #endregion

        #region 打开修改用户信息
        private void button7_Click(object sender, EventArgs e)
        {
            if (listUser.Count != 0)
            {
                if (select > -1)
                {
                    AddEditUser newform = new AddEditUser(true, llistU[page][select]);
                    newform.ShowDialog();
                }
            }
        } 
        #endregion

        #region 点击表格事件
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            select = e.RowIndex;
        } 
        #endregion
    }
}
