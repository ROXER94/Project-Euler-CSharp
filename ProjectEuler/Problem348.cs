using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the five smallest palindromic numbers that are the sum of square and a cube in exactly 4 different ways
        /// </summary>
        static void P348()
        {
            IDictionary<int, int> palindromesDict = new Dictionary<int, int>();
            for (int i = 2; i < 30000; i++)
                for (int j = 2; j < 1000; j++)
                {
                    int currentValue = i * i + j * j * j;
                    if (Functions.isPalindrome(currentValue.ToString()))
                        if (palindromesDict.ContainsKey(currentValue))
                            palindromesDict[currentValue]++;
                        else
                            palindromesDict.Add(currentValue, 1);
                }
            Console.WriteLine((from i in palindromesDict.OrderByDescending(x => x.Value == 4).Take(5) select i.Key).Sum());
        }
    }
}