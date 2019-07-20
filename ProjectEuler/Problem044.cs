using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the minimum difference of two pentagonal numbers whose sum and difference are pentagonal
        /// </summary>
        static void P044()
        {
            HashSet<long> pentagon = Functions.ToHashSet(from i in Enumerable.Range(1, 2500) select Functions.getPentagon(i));
            List<Tuple<long, long>> pairs = new List<Tuple<long, long>>();
            long[] pentagonArray = pentagon.ToArray();
            for (int i = 0; i < pentagon.Count - 1; i++)
                for (int j = i; j < pentagon.Count - 1; j++)
                    if (pentagon.Contains(pentagonArray[i] + pentagonArray[j]))
                        pairs.Add(Tuple.Create(pentagonArray[i], pentagonArray[j]));
            foreach (var i in pairs)
                if (pentagon.Contains(i.Item2 - i.Item1))
                {
                    Console.WriteLine(i.Item2 - i.Item1);
                    break;
                }
        }
    }
}