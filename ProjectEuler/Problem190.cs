using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates Σ[Pm] for 2 ≤ m ≤ 15
        /// </summary>
        static void P190()
        {
            Console.WriteLine((from m in Enumerable.Range(2, 14) select (int)(from i in Enumerable.Range(1, m) select Math.Pow(2.0 * i / (m + 1), i)).Aggregate((a, x) => a * x)).Sum());
        }
    }
}