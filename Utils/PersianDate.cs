using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiPersianCalendar.Utils.Enums;

namespace MauiPersianCalendar.Utils
{
    public class PersianDate
    {
        private int _day;
        private int _month;
        private int _year;

        public PersianDate(int year, int month, int day)
        {
            _day = day;
            _year = year;
            _month = month;
        }

        public int Day
        {
            get { return _day; }
            private set { _day = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public void AddDay(int day, int lastDay)
        {
            if (_day == lastDay)
            {
                if (_month == (int)Months.Last)
                {
                    _month = 1;
                    _year++;

                }
                else
                {
                    _month++;
                }
                _day = 1;
                return;
            }

            _day += day;
        }

        public PersianDate AddDay(int day)
        {
            _day += day;
            return this;
        }

        public DateTime ToDateTime()
        {
            var pc = new PersianCalendar();
            return pc.ToDateTime(_year, _month, _day, 0, 0, 0, 0);
        }

    }
}