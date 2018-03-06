using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of continued fractions for N ≤ 10,000 that have an odd period
        /// </summary>
        static void P064()
        {
            HashSet<string> ans = new HashSet<string>();
            for (int i = 1; i <= 10000; i++)
            {
                if (!Functions.isSquare(i))
                {
                    List<int> CFrepresentation = new List<int>();
                    int residue = (int)Math.Pow(i, .5);
                    double denominator = residue;
                    double numerator = i - Math.Pow(denominator, 2);
                    while (true)
                    {
                        int sequenceNumber = (int)((residue + denominator) / numerator);
                        CFrepresentation.Add(sequenceNumber);
                        double newDenominator = sequenceNumber * numerator - denominator;
                        double newNumerator = (i - Math.Pow(newDenominator, 2)) / numerator;
                        denominator = newDenominator;
                        numerator = newNumerator;
                        if (newNumerator == 1) break;
                    }
                    CFrepresentation.Add(2 * residue);
                    if (CFrepresentation.Count == 2 && CFrepresentation.IndexOf(0) == CFrepresentation.IndexOf(1)) CFrepresentation.RemoveAt(0);
                    if (CFrepresentation.Count % 2 != 0) ans.Add(String.Join(",", CFrepresentation));
                }
            }
            Console.WriteLine(ans.Count);
        }
    }
}