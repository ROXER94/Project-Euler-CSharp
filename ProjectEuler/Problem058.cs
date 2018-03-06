using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%
        /// </summary>
        static void P058()
        {
            int ans = 3;
            double ratio = 1.0;
            double diagonalCount = 1;
            int primesCount = 0;
            while (ratio > .10)
            {
                int corner1 = ans * ans - 1 * (ans - 1);
                int corner2 = ans * ans - 2 * (ans - 1);
                int corner3 = ans * ans - 3 * (ans - 1);
                if (Functions.isPrime(corner1)) primesCount++;
                if (Functions.isPrime(corner2)) primesCount++;
                if (Functions.isPrime(corner3)) primesCount++;
                diagonalCount += 4;
                ratio = primesCount / diagonalCount;
                ans += 2;
            }
            Console.WriteLine(ans - 2);
        }
    }
}