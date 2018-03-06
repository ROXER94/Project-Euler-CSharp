using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used in the Partition Function
        /// </summary>
        static IDictionary<int, long> partitionDict = new Dictionary<int, long> { { 0, 1 } };

        /// <summary>
        /// Gets the number of partitions of a number via the Partition Function
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The number of partitions of a number</returns>
        static long getPartition(int n)
        {
            if (!partitionDict.ContainsKey(n))
                partitionDict[n] = (from k in Enumerable.Range(0, n) select Functions.getFactors(n - k).Sum() * getPartition(k)).Sum() / n;
            return partitionDict[n];
        }

        /// <summary>
        /// Calculates the number of different ways 100 can be written as a sum of at least two positive integers
        /// </summary>
        static void P076()
        {
            Console.WriteLine(getPartition(100) - 1);
        }
    }
}