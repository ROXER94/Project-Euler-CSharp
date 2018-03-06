using ProjectEuler.Common;
using System;
using System.Linq;

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
            int[] phi = Functions.getTotients(40000000).ToArray();
            foreach (int p in Functions.getPrimesList(40000000))
            {
                int currentPrime = p;
                int chain = 1;
                while (currentPrime != 1)
                {
                    currentPrime = phi[currentPrime - 1];
                    chain++;
                }
                if (chain == 25) ans += p;
            }
            Console.WriteLine(ans);
        }
    }
}