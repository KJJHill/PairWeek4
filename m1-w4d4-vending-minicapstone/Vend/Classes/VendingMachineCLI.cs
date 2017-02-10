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

        public VendingMachineCLI(VendMachine theVendingMachine, Menus theMenus)
        {
            theVendingMachine.LoadInventory();
            string startMenuInput = "";
            while (true)
            // The above while-loop holds the entire program
            // Should not be broken until you turn the vending machine off
            {
                Console.WriteLine("\nPress (1) to go to the display menu.");
                Console.WriteLine("Press (2) to go to the purchase menu.");

                //string purchaseMenuInput = "";

                while (true)
                // This while loops runs the Main menu of the CLI
                // You break it when you want to continue to the Purchase menu
                {
                    startMenuInput = Console.ReadLine();

                    if (startMenuInput == "1")
                    {
                        theMenus.DisplayProducts();
                        break;
                    }

                    if (startMenuInput == "2")
                    {
                        theMenus.DisplayPurchaseMenu();
                        break;
                    }
                    if (startMenuInput == "0")
                    {
                        SalesReportWriter salesReport = new SalesReportWriter(theVendingMachine.ItemsStocked);
                        salesReport.WriteSalesReport();
                    }

                }
            }
        }
    }
}
