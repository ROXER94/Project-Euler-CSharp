using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the score of each name in the text file
        /// </summary>
        static void P022()
        {
            int ans = 0;
            IDictionary<char, int> alphabetValues = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToDictionary(l => l, l => l - 'A' + 1);
            List<string> names = File.ReadAllText(@"...\...\Resources\p022_names.txt").Split(',').Select(s => s.Replace("\"", "")).OrderBy(n => n).ToList();
            foreach (string name in names)
                ans += (from c in name select Convert.ToInt32(alphabetValues[c])).Sum() * (names.IndexOf(name) + 1);
            Console.WriteLine(ans);
        }
    }
}