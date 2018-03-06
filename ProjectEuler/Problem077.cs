using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the first number which can be written as the sum of primes in over 5000 different ways
        /// </summary>
        static void P077()
        {
            int ans = 0;
            IDictionary<int, long> primesDict = new Dictionary<int, long>();
            foreach (long p in Functions.getPrimesList(100))
                primesDict[primesDict.Count + 1] = p;
            int primeSummationCount = 0;
            while (primeSummationCount <= 5000)
            {
                ans++;
                int[] ways = new int[ans+1];
                ways[0] = 1;
                for (int i = 1; i <= primesDict.Count; i++)
                    for (int j = (int)primesDict[i]; j <= ans; j++)
                        ways[j] = ways[j] + ways[j - primesDict[i]];
                primeSummationCount = ways[ans];
            }
            Console.WriteLine(ans);
        }
    }
}