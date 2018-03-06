using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of letters used in writing out all the numbers from 1 to 1000
        /// </summary>
        static void P017()
        {
            int OneTo9 = "onetwothreefourfivesixseveneightnine".Length;
            int TenTo19 = "teneleventwelvethirteenfourteenfifteensixteenseventeeneighteennineteen".Length;
            int Tens = "twentythirtyfortyfiftysixtyseventyeightyninety".Length;
            int OneTo99 = 10 * Tens + 9 * OneTo9 + TenTo19;
            int OneTo999 = 9 * 99 * "hundredand".Length + 100 * OneTo9 + 9 * "hundred".Length + 10 * OneTo99;
            Console.WriteLine(OneTo999 + "onethousand".Length);
        }
    }
}