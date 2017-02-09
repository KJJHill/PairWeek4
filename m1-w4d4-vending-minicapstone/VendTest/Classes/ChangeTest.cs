using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vend.Classes;

namespace VendTest.Classes
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void ChangeTests()
        {
            Change changeTest01 = new Change(1.00);
            Assert.AreEqual(4, changeTest01.Quarters);
            Assert.AreEqual(0, changeTest01.Dimes);
            Assert.AreEqual(0, changeTest01.Nickels);

            Change changeTest02 = new Change(12.00);
            Assert.AreEqual(48, changeTest02.Quarters);
            Assert.AreEqual(0, changeTest02.Dimes);
            Assert.AreEqual(0, changeTest02.Nickels);

            Change changeTest03 = new Change(1.10);
            Assert.AreEqual(4, changeTest03.Quarters);
            Assert.AreEqual(1, changeTest03.Dimes);
            Assert.AreEqual(0, changeTest03.Nickels);

            Change changeTest04 = new Change(12.20);
            Assert.AreEqual(48, changeTest04.Quarters);
            Assert.AreEqual(2, changeTest04.Dimes);
            Assert.AreEqual(0, changeTest04.Nickels);

            Change changeTest05 = new Change(1.15);
            Assert.AreEqual(4, changeTest05.Quarters);
            Assert.AreEqual(1, changeTest05.Dimes);
            Assert.AreEqual(1, changeTest05.Nickels);

            Change changeTest06 = new Change(12.35);
            Assert.AreEqual(49, changeTest06.Quarters);
            Assert.AreEqual(1, changeTest06.Dimes);
            Assert.AreEqual(0, changeTest06.Nickels);

            Change changeTest07 = new Change(12.25);
            Assert.AreEqual(49, changeTest07.Quarters);
            Assert.AreEqual(0, changeTest07.Dimes);
            Assert.AreEqual(0, changeTest07.Nickels);

            Change changeTest08 = new Change(12.40);
            Assert.AreEqual(49, changeTest08.Quarters);
            Assert.AreEqual(1, changeTest08.Dimes);
            Assert.AreEqual(1, changeTest08.Nickels);

        }
    }
}
