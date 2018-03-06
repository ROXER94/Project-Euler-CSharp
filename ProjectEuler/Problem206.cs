using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number has the form 1_2_3_4_5_6_7_8_9_0
        /// </summary>
        /// <param name="n">Long</param>
        /// <returns>True if n has the form 1_2_3_4_5_6_7_8_9_0</returns>
        static bool isConcealed(long n)
        {
            string s = n.ToString();
            return s[0] == '1' && s[2] == '2' && s[4] == '3' && s[6] == '4' && s[8] == '5' && s[10] == '6' && s[12] == '7' && s[14] == '8' && s[16] == '9' && s[18] == '0';
        }

        /// <summary>
        /// Calculates the only positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0
        /// </summary>
        static void P206()
        {
            long ans = (long)(Math.Pow(10, 9) + Math.Pow(10, 7) + Math.Pow(10, 5) + Math.Pow(10, 3) + Math.Pow(10, 1) + 20);
            bool b = true;
            while (!isConcealed(ans * ans))
            {
                if (b) ans += 40;
                else ans += 60;
                b = !b;
            }
            Console.WriteLine(ans);
        }
    }
}