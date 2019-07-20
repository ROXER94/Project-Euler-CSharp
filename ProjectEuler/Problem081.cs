using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the minimal path sum from the top left to the bottom right of the matrix by only moving right and down
        /// </summary>
        static void P081()
        {
            List<int[]> matrix = new List<int[]>();
            foreach (string s in File.ReadAllText(@"...\...\Resources\p081_matrix.txt").Split('\n').Select(s => s.Replace("\"", "")))
                matrix.Add(s.Split(',').Select(i => Convert.ToInt32(i)).ToArray());
            int[][] m = matrix.ToArray();
            int n = 80;
            for (int i = 1; i < n; i++)
                m[0][i] += m[0][i - 1];
            for (int j = 1; j < n; j++)
                m[j][0] += m[j - 1][0];
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    m[i][j] += Math.Min(m[i][j - 1], m[i - 1][j]);
            Console.WriteLine(matrix.Last().Last());
        }
    }
}