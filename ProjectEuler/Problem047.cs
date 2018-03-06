using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the distinct factors of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The distinct factors of n</returns>
        static SortedSet<long> getDistinctFactors(int n)
        {
            List<long> primeFactors = Functions.getPrimeFactors(n);
            SortedSet<long> distinctFactors = new SortedSet<long>();
            foreach (int i in primeFactors)
            {
                int count = Functions.getOccurrenceOfValue(primeFactors,i);
                if (count == 1) distinctFactors.Add(i);
                else distinctFactors.Add(i * count);
            }
            return distinctFactors;
        }

        /// <summary>
        ///  Calculates the first of four consecutive integers to have four distinct prime factors
        /// </summary>
        static void P047()
        {
            int ans = 1;
            while (true)
            {
                SortedSet<long> pfactors1 = getDistinctFactors(ans);
                if (pfactors1.Count == 4)
                {
                    SortedSet<long> pfactors2 = getDistinctFactors(ans + 1);
                    if (pfactors2.Count == 4)
                    {
                        SortedSet<long> pfactors3 = getDistinctFactors(ans + 2);
                        if (pfactors3.Count == 4)
                        {
                            SortedSet<long> pfactors4 = getDistinctFactors(ans + 3);
                            if (pfactors4.Count == 4)
                            {
                                HashSet<long> currentPrimeFactors = Functions.ToHashSet(from i in pfactors1 select i);
                                foreach (int i in pfactors2)
                                {
                                    if (currentPrimeFactors.Contains(i)) break;
                                    else currentPrimeFactors.Add(i);
                                }
                                if (currentPrimeFactors.Count != 8) break;
                                foreach (int i in pfactors3)
                                {
                                    if (currentPrimeFactors.Contains(i)) break;
                                    else currentPrimeFactors.Add(i);
                                }
                                if (currentPrimeFactors.Count != 12) break;
                                foreach (int i in pfactors4)
                                {
                                    if (currentPrimeFactors.Contains(i)) break;
                                    else currentPrimeFactors.Add(i);
                                }
                                if (currentPrimeFactors.Count == 16) break;       
                            }
                        }
                    }
                }
                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}