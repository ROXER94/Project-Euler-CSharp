using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used to memoize the Collatz sequence
        /// </summary>
        static IDictionary<long, long> collatzDict = new Dictionary<long, long>();

        /// <summary>
        /// Gets the length of the Collatz chain of a number via memoization
        /// </summary>
        /// <param name="n">Long</param>
        /// <returns>The length of the Collatz sequence of n</returns>
        public static long getCollatz(long n)
        {
            if (!collatzDict.ContainsKey(n))
                collatzDict[n] = getCollatzUncached(n);
            return collatzDict[n];
        }

        /// <summary>
        /// Gets the length of the Collatz chain of a number via recursion
        /// </summary>
        /// <param name="n">Long</param>
        /// <returns>The length of the Collatz sequence of n</returns>
        public static long getCollatzUncached(long n)
        {
            if (n == 1) return 1;
            else if (n % 2 != 0) return 2 + getCollatz((3 * n + 1) / 2);
            else return 1 + getCollatz(n / 2);
        }

        /// <summary>
        /// Calculates the number under one million that produces the longest Collatz sequence
        /// </summary>
        static void P014()
        {
            long ans = 0;
            long chain = 0;
            for (long i = 1; i < 1000000; i++)
            {
                getCollatz(i);
                if (collatzDict[i] > chain)
                {
                    chain = collatzDict[i];
                    ans = i;
                }
            }
            Console.WriteLine(ans);
        }
    }
}