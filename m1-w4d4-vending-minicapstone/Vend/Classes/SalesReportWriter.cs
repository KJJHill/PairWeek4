using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vend.Classes
{
    public class SalesReportWriter
    {
        /* Hidden option 0 on the start menu
         * Writes to Vendo-Matic-Sales-[Date/Time]-csv file
         * Displays all of the Items in the vending machine
         * Their current quantity
         * 
         * Calculates the sales based on current quantity
         * If any product haven't sold they are marked with an asterisk
         * These products are low performers
         * 
         * Gets passed the vending machine
         * SalesReportWriter(VendMachine)
         *  */

        private string directory = Environment.CurrentDirectory;
        private string fileName;
        private string fullPath;

        private double totalSales = 0;
        public double TotalSales
        {
            get { return totalSales; }
        }

        public SalesReportWriter(Dictionary<string, VendingMachineItem> remainingVendingProducts)
        {
            string dateTime = DateTime.UtcNow.ToString().Replace('/', '-').Replace(':', '.');
            fileName = "Vendo-Matic-Sales " + dateTime + ".csv";
            fullPath = Path.Combine(directory, fileName);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    foreach (KeyValuePair<string, VendingMachineItem> kvp in remainingVendingProducts)
                    {
                        sw.Write(kvp.Value.ProductName + "," + kvp.Value.ProductQuantity.ToString());

                        if (kvp.Value.ProductQuantity == 5)
                        {
                            sw.Write(", *Low Performer*");
                        }

                        sw.WriteLine();

                        totalSales += (5 - kvp.Value.ProductQuantity) * kvp.Value.ProductPrice;
                    }
                    sw.WriteLine();
                    sw.WriteLine("**TOTAL SALES** , $" + totalSales);
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
