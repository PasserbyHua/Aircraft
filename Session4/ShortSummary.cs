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
    public partial class ShortSummary : Form
    {
        SurveyHelper sh = new SurveyHelper();
        List<OneRateinfo> listone = null;
        public ShortSummary()
        {
            InitializeComponent();
        }

        #region 查询
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startdt = dateTimePicker1.Value;
            DateTime enddt = dateTimePicker2.Value;
            //准点率前三
            listone = sh.GetlistRate(startdt, enddt);
            label8.Text = "1.(" + listone[0].DeparCode1.Trim() + "-" + listone[0].DestCode1.Trim() + ")" + listone[0].Rate1.ToString("P0");
            label9.Text = "2.(" + listone[1].DeparCode1.Trim() + "-" + listone[1].DestCode1.Trim() + ")" + listone[1].Rate1.ToString("P0");
            label10.Text = "3.(" + listone[2].DeparCode1.Trim() + "-" + listone[2].DestCode1.Trim() + ")" + listone[2].Rate1.ToString("P0");
            //空座率
            OneSeatInfo os = sh.GetListSeats(startdt, enddt);
            label13.Text = "Economy Class:(" + os.Economylv.ToString("P0") + ")";
            label12.Text = "Business Class:(" + os.Businesslv.ToString("P0") + ")";
            label11.Text = "First Class:(" + os.Firstlv.ToString("P0") + ")";
            //最多和最少的一天
            label14.Visible = true;
            label15.Visible = true;
            List<string[]> ls = sh.GetDayinfo(startdt, enddt);
            label17.Text = "[" + ls[0][0] + "] With [" + ls[0][1] + "] flying";
            label16.Text = "[" + ls[1][0] + "] With [" + ls[1][1] + "] flying";
            //最受欢迎城市
            string[] cityname = sh.GetLikeCity(startdt, enddt);
            label20.Text = "1." + cityname[0];
            label19.Text = "2." + cityname[1];
            label18.Text = "3." + cityname[2];
            //最有钱的
            List<string[]> ls2 = sh.GetSalesVolume(startdt, enddt);
            label23.Text = "1." + ls2[0][0] + "-" + ls2[0][1] + ",$" + ls2[0][2].ToString();
            label22.Text = "2." + ls2[1][0] + "-" + ls2[1][1] + ",$" + ls2[1][2].ToString();
            label21.Text = "3." + ls2[2][0] + "-" + ls2[2][1] + ",$" + ls2[2][2].ToString();

        } 
        #endregion

    }
}
