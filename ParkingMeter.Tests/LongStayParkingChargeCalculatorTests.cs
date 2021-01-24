using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParkingMeter.Tests
{
    [TestClass]
    public class LongStayParkingChargeCalculatorTests
    {
        const decimal DAY_RATE = 7.5m;

        [TestMethod]
        public void CalculateTotalCharge_ForSingleDay_ChargedAccordingly()
        {
            var calculator = new LongStayParkingChargeCalculator(DAY_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 25, 7, 50, 0), new DateTime(2021, 1, 25, 22, 0, 0));

            Assert.AreEqual(DAY_RATE * 1, result);
        }

        [TestMethod]
        public void CalculateTotalCharge_ForSeveralDays_ChargedAccordingly()
        {
            var calculator = new LongStayParkingChargeCalculator(DAY_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 25, 7, 50, 0), new DateTime(2021, 1, 27, 5, 20, 0));

            Assert.AreEqual(DAY_RATE * 3, result);
        }

        [TestMethod]
        public void CalculateTotalCharge_ForSeveralDaysAcrossTwoMonths_ChargedAccordingly()
        {
            var calculator = new LongStayParkingChargeCalculator(DAY_RATE);

            var result = calculator.CalculateTotalCharge(new DateTime(2021, 1, 30, 7, 50, 0), new DateTime(2021, 2, 1, 5, 20, 0));

            Assert.AreEqual(DAY_RATE * 3, result);
        }
    }
}