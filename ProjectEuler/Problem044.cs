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
            var pentagon = Functions.ToHashSet(from i in Enumerable.Range(1, 2500) select Functions.getPentagon(i));
            List<Tuple<long, long>> myTupleList = new List<Tuple<long, long>>();
            foreach (var p1 in pentagon)
                foreach (var p2 in pentagon.ToList().GetRange(pentagon.ToList().IndexOf(p1) + 1, pentagon.ToList().Count - pentagon.ToList().IndexOf(p1) - 1))
                    if (pentagon.Contains(p1 + p2))
                            myTupleList.Add(Tuple.Create(p1, p2));
            foreach (var i in myTupleList)
                if (pentagon.Contains(i.Item2 - i.Item1))
                {
                    Console.WriteLine(i.Item2 - i.Item1);
                    break;
                }
        }
    }
}