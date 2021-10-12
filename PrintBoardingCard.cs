using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aircraft
{
    public partial class PrintBoardingCard : Form
    {
        PrintTickInfo info = new PrintTickInfo();
        public PrintBoardingCard(PrintTickInfo pt)
        {
            InitializeComponent();
            this.info = pt;
        }

        #region 打印
        private void PrintBoardingCard_Load(object sender, EventArgs e)
        {
            label4.Text = info.FlightNumber.Trim();
            label12.Text = info.Name;
            label14.Text = info.DeparDateTime.ToShortDateString();
            label21.Text = info.CanbinTypeName;
            label10.Text = info.FromCityNameAndCode;
            label15.Text = info.ToCityNameAndCode;
            label9.Text = info.DeparDateTime.ToShortTimeString();
            label18.Text = info.Gate;
            label22.Text = info.SeatName;
            label40.Text = info.DeparDateTime.AddMinutes(-40).ToShortTimeString();
            label25.Text= info.Name;
            label35.Text= info.DeparDateTime.ToShortDateString();
            label37.Text= info.CanbinTypeName;
            label27.Text= info.FromCityNameAndCode;
            label34.Text= info.ToCityNameAndCode;
            label28.Text=info.DeparDateTime.ToShortTimeString();
            label31.Text= info.Gate;
            label36.Text= info.SeatName;
            label7.Text = info.FlightNumber.Trim();
        } 
        #endregion
    }
}
