using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the Farey Sequence of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The Farey sequence of order n</returns>
        static HashSet<double> getFareySequence(int n)
        {
            HashSet<double> FareySequence = new HashSet<double>();
            int a = 0;
            int b = 1;
            int c = 1;
            int d = n;
            FareySequence.Add(a / b);
            while (c <= n)
            {
                int k = (n + b) / d;
                int p = c;
                int q = d;
                c = k * c - a;
                d = k * d - b;
                a = p;
                b = q;
                FareySequence.Add((double)a / b);
            }
            return FareySequence;
        }

        /// <summary>
        /// Calculates the number of fractions that lie between 1/3 and 1/2 in the sorted set of reduced proper fractions for d ≤ 12,000
        /// </summary>
        static void P073()
        {
            HashSet<double> FareySequence = getFareySequence(12000);
            Console.WriteLine((from i in FareySequence where i > 1.0 / 3 && i < 1.0 / 2 select i).Count());
        }
    }
}