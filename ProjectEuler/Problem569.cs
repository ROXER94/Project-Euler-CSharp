using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used to memoize the prime peaks counts
        /// </summary>
        static IDictionary<int, List<int>> primePeakDict = new Dictionary<int, List<int>>();

        /// <summary>
        /// Gets the number of prime peaks that are visible from a peak
        /// </summary>
        /// <param name="n">Int</param>
        /// <param name="primePeaks">List</param>
        /// <param name="primePeakDict">IDictionary</param>
        /// <returns>The number of prime peaks that are visible from peak n</returns>
        static int getPrimePeakCount(int n, List<Tuple<long, long>> primePeaks, IDictionary<int, List<int>> primePeakDict)
        {
            primePeakDict[n] = new List<int>() { n - 1 };
            double currentMinSlope = Functions.getSlope(primePeaks[n - 1].Item1, primePeaks[n - 1].Item2, primePeaks[n].Item1, primePeaks[n].Item2);
            HashSet<int> potentiallyVisible = Functions.ToHashSet(primePeakDict[n - 1]);
            while (potentiallyVisible.Count != 0)
            {
                int currentPeak = potentiallyVisible.Max();
                double currentSlope = Functions.getSlope(primePeaks[currentPeak].Item1, primePeaks[currentPeak].Item2, primePeaks[n].Item1, primePeaks[n].Item2);
                if (currentSlope < currentMinSlope)
                {
                    currentMinSlope = currentSlope;
                    primePeakDict[n].Add(currentPeak);
                    potentiallyVisible.UnionWith(primePeakDict[currentPeak]);
                }
                potentiallyVisible.Remove(currentPeak);
            }
            return primePeakDict[n].Count;
        }

        /// <summary>
        /// Calculates the number of peaks that are visible looking back from the kth mountain for 1 ≤ k ≤ 2500000
        /// </summary>
        static void P569()
        {
            List<Tuple<long, long>> primePeaks = new List<Tuple<long, long>>();
            List<long> primes = Functions.getPrimesList(90000000);
            long x = 0;
            long y = 0;
            primePeaks.Add(Tuple.Create(x, y));
            primePeakDict[1] = new List<int>();
            for (int i = 0; i < primes.Count - 1; i += 2)
            {
                x += primes[i];
                y += primes[i];
                primePeaks.Add(Tuple.Create(x, y));
                x += primes[i + 1];
                y -= primes[i + 1];
            }
            Console.WriteLine((from i in Enumerable.Range(2, 2499999) select getPrimePeakCount(i, primePeaks, primePeakDict)).Sum());
        }
    }
}