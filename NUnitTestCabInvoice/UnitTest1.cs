using NUnit.Framework;
using CabInvoice;
using System.Collections.Generic;

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
        /// <summary>
        /// Givens the rides for different users should return invoice summary. UC4
        /// </summary>
        [Test]
        public void GivenRidesForDifferentUsersShouldReturnInvoiceSummary()
        {
            //Creating instance of invoice generator 
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            RideDetails[] rides = { new RideDetails(3, 5), new RideDetails(5, 4), new RideDetails(2, 5) };
            string firstUserId = "001";
            invoiceGenerator.AddRides(firstUserId, rides);
            string userIdForSecondUser = "002";
            RideDetails[] ridesForSecondUser = { new RideDetails(3, 10), new RideDetails(6, 2) };
            invoiceGenerator.AddRides(userIdForSecondUser, ridesForSecondUser);
            //Generating Summary for rides
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary(firstUserId);
            InvoiceSummary expectedSummary = new InvoiceSummary(3,114,38);
            //Asserting values with average in equals to formula in invoice summary
            Assert.AreEqual(expectedSummary, summary);
        }
        /// <summary>
        /// UC 5:
        /// This method takes distance and time and  returns total fare
        /// For Premium Rides
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ReturnsTotalFare_For_Premium_Ride()
        {
            double distance = 5.0;
            int time = 10;
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 95;
            /// Assert
            Assert.AreEqual(expectedFare, actualFare);
        }
    }
}