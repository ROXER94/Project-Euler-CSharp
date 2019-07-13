using System;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the ASCII values in the original message of the text file
        /// </summary>
        static void P059()
        {
            int ans = 0;
            string[] cipher = File.ReadAllText(@"...\...\Resources\p059_cipher.txt").Split(',').Select(s => s.Replace("\"", "")).ToArray();
            for (int p1 = 97; p1 < 123; p1++)
                for (int p2 = 97; p2 < 123; p2++)
                    for (int p3 = 97; p3 < 123; p3++)
                    {
                        var A = from s in cipher.Where((x, i) => i % 3 == 0) select Convert.ToChar(Int32.Parse(s) ^ p1);
                        var B = from s in cipher.Where((x, i) => i % 3 == 1) select Convert.ToChar(Int32.Parse(s) ^ p2);
                        var C = from s in cipher.Where((x, i) => i % 3 == 2) select Convert.ToChar(Int32.Parse(s) ^ p3);
                        String text = String.Join("", (from s in A.Zip(B, (e1, e2) => new { e1, e2 }).Zip(C, (z1, e3) => Tuple.Create(z1.e1, z1.e2, e3)) select new String(new Char[3] { s.Item1, s.Item2, s.Item3 })).ToArray());
                        if (text.Contains(" the "))
                        {
                            ans += (from c in text select (int)c).Sum();
                            if (A.Count() != C.Count()) ans += Int32.Parse(cipher.Last()) ^ p1;
                            if (B.Count() != C.Count()) ans += Int32.Parse(cipher[cipher.Count() - 2]) ^ p2;
                            Console.WriteLine(ans);
                            return;
                        }
                    }
        }
    }
}