using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the digits of the number 2^1000
        /// </summary>
        static void P016()
        {
            Console.WriteLine((from n in (BigInteger.Pow(2, 1000)).ToString() select (int)Char.GetNumericValue(n)).Sum());
        }
    }
}