using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Evaluates the array of primes to determine if every concatenation of two primes yields another prime
        /// </summary>
        /// <param name="primes">Long[]</param>
        /// <param name="primesDict">IDictionary</param>
        /// <returns>True if concatenating any two primes yields another prime</returns>
        static bool evaluatePrimes(long[] primes, IDictionary<long, bool> primesDict)
        {
            if (primes.Count() == 2)
                return primesDict.ContainsKey(Int32.Parse(primes[0].ToString() + primes[1].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[1].ToString() + primes[0].ToString()));
            else if (primes.Count() == 3)
                return primesDict.ContainsKey(Int32.Parse(primes[0].ToString() + primes[2].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[2].ToString() + primes[0].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[1].ToString() + primes[2].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[2].ToString() + primes[1].ToString()));
            else if (primes.Count() == 4)
                return primesDict.ContainsKey(Int32.Parse(primes[0].ToString() + primes[3].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[3].ToString() + primes[0].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[1].ToString() + primes[3].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[3].ToString() + primes[1].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[2].ToString() + primes[3].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[3].ToString() + primes[2].ToString()));
            else
                return primesDict.ContainsKey(Int32.Parse(primes[0].ToString() + primes[4].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[4].ToString() + primes[0].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[1].ToString() + primes[4].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[4].ToString() + primes[1].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[2].ToString() + primes[4].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[4].ToString() + primes[2].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[3].ToString() + primes[4].ToString())) &&
                       primesDict.ContainsKey(Int32.Parse(primes[4].ToString() + primes[3].ToString()));
        }

        /// <summary>
        /// Calculates the sum of a set of five primes for which any two primes concatenate to produce another prime
        /// </summary>
        static void P060()
        {
            IDictionary<long, bool> primesDict = Functions.getPrimesDict(85000000);
            List<long> primes = Functions.getPrimesList(85000000);
            for (int a = 1; a < 10; a++)
                for (int b = a + 1; b < 700; b++)
                    if (evaluatePrimes(new long[] { primes[a], primes[b] }, primesDict))
                        for (int c = b + 1; c < 755; c++)
                            if (evaluatePrimes(new long[] { primes[a], primes[b], primes[c] }, primesDict))
                                for (int d = c + 1; d < 900; d++)
                                    if (evaluatePrimes(new long[] { primes[a], primes[b], primes[c], primes[d] }, primesDict))
                                        for (int e = d + 1; e < 1100; e++)
                                            if (evaluatePrimes(new long[] { primes[a], primes[b], primes[c], primes[d], primes[e] }, primesDict))
                                            {
                                                Console.WriteLine(primes[a] + primes[b] + primes[c] + primes[d] + primes[e]);
                                                return;
                                            }
        }
    }
}