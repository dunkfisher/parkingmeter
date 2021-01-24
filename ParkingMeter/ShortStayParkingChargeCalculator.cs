using System;

namespace ParkingMeter
{
    public class ShortStayParkingChargeCalculator : IParkingChargeCaculator
    {
        private readonly decimal _hourRate;

        public ShortStayParkingChargeCalculator(decimal hourRate)
        {
            _hourRate = hourRate;
        }

        public decimal CalculateTotalCharge(DateTime periodStart, DateTime periodEnd)
        {
            return _hourRate;
        }
    }
}
