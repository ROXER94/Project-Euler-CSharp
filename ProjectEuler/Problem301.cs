using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of positive integers n ≤ 2^30 for which X(n,2n,3n) = 0 
        /// </summary>
        static void P301()
        {
            Console.WriteLine((from i in Enumerable.Range(1, (int)Math.Pow(2, 30)) where (i ^ 2 * i ^ 3 * i) == 0 select 1).Count());
        }
    }
}