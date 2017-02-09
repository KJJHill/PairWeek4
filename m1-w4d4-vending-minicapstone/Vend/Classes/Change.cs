using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend.Classes
{
    public class Change
    {
        /* This class returns change to the customer in nickels, dimes, and quarters
         *  Should return as few coins as possible.
         *  
         *  Nickels
         *  Dimes
         *  Quarters
         *  
         *  
         *  Variable/Property for each coin type */

        private int nickels;
        public int Nickels
        {
            get { return nickels; }
        }

        private int dimes;
        public int Dimes
        {
            get { return dimes; }
        }

        private int quarters;

        public int Quarters
        {
            get { return quarters; }
        }

        public Change(double balance)
        {
            int balanceInCents = (int)Math.Round((balance*100));
            int remainder = 0;

            quarters = Math.DivRem(balanceInCents, 25, out remainder);

            if (remainder >= 10)
            {
                dimes = Math.DivRem(remainder, 10, out remainder);
            }

            if (remainder >= 5)
            {
                nickels = remainder / 5;
            }
        }

    }
}
