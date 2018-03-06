using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the numerator of the fraction immediately to the left of 3/7 in the sorted set of reduced proper fractions for d ≤ 1,000,000
        /// </summary>
        static void P071()
        {
            Console.WriteLine(1000000 / 7 * 3 - 1);
        }
    }
}