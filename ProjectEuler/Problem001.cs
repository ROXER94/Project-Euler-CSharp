using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all the multiples of 3 or 5 below 1000
        /// </summary>
        static void P001()
        {
            Console.WriteLine((from i in Enumerable.Range(0, 1000) where i % 3 == 0 || i % 5 == 0 select i).Sum());
        }
    }
}
