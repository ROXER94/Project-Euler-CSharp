using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the number of t ≤ 1000000 such that t is type L(n) for 1 ≤ n ≤ 10
        /// </summary>
        static void P174()
        {
            int n = 1000000;
            IDictionary<long, int> tilesDict = new Dictionary<long, int>();
            for (int l = 3; l <= n / 4 + 1; l++)
                for (int s = l - 2; s > 0; s -= 2)
                {
                    int currentValue = l * l - s * s;
                    if (currentValue <= n)
                    {
                        if (tilesDict.ContainsKey(currentValue))
                            tilesDict[currentValue]++;
                        else
                            tilesDict.Add(currentValue, 1);
                    }
                    else break;
                }
            Console.WriteLine((from i in tilesDict.Values where i <= 10 select 1).Sum());
        }
    }
}