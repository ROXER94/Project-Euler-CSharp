using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the largest n-digit pandigital prime
        /// </summary>
        static void P041()
        {
            foreach (var i in Functions.getPermutations(Enumerable.Range(1, 7), 7).Reverse())
                if (Functions.isPrime(Convert.ToInt32(String.Join("", i.ToArray()))))
                {
                    Console.WriteLine(String.Join("", i.ToArray()));
                    break;
                }
        }
    }
}