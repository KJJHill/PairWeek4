using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend.Classes
{
    public class VendingMachineItem
    {
        /* Creates an object for each vending machine item
         * 
         * Takes each line from the file reader and turns it into an object
         * Each object will have Name, price, and stock.
         * Stock defaults to 5
         * 
         * Stored in the dictionary in a slot number
         * 
         * ProductName
         * ProductPrice
         * ProductQuantity
         * 
         * 
         *  */

        private string productName;
        private double productPrice;
        private int productQuantity = 5;

        public string ProductName
        {
            get { return productName; }
        }

        public double ProductPrice
        {
            get { return productPrice; }
        }

        public int ProductQuantity
        {
            get { return productQuantity; }
        }

        public VendingMachineItem(string productName, double productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }
        public void MinusProductQuantity()
        {
            productQuantity -= 1;
        }
    }
}
