using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the number of triangle words in the text file
        /// </summary>
        static void P042()
        {
            int ans = 0;
            IDictionary<char, int> alphabetValues = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToDictionary(l => l, l => l - 'A' + 1);
            var TriangleNumbers = from i in Enumerable.Range(1, 30) select Functions.getTriangle(i);
            foreach (string word in File.ReadAllText(@"...\...\Resources\p042_words.txt").Split(',').Select(s => s.Replace("\"", "")).ToArray())
                if (TriangleNumbers.Contains((from c in word select Convert.ToInt32(alphabetValues[c])).Sum())) ans++;
            Console.WriteLine(ans);
        }
    }
}