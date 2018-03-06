using System;
using System.Text;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the product of the 1st, 10th, 100th, 1000th, 10,000th, 100,000th, and 1,000,000th digits in Champernowne's Constant
        /// </summary>
        static void P040()
        {
            StringBuilder Champernowne = new StringBuilder();
            int n = 1;
            while (Champernowne.Length < 1000000)
            {
                Champernowne.Append(n);
                n++;
            }
            Console.WriteLine((int)Char.GetNumericValue(Champernowne[0]) *
                              (int)Char.GetNumericValue(Champernowne[9]) *
                              (int)Char.GetNumericValue(Champernowne[99]) *
                              (int)Char.GetNumericValue(Champernowne[999]) *
                              (int)Char.GetNumericValue(Champernowne[9999]) *
                              (int)Char.GetNumericValue(Champernowne[99999]) *
                              (int)Char.GetNumericValue(Champernowne[999999]));
        }
    }
}