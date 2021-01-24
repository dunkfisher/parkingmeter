using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingMeter
{
    public interface IParkingChargeCaculator
    {
        decimal CalculateTotalCharge(DateTime periodStart, DateTime periodEnd);
    }
}
