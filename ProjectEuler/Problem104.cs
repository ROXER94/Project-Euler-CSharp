using ProjectEuler.Common;
using System;
using System.Numerics;

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
            BigInteger a = 0;
            BigInteger b = 1;
            while (true)
            {
                if (ans % 2 == 0) a += b;
                else b += a;
                if (Functions.isPandigital((long)(Functions.getFibonacci(ans) % 1000000000)) && Functions.isPandigital(Convert.ToInt64(Functions.getFibonacci(ans).ToString().Substring(0, 9))))
                    break;
                else ans++;
            }
            Console.WriteLine(ans);
        }
    }
}