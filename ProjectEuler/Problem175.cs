using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the continued fraction representation of a rational number
        /// </summary>
        /// <param name="fraction">Tuple</param>
        /// <param name="res">List</param>
        /// <returns>A list containing the continued fraction representation of the fraction</returns>
        static List<double> getContinuedFraction(Tuple<decimal, decimal> fraction,List<double> res)
        {
            int i = (int)(fraction.Item1 / fraction.Item2);
            decimal f = fraction.Item1 / fraction.Item2 - i;
            res.Add(i);
            if (Math.Round(f,10) == 1) return res;
            return getContinuedFraction(Tuple.Create((decimal)1, f), res);
        }

        /// <summary>
        /// Calculates the Shortened Binary Expansion of the smallest n for which f(n)/f(n-1) = 123456789/987654321
        /// </summary>
        static void P175()
        {
            List<double> ans = getContinuedFraction(Tuple.Create((decimal)123456789, (decimal)987654321), new List<double>());
            ans.RemoveAt(0);
            if (ans.Count % 2 == 0) ans.Add(1);
            ans.Reverse();
            Console.WriteLine(String.Join(",", ans));
        }
    }
}