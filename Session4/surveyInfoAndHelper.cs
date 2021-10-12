using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSQLClass;

namespace Aircraft.Session4
{
    public class SurveyHelper
    {
        #region MyRegion
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        #endregion

        #region 获取日期
        public List<DateTime> GetDate(int year)
        {
            List<DateTime> listd = new List<DateTime>();
            var query = from q in db.surveyInfo
                        where q.surveyDate.Value.Year >= year && q.surveyDate.Value.Year < year + 1
                        group q by q.surveyDate.Value.Month into g
                        orderby g.Key ascending
                        select new
                        {
                            month = g.Key
                        };
            foreach (var item in query)
            {
                DateTime dateTime = new DateTime(year, item.month, 1);
                listd.Add(dateTime);
            }
            return listd;
        }
        #endregion

        #region 获取调查问题
        public string getQueName(int QueID)
        {
            string QueName = db.question.First(q => q.questionId == QueID).questionName.Trim();
            return QueName;
        }
        #endregion

        #region 获取总结报表信息
        public SurveyInfo getSurveyInfo()
        {
            var CaBin = from q in db.surveyInfo
                        group q by q.CabinType into g
                        select new
                        {
                            CabinName = g.Key,
                            CabinCount = g.Count()
                        };
            var IATAType = from q in db.surveyInfo
                           where q.Arrival.Trim().Length == 3
                           group q by q.Arrival into g
                           select new
                           {
                               ArrName = g.Key,
                               ArrCount = g.Count()
                           };
            SurveyInfo si = new SurveyInfo();
            si.InfoCount = db.surveyInfo.Count();
            si.FemaleCount = db.surveyInfo.Count(q => q.Gender == "F");
            si.MaleCount = db.surveyInfo.Count(q => q.Gender == "M");
            si.Age18 = db.surveyInfo.Count(q => q.Age >= 18 && q.Age <= 24);
            si.Age25 = db.surveyInfo.Count(q => q.Age >= 25 && q.Age <= 39);
            si.Age40 = db.surveyInfo.Count(q => q.Age >= 40 && q.Age <= 59);
            si.Age60 = db.surveyInfo.Count(q => q.Age >= 60);
            si.Economy1 = CaBin.First(q => q.CabinName == "Economy").CabinCount;
            si.Business1 = CaBin.First(q => q.CabinName == "Business").CabinCount;
            si.First1 = CaBin.First(q => q.CabinName == "First").CabinCount;
            si.ArrName = new string[IATAType.Count()];
            si.ArrCount = new int[IATAType.Count()];
            int i = 0;
            foreach (var item in IATAType)
            {
                si.ArrName[i] = item.ArrName;
                si.ArrCount[i] = item.ArrCount;
                i++;
            }
            return si;
        }
        #endregion

        #region 获取详细信息
        public List<SurveyInfo> getDetailInfo(int QueID, DateTime dt)
        {
            List<SurveyInfo> lists = new List<SurveyInfo>();
            var query = from q in db.answer
                        join p in db.surveyInfo on q.surveyID equals p.surveyID
                        where q.questionId == QueID && p.surveyDate >= dt.Date && p.surveyDate < dt.Date.AddMonths(1)
                        orderby q.questionId ascending
                        group p by q.QuestionAnswer into g
                        select new
                        {
                            QueID = g.Key,
                            QueCount = g.Count(),
                            MaleCount = g.Count(a => a.Gender == "M"),
                            FemaleCount = g.Count(a => a.Gender == "F"),
                            Age18Count = g.Count(q => q.Age >= 18 && q.Age <= 24),
                            Age25Count = g.Count(q => q.Age >= 25 && q.Age <= 39),
                            Age40Count = g.Count(q => q.Age >= 40 && q.Age <= 59),
                            Age60Count = g.Count(q => q.Age >= 60),
                            Economy = g.Count(q => q.CabinType == "Economy"),
                            Business = g.Count(q => q.CabinType == "Business"),
                            First = g.Count(q => q.CabinType == "First"),
                            g
                        };
            var query2 = from q in db.answer
                         join p in db.surveyInfo on q.surveyID equals p.surveyID
                         where q.questionId == QueID && p.surveyDate == dt.Date && (p.Arrival.Trim().Length == 3)
                         orderby q.questionId ascending
                         group p by p.Arrival into g
                         select new
                         {
                             IATAName = g.Key,
                             IATACount = g.Count(),
                         };
            int allcount = 0;
            foreach (var item in query)
            {
                SurveyInfo si = new SurveyInfo();
                si.InfoCount = item.QueCount;
                si.FemaleCount = item.FemaleCount;
                si.MaleCount = item.MaleCount;
                si.Age18 = item.Age18Count;
                si.Age25 = item.Age25Count;
                si.Age40 = item.Age40Count;
                si.Age60 = item.Age60Count;
                si.Economy1 = item.Economy;
                si.Business1 = item.Business;
                si.First1 = item.First;
                si.ArrName = new string[query2.Count()];
                si.ArrCount = new int[query2.Count()];

                #region 计算总人数
                allcount += item.FemaleCount;
                allcount += item.MaleCount;
                allcount += item.Age18Count;
                allcount += item.Age25Count;
                allcount += item.Age40Count;
                allcount += item.Age60Count;
                allcount += item.Economy;
                allcount += item.Business;
                allcount += item.First;
                #endregion

                int i = 0;
                var query3 = from q in item.g
                             where q.Arrival.Trim().Length == 3
                             group q by q.Arrival into g
                             select new
                             {
                                 IATAName = g.Key,
                                 IATACount = g.Count(),
                             };
                foreach (var item3 in query3)
                {
                    si.ArrName[i] = item3.IATAName;
                    si.ArrCount[i] = item3.IATACount;
                    allcount += item3.IATACount;
                    i++;
                }
                si.AllCount = allcount;
                allcount = 0;
                lists.Add(si);
            }
            return lists;
        }
        #endregion

        #region 准点率前三
        public List<OneRateinfo> GetlistRate(DateTime stardt, DateTime enddt)
        {
            List<OneRateinfo> listO = new List<OneRateinfo>();
            var query = from q in db.Schedule
                        join a in db.Route on q.RouteId equals a.RouteId
                        where q.Date >= stardt && q.Date <= enddt
                        select new
                        {
                            DeparCode = a.DepartureAirportIATA,
                            DestCode = a.ArrivalAirportIATA,
                            Punc = (float)(1.00 * (from p in db.Schedule
                                                   join b in db.Route on p.RouteId equals b.RouteId
                                                   join c in db.FlightStatus on p.ScheduleId equals c.ScheduleId
                                                   where p.FlightNumber == q.FlightNumber
                                                   && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) < new DateTime(q.Date.Year, q.Date.Month, q.Date.Day)
                                                   && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) > new DateTime(q.Date.Year, q.Date.Month, q.Date.Day).AddDays(-30)
                                                   && (c.ActualArrivalTime - Convert.ToDateTime(String.Concat(q.Date, " ", q.Time.Hours.ToString(), ":", q.Time.Minutes.ToString(), ":", q.Time.Seconds.ToString())).AddMinutes(a.FlightTime)) > new TimeSpan(0, 15, 0)
                                                   select p).Count()
                                    / ((1.00 * (from p in db.Schedule
                                                join b in db.Route on p.RouteId equals b.RouteId
                                                join c in db.FlightStatus on p.ScheduleId equals c.ScheduleId
                                                where p.FlightNumber == q.FlightNumber
                                                && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) < new DateTime(q.Date.Year, q.Date.Month, q.Date.Day)
                                                && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) > new DateTime(q.Date.Year, q.Date.Month, q.Date.Day).AddDays(-30)
                                                select p).Count()) == 0 ? 1 : (1.00 * (from p in db.Schedule
                                                                                       join b in db.Route on p.RouteId equals b.RouteId
                                                                                       join c in db.FlightStatus on p.ScheduleId equals c.ScheduleId
                                                                                       where p.FlightNumber == q.FlightNumber
                                                                                       && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) < new DateTime(q.Date.Year, q.Date.Month, q.Date.Day)
                                                                                       && Convert.ToDateTime(String.Concat(p.Date, " ", p.Time.Hours.ToString(), ":", p.Time.Minutes.ToString(), ":", p.Time.Seconds.ToString())) > new DateTime(q.Date.Year, q.Date.Month, q.Date.Day).AddDays(-30)
                                                                                       select p).Count()))
                                    )
                        };
            var query2 = from q in query
                         orderby q.Punc ascending
                         select q;
            for (int i = 0; listO.Count < 3; i++)
            {
                if (listO.Count > 0)
                {
                    bool isexc = false;
                    foreach (var item in listO)
                    {
                        if (item.DeparCode1 == query2.ToList()[i].DeparCode && item.DestCode1 == query2.ToList()[i].DestCode)
                            isexc = true;
                    }
                    if (isexc)
                        continue;
                    else
                    {
                        OneRateinfo or = new OneRateinfo();
                        or.DeparCode1 = query2.ToList()[i].DeparCode;
                        or.DestCode1 = query2.ToList()[i].DestCode;
                        or.Rate1 = Convert.ToDecimal(1.00 - query2.ToList()[i].Punc);
                        listO.Add(or);
                    }
                }
                else
                {
                    OneRateinfo or = new OneRateinfo();
                    or.DeparCode1 = query2.ToList()[i].DeparCode;
                    or.DestCode1 = query2.ToList()[i].DestCode;
                    or.Rate1 = Convert.ToDecimal(1.00 - query2.ToList()[i].Punc);
                    listO.Add(or);
                }
            }
            return listO;
        }
        #endregion

        #region 空座率
        public OneSeatInfo GetListSeats(DateTime stardt, DateTime enddt)
        {
            OneSeatInfo os = new OneSeatInfo();
            var Aircount = from q in db.Aircraft
                           select new
                           {
                               q.AircraftId,
                               EconomyCount = q.EconomySeatsAmount,
                               BusinessCount = q.BusinessSeatsAmount,
                               FirstCount = q.FirstSeatsAmount
                           };
            var query = from q in db.Schedule
                        where q.Date >= stardt && q.Date <= enddt && q.Status == "Confirmed"
                        select q;
            decimal SoldCount = 0;
            decimal AllSoldCnt = 0;
            foreach (var item in query)
            {
                SoldCount += db.FlightReservation.Count(q => q.ScheduleId == item.ScheduleId && q.CabinTypeId == 1);
                AllSoldCnt += Aircount.First(q => q.AircraftId == item.AircraftId).EconomyCount;
            }
            os.Economylv = 1.00m - SoldCount / AllSoldCnt;
            SoldCount = 0;
            AllSoldCnt = 0;
            foreach (var item in query)
            {
                SoldCount += db.FlightReservation.Count(q => q.ScheduleId == item.ScheduleId && q.CabinTypeId == 2);
                AllSoldCnt += Aircount.First(q => q.AircraftId == item.AircraftId).BusinessCount;
            }
            os.Businesslv = 1.00m - SoldCount / AllSoldCnt;
            SoldCount = 0;
            AllSoldCnt = 0;
            foreach (var item in query)
            {
                SoldCount += db.FlightReservation.Count(q => q.ScheduleId == item.ScheduleId && q.CabinTypeId == 3);
                AllSoldCnt += Aircount.First(q => q.AircraftId == item.AircraftId).FirstCount;
            }
            os.Firstlv = 1.00m - SoldCount / AllSoldCnt;
            SoldCount = 0;
            AllSoldCnt = 0;

            return os;
        }
        #endregion

        #region 最忙最轻松查询
        public List<string[]> GetDayinfo(DateTime stardt, DateTime enddt)
        {
            List<string[]> lists = new List<string[]>();
            string[] BDay = new string[2];
            string[] MDay = new string[2];
            var query = from q in db.Schedule
                        where q.Date >= stardt && q.Date <= enddt && q.Status == "Confirmed"
                        group q by q.Date into g
                        select new
                        {
                            Date = g.Key,
                            FlyCount = g.Count()
                        };
            BDay[0] = (from q in query orderby q.FlyCount descending select q).First().Date.ToString("yyyy-MM-dd");
            BDay[1] = (from q in query orderby q.FlyCount descending select q).First().FlyCount.ToString();
            MDay[0] = (from q in query orderby q.FlyCount ascending select q).First().Date.ToString("yyyy-MM-dd");
            MDay[1] = (from q in query orderby q.FlyCount ascending select q).First().FlyCount.ToString();
            lists.Add(BDay);
            lists.Add(MDay);
            return lists;
        }
        #endregion

        #region 最受欢迎城市
        public string[] GetLikeCity(DateTime stardt, DateTime enddt)
        {
            var query = from q in db.FlightReservation
                        join p in db.Schedule on q.ScheduleId equals p.ScheduleId
                        join r in db.Route on p.RouteId equals r.RouteId
                        join a in db.Airport on r.ArrivalAirportIATA equals a.IATACode
                        where p.Date >= stardt && p.Date <= enddt && p.Status == "Confirmed"
                        group a by a.CityCode into g
                        orderby g.Count() descending
                        select new
                        {
                            IATAName = g.Key,
                            IATACount = g.Count()
                        };
            string[] Name = new string[3];
            for (int i = 0; i < 3; i++)
            {
                var query2 = from q in db.City
                             where q.CityCode == query.ToList()[i].IATAName
                             select q;
                if (query2.Count() == 0)
                    Name[i] = "null";
                else
                    Name[i] = query2.First().CityName;
            }
            return Name;
        }
        #endregion

        #region 最多钱
        public List<string[]> GetSalesVolume(DateTime stardt, DateTime enddt)
        {
            var query = from q in db.FlightReservation
                        join p in db.Schedule on q.ScheduleId equals p.ScheduleId
                        join r in db.Route on p.RouteId equals r.RouteId
                        where p.Date >= stardt && p.Date <= enddt && p.Status == "Confirmed"
                        select new
                        {
                            price = p.EconomyPrice * (decimal)(1.00 + 0.25 * (q.CabinTypeId - 1)),
                            RouteId = r.RouteId
                        };
            var query2 = from q in query
                         group q by q.RouteId into g
                         orderby g.Select(o => o.price).Sum() descending
                         select new
                         {
                             g.Key,
                             Allprice = g.Select(o => o.price).Sum(),
                         };
            List<string[]> lo = new List<string[]>();
            for (int i = 0; i < 3; i++)
            {
                string[] str = new string[3];
                str[0] = db.Route.First(q => q.RouteId == query2.ToList()[i].Key).DepartureAirportIATA;
                str[1] = db.Route.First(q => q.RouteId == query2.ToList()[i].Key).ArrivalAirportIATA;
                str[2] = query2.ToList()[i].Allprice.ToString("#0.00");
                lo.Add(str);
            }
            return lo;
        } 
        #endregion
    }

    #region 航班调查信息
    public class SurveyInfo
    {
        private int infoCount;
        private int femaleCount;
        private int maleCount;
        private int age18;
        private int age25;
        private int age40;
        private int age60;
        private int Economy;
        private int Business;
        private int First;
        private string[] arrName;
        private int[] arrCount;
        public int AllCount;

        public int InfoCount { get => infoCount; set => infoCount = value; }
        public int FemaleCount { get => femaleCount; set => femaleCount = value; }
        public int MaleCount { get => maleCount; set => maleCount = value; }
        public int Age18 { get => age18; set => age18 = value; }
        public int Age25 { get => age25; set => age25 = value; }
        public int Age40 { get => age40; set => age40 = value; }
        public int Age60 { get => age60; set => age60 = value; }
        public int Economy1 { get => Economy; set => Economy = value; }
        public int Business1 { get => Business; set => Business = value; }
        public int First1 { get => First; set => First = value; }
        public string[] ArrName { get => arrName; set => arrName = value; }
        public int[] ArrCount { get => arrCount; set => arrCount = value; }
    }
    #endregion

    #region 准点率信息
    public class OneRateinfo
    {
        string DeparCode;
        string DestCode;
        decimal Rate;

        public string DeparCode1 { get => DeparCode; set => DeparCode = value; }
        public string DestCode1 { get => DestCode; set => DestCode = value; }
        public decimal Rate1 { get => Rate; set => Rate = value; }
    }
    #endregion

    #region 座位购买率
    public class OneSeatInfo
    {
        private decimal economylv;
        private decimal businesslv;
        private decimal firstlv;

        public decimal Economylv { get => economylv; set => economylv = value; }
        public decimal Businesslv { get => businesslv; set => businesslv = value; }
        public decimal Firstlv { get => firstlv; set => firstlv = value; }
    }
    #endregion
}
