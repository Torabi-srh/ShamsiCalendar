using MauiPersianCalendar.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPersianCalendar.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToEnDateTime(this DateTime cDate)
        {
            var pc = new PersianCalendar();
            return pc.ToDateTime(cDate.Year, cDate.Month, cDate.Day, cDate.Hour, cDate.Minute, cDate.Second, cDate.Millisecond);
        }

        public static string ToPersianDate(this DateTime dateTime, string seperator = "/")
        {
            if (seperator == null)
            {
                // in case if somebody has passed null
                seperator = "/";
            }
            //PersianDate g= FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(dateTime);
            var calendar = new PersianCalendar();
            string year = calendar.GetYear(dateTime).ToString();
            string month = calendar.GetMonth(dateTime).ToString();
            string day = calendar.GetDayOfMonth(dateTime).ToString();
            month = month.Length == 1 ? month.PadLeft(2, '0') : month;
            day = day.Length == 1 ? day.PadLeft(2, '0') : day;
            return string.Format("{0}{1}{2}{1}{3}", year, seperator, month, day);
        }

        public static PersianDate ToPersianDateTime(this DateTime date)
        {
            var pc = new PersianCalendar();
            return new PersianDate(pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }

        public static DateTime ToDateTime(this string dateStr)
        {
            if (dateStr == null && dateStr.Length != 8)
            {
                throw new Exception("Invalid string Date");
            }

            if (dateStr.Contains("/"))
            {
                dateStr = dateStr.Replace("/", "");
            }

            int.TryParse(dateStr.Substring(0, 4), out var year);
            int.TryParse(dateStr.Substring(4, 2), out var month);
            int.TryParse(dateStr.Substring(6, 2), out var day);
            if (year == 0 || month == 0 || day == 0)
            {
                throw new Exception("Invalid string Date");
            }
            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
    }
}
