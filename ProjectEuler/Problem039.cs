using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the perimeter length that produces the maximum number of integer right triangles
        /// </summary>
        static void P039()
        {
            List<List<int>> pythagoreanTriplesList = new List<List<int>>();
            for (int a = 1; a < 481; a++)
                for (int b = a + 1; b < 481; b++)
                {
                    double c = Math.Sqrt(a * a + b * b);
                    if (Functions.isSquare(Convert.ToInt32(c * c)) && a + b + c <= 1000)
                        pythagoreanTriplesList.Add(new List<int> { a, b, (int)c });
                }
            int maximumCount = 0;
            int perimeter = 12;
            List<List<int>> countList = new List<List<int>>();
            while (perimeter <= 1000)
            {
                int currentCount = 0;
                foreach (List<int> i in pythagoreanTriplesList)
                {
                    if (i.Sum() == perimeter) currentCount++;
                    if (currentCount > maximumCount)
                    {
                        maximumCount = currentCount;
                        countList.Add(i);
                    }
                }
                perimeter++;
            }
            Console.WriteLine(countList.Last().Sum());
        }
    }
}