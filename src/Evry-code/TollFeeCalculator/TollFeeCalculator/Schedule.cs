using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
    public class Schedule
    {
        private readonly Dictionary<Time, double> _schedule = new Dictionary<Time, double>();
​
        public Schedule()
        {
            Initialize();
        }

        public double GetFee(DateTime dateTime)
        {
            var timeInstance = _schedule.Where(x => x.Key.IsWithinInterval(dateTime)).FirstOrDefault();
            return timeInstance.Value;
        }
​
        private void Initialize()
        {
            _schedule.Add(new Time(6, 0, 6, 29), 9);
            _schedule.Add(new Time(6, 30, 6, 59), 16);
            _schedule.Add(new Time(7, 0, 7, 59), 22);
            _schedule.Add(new Time(8, 0, 8, 29), 16);
            _schedule.Add(new Time(8, 30, 14, 59), 9);
            _schedule.Add(new Time(15, 0, 15, 29), 16);
            _schedule.Add(new Time(15, 30, 16, 59), 22);
            _schedule.Add(new Time(17, 0, 17, 59), 16);
            _schedule.Add(new Time(18, 0, 18, 29), 9);
            _schedule.Add(new Time(18, 30, 5, 59), 0);
        }
    }
}
