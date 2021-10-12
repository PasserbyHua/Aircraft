using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Aircraft
{
    public partial class TransactBoardingCardSelectForm1 : UserControl
    {
        #region 加载事件
        BoardingCardinfo bc = null;
        //事件
        public delegate void returninfo(BoardingCardinfo selectbc);
        public event returninfo eventinfo;
        public TransactBoardingCardSelectForm1(BoardingCardinfo b)
        {
            InitializeComponent();
            this.bc = b;
        }

        private void TransactBoardingCardSelectForm1_Load(object sender, EventArgs e)
        {
            Nametext.Text = "Mr." + bc.Name;
            Flighttext.Text = "Flight " + bc.FlightNum;
            Airname.Text = bc.AirName;
            Canbintext.Text = bc.CanbinName;
            frominfotext.Text = bc.FromName + "/" + bc.FromCode;
            toinfotext.Text = bc.ToName + "/" + bc.ToCode;
            departimetext.Text = bc.DeparTime.ToString();
            desttimetext.Text = bc.DestTime.ToString();
        }
        #endregion

        #region 选中事件
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                eventinfo?.Invoke(bc);
            }
        } 
        #endregion
    }
}
