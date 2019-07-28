using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the index of the first Fibonacci number for which the first and last nine digits are 1-9 pandigital
        /// </summary>
        static void P104()
        {
            int ans = 1;
            while (!Functions.isPandigital((long)(Functions.getFibonacci(ans) % 1000000000)) || !Functions.isPandigital(Convert.ToInt64(Functions.getFibonacci(ans).ToString().Substring(0, 9))))
                ans++;
            Console.WriteLine(ans);

        }
    }
}