using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the least value of n for which the number of distinct solutions of the equation x^-1 + y^-1 = n^-1 exceeds 1000
        /// </summary>
        static void P108()
        {
            int ans = 0;
            while (Functions.getFactors((long)Math.Pow(ans, 2)).Count < 2000)
                ans += (2 * 3 * 5 * 7);
            Console.WriteLine(ans);
        }
    }
}