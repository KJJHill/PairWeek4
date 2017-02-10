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
            VendMachine newVendingMachine = new VendMachine();
            Menus runningMenus = new Menus(newVendingMachine);
            VendingMachineCLI runningMachine = new VendingMachineCLI(newVendingMachine, runningMenus);
        }
    }
}
