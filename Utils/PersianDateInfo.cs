using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPersianCalendar.Utils
{
    public static class PersianDateInfo
    {
        public static string[] Months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        public static Dictionary<int, string> MonthDic = new Dictionary<int, string>()
        {
            {1,"فروردین"},
            {2,"اردیبهشت"},
            {3,"خرداد"},
            {4,"تیر"},
            {5,"مرداد"},
            {6,"شهریور"},
            {7,"مهر"},
            {8,"آبان"},
            {9,"آذر"},
            {10,"دی"},
            {11,"بهمن"},
            {12,"اسفند"}
        };

        public static Dictionary<string, string> WeekDays = new Dictionary<string, string>()
        {
            { "Tue","سه شنبه"},
            { "Wed","چهارشنبه"},
            { "Thu","پنج شنبه"},
            { "Fri","جمعه"},
            { "Sat","شنبه"},
            { "Sun","یکشنبه"},
            { "Mon","دوشنبه"}
        };
    }
}
