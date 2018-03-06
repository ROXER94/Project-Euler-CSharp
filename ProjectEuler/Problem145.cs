using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is reversible
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is reversible</returns>
        static bool isReversible(int n)
        {
            if (n.ToString()[n.ToString().Length - 1] == '0') return false;
            string test = (n + Int32.Parse(new String(n.ToString().ToCharArray().Reverse().ToArray()))).ToString();
            if (test.Contains('0') || test.Contains('2') || test.Contains('4') || test.Contains('6') || test.Contains('8')) return false;
            return true;
        }

        /// <summary>
        /// Calculates the number of reversible numbers below 1,000,000,000
        /// </summary>
        static void P145()
        {
            Console.WriteLine((from i in Enumerable.Range(1, 100000000) where isReversible(i) select 1).Count());
        }
    }
}