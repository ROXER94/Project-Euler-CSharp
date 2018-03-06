using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the index of the first term in the Fibonacci sequence to contain 1000 digits
        /// </summary>
        static void P025()
        {
            int ans = 0;
            while (Functions.getFibonacci(ans).ToString().Length < 1000)
                ans++;
            Console.WriteLine(ans);
        }
    }
}