using System;

namespace ParkingMeter
{
    public class LongStayParkingChargeCalculator : IParkingChargeCaculator
    {
        private readonly decimal _dayRate;

        public LongStayParkingChargeCalculator(decimal dayRate)
        {
            _dayRate = dayRate;
        }

        public decimal CalculateTotalCharge(DateTime periodStart, DateTime periodEnd)
        {
            var totalCharge = 0.0m;
            do
            {
                totalCharge += _dayRate;
                periodStart = periodStart.AddDays(1);
            }
            while (periodStart.Date <= periodEnd.Date);
            return totalCharge;
        }
    }
}
