using System;
using System.Linq;

namespace TollFeeCalculator
{
    public class TollCalculator
    {

        private TollFreeVehicles _tollFreeVehicles;
        private readonly Schedule _schedule = new Schedule();

        public TollCalculator() { }

        /// <summary> 
        /// Calculate the total toll fee for one day
        /// </summary>
        /// <param name="vehicle">The <see cref="Vehicle"/></param>
        /// <param name="timeStamps">Date and time of all passes on one day</param>
        /// <returns>The total toll fee for that day</returns>
        public double GetTollFee(IVehicle vehicle, DateTime[] timeStamps)
        {
            DateTime intervalStart = timeStamps[0];
            var totalFee = GetTollFeeByDate(intervalStart, vehicle);

            foreach (DateTime timeStamp in timeStamps.Skip(1))
            {
                var minutes = (timeStamp.Minute - intervalStart.Minute);

                if (minutes > 60)
                    totalFee += GetTollFeeByDate(timeStamp, vehicle);
            }

            if (totalFee > 60)
                totalFee = 60;

            return totalFee;
        }

        private bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
                return false;

            return Enum.IsDefined(typeof(TollFreeVehicles), vehicle.Type);
        }

        public double GetTollFeeByDate(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle))
                return 0;

            return _schedule.GetFee(date);
        }

        private bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}