using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the probability that Pyramidal Pete beats Cubic Colin
        /// </summary>
        static void P205()
        {
            double ans = 0;
            List<long> Colin = new List<long>();
            for (int a = 1; a < 7; a++)
                for (int b = 1; b < 7; b++)
                    for (int c = 1; c < 7; c++)
                        for (int d = 1; d < 7; d++)
                            for (int e = 1; e < 7; e++)
                                for (int f = 1; f < 7; f++)
                                    Colin.Add(a + b + c + d + e + f);
            List<long> Peter = new List<long>();
            for (int a = 1; a < 5; a++)
                for (int b = 1; b < 5; b++)
                    for (int c = 1; c < 5; c++)
                        for (int d = 1; d < 5; d++)
                            for (int e = 1; e < 5; e++)
                                for (int f = 1; f < 5; f++)
                                    for (int g = 1; g < 5; g++)
                                        for (int h = 1; h < 5; h++)
                                            for (int i = 1; i < 5; i++)
                                                Peter.Add(a + b + c + d + e + f + g + h + i);
            IDictionary<int, int> P = new Dictionary<int, int>();
            IDictionary<int, int> C = new Dictionary<int, int>();
            for (int i = 6; i <= 36; i++)
            {
                P[i] = Functions.getOccurrenceOfValue(Peter, i);
                C[i] = Functions.getOccurrenceOfValue(Colin, i);
            }
            for (int c = 6; c < 36; c++)
                for (int p = c + 1; p <= 36; p++)
                    ans += C[c] * P[p];
            Console.WriteLine(Math.Round(ans / ((long)Peter.Count * Colin.Count), 7));
        }
    }
}