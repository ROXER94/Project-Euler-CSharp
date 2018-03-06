using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all primes below 2,000,000
        /// </summary>
        static void P010()
        {
            Console.WriteLine(Functions.getPrimesList(2000000).Sum());
        }
    }
}