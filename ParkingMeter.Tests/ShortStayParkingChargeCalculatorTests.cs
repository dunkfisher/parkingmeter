using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParkingMeter.Tests
{
    [TestClass]
    public class ShortStayParkingChargeCalculatorTests
    {
        const decimal HOUR_RATE = 1.1m;

        [TestMethod]        
        public void CalculateTotalCharge_ForWeekdayEvening_NothingCharged()
        {
            var calculator = new ShortStayParkingChargeCalculator(HOUR_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 25, 19, 0, 0), new DateTime(2021, 1, 26, 7, 0, 0));

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateTotalCharge_ForWeekend_NothingCharged()
        {
            var calculator = new ShortStayParkingChargeCalculator(HOUR_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 30, 8, 0, 0), new DateTime(2021, 1, 30, 17, 0, 0));

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateTotalCharge_OverSeveralWeekdays_ChargedAccordingly()
        {
            var calculator = new ShortStayParkingChargeCalculator(HOUR_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 25, 16, 50, 0), new DateTime(2021, 1, 27, 19, 15, 0));

            Assert.AreEqual(23.28m, Math.Round(result, 2));
        }

        [TestMethod]
        public void CalculateTotalCharge_OverMixOfWeekdaysAndWeekends_ChargedAccordingly()
        {
            var calculator = new ShortStayParkingChargeCalculator(HOUR_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 28, 16, 50, 0), new DateTime(2021, 1, 30, 19, 15, 0));

            Assert.AreEqual(12.28m, Math.Round(result, 2));
        }
    }
}
