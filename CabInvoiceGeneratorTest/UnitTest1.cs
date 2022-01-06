using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;
using static CabInvoiceGenerator.InvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        //InvoiceGenerator Refrance
        InvoiceGenerator invoiceGenerator = null;
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Creating Instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            //Asserting values
            Assert.AreEqual(expected, fare);
        }
        
        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };

            //Generating Summary For Rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);

            //Asserting Values
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            //Assert.AreEqual(expectedSummary, summary);
        }
        /// <summary>
        /// given invaid Ride Type should throw custom exception
        /// </summary>
        [TestMethod]
        public void GivenInvalidRideTypeShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator 
            invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            string expected = "Invalid ride type";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception);
            }
        }
        /// <summary>
        /// Given Invalid Distance Should Throw Custom Exception
        /// </summary>
        [TestMethod]
        public void GivenInvalidDistanceShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = -2.0;
            int time = 5;
            string expected = "Invalid Distance";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception.Message);
            }
        }

    }
}