using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFW.Helper
{
    public class DateTimeHelper
    {
        public static DateTime GetThreeDayNextTomorrow(DateTime dt, DayOfWeek nextTomorrow)
        {
            DateTime nextTomorrowday = dt.AddDays(2);
            int currentDay = (int)dt.DayOfWeek;
            int diff = (int)nextTomorrow - (int)currentDay;
            if (diff <= 0)
                nextTomorrowday.AddDays(7);

            while (nextTomorrowday.DayOfWeek != nextTomorrow)
                nextTomorrowday = nextTomorrowday.AddDays(1);
            return nextTomorrowday;
        }
        public static DateTime GetNextWeekday( DateTime dt, DayOfWeek weekday)
        {
            DateTime nextWeekday = dt.AddDays(1);

            int currentDay = (int)dt.DayOfWeek;
            int diff = (int)weekday - (int)currentDay;

            if (diff <= 0)
                nextWeekday.AddDays(7);

            while (nextWeekday.DayOfWeek != weekday)
                nextWeekday = nextWeekday.AddDays(1);
            return nextWeekday;
        }
    }
}
