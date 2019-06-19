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
        ///  Calculates the shortest possible secret passcode using the keylog information in the text file
        /// </summary>
        static void P079()
        {
            var passcodes = Functions.getPermutations(new List<int>() { 0, 1, 2, 3, 6, 7, 8, 9 }, 8).OrderBy(n => n.ToString());
            var keylog = new HashSet<string>();
            foreach (string s in File.ReadAllText(@"...\...\Resources\p079_keylog.txt").Split('\n'))
                keylog.Add(s);
            foreach (var i in passcodes)
                foreach (var j in keylog)
                    if (i.ToList().IndexOf((int)Char.GetNumericValue(j[0])) < i.ToList().IndexOf((int)Char.GetNumericValue(j[1])) &&
                        i.ToList().IndexOf((int)Char.GetNumericValue(j[1])) < i.ToList().IndexOf((int)Char.GetNumericValue(j[2])))
                    {
                        if (j == keylog.Last()) Console.WriteLine(String.Join("", i));
                    }
                    else break;
        }
    }
}
