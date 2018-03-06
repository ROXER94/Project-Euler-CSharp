using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the next Triangle, Pentagonal, and Hexagonal number after 40755
        /// </summary>
        static void P045()
        {
            HashSet<long> hexagons = new HashSet<long>();
            for (int i = 144; i <= 50000; i++)
            {
                hexagons.Add(Functions.getHexagon(i));
                if (hexagons.Contains(Functions.getPentagon(i)))
                {
                    Console.WriteLine(Functions.getPentagon(i));
                    break;
                }
            }
        }
    }
}