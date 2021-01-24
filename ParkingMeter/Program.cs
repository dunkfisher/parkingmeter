using System;

namespace ParkingMeter
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingChargeType chargeType;
            DateTime periodStart, periodEnd;
            if (!ValidateInput(args, out chargeType, out periodStart, out periodEnd))
            {                
                Environment.Exit(1);
            }

            var chargeCalculator = new ParkingChargeCalculatorFactory().GetCalculator(chargeType);
            if (chargeCalculator == null)
            {
                Environment.Exit(1);
            }

            var totalChargeGbp = chargeCalculator.CalculateTotalCharge(periodStart, periodEnd);
            Console.WriteLine($"{totalChargeGbp:C2}");

            Console.ReadKey();
        }

        static bool ValidateInput(string[] rawInput, out ParkingChargeType chargeType, out DateTime periodStart, out DateTime periodEnd)
        {
            chargeType = ParkingChargeType.ShortStay;
            periodStart = periodEnd = DateTime.MinValue;
            return rawInput != null && rawInput.Length == 3 && Enum.TryParse(rawInput[0], out chargeType)
                && DateTime.TryParse(rawInput[1], out periodStart) && DateTime.TryParse(rawInput[2], out periodEnd);            
        }
    }
}
