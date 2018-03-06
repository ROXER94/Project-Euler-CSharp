using System;
using System.IO;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the line number of the text file that has the greatest numerical value
        /// </summary>
        static void P099()
        {
            int ans = 0;
            int lineCount = 1;
            double maximumValue = 0;
            foreach (string line in File.ReadAllText(@"...\...\Resources\p099_base_exp.txt").Split('\n'))
            {
                double currentValue = Int32.Parse(line.Split(',')[1]) * Math.Log(Int32.Parse(line.Split(',')[0]));
                if (currentValue > maximumValue)
                {
                    maximumValue = currentValue;
                    ans = lineCount;
                }
                lineCount++;
            }
            Console.WriteLine(ans);
        }
    }
}