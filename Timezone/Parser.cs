using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        public void DisplayTime(string time, string timezone)
        {
            DateTime parsedTime;
            if (DateTime.TryParse(time, out parsedTime))
                //check for valid time
            {
                parsedTime = DateTime.Parse(time);
                //convert string time to datetime object

                ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
                //use TimeZoneInfo.GetSystemTimeZones to generate list of time zones

                TimeZoneInfo parsedTimeZone = null;
                foreach (TimeZoneInfo timeZone in timeZones)
                {
                    if (timeZone.Id.Contains(timezone))
                    {
                        parsedTimeZone = timeZone;
                        break;
                    }
                }
                //loop through this list to find a match contained in timezone id with string timezone

                DateTime convertedTime = TimeZoneInfo.ConvertTimeFromUtc(parsedTime, parsedTimeZone);
                //use date time object and timezone to find converted time

                Console.WriteLine("The time in the UK is {0} and the time in {1} is {2}", parsedTime.TimeOfDay, timezone, convertedTime.TimeOfDay);
                //print to system "The time in the UK is {time} and the time in {timezone} is {converted time}
            }
            else
                Console.WriteLine("The time format was not valid");
            
        }
    }
}
