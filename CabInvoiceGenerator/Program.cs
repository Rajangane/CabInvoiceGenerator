// See https://aka.ms/new-console-template for more information
//Console.WriteLine("******************* Welcome To Cab Invoice Generator *******************");
using CabInvoiceGenerator;
InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
double fare = invoiceGenerator.CalculateFare(2.0, 5);
Console.WriteLine($"Fare : {fare}");