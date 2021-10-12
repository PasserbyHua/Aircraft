using LinqToSQLClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.SqlServer.Server;
using System.Data.Linq.SqlClient;

namespace Aircraft.Session3
{
    public class QueryCreate2
    {
        #region 常用类
        userDataContext userdb = new userDataContext();
        FlightInquiryDBDataContext db = new FlightInquiryDBDataContext();
        #endregion

        #region 读取数据
        public List<QueryResultS> SelectResult(FlightCityQuery Cityinfo)
        {
            List<QueryResultS> listR = new List<QueryResultS>();
            var FromCityToIATA = from a in db.Airport
                                 where a.CityCode == Cityinfo.FromCityCode
                                 select a;
            if (FromCityToIATA.Count() > 0)
            {
                foreach (var item in FromCityToIATA)
                {
                    var ToCityToIATA = from a in db.Airport
                                       where a.CityCode == Cityinfo.ToCityCode
                                       select a;
                    if (ToCityToIATA.Count() > 0)
                    {
                        foreach (var item2 in ToCityToIATA)
                        {
                            FlightIATAQuery IATAinfo = new FlightIATAQuery()
                            {
                                FromIATACode = item.IATACode,
                                ToIATACode = item2.IATACode,
                                DT1 = Cityinfo.DT1,
                                DT2 = Cityinfo.DT2
                            };
                            listR.AddRange(SelectResult(IATAinfo));
                        }
                    }
                }
            }
            return listR;
        }
        public List<QueryResultS> SelectResult(FlightIATAQuery IATAinfo)
        {
            List<QueryResultS> listR = new List<QueryResultS>();
            var Query = from s in db.Schedule
                        join r in db.Route on s.RouteId equals r.RouteId
                        where r.DepartureAirportIATA == IATAinfo.FromIATACode
                        && r.ArrivalAirportIATA == IATAinfo.ToIATACode
                        && Convert.ToDateTime(String.Concat(s.Date, " ", s.Time.Hours.ToString(), ":", s.Time.Minutes.ToString(), ":", s.Time.Seconds.ToString())) > IATAinfo.DT1
                        && Convert.ToDateTime(String.Concat(s.Date, " ", s.Time.Hours.ToString(), ":", s.Time.Minutes.ToString(), ":", s.Time.Seconds.ToString())) < IATAinfo.DT2
                        orderby s.Time ascending
                        orderby s.Date ascending
                        select new
                        {
                            Schedule = s.ScheduleId,
                            Date = s.Date,
                            Time = s.Time,
                            FromIATACode = r.DepartureAirportIATA,
                            ToIATACode = r.ArrivalAirportIATA,
                            AirID = s.AircraftId,
                            Price = s.EconomyPrice,
                            FlightNum = s.FlightNumber,
                            Gate = s.Gate,
                            Status = s.Status,
                            RouteId = r.RouteId
                        };
            foreach (var item in Query)
            {
                QueryResultS qr = new QueryResultS()
                {
                    Schedule = item.Schedule.ToString(),
                    Date = item.Date.ToShortDateString(),
                    Time = item.Time.ToString(),
                    From = (from q in db.City
                            where q.CityCode == (from p in db.Airport
                                                 where p.IATACode == item.FromIATACode
                                                 select p).First().CityCode
                            select q).First().CityName + "/" + item.FromIATACode,
                    To = (from q in db.City
                          where q.CityCode == (from p in db.Airport
                                               where p.IATACode == item.ToIATACode
                                               select p).First().CityCode
                          select q).First().CityName + "/" + item.ToIATACode,
                    Aircraft = (from q in db.Aircraft
                                where q.AircraftId == item.AirID
                                select q.Name).First(),
                    EconomyPrice = item.Price.ToString(),
                    FlightNumber = item.FlightNum,
                    Gate = item.Gate,
                    Status = item.Status,
                    RouteId = item.RouteId
                };
                listR.Add(qr);
            }
            return listR;
        }
        #endregion

        #region 添加时刻表数据
        public bool intsetschedele(RouteInfo ri)
        {
            var query = from q in db.Schedule
                        where q.Date == ri.DeparDateTime.Date && q.RouteId == ri.RouteId
                        select q;
            if (query.Count() > 0) return false;
            Schedule s = new Schedule()
            {
                Date = ri.DeparDateTime.Date,
                Time = ri.DeparDateTime.TimeOfDay,
                AircraftId = ri.AircraftId,
                RouteId = ri.RouteId,
                EconomyPrice = ri.EconomyPrice,
                FlightNumber = ri.FlightNumber.ToString(),
                Gate = ri.Gate,
                Status = ri.Status,
            };
            db.Schedule.InsertOnSubmit(s);
            db.SubmitChanges();
            return true;
        }
        #endregion

        #region 修改时刻表数据
        public void updateschedule(int sid, RouteInfo newr)
        {
            var query = db.Schedule.First(q => q.ScheduleId == sid);
            query.Date = newr.DeparDateTime.Date;
            query.Time = newr.DeparDateTime.TimeOfDay;
            query.EconomyPrice = newr.EconomyPrice;
            query.Gate = newr.Gate;
            db.SubmitChanges();
        }
        #endregion

        #region 添加时刻表数据
        public bool intsetschedele(ScheduleInfo si)
        {
            var query = from q in db.Route
                        where q.DepartureAirportIATA == si.FromCode && q.ArrivalAirportIATA == si.ToCode
                        select q;
            int routeid;
            if (query.Count() > 0)
            {
                routeid = query.First().RouteId;
            }
            else
            {
                return false;
            }
            int AirId;
            var query2 = from q in db.Schedule
                         where q.Date == si.DeparDatetime.Date
                         select q;
            if (query2.Count() > 0)
            {
                return false;
            }
            else
            {
                AirId = db.Aircraft.First(q => q.Name == si.Aircraft).AircraftId;
            }
            RouteInfo ri = new RouteInfo()
            {
                DeparDateTime = si.DeparDatetime,
                AircraftId = AirId,
                RouteId = routeid,
                EconomyPrice = si.EconomyPrice,
                FlightNumber = si.FlightNumber,
                Gate = si.Gate,
                Status = si.Status
            };
            if (intsetschedele(ri))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 读取用户等级信息
        public List<string> GetRoleInfo()
        {
            var query = from s in userdb.Role
                        select s;
            List<string> listinfo = new List<string>();
            foreach (var item in query)
            {
                listinfo.Add(item.RoleName.ToString());
            }
            return listinfo;
        }
        #endregion

        #region 读取用户信息
        public List<UserInfo> GetUserInfos(int id, string name)
        {
            if (id != 0)
            {
                string likename = "%" + name + "%";
                var query = from q in userdb.Users
                            join r in userdb.Role on q.RoleId equals r.RoldId
                            where q.RoleId == id && SqlMethods.Like(q.FirstName + q.LastName, likename)
                            select q;
                List<UserInfo> listu = new List<UserInfo>();
                foreach (var item in query)
                {
                    string Gender = "Null";
                    if (item.Gender == "M") Gender = "Male";
                    if (item.Gender == "F") Gender = "Female";
                    UserInfo ui = new UserInfo()
                    {
                        UserId1 = item.UserId,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Gender = Gender,
                        DateOfBirth = item.DateOfBirth,
                        Phone = item.Phone,
                        RoleName = item.Role.RoleName,
                        Address = item.Address,
                        PhotoByte = item.Photo == null ? null : (Byte[])item.Photo.ToArray()
                    };
                    listu.Add(ui);
                }
                return listu;
            }
            else
            {
                string likename = "%" + name + "%";
                var query = from q in userdb.Users
                            join r in userdb.Role on q.RoleId equals r.RoldId
                            where SqlMethods.Like(q.FirstName + q.LastName, likename)
                            select new
                            {
                                q.UserId,
                                q.Email,
                                q.FirstName,
                                q.LastName,
                                q.Gender,
                                q.DateOfBirth,
                                q.Phone,
                                r.RoleName,
                                q.Address,
                                q.Photo
                            };
                List<UserInfo> listu = new List<UserInfo>();

                foreach (var item in query)
                {
                    Byte[] PhotoByte = new byte[100 * 1024];
                    if (item.Photo != null)
                        PhotoByte = (Byte[])item.Photo.ToArray();
                    else
                        PhotoByte = new byte[0];
                    UserInfo ui = new UserInfo()
                    {
                        UserId1 = item.UserId,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Gender = item.Gender,
                        DateOfBirth = item.DateOfBirth,
                        Phone = item.Phone,
                        RoleName = item.RoleName,
                        Address = item.Address,
                        PhotoByte = PhotoByte
                    };
                    listu.Add(ui);
                }
                return listu;
            }
        }
        #endregion

        #region 添加用户信息
        public bool InsertUser(UserInfo ui)
        {

            string[] pass = ui.Email.Split('@');
            string pwd = "";
            if (pass[0].Length > 6)
            {
                pwd = pass[0].Substring(0, 6);
            }
            else
            {
                pwd = pass[0];
            }
            Users newUser = new Users()
            {
                Email = ui.Email,
                FirstName = ui.FirstName,
                LastName = ui.LastName,
                Password = pwd,
                Gender = ui.Gender,
                DateOfBirth = ui.DateOfBirth,
                Phone = ui.Phone,
                Photo = ui.PhotoByte,
                RoleId = userdb.Role.First(q => q.RoleName == ui.RoleName).RoldId,
                Address = ui.Address
            };
            userdb.Users.InsertOnSubmit(newUser);
            userdb.SubmitChanges();
            return true;
        }
        #endregion

        #region 修改用户信息
        public bool updateUser(UserInfo ui)
        {
            var query = from q in userdb.Users
                        where q.UserId == ui.UserId1
                        select q;

            if (query.Count() == 1)
            {
                query.First().FirstName = ui.FirstName;
                query.First().LastName = ui.LastName;
                query.First().Gender = ui.Gender;
                query.First().DateOfBirth = ui.DateOfBirth;
                query.First().Phone = ui.Phone;
                query.First().Photo = ui.PhotoByte;
                query.First().Address = ui.Address;
                query.First().RoleId = userdb.Role.First(q => q.RoleName == ui.RoleName).RoldId;
            }
            userdb.SubmitChanges();
            return true;
        }
        #endregion

        #region 修改航班状态
        public bool updateConfid(int scheduleid)
        {
            var query = db.Schedule.First(q => q.ScheduleId == scheduleid);
            if (query.Status == "Confirmed")
                query.Status = "Canceled";
            else if (query.Status == "Canceled")
                query.Status = "Confirmed";
            db.SubmitChanges();
            return true;
        }
        #endregion

        #region 读取总共售卖信息
        public List<StatisticsView> listSV(DateTime StartD, DateTime EndD)
        {
            List<StatisticsView> ls = new List<StatisticsView>();
            var query = from q in db.Schedule
                        join r in db.Route on q.RouteId equals r.RouteId
                        where q.Date.Month >= StartD.Date.Month && q.Date.Month <= EndD.Date.Month
                        orderby q.Date ascending
                        select q;
            int month = StartD.Month;
            int FA = 0;
            int TA = 0;
            decimal TR = 0;
            StatisticsView sv = new StatisticsView();
            foreach (var item in query)
            {
                if (month != item.Date.Month)
                {
                    month = item.Date.Month;
                    ls.Add(sv);
                    FA = 0;
                    TA = 0;
                    TR = 0;
                    sv = new StatisticsView();
                }
                FA++;
                var query2 = from q in db.Aircraft
                             where q.AircraftId == item.AircraftId
                             select q;
                var query3 = from q in db.FlightReservation
                             where q.ScheduleId == item.ScheduleId
                             select q;
                foreach (var item2 in query3)
                {
                    TA++;
                    TR += Convert.ToDecimal(item.EconomyPrice * (1.00m + (0.25m * (item2.CabinTypeId - 1))));
                }
                sv.Mouthdate = item.Date.Year.ToString() + "-" + item.Date.Month.ToString();
                sv.FlightsAmount = FA;
                sv.TicketsAmount = TA;
                sv.TicketsRevenue = TR;
            }
            ls.Add(sv);
            return ls;
        }
        #endregion
    }
}
