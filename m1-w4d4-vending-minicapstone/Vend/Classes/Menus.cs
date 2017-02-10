using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend.Classes
{
    public class Menus
    {
        private VendMachine theVendingMachine;
        public Menus(VendMachine theVendingMachine)
        {
            this.theVendingMachine = theVendingMachine;
        }

        public void DisplayProducts()
        {
            foreach (KeyValuePair<string, VendingMachineItem> kvp in theVendingMachine.ItemsStocked)
            {
                if (kvp.Value.ProductQuantity <= 0)
                {
                    Console.WriteLine($"{kvp.Key} is sold out!");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key} {kvp.Value.ProductQuantity} {kvp.Value.ProductName} Remain. They are {kvp.Value.ProductPrice} each.");
                }
            }
            Console.WriteLine("\n\n");
        }
        public void DisplayPurchaseMenu()
        {
            string purchaseMenuInput = "";
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("\nPress (1) to input money.");
                    Console.WriteLine("Press (2) to select an item.");
                    Console.WriteLine("Press (3) to finish the transaction.");
                    purchaseMenuInput = Console.ReadLine();

                    if (purchaseMenuInput != "1" && purchaseMenuInput != "2" && purchaseMenuInput != "3")
                    {
                        Console.WriteLine("Wrong input, try again!");
                    }
                    else
                    {
                        break;
                    }
                }

                if (purchaseMenuInput == "1")
                {

                    Console.WriteLine("\n\n\nHow much money do you want to input?(1.00)(2.00)(5.00)(10.00)");
                    while (true)
                    {
                        string cashInput = Console.ReadLine();

                        theVendingMachine.FeedMoney(double.Parse(cashInput));

                        Console.WriteLine($"There are {theVendingMachine.CurrentBalance} dollars in the machine");
                        break;
                    }
                }
                if (purchaseMenuInput == "2")
                {
                    Console.WriteLine("What item do you want to purchase? (A1-D4)");
                    string selectedProduct = Console.ReadLine();
                    if (theVendingMachine.ItemsStocked.ContainsKey(selectedProduct))
                    {
                        theVendingMachine.PurchaseAProduct(selectedProduct);
                    }
                }
                if (purchaseMenuInput == "3")
                {
                    theVendingMachine.FinishTransaction();
                    break;
                }
            }
        }
    }
}
