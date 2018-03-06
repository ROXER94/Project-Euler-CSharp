using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of n-digit positive integers which are also an nth power
        /// </summary>
        static void P063()
        {
            Console.WriteLine((from i in Enumerable.Range(1, 9)
                               select (from j in Enumerable.Range(1, 25)
                                       where BigInteger.Pow(i, j).ToString().Length == j select 1).Count()).Sum());
        }
    }
}