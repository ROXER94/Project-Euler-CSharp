using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the minimum size of cuboids, up to a maximum size of N x N x N, for which the shortest path has integer length and the number of solutions first exceeds 1,000,000
        /// </summary>
        static void P086()
        {
            HashSet<long> primes = Functions.ToHashSet(Functions.getPrimesList(2000));
            IDictionary<double,int> squaresDict = new Dictionary<double, int>();
            for (int i = 1; i < 6000; i++) squaresDict[i] = i * i;
            IDictionary<int, bool> isSquareDict = new Dictionary<int, bool>();
            int solutions = 2;
            for (int n = 1; n < 2000; n++)
                if (!primes.Contains(n))
                {
                    int paths = 0;
                    for (int a = 1; a <= n; a++)
                        for (int b = a; b <= n; b++)
                        {
                            int side = squaresDict[a + b] + squaresDict[n];
                            if (!isSquareDict.ContainsKey(side))
                                isSquareDict[side] = Functions.isSquare(side);
                            if (isSquareDict[side]) paths++;
                        }
                    solutions += paths;
                    if (solutions > 1000000)
                    {
                        Console.WriteLine(n);
                        break;
                    }
                }
        }
    }
}