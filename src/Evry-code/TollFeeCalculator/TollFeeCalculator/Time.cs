using System;

namespace TollFeeCalculator
{
    public struct Time
    {
        public Time(int startHour, int startMinute, int endHour, int endMinute)
        {
            StartHour = startHour;
            StartMinute = startMinute;
            EndHour = endHour;
            EndMinute = endMinute;
        }
        
        public int StartHour { get; }
        public int StartMinute { get; }
        public int EndHour { get; }
        public int EndMinute { get; }
​
        public bool IsWithinInterval(DateTime dateTime)
        {
            return dateTime.Hour >= StartHour
                && dateTime.Hour <= EndHour
                && dateTime.Minute >= StartMinute
                && dateTime.Minute <= EndMinute;
        }
    }
}
