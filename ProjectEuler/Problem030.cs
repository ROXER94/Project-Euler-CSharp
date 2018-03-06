using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all the numbers that can be written as the sum of fifth powers of their digits
        /// </summary>
        static void P030()
        {
            Console.WriteLine((from i in Enumerable.Range(2, (int)(6 * Math.Pow(9, 5) - 2)) where (from c in i.ToString() select (int)Math.Pow(Char.GetNumericValue(c), 5)).Sum() == i select i).Sum());
        }
    }
}