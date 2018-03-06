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
        /// Gets the number of gozinta chains via MacMahon's general formula
        /// </summary>
        /// <param name="n">Long[]</param>
        /// <returns>The number of gozinta chains</returns>
        static BigInteger getGozinta(long[] n)
        {
            List<long> L = new List<long>();
            if (n.Length == 1)
                foreach (int i in Functions.getOmega(n[0]).Values)
                    L.Add(i);
            else L = n.ToList();
            long[] O = L.ToArray();
            BigInteger S = 0;
            for (int i = 1; i <= O.Sum(); i++)
                for (int j = 0; j < i; j++)
                    S += BigInteger.Pow(-1, j) * Functions.getnCk(i, j) * (from k in Enumerable.Range(0, O.Length) select Functions.getnCk((int)O[k] + i - j - 1, (int)O[k])).Aggregate((a, x) => a * x);
            return S;
        }

        /// <summary>
        /// Calculates the sum of the numbers n not exceeding 10^16 for which g(n) = n
        /// </summary>
        static void P548()
        {
            HashSet<long> ans = new HashSet<long>();
            for (int a = 1; a < 45; a++)
                for (int b = 1; b < 5; b++)
                    for (int c = 0; c < 2; c++)
                        for (int d = c; d < 2; d++)
                            for (int e = d; e < 2; e++)
                                for (int f = e; f < 2; f++)
                                {
                                    BigInteger n = getGozinta(new long[6] { a, b, c, d, e, f });
                                    if (n < BigInteger.Pow(10, 16) && getGozinta(new long[1] { (long)n }) == n)
                                        ans.Add((long)n);
                                }
            Console.WriteLine(ans.Sum() + 1);
        }
    }
}