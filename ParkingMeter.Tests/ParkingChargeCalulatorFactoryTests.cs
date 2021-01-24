using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingMeter;

namespace ParkingMeter.Tests
{
    [TestClass]
    public class ParkingChargeCalulatorFactoryTests
    {
        [TestMethod]
        public void GetCalculator_UnknownPassed_ReturnsNull()
        {
            var factory = new ParkingChargeCalculatorFactory();

            var result = factory.GetCalculator(ParkingChargeType.Unknown);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCalculator_ShortPassed_ReturnsShortStayCalculator()
        {
            var factory = new ParkingChargeCalculatorFactory();

            var result = factory.GetCalculator(ParkingChargeType.ShortStay);

            Assert.IsInstanceOfType(result, typeof(ShortStayParkingChargeCalculator));
        }

        [TestMethod]
        public void GetCalculator_LongPassed_ReturnsLongStayCalculator()
        {
            var factory = new ParkingChargeCalculatorFactory();

            var result = factory.GetCalculator(ParkingChargeType.LongStay);

            Assert.IsInstanceOfType(result, typeof(LongStayParkingChargeCalculator));
        }
    }
}
