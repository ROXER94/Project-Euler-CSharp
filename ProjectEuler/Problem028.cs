using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the numbers on the diagonals in a 1001x1001 spiral
        /// </summary>
        static void P028()
        {
            Console.WriteLine((from i in Enumerable.Range(3, 1000) where i % 2 != 0 select 4 * i * i - 6 * i + 6).Sum() + 1);
        }
    }
}