using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of elements in the set of reduced proper fractions for d ≤ 1,000,000
        /// </summary>
        static void P072()
        {
            Console.WriteLine((from i in Enumerable.Range(1, 1000000) select Convert.ToInt64(Functions.getPhi(i))).Sum() - 1);
        }
    }
}