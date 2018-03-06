using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of regular hexagons that can be found by connecting six triangular lattice points in an equilateral triangle with side lengths of 3 to 12345
        /// </summary>
        static void P577()
        {
            Console.WriteLine((from n in Enumerable.Range(3, 12343) select (from i in Enumerable.Range(3, (int)n) where i % 3 == 0 select (long)i * (n - i + 1) * (n - i + 2) / 6).Sum()).Sum());
        }
    }
}