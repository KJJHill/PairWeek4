using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vend.Classes
{
    public class VendMachine
    {
        /* Items in vending machine stored in a dictionary
         * Current balance stored in a double
         * 
         * METHODS
         * FeedMoney(double input)
         * updates current balance
         * Writes to the log file
         * 
         * PurchaseAProduct(string slotNumber)
         * Update stock of item in dictionary
         * Update currentBalance
         * Write to the log file
         * 
         * FinishTransaction()
         * return current balance in change
         * writes to the log file
         * 
         * PROPERTIES
         * ItemsStocked
         * CurrentBalance
         *  */

        private Dictionary<string, VendingMachineItem> itemsStocked = new Dictionary<string, VendingMachineItem>();
        public Dictionary<string, VendingMachineItem> ItemsStocked
        {
            get { return itemsStocked; }
        }

        private double currentBalance;
        public double CurrentBalance
        {
            get { return currentBalance; }
        }

        public void FeedMoney(double moneyInserted)
        {
            if (moneyInserted >= 0)
            {
                currentBalance += moneyInserted;
            }
            if (moneyInserted < 0)
            {
                Console.WriteLine("That's stealing!!!");
            }
            LogWriter newLog = new LogWriter();
            newLog.FeedMoneyTransaction(moneyInserted,currentBalance);
        }
        public void PurchaseAProduct(string slotNumber)
        {
             if (itemsStocked[slotNumber].ProductQuantity > 0 && currentBalance >= itemsStocked[slotNumber].ProductPrice)
             {
                itemsStocked[slotNumber].MinusProductQuantity();
                currentBalance -= itemsStocked[slotNumber].ProductPrice;
                Console.WriteLine($"Enjoy your {itemsStocked[slotNumber].ProductName}, there are {currentBalance} dollars remaining in the machine");
             }
             if (itemsStocked[slotNumber].ProductQuantity <= 0)
            {
                Console.WriteLine("Item is out of stock!");
            }
             if (currentBalance < itemsStocked[slotNumber].ProductPrice)
            {
                Console.WriteLine("You haven't inserted enough money to buy that!");
            }
            LogWriter newLog = new LogWriter();
            newLog.PurchaseAProductTransaction(itemsStocked[slotNumber],slotNumber);
        }

        public void FinishTransaction()
        {

            Change currentChange = new Change(currentBalance);
            Console.WriteLine($"Your change is {currentChange.Quarters} quarters, {currentChange.Dimes} dimes, and {currentChange.Nickels} nickels.");
            LogWriter newLog = new LogWriter();
            newLog.FinishedTransaction(currentBalance,currentChange);
        }

        public void LoadInventory()
        {
            string directory = @"C:\Users\ncollins\c-week4-pair-exercises\m1-w4d4-vending-minicapstone";
            string filename = "vendingmachine.csv";

            string fullPath = Path.Combine(directory, filename);

            List<string> allWords = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] words = line.Split('|');

                        allWords.AddRange(words);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < allWords.Count - 2; i += 3)
            {
                VendingMachineItem tempItem = new VendingMachineItem(allWords[i + 1], double.Parse(allWords[i + 2]));
                itemsStocked.Add(allWords[i], tempItem);
            }
        }
    }
}
