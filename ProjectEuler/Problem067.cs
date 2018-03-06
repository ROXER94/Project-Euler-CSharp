using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the maximum total from top to bottom of the triangle
        /// </summary>
        static void P067()
        {
            List<int[]> matrix = new List<int[]>();
            foreach (string s in File.ReadAllText(@"...\...\Resources\p067_triangle.txt").Split('\n').Select(s => s.Replace("\"", "")))
                matrix.Add(s.Split(' ').Select(n => Convert.ToInt32(n)).ToArray());
            int[][] m = matrix.ToArray();
            int[] t = m[m.Length - 1];
            for (int i = m.Length - 2; i >= 0; i--)
                t = (from j in Enumerable.Range(0, m[i].Length) select Math.Max(m[i][j] + t[j], m[i][j] + t[j + 1])).ToArray();
            Console.WriteLine(t[0]);
        }
    }
}