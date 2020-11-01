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
        /// <summary>
        /// UC 3 : 
        /// Given multiple rides should return invoice summary with aggregate totalFare
        /// Also included Average of fares
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            // Arrange
            RideDetails[] rides = { new RideDetails(3, 5), new RideDetails(5, 4), new RideDetails(2, 5)};
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 114, 38);
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            // Act
            InvoiceSummary actualSummary = invoiceGenerator.CalculateFare(rides);
            //Assert
            Assert.AreEqual(expectedSummary, actualSummary);
        }
    }
}