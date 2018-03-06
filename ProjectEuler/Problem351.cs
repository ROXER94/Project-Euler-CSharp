using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of points hidden from the center in a hexagonal orchard of order 100,000,000
        /// </summary>
        static void P351()
        {
            Console.WriteLine(6 * (Functions.getnCk(100000001, 2) - (from i in Functions.getTotients(100000000) select (long)i).Sum()));
        }
    }
}