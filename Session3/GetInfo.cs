using LinqToSQLClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircraft.Session3
{
    public  class GetInfo
    {
        #region 常用类

        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        #endregion

        #region 读取城市表
        public List<City> GetCity2()
        {
            var query = from q in db.City
                        orderby q.CityName ascending
                        select q;
            return query.ToList();
        }
        #endregion

        #region 读取机场表
        public List<Airport> GetAirports()
        {
            var query = from q in db.Airport
                        orderby q.IATACode ascending
                        select q;
            return query.ToList();
        } 
        #endregion

    }
}
