using NUnit.Framework;
using CabInvoice;

namespace NUnitTestCabInvoice
{
    public class Tests
    {
        /// <summary>
        /// UC 1:
        /// This method takes distance and time and  returns total fare
        /// </summary>
        public InvoiceGenerator invoiceGenerator ;

        [Test]
        public void GivenDistanceAndTime_ReturnsTotalFare()
        {
            double distance = 5.0;
            int time = 10;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 60.0;
            /// Assert
            Assert.AreEqual(expectedFare, actualFare);
        }
    }
}