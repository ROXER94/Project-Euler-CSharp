﻿using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Get the last digits of a factorial
        /// </summary>
        /// <param name="n">Long</param>
        /// <param name="e">Int</param>
        /// <returns>The last e digits of n!</returns>
        public static long getFactorialLastDigits(long n, int e)
        {
            long a = 1;
            long b = 1;
            long c = (long)Math.Pow(10, e);
            long current;
            for (long i = 1; i <= n; i++)
            {
                current = i % 2 == 0 ? b * i : a * i;
                while (current % 10 == 0) { current /= 10; }
                if (i % 2 == 0) a = current % (n > c ? n : c);
                else b = current % (n > c ? n : c);
            }
            return n % 2 == 0 ? a % c : b % c;
        }

        /// <summary>
        /// Calculates the last five digits in 1,000,000,000,000!
        /// </summary>
        static void P160()
        {
            Console.WriteLine(getFactorialLastDigits((long)(Math.Pow(10, 12) / Math.Pow(5, 7)), 5));
        }
    }
}