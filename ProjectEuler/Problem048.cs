using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000
        /// </summary>
        static void P048()
        {
            Console.WriteLine(new String(Enumerable.Range(1, 1000).Select(i => BigInteger.Pow(i, i)).Aggregate((sum, next) => sum + next).ToString().Reverse().Take(10).Reverse().ToArray()));
        }
    }
}