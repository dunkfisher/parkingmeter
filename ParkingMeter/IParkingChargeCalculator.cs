using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingMeter
{
    public interface IParkingChargeCalculator
    {
        decimal CalculateTotalCharge(DateTime periodStart, DateTime periodEnd);
    }
}
