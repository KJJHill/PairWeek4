using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vend.Classes;

namespace Vend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VendMachine bats = new VendMachine();
            bats.LoadInventory();
            foreach (KeyValuePair<string, VendingMachineItem> kvp in bats.ItemsStocked)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.ProductName} {kvp.Value.ProductPrice} {kvp.Value.ProductQuantity}");
            }
        }
    }
}
