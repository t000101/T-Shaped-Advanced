using CoreFW.Helper;
using System;

namespace TestFW.TestData
{
    public class Info
    {
        public static string place = "Da Lat";
        public static int numberRooms = 1;
        public static int numberAdults = 2;
        public static int numberChildren = 0;
        public static string minPrice = "500000";
        public static string maxPrice = "1000000";
    }
    public class InfoDate
    {
        public static DateTime startDate = DateTimeHelper.GetNextWeekday(DateTime.Now, DayOfWeek.Friday);
        public static DateTime endDate = startDate.AddDays(3);
    }
    public class Account
    {
        public static string email = "testlinhcz@gmail.com";
        public static string password = "linh12071995";
    }
}
