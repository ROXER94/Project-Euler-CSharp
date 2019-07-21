using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the least value of n for which the number of distinct solutions of the equation x^-1 + y^-1 = n^-1 exceeds 4,000,000
        /// </summary>
        static void P110()
        {
            long ans = 1;
            int A = 0;
            int B = 0;
            int C = 0;
            int D = 0;
            int E = 0;
            int n = 8000000;
            List<long> primes = Functions.getPrimesList(50).GetRange(0, (int)Math.Log(n));
            long limit = primes.Aggregate((a, x) => a * x);
            for (int a = 0; a < 10; a++)
            {
                if (Math.Pow(3, a) > limit) break;
                for (int b = 0; b < 5; b++)
                {
                    if (Math.Pow(3, a) * Math.Pow(5, b) > limit) break;
                    for (int c = 0; c < 5; c++)
                    {
                        if (Math.Pow(3, a) * Math.Pow(5, b) * Math.Pow(7, c) > limit) break;
                        for (int d = 0; d < 5; d++)
                        {
                            if (Math.Pow(3, a) * Math.Pow(5, b) * Math.Pow(7, c) * Math.Pow(9, d) > limit) break;
                            for (int e = 0; e < 5; e++)
                            {
                                long currentValue = (long)(Math.Pow(3, a) * Math.Pow(5, b) * Math.Pow(7, c) * Math.Pow(9, d) * Math.Pow(11, e));
                                if (currentValue > limit) break;
                                else if (currentValue > n)
                                {
                                    limit = currentValue;
                                    A = a;
                                    B = b;
                                    C = c;
                                    D = d;
                                    E = e;
                                }
                            }
                        }
                    }
                }
            }
            List<int> values = new List<int> { E, D, C, B, A };
            while (values.Contains(0))
                values.Remove(0);
            List<int> exponents = new List<int> { 5, 4, 3, 2, 1 };
            exponents.RemoveRange(0, 5 - values.Count());
            int index = 0;
            foreach (int i in values)
            {
                foreach (long j in primes.GetRange(0, i))
                    ans *= (long)Math.Pow(j, exponents[index]);
                primes = primes.GetRange(i, primes.Count() - i);
                index++;
            }
            Console.WriteLine(ans);
        }
    }
}