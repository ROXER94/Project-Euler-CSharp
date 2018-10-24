using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of distinct arrangements of the two cubes that allow for all of the square numbers to be displayed
        /// </summary>
        static void P090()
        {
            int ans = 0;
            List<string> squares = new List<string>() { "01", "04", "09", "16", "25", "36", "49", "64", "81" };
            List<int[]> cubeList = new List<int[]>();
            for (int side1 = 0; side1 < 5; side1++)
                for (int side2 = side1 + 1; side2 < 6; side2++)
                    for (int side3 = side2 + 1; side3 < 7; side3++)
                        for (int side4 = side3 + 1; side4 < 8; side4++)
                            for (int side5 = side4 + 1; side5 < 9; side5++)
                                for (int side6 = side5 + 1; side6 < 10; side6++)
                                    cubeList.Add(new int[] { side1, side2, side3, side4, side5, side6 });
            int[][] cubes = cubeList.ToArray();
            for (int i = 0; i < cubes.Length - 1; i++)
                for (int j = i + 1; j < cubes.Length; j++)
                {
                    List<int> die1 = cubes[i].ToList();
                    List<int> die2 = cubes[j].ToList();
                    List<string> currentSquares = new List<string>(squares);
                    if (die1.Contains(6) && !die1.Contains(9))
                        die1.Add(9);
                    if (die1.Contains(9) && !die1.Contains(6))
                        die1.Add(6);
                    if (die2.Contains(6) && !die2.Contains(9))
                        die2.Add(9);
                    if (die2.Contains(9) && !die2.Contains(6))
                        die2.Add(6);
                    foreach (int side1 in die1)
                        foreach (int side2 in die2)
                        {
                            string pair1 = side1.ToString() + side2.ToString();
                            string pair2 = side2.ToString() + side1.ToString();
                            if (currentSquares.Contains(pair1))
                                currentSquares.Remove(pair1);
                            if (currentSquares.Contains(pair2))
                                currentSquares.Remove(pair2);
                        }
                    if (currentSquares.Count == 0)
                        ans++;
                }
            Console.WriteLine(ans);
        }
    }
}