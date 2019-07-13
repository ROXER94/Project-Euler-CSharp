using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of values of nCk, for 1 ≤ n ≤ 100, that are greater than 1,000,000
        /// </summary>
        static void P053()
        {
            Console.WriteLine((from k in Enumerable.Range(1, 100)
                               from n in Enumerable.Range(k, 100 - k + 1)
                               where Functions.getnCk(n, k) > 1000000 select 1).Count());
        }
    }
}