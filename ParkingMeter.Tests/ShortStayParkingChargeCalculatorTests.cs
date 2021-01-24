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

            //Assert.AreEqual(HOURLY_RATE * , result);
            Assert.AreEqual(22.38, result);
        }

        public void CalculateTotalCharge_OverMixOfWeekdaysAndWeekends_ChargedAccordingly()
        {
            var calculator = new ShortStayParkingChargeCalculator(HOUR_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 24, 16, 50, 0), new DateTime(2021, 1, 26, 19, 15, 0));

            //Assert.AreEqual(HOURLY_RATE * , result);
            Assert.AreEqual(12.28, result);
        }
    }
}
