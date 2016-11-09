using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Tool
{
    public class DateHelper
    {
        /// <summary>
        /// 获得当前日期所在周数的开始日期和结束日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="firstdate"></param>
        /// <param name="lastdate"></param>
        public static void GetDateOfWeek(DateTime date, out DateTime firstdate, out DateTime lastdate)
        {
            DateTime first = System.DateTime.Now;
            DateTime last = System.DateTime.Now;

            switch (date.DayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    first = date;
                    last = date.AddDays(6);
                    break;
                case System.DayOfWeek.Tuesday:
                    first = date.AddDays(-1);
                    last = date.AddDays(5);
                    break;
                case System.DayOfWeek.Wednesday:
                    first = date.AddDays(-2);
                    last = date.AddDays(4);
                    break;
                case System.DayOfWeek.Thursday:
                    first = date.AddDays(-3);
                    last = date.AddDays(3);
                    break;
                case System.DayOfWeek.Friday:
                    first = date.AddDays(-4);
                    last = date.AddDays(2);
                    break;
                case System.DayOfWeek.Saturday:
                    first = date.AddDays(-5);
                    last = date.AddDays(1);
                    break;
                case System.DayOfWeek.Sunday:
                    first = date.AddDays(-6);
                    last = date;
                    break;
            }
            firstdate = first;

            lastdate = last;
        }
        /// <summary>
        /// 获得当前日期所在周的下一周或上一周的开始日期
        /// </summary>
        /// <param name="dateTime"></param>
        public static DateTime GetWeekStartDate(DateTime dateTime,string strType)
        {
            DateTime dtSDate = dateTime;

            if(strType.Equals("Next"))
            {
                switch (dateTime.DayOfWeek)
                {
                    case System.DayOfWeek.Monday:
                        dtSDate = dateTime.AddDays(7);
                        break;
                    case System.DayOfWeek.Tuesday:
                        dtSDate = dateTime.AddDays(6);
                        break;
                    case System.DayOfWeek.Wednesday:
                        dtSDate = dateTime.AddDays(5);
                        break;
                    case System.DayOfWeek.Thursday:
                        dtSDate = dateTime.AddDays(4);
                        break;
                    case System.DayOfWeek.Friday:
                        dtSDate = dateTime.AddDays(3);
                        break;
                    case System.DayOfWeek.Saturday:
                        dtSDate = dateTime.AddDays(2);
                        break;
                    case System.DayOfWeek.Sunday:
                        dtSDate = dateTime.AddDays(1);
                        break;
                }
            }
            else if(strType.Equals("Prev"))
            {
                switch (dateTime.DayOfWeek)
                {
                    case System.DayOfWeek.Monday:
                        dtSDate = dateTime.AddDays(-7);
                        break;
                    case System.DayOfWeek.Tuesday:
                        dtSDate = dateTime.AddDays(-8);
                        break;
                    case System.DayOfWeek.Wednesday:
                        dtSDate = dateTime.AddDays(-9);
                        break;
                    case System.DayOfWeek.Thursday:
                        dtSDate = dateTime.AddDays(-10);
                        break;
                    case System.DayOfWeek.Friday:
                        dtSDate = dateTime.AddDays(-11);
                        break;
                    case System.DayOfWeek.Saturday:
                        dtSDate = dateTime.AddDays(-12);
                        break;
                    case System.DayOfWeek.Sunday:
                        dtSDate = dateTime.AddDays(-13);
                        break;
                }
            }

            return dtSDate;
        }

        /// <summary>
        /// 获得每年
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        //public static DateTime GetYearFirstWeekToFirstDate(DateTime dateTime)
        //{

        //}

        /// <summary>   
        /// 获取一年中指定的一周的开始日期和结束日期。开始日期遵循ISO 8601即星期一。   
        /// </summary>   
        /// <remarks>Write by vrhero</remarks>   
        /// <param name="year">年（1 到 9999）</param>   
        /// <param name="weeks">周（1 到 53）</param>   
        /// <param name="first">当此方法返回时，则包含参数 year 和 weeks 指定的周的开始日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。如果参数 year 或 weeks 超出有效范围，则操作失败。该参数未经初始化即被传递。</param>   
        /// <param name="last">当此方法返回时，则包含参数 year 和 weeks 指定的周的结束日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。如果参数 year 或 weeks 超出有效范围，则操作失败。该参数未经初始化即被传递。</param>   
        /// <returns>成功返回 true，否则为 false。</returns>   
        public static bool GetDaysOfWeeks(int year, int weeks, out DateTime first, out DateTime last)  
        {  
            //初始化 out 参数   
            first = DateTime.MinValue;  
            last = DateTime.MinValue;  
          
            //不用解释了吧...   
            if (year < 1 || year > 9999)  
                return false;  
          
            //一年最多53周地球人都知道...   
            if (weeks < 1 || weeks > 53)  
                return false;  
          
            //取当年首日为基准...为什么？容易得呗...   
            DateTime firstCurr = new DateTime(year, 1, 1);  
            //取下一年首日用于计算...   
            DateTime firstNext = new DateTime(year + 1, 1, 1);  
          
            //将当年首日星期几转换为数字...星期日特别处理...ISO 8601 标准...   
            int dayOfWeekFirst = (int)firstCurr.DayOfWeek;  
            if (dayOfWeekFirst == 0) dayOfWeekFirst = 7;  
          
            //得到未经验证的周首日...   
            first = firstCurr.AddDays((weeks - 1) * 7 - dayOfWeekFirst + 1);

            if(first.Year<year)
            {
                first = firstCurr;  
            }
            //得到未经验证的周末日...   
            last = first.AddDays(7).AddSeconds(-1); 

            if (last.Year > year)
            {
                last = firstNext.AddSeconds(-1);  
            }
            else if (last.DayOfWeek != DayOfWeek.Monday)
            {
                last = first.AddDays(7 - (int)first.DayOfWeek).AddSeconds(-1);  
            }
            return true;  
        }
        /// <summary>
        /// 获得今年有几周
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(int year)
        {
            DateTime the_Date = new DateTime(year, 1, 1);//本年的第一天
            TimeSpan tt = the_Date.AddYears(1) - the_Date;//求出本年有几天
            return tt.Days / 7+1; //因为年只有366天和365天除以7有余数所以始终需要加一周
        }
        ///   <summary>   
        ///   返回两个日期之间的时间间隔   
        ///   </summary>   
        ///   <param   name="Date1">开始日期</param>   
        ///   <param   name="Date2">结束日期</param>   
        ///   <returns>返回间隔标志指定的时间间隔</returns>   
        public static string DateDiff(DateTime beginDate, DateTime endDate)
        {
            TimeSpan tsBegin=new TimeSpan(beginDate.Ticks);
            TimeSpan tsEnd = new TimeSpan(endDate.Ticks);   
            TimeSpan ts = tsEnd.Subtract(tsBegin).Duration();//:获取TimeSpan的绝对值  
            //return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒"; 
            return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分"; 
        }
        ///   <summary>   
        ///   返回两个日期之间的时间间隔天数   
        ///   </summary>   
        ///   <param   name="Date1">开始日期</param>   
        ///   <param   name="Date2">结束日期</param>   
        ///   <returns>返回间隔标志指定的时间间隔</returns>   
        public static int DateDiffDay(DateTime beginDate, DateTime endDate)
        {
            TimeSpan tsBegin = new TimeSpan(beginDate.Ticks);
            TimeSpan tsEnd = new TimeSpan(endDate.Ticks);
            TimeSpan ts = tsEnd.Subtract(tsBegin).Duration();//:获取TimeSpan的绝对值  
            //return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒"; 
            return ts.Days;
        }
        /// <summary>
        /// 返回间隔
        /// </summary>
        /// <returns></returns>
        public static string GetDatediff(string strSDate, string strEDate)
        {
            string strdiff = "";

            if (!strSDate.Equals("") && !strEDate.Equals(""))
            {
                strdiff =DateDiff(Convert.ToDateTime(strSDate),
                                                              Convert.ToDateTime(strEDate));
            }

            return strdiff;
        }
    }
}
