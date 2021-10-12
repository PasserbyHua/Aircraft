using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aircraft
{
    public partial class FoodServicesControl : UserControl
    {
        #region 加载事件
        public delegate void huazilong(bool check, int foodid, int foodcount);
        public event huazilong timing;
        public FoodServicesControl()
        {
            InitializeComponent();
        }

        private void foodcountlist_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                timing?.Invoke(checkBox1.Checked, Convert.ToInt32(this.Tag), Convert.ToInt32(foodcountlist.Value));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timing?.Invoke(checkBox1.Checked, Convert.ToInt32(this.Tag), Convert.ToInt32(foodcountlist.Value));
        } 
        #endregion
    }
}
