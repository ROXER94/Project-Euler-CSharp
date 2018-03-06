using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is equal to the sum of its digits raised to some power
        /// </summary>
        /// <param name="n">Long</param>
        /// <returns>True if a number is equal to the sum of its digits raised to some power</returns>
        static bool isDigitPowerSum(long n)
        {
            int sum = n.ToString().Select(c => (int)Char.GetNumericValue(c)).Sum();
            if (sum == 1) return false;
            while ((double)n / sum % 1 == 0) n /= sum;
            if (n == 1) return true;
            else return false;
        }

        /// <summary>
        /// Calculates the 30th number for which the sum of its digits is some number raised to a power
        /// </summary>
        static void P119()
        {
            SortedSet<long> digitPowerSums = new SortedSet<long>();
            for (int b = 3; b < 70; b++)
                for (int e = 3; e < 10; e++)
                    if (isDigitPowerSum((long)Math.Pow(b, e)))
                        digitPowerSums.Add((long)Math.Pow(b, e));
            Console.WriteLine(digitPowerSums.ElementAt(29));
        }
    }
}