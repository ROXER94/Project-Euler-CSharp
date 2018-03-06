using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        static string getFivePermutations(IDictionary<string, int> dict)
        {
            var values = dict.Values.ToArray();
            var keys = dict.Keys.ToArray();
            return keys[values.ToList().IndexOf(5)];
        }

        /// <summary>
        ///  Calculates the smallest cube for which exactly five permutations of its digits are cube
        /// </summary>
        static void P062()
        {
            var cubes = from i in Enumerable.Range(1, 8400) select Math.Pow(i,3);
            IDictionary<string, int> cubePermutationsDict = new Dictionary<string, int>();
            foreach (string i in (from cube in cubes select String.Concat((from c in cube.ToString() select c.ToString()).OrderBy(c => c))))
            {
                if (!cubePermutationsDict.ContainsKey(i)) cubePermutationsDict[i] = 1;
                else cubePermutationsDict[i]++; 
            }
            foreach (double ans in cubes)
                if (String.Concat((from c in ans.ToString() select c.ToString()).OrderBy(c => c)) == getFivePermutations(cubePermutationsDict))
                {
                    Console.WriteLine(ans);
                    break;
                }
        }
    }
}