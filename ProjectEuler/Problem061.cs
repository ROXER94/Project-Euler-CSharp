using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if two numbers are cyclic
        /// </summary>
        /// <param name="n">Long</param>
        /// <param name="m">Long</param>
        /// <returns>True if the last two digits of n are the first two digits of the m</returns>
        static bool isCyclic(long n, long m)
        {
            return n.ToString().Substring(2) == m.ToString().Substring(0, 2);
        }

        /// <summary>
        /// Calculates the sum of the only set of six cyclic 4-digit numbers that contains a triangle, square, pentagonal, hexagonal, heptagonal, and octogonal number
        /// </summary>
        static void P061()
        {
            var triangles = from i in Enumerable.Range(45, 96) select Functions.getTriangle(i);
            var squares = from i in Enumerable.Range(32, 68) select Functions.getSquare(i);
            var pentagons = from i in Enumerable.Range(26, 56) select Functions.getPentagon(i);
            var hexagons = from i in Enumerable.Range(23, 48) select Functions.getHexagon(i);
            var heptagons = from i in Enumerable.Range(21, 43) select Functions.getHeptagon(i);
            var octagons = from i in Enumerable.Range(19, 40) select Functions.getOctagon(i);
            foreach (var i in Functions.getPermutations(new List<IEnumerable<long>>() { triangles, squares, pentagons, hexagons, heptagons, octagons }, 6))
                foreach (long a in i.ElementAt(0))
                    foreach (long b in i.ElementAt(1))
                        if (isCyclic(a, b))
                            foreach (long c in i.ElementAt(2))
                                if (isCyclic(b, c))
                                    foreach (long d in i.ElementAt(3))
                                        if (isCyclic(c, d))
                                            foreach (long e in i.ElementAt(4))
                                                if (isCyclic(d, e))
                                                    foreach (long f in i.ElementAt(5))
                                                        if (isCyclic(e, f))
                                                            if (isCyclic(f, a))
                                                            {
                                                                Console.WriteLine(a + b + c + d + e + f);
                                                                return;
                                                            }
        }
    }
}