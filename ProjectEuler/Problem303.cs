using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the smallest multiple of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <param name="multiples">SortedSet</param>
        /// <returns>The smallest multiple of n</returns>
        static long getSmallDigitMultiple(int n, SortedSet<long> multiples)
        {
            foreach (long i in multiples)
                if (i % n == 0)
                    return i;
            return 0;
        }

        /// <summary>
        /// Calculates the sum of the multipliers k for which the least positive multiple n*k, written in base 10, uses only digits ≤ 2, from 1 to 10,000
        /// </summary>
        static void P303()
        {
            long ans = 0;
            IDictionary<int, long> dict = new Dictionary<int, long>();
            SortedSet<long> multiples = new SortedSet<long>();
            for (int a = 0; a < 3; a++)
                for (int b = 0; b < 3; b++)
                    for (int c = 0; c < 3; c++)
                        for (int d = 0; d < 3; d++)
                            for (int e = 0; e < 3; e++)
                                for (int f = 0; f < 3; f++)
                                    for (int g = 0; g < 3; g++)
                                        for (int h = 0; h < 3; h++)
                                            for (int i = 0; i < 3; i++)
                                                for (int j = 0; j < 3; j++)
                                                    for (int k = 0; k < 3; k++)
                                                        for (int l = 0; l < 3; l++)
                                                            for (int m = 0; m < 3; m++)
                                                                for (int n = 0; n < 3; n++)
                                                                    for (int o = 0; o < 3; o++)
                                                                        for (int p = 0; p < 3; p++)
                                                                            multiples.Add(Int64.Parse(a.ToString() + b.ToString() + c.ToString() + d.ToString() +
                                                                                e.ToString() + f.ToString() + g.ToString() + h.ToString() + i.ToString() + j.ToString() +
                                                                                k.ToString() + l.ToString() + m.ToString() + n.ToString() + o.ToString() + p.ToString()));
            multiples.Remove(0);
            for (int n = 1; n < 9999; n++)
            {
                if (!dict.ContainsKey(n))
                    dict[n] = getSmallDigitMultiple(n, multiples);
                dict[10 * n] = 10 * dict[n];
                ans += dict[n] / n;
            }
            Console.WriteLine(ans + (long)(11112222222222222222 / 9999) + 1);
        }
    }
}