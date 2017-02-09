using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vend.Classes
{
    public class LogWriter
    {
        /* When you take in money:
         * Displays the date/time
         * Amount of money added
         * Current Balance
         * 
         * Upon Purchase:
         * Display date and time
         * cost of item
         * Updated balance
         * 
         * Finish Transaction:
         * Date/Time
         * Final Balance
         * Coin Count
         * 
         * 
         * 
         * Writes to TransactionLog.txt 
         */

        private string directory = Environment.CurrentDirectory;
        private string fileName = "TransactionLog.txt";
        private string fullPath;

        public LogWriter()
        {
            fullPath = Path.Combine(directory, fileName);
        }

        public void FeedMoneyTransaction(int amountAdded, double updatedBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.UtcNow);
                    sw.Write("     ${0}.00 was added the updated balance is now ${1}.", amountAdded, updatedBalance);
                    sw.WriteLine();
                }
            }
            catch (IOException e) 
            {
                Console.WriteLine("Error writing the file");
                Console.WriteLine(e.Message);
            }
        }

        public void PurchaseAProductTransaction(VendingMachineItem productPurchased)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.UtcNow);
                    sw.Write("     {0} was purchased from {1} slot for ${2}.  There are now {3} remaining.",
                        productPurchased.ProductName, "[INSERT SLOT PARAMETER HERE]", productPurchased.ProductPrice, productPurchased.ProductQuantity);
                    sw.WriteLine();
                }
            }
            catch (IOException e) 
            {
                Console.WriteLine("Error writing the file");
                Console.WriteLine(e.Message);
            }
        }

        public void FinishedTransaction(double currentBalance, Change changeGiven)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.UtcNow);
                    sw.Write("     The ending balance was {0}. The change given was {1} quarters, {2} dime(s), {3} nickel.  The transaction is now finished.",
                        currentBalance, changeGiven.Quarters, changeGiven.Dimes, changeGiven.Nickels);
                    sw.WriteLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error writing the file");
                Console.WriteLine(e.Message);
            }
        }
    }
}
