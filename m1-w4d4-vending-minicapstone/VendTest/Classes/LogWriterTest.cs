using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vend.Classes;

namespace VendTest.Classes
{
    [TestClass]
    public class LogWriterTest
    {
        [TestMethod]
        public void LogWriterTests()
        {
            LogWriter logTest = new LogWriter();
            logTest.FeedMoneyTransaction(12, 3.25);

            VendingMachineItem itemTest = new VendingMachineItem("Potato Crisps", 0.85);
            logTest.PurchaseAProductTransaction(itemTest);

            Change changeTest = new Change(25.65);
            logTest.FinishedTransaction(25.65, changeTest);

        }
    }
}
