using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vend.Classes;
using System.Collections.Generic;

namespace VendTest.Classes
{
    [TestClass]
    public class SalesReportWriterTest
    {
        [TestMethod]
        public void SalesReportWriterTests()
        {
            VendingMachineItem test1 = new VendingMachineItem("Potatoe Crisps", 3.05);
            test1.MinusProductQuantity();
            test1.MinusProductQuantity();

            VendingMachineItem test2 = new VendingMachineItem("Candy Bar", 0.85);
            test2.MinusProductQuantity();

            VendingMachineItem test3 = new VendingMachineItem("Gum", 1.00);

            VendingMachineItem test4 = new VendingMachineItem("Cola", 1.50);
            test4.MinusProductQuantity();
            test4.MinusProductQuantity();
            test4.MinusProductQuantity();
            test4.MinusProductQuantity();
            test4.MinusProductQuantity(); 

            Dictionary<string, VendingMachineItem> vendingTest = new Dictionary<string, VendingMachineItem>();
            vendingTest.Add("A1", test1);
            vendingTest.Add("B2", test2);
            vendingTest.Add("C3", test3);
            vendingTest.Add("D4", test4);

            SalesReportWriter salesReportTest = new SalesReportWriter(vendingTest);
            Assert.AreEqual(14.45, salesReportTest.TotalSales);
        }
    }
}
