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

        public void FeedMoneyTransaction(double amountAdded, double updatedBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.UtcNow);
                    sw.Write($"     ${amountAdded}.00 was added the updated balance is now ${updatedBalance}.");
                    sw.WriteLine();
                }
            }
            catch (IOException e) 
            {
                Console.WriteLine("Error writing the file");
                Console.WriteLine(e.Message);
            }
        }

        public void PurchaseAProductTransaction(VendingMachineItem productPurchased, string productSlot)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.UtcNow);
                    sw.Write($"     {productPurchased.ProductName} was purchased from {productSlot} slot for ${productPurchased.ProductPrice}.  There are now {productPurchased.ProductQuantity} remaining.");
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
                    sw.Write($"     The ending balance was ${currentBalance}. The change given was {changeGiven.Quarters} quarter(s), {changeGiven.Dimes} dime(s), and {changeGiven.Nickels} nickel(s).  The transaction is now finished.");
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
