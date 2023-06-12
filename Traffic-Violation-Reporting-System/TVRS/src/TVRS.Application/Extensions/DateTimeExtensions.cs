using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVRS.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime CombineDateTime(this string time, string date)
        {
            var timeComponents = time.Split(':');
            int hour = int.Parse(timeComponents[0]);
            int minute = int.Parse(timeComponents[1]);

            var dateComponents = date.Split('.'); 
            int day = int.Parse(dateComponents[0]);
            int month = int.Parse(dateComponents[1]);
            int year = int.Parse(dateComponents[2]);

            return new DateTime(year, month, day, hour, minute, 0);
        }
        /*
            string time = "10:30";
            string date = "09.06.2023";

            DateTime combinedDateTime = time.CombineDateTime(date);
         
         */

        public static DateTime ToDateTime(this string date, string time)
        {
            string dateTimeString = $"{date} {time}";
            return DateTime.Parse(dateTimeString);
        }
        /*
            string incidentDate = "2023-06-09";
            string incidentTime = "10:30:00";

            DateTime dateTime = incidentDate.ToDateTime(incidentTime);
   
         */
        public static void SplitDateTime(this DateTime dateTime, out string time, out string date)
        {
            time = dateTime.ToString("HH:mm");
            date = dateTime.ToString("dd.MM.yyyy");
        }

        /*
            DateTime datetime = DateTime.Now;
            string time;
            string date;

            SplitDateTime(datetime, out time, out date);
         
         */
    }
}
