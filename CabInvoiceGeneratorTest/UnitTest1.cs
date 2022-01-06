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
    }
}