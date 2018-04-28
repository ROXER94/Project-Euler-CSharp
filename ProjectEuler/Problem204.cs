using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of generalised Hamming numbers which don't exceed a limit
        /// </summary>
        /// <param name="index">Int</param>
        /// <param name="value">Long</param>
        /// <param name="primesList">List</param>
        /// <param name="limit">Int</param>
        /// <returns>The count of generalised Hamming numbers which don't exceed a limit</returns>
        static int getHammingCount(int index, long value, List<long> primes, int limit)
        {
            int count = 0;
            while (value <= limit)
            {
                if (index == primes.Count)
                {
                    count++;
                    break;
                }
                count += getHammingCount(index + 1, value, primes, limit);
                value *= primes[index];
            }
            return count;
        }

        /// <summary>
        /// Calculates the number of generalised Hamming numbers of type 100 which don't exceed 10^9
        /// </summary>
        static void P204()
        {
            Console.WriteLine(getHammingCount(0, 1, Functions.getPrimesList(100), 1000000000));
        }
    }
}
