using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the first triangle number to have over five hundred divisors
        /// </summary>
        static void P012()
        {
            int ans = 1;
            while (true)
            {
                if (Functions.getFactors(Functions.getTriangle(ans)).Count > 500) break;
                ans++;
            }
            Console.WriteLine(Functions.getTriangle(ans));
        }
    }
}