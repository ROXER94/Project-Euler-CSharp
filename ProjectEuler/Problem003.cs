using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the largest prime factor of 600,851,475,143
        /// </summary>
        static void P003()
        {
            Console.WriteLine(Functions.getPrimeFactors(600851475143).Last());
        }
    }
}