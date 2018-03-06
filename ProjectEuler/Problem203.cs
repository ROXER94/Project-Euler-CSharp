using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the number located at (n,r) in Pascal's triangle
        /// </summary>
        /// <param name="n">Int</param>
        /// <param name="r">Int</param>
        /// <returns>The number located at (n,r) in Pascal's triangle</returns>
        static BigInteger getPascal(int n, int r)
        {
            return Functions.getnCk(n - 1, r) + Functions.getnCk(n - 1, r - 1);
        }

        /// <summary>
        /// Calculates the sum of the distinct squarefree numbers in the first 51 rows of Pascal's triangle
        /// </summary>
        static void P203()
        {
            List<long> primes = Functions.getPrimesList(8);
            HashSet<BigInteger> PascalTriangle = new HashSet<BigInteger>();
            for (int i = 2; i < 51; i++)
                for (int j = 1; j < i; j++)
                    PascalTriangle.Add(getPascal(i, j));
            Console.WriteLine((from i in PascalTriangle where Functions.isSquarefree(i, primes) select i).Aggregate((sum, next) => sum + next) + 1);
        }
    }
}