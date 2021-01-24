using System;

namespace ParkingMeter
{
    public class ShortStayParkingChargeCalculator : IParkingChargeCalculator
    {
        private readonly int _chargeStartHour;
        private readonly int _chargeEndHour;
        private readonly decimal _hourRate;

        public ShortStayParkingChargeCalculator(decimal hourRate)
        {
            _chargeStartHour = 8;
            _chargeEndHour = 18;
            _hourRate = hourRate;
        }

        public decimal CalculateTotalCharge(DateTime periodStart, DateTime periodEnd)
        {
            var timeTracker = periodStart;
            TimeSpan difference;
            var totalCharge = 0.0m;

            do
            {
                while (timeTracker < periodEnd && !IsWithinChargeablePeriod(timeTracker, periodEnd))
                {
                    timeTracker = timeTracker.AddHours(1);
                }

                // Add fractional charge (if any)
                if (timeTracker > periodStart && timeTracker < periodEnd)
                {
                    difference = timeTracker - ChargeStartHour(timeTracker);
                    totalCharge += ((decimal)difference.Minutes / 60) * _hourRate;
                }

                while (timeTracker < periodEnd && IsWithinChargeablePeriod(timeTracker, periodEnd))
                {
                    totalCharge += _hourRate;
                    timeTracker = timeTracker.AddHours(1);
                }

                // Deduct fractional charge (if any)
                if (timeTracker > periodStart && timeTracker < periodEnd)
                {
                    difference = timeTracker - ChargeEndHour(timeTracker);
                    totalCharge -= ((decimal)difference.Minutes / 60) * _hourRate;
                }
            }
            while (timeTracker < periodEnd);

            return totalCharge;
        }

        private bool IsWithinChargeablePeriod(DateTime currentTime, DateTime periodEnd)
        {            
            return currentTime.DayOfWeek != DayOfWeek.Saturday && currentTime.DayOfWeek != DayOfWeek.Sunday
                && currentTime >= ChargeStartHour(currentTime)
                && currentTime < new DateTime(Math.Min(ChargeEndHour(currentTime).Ticks, periodEnd.Ticks));
        }

        private DateTime ChargeStartHour(DateTime currentTime)
        {
            return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, _chargeStartHour, 0, 0);
        }

        private DateTime ChargeEndHour(DateTime currentTime)
        {
            return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, _chargeEndHour, 0, 0);
        }
    }
}
