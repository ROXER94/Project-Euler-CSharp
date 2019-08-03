using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the multipliers k for which the least positive multiple n*k, written in base 10, uses only digits ≤ 2, from 1 to 10,000
        /// </summary>
        static void P303()
        {
            long ans = 1;
            IDictionary<int, long> multiplesDict = new Dictionary<int, long>();
            var base3 = (from i in Enumerable.Range(1, 25000000) select Functions.getConvertBaseFromDecimal(i, 3));
            for (int i = 1; i < 9999; i++)
            {
                if (!multiplesDict.ContainsKey(i))
                    foreach (long m in base3)
                        if (m % i == 0)
                        {
                            multiplesDict[i] = m;
                            break;
                        }
                multiplesDict[10 * i] = 10 * multiplesDict[i];
                ans += multiplesDict[i] / i;
            }
            ans += (long)(11112222222222222222 / 9999);
            Console.WriteLine(ans);
        }
    }
}