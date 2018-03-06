using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the smallest member of an Amicable Chain
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>Returns the smallest member of an Amicable Chain</returns>
        static int getMinAmicableChain(int n)
        {
            HashSet<int> hs = new HashSet<int>();
            while (!hs.Contains(n))
            {
                hs.Add(n);
                n = (int)Functions.getFactors(n).Sum() - n;
            }
            return hs.Min();
        }

        /// <summary>
        /// Calculates the smallest member of the longest amicable chain with no element exceeding 1,000,000
        /// </summary>
        static void P095()
        {
            SortedSet<int> ans = new SortedSet<int>();
            int maximumChainCount = 0;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 2; i < 6000; i += 2)
            {
                int j = i;
                if (!seen.Contains(i))
                {
                    SortedSet<int> chain = new SortedSet<int>();
                    while (!chain.Contains(i))
                    {
                        chain.Add(i);
                        i = (int)Functions.getFactors(i).Sum() - i;
                        seen.Add(i);
                        if (i % 2 == 1 || i < 220 || i > 1000000)
                        {
                            chain = new SortedSet<int>();
                            break;
                        }
                    }
                    int currentChainCount = chain.Count;
                    if (currentChainCount > maximumChainCount)
                    {
                        maximumChainCount = currentChainCount;
                        ans = chain;
                    }
                }
                i = j;
            }
            Console.WriteLine(getMinAmicableChain(ans.Last()));
        }
    }
}