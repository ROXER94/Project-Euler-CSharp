using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all values of n that satisfy s(n) = 60
        /// </summary>
        static void P622()
        {
            int e = 60;
            SortedSet<long> factors1 = Functions.getFactors((long)Math.Pow(2, e / 2) + 1);
            SortedSet<long> factors2 = Functions.getFactors((long)Math.Pow(2, e / 2) - 1);
            var Factors = (from i in factors1 from j in factors2 select i * j);
            Console.WriteLine((from n in Factors.Skip(1) where Functions.getMultiplicativeOrder(2, n) == 60 select n + 1).Sum());
        }
    }
}
