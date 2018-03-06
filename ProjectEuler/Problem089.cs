using System;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the number of characters saved by writing the string in its minimal Roman Numeral form
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>The number of characters saved by writing the string in its minimal Roman Numeral form</returns>
        static int getRomanReplacementCount(string s)
        {
            int charactersReplaced = 0;
            while (s.Contains("IIII"))
            {
                s = s.Replace("IIII", "IV");
                charactersReplaced += 2;
            }
            while (s.Contains("VIV"))
            {
                s = s.Replace("VIV", "IX");
                charactersReplaced++;
            }
            while (s.Contains("XXXX"))
            {
                s = s.Replace("XXXX", "XL");
                charactersReplaced += 2;
            }
            while (s.Contains("LXL"))
            {
                s = s.Replace("LXL", "XC");
                charactersReplaced++;
            }
            while (s.Contains("CCCC"))
            {
                s = s.Replace("CCCC", "CD");
                charactersReplaced += 2;
            }
            while (s.Contains("DCD"))
            {
                s = s.Replace("DCD", "CM");
                charactersReplaced++;
            }
            return charactersReplaced;
        }

        /// <summary>
        ///  Calculates the number of characters saved by writing each line of the text file in its minimal Roman Numeral form
        /// </summary>
        static void P089()
        {
            Console.WriteLine(File.ReadAllText(@"...\...\Resources\p089_roman.txt").Split('\n').Select(line => getRomanReplacementCount(line)).Sum());
        }
    }
}