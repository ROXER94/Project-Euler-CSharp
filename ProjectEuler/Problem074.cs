using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of starting numbers below 1,000,000 that produce a digit factorial chain of exactly sixty non-repeating terms
        /// </summary>
        static void P074()
        {
            int ans = 0;
            for (int i = 1; i < 1000000; i++)
            {
                int j = i;
                HashSet<int> chain = new HashSet<int>();
                int currentCount = 0;
                while (true)
                {
                    chain.Add(i);
                    currentCount++;
                    int digitFactorial = (int)i.ToString().Select(c => Functions.getFactorial((int)Char.GetNumericValue(c))).Aggregate(BigInteger.Add);
                    if (chain.Contains(digitFactorial)) break;
                    i = digitFactorial;
                }
                if (currentCount == 60) ans++;
                i = j;
            }
            Console.WriteLine(ans);
        }
    }
}