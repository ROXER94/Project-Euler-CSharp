using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all primes less than 40,000,000 which generate a totient chain of length 25
        /// </summary>
        static void P214()
        {
            long ans = 0;
            int[] phi = Functions.getTotients(40000000);
            foreach (int p in Functions.getPrimesList(40000000))
            {
                int chain = 1;
                int current = p;
                while (current != 1)
                {
                    current = phi[current];
                    chain++;
                }
                if (chain == 25) ans += p;
            }
            Console.WriteLine(ans);
        }
    }
}