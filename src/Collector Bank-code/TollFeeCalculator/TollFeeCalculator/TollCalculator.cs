// <copyright file="TollCalculator.cs" company="Collector Bank AB">//     Copyright (c) Collector Bank AB. All rights reserved.// </copyright>// <author>//     <a href="mailto:mustafa.s.hamada@gmail.com">Mustafa S. Hamada</a>// </author>
// <not implemented>
//      - Unit testing
//      - More technical comments
//      - More code refactoring
// </not implemented>

namespace TollFeeCalculator
{
    using System;
    using System.Linq;
    using Nager.Date;

    public class TollCalculator
    {

        private TollFreeVehicles _tollFreeVehicles;
        private readonly Schedule _schedule;

        public TollCalculator()
        {
            _schedule = new Schedule();
        }

        /// <summary> 
        /// Calculate the total toll fee for one day
        /// </summary>
        /// <param name="vehicle">The <see cref="IVehicle"/></param>
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
                if (DateSystem.IsPublicHoliday(date, CountryCode.SE))
                    return true;
            }
            return false;
        }
    }
}