using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vend.Classes;

namespace VendTest.Classes
{
    [TestClass]
    public class VendMachineTest
    {
        [TestMethod]
        public void LoadInventoryTest()
        {
            VendMachine testVendMachine = new VendMachine();
            testVendMachine.LoadInventory();
            Assert.AreEqual("Potato Crisps",testVendMachine.ItemsStocked["A1"].ProductName);
            Assert.AreEqual("Grain Waves", testVendMachine.ItemsStocked["A3"].ProductName);
            Assert.AreEqual(1.80, testVendMachine.ItemsStocked["B1"].ProductPrice);
            Assert.AreEqual(5, testVendMachine.ItemsStocked["C1"].ProductQuantity);
        }

        [TestMethod]
        public void FeedMoneyTest()
        {
            VendMachine testVendMachine = new VendMachine();
            testVendMachine.LoadInventory();
            Assert.AreEqual(0, testVendMachine.CurrentBalance);
            testVendMachine.FeedMoney(50);
            Assert.AreEqual(50, testVendMachine.CurrentBalance);
        }

        [TestMethod]
        public void PurchaseAnItemTest()
        {
            VendMachine testVendMachine = new VendMachine();
            testVendMachine.LoadInventory();
            testVendMachine.FeedMoney(10);
            testVendMachine.PurchaseAProduct("A1");
            Assert.AreEqual(4,testVendMachine.ItemsStocked["A1"].ProductQuantity);
            Assert.AreEqual(6.95, testVendMachine.CurrentBalance);
        }
        
        [TestMethod]
        public void FinishTransactionTest()
        {

        }
    }
}
