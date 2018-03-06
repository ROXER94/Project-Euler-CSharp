using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the number of numbers below 50,000,000 that can be expressed as the sum of a prime square, prime cube, and prime fourth power
        /// </summary>
        static void P087()
        {
            HashSet<long> ans = new HashSet<long>();
            int limit = 50000000;
            var primes = Functions.ToHashSet(Functions.getPrimesList((int)Math.Pow(limit, .5)));
            for (int a = 2; a <= (int)Math.Pow(limit, .5); a++)
                if (primes.Contains(a))
                    for (int b = 2; b <= (int)Math.Pow(limit, .3333); b++)
                        if (a * a + b * b * b < limit)
                            if (primes.Contains(b))
                                for (int c = 2; c <= (int)Math.Pow(limit, .25); c++)
                                    if (primes.Contains(c))
                                        if (a * a + b * b * b + c * c * c * c < limit) ans.Add(a * a + b * b * b + c * c * c * c);
            Console.WriteLine(ans.Count);
        }
    }
}