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
        /// Calculates the largest square number formed by any member of a pair of anagramic squares in the text file
        /// </summary>
        static void P098()
        {
            string[] words = File.ReadAllText(@"...\...\Resources\p098_words.txt").Split(',').Select(s => s.Replace("\"", "")).ToArray();
            List<Tuple<string,string>> anagrams = new List<Tuple<string,string>>();
            for (int i = 0; i < words.Length - 1; i++)
                for (int j = i + 1; j < words.Length; j++)
                    if (Functions.isAnagram(words[i], words[j]))
                        if (words[i].ToString().Distinct().Count() == words[i].ToString().Length)
                            anagrams.Add(Tuple.Create(words[i], words[j]));
            int[] squares3 = (from i in Enumerable.Range(10, 22) select i * i).ToArray();
            List<Tuple<int, int>> squares3Anagrams = new List<Tuple<int, int>>();
            for (int i = 0; i < squares3.Length - 1; i++)
                for (int j = i + 1; j < squares3.Length; j++)
                    if (Functions.isAnagram(squares3[i].ToString(), squares3[j].ToString()))
                        if (squares3[i].ToString().Distinct().Count() == squares3[i].ToString().Length)
                            squares3Anagrams.Add(Tuple.Create(squares3[i], squares3[j]));
            int[] squares4 = (from i in Enumerable.Range(32, 68) select i * i).ToArray();
            List<Tuple<int, int>> squares4Anagrams = new List<Tuple<int, int>>();
            for (int i = 0; i < squares4.Length - 1; i++)
                for (int j = i + 1; j < squares4.Length; j++)
                    if (Functions.isAnagram(squares4[i].ToString(), squares4[j].ToString()))
                        if (squares4[i].ToString().Distinct().Count() == squares4[i].ToString().Length)
                            squares4Anagrams.Add(Tuple.Create(squares4[i], squares4[j]));
            int[] squares5 = (from i in Enumerable.Range(100, 216) select i * i).ToArray();
            List<Tuple<int, int>> squares5Anagrams = new List<Tuple<int, int>>();
            for (int i = 0; i < squares5.Length - 1; i++)
                for (int j = i + 1; j < squares5.Length; j++)
                    if (Functions.isAnagram(squares5[i].ToString(), squares5[j].ToString()))
                        if (squares5[i].ToString().Distinct().Count() == squares5[i].ToString().Length)
                            squares5Anagrams.Add(Tuple.Create(squares5[i], squares5[j]));
            int[] squares6 = (from i in Enumerable.Range(316, 684) select i * i).ToArray();
            List<Tuple<int, int>> squares6Anagrams = new List<Tuple<int, int>>();
            for (int i = 0; i < squares6.Length - 1; i++)
                for (int j = i + 1; j < squares6.Length; j++)
                    if (Functions.isAnagram(squares6[i].ToString(), squares6[j].ToString()))
                        if (squares6[i].ToString().Distinct().Count() == squares6[i].ToString().Length)
                            squares6Anagrams.Add(Tuple.Create(squares6[i], squares6[j]));
            List<int> ans = new List<int>();
            foreach (var i in anagrams)
            {
                if ((i.Item1 + i.Item2).Length / 2 == 3)
                {
                    int a = i.Item2.IndexOf(i.Item1[0]);
                    int b = i.Item2.IndexOf(i.Item1[1]);
                    int c = i.Item2.IndexOf(i.Item1[2]);
                    foreach (var j in squares3Anagrams)
                        if (a == j.Item2.ToString().IndexOf(j.Item1.ToString()[0]) &&
                            b == j.Item2.ToString().IndexOf(j.Item1.ToString()[1]) &&
                            c == j.Item2.ToString().IndexOf(j.Item1.ToString()[2]))
                            ans.Add(j.Item2);
                }
                else if ((i.Item1 + i.Item2).Length / 2 == 4)
                {
                    int a = i.Item2.IndexOf(i.Item1[0]);
                    int b = i.Item2.IndexOf(i.Item1[1]);
                    int c = i.Item2.IndexOf(i.Item1[2]);
                    int d = i.Item2.IndexOf(i.Item1[3]);
                    foreach (var j in squares4Anagrams)
                        if (a == j.Item2.ToString().IndexOf(j.Item1.ToString()[0]) &&
                            b == j.Item2.ToString().IndexOf(j.Item1.ToString()[1]) &&
                            c == j.Item2.ToString().IndexOf(j.Item1.ToString()[2]) &&
                            d == j.Item2.ToString().IndexOf(j.Item1.ToString()[3]))
                            ans.Add(j.Item2);
                }
                else if ((i.Item1 + i.Item2).Length / 2 == 5)
                {
                    int a = i.Item2.IndexOf(i.Item1[0]);
                    int b = i.Item2.IndexOf(i.Item1[1]);
                    int c = i.Item2.IndexOf(i.Item1[2]);
                    int d = i.Item2.IndexOf(i.Item1[3]);
                    int e = i.Item2.IndexOf(i.Item1[4]);
                    foreach (var j in squares5Anagrams)
                        if (a == j.Item2.ToString().IndexOf(j.Item1.ToString()[0]) &&
                            b == j.Item2.ToString().IndexOf(j.Item1.ToString()[1]) &&
                            c == j.Item2.ToString().IndexOf(j.Item1.ToString()[2]) &&
                            d == j.Item2.ToString().IndexOf(j.Item1.ToString()[3]) &&
                            e == j.Item2.ToString().IndexOf(j.Item1.ToString()[4]))
                            ans.Add(j.Item2);
                }
                else if ((i.Item1 + i.Item2).Length / 2 == 6)
                {
                    int a = i.Item2.IndexOf(i.Item1[0]);
                    int b = i.Item2.IndexOf(i.Item1[1]);
                    int c = i.Item2.IndexOf(i.Item1[2]);
                    int d = i.Item2.IndexOf(i.Item1[3]);
                    int e = i.Item2.IndexOf(i.Item1[4]);
                    int f = i.Item2.IndexOf(i.Item1[5]);
                    foreach (var j in squares6Anagrams)
                        if (a == j.Item2.ToString().IndexOf(j.Item1.ToString()[0]) &&
                            b == j.Item2.ToString().IndexOf(j.Item1.ToString()[1]) &&
                            c == j.Item2.ToString().IndexOf(j.Item1.ToString()[2]) &&
                            d == j.Item2.ToString().IndexOf(j.Item1.ToString()[3]) &&
                            e == j.Item2.ToString().IndexOf(j.Item1.ToString()[4]) &&
                            e == j.Item2.ToString().IndexOf(j.Item1.ToString()[5]))
                            ans.Add(j.Item2);
                }
            }
            Console.WriteLine(ans.Max());
        }
    }
}