using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the maximum remainders of ((a−1)^n + (a+1)^n) / a^2 for 3 ≤ a ≤ 1000
        /// </summary>
        static void P120()
        {
            Console.WriteLine((from a in Enumerable.Range(3, 998) select (a + a % 2 - 2) * a).Sum());
        }
    }
}