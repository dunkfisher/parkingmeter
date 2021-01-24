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
            return _dayRate;
        }
    }
}
