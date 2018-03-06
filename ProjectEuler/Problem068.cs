using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the maximum 16-digit string for a magic 5-gon ring
        /// </summary>
        static void P068()
        {
            foreach (var ring in Functions.getPermutations(Enumerable.Range(1, 10).Reverse(), 10))
            {
                int[] i = ring.ToArray();
                int[] ans = new int[]
                { 
                    i[0], i[1], i[2],
                    i[3], i[2], i[4],
                    i[5], i[4], i[6],
                    i[7], i[6], i[8],
                    i[9], i[8], i[1]
                };
                if (i[0] + i[1] + i[2] == i[3] + i[2] + i[4] &&
                    i[3] + i[2] + i[4] == i[5] + i[4] + i[6] &&
                    i[5] + i[4] + i[6] == i[7] + i[6] + i[8] &&
                    i[7] + i[6] + i[8] == i[9] + i[8] + i[1] &&
                    i[9] + i[8] + i[1] == i[0] + i[1] + i[2] &&
                   (i[0].ToString() + i[1].ToString() + i[2].ToString() + 
                    i[3].ToString() + i[2].ToString() + i[4].ToString() + 
                    i[5].ToString() + i[4].ToString() + i[6].ToString() + 
                    i[7].ToString() + i[6].ToString() + i[8].ToString() + 
                    i[9].ToString() + i[8].ToString() + i[1].ToString()).Length == 16 &&
                    ans[0] < ans[3] &&
                    ans[0] < ans[6] &&
                    ans[0] < ans[9] &&
                    ans[0] < ans[12])
                {
                    Console.WriteLine(String.Join("", ans));
                    return;
                }
            }
        }
    }
}