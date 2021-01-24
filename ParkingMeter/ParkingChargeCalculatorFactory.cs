namespace ParkingMeter
{
    public class ParkingChargeCalculatorFactory
    {
        const decimal HOUR_RATE = 1.1m;
        const decimal DAY_RATE = 7.5m;

        public IParkingChargeCaculator GetCalculator(ParkingChargeType chargeType)
        {
            switch (chargeType)
            {
                case ParkingChargeType.ShortStay:
                    return new ShortStayParkingChargeCalculator(HOUR_RATE);
                case ParkingChargeType.LongStay:
                    return new LongStayParkingChargeCalculator(DAY_RATE);
                default:
                    return null;
            }
        }
    }

    public enum ParkingChargeType
    {
        Unknown,
        ShortStay,
        LongStay
    }
}
