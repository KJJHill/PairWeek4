using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend.Classes
{
    class VendingMachineCLI
    {
        /* Determines which menu to display
         * Initially it displays the start menu
         * Start menu has (1) purchase menu and (2) display menu as options
         * 
         * Purchase menu:
         * (1) Feed Money
         * (2) Select Product
         * (3) Finish Transaction
         * Current Balance
         * 
         * This menu loops until finish transaction is selected */

        public VendingMachineCLI(VendMachine theVendingMachine)
        {
            theVendingMachine.LoadInventory();
            while (true)
            {
                Console.WriteLine("Press (1) to go to the purchase menu.");
                Console.WriteLine("Press (2) to go to the display menu.");

                bool correctInput = false;
                bool purchaseMenuCorrectInput = false;
                string purchaseMenuInput = "";
                do
                {
                    string startMenuInput = Console.ReadLine();
                    if (startMenuInput == "1")
                    {
                        do
                        {
                            Console.WriteLine("Press (1) to input money.");
                            Console.WriteLine("Press (2) to select an item.");
                            Console.WriteLine("Press (3) to finish the transaction.");
                            purchaseMenuInput = Console.ReadLine();

                            if (purchaseMenuInput != "1" && purchaseMenuInput != "2" && purchaseMenuInput != "3")
                            {
                                Console.WriteLine("Wrong input idiot, try again!");
                            }
                            else
                            {
                                purchaseMenuCorrectInput = true;
                            }
                        } while (!purchaseMenuCorrectInput);
                        
                        correctInput = true;
                    }
                    if (startMenuInput == "2")
                    {
                        foreach (KeyValuePair<string, VendingMachineItem> kvp in theVendingMachine.ItemsStocked)
                        {
                            Console.WriteLine($"{kvp.Key} {kvp.Value.ProductQuantity} {kvp.Value.ProductName} Remain. They are {kvp.Value.ProductPrice} each.");
                        }
                        correctInput = true;
                    }
                } while (!correctInput);

                if (purchaseMenuInput == "1")
                {
                    Console.WriteLine("How much money do you want to input? (.05)(.10)(.25)(1.00)(5.00)(10.00)(20.00)");
                    Console.WriteLine("Say (STOP) when you're done inputting money.");
                    double cashCounter = 0;
                    bool shouldStop = false;
                    do
                    {
                        string cashInput = Console.ReadLine();
                        if (cashInput == "STOP")
                        {
                            shouldStop = true;
                        }
                        else
                        {
                            theVendingMachine.FeedMoney(double.Parse(cashInput));
                            cashCounter += double.Parse(cashInput);
                        }
                        Console.WriteLine($"There are {cashCounter} dollars in the machine");
                    } while (!shouldStop);
                }
                if (purchaseMenuInput == "2")
                {
                    Console.WriteLine("What item do you want to purchase? (A1-D4)");
                    theVendingMachine.PurchaseAProduct(Console.ReadLine());
                }
                if (purchaseMenuInput == "3")
                {
                    theVendingMachine.FinishTransaction();
                }
            }
        }
    }
}
