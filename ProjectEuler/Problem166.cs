using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of ways a 4x4 grid can be filled with the digits d, 0 ≤ d ≤ 9 so that each row, column, and diagonal have the same sum
        /// </summary>
        static void P166()
        {
            /*
             * a b c d
             * e f g h
             * i j k l
             * m n o p
             */
            int ans = 0;
            for (int a = 0; a < 10; a++)
                for (int b = 0; b < 10; b++)
                    for (int c = 0; c < 10; c++)
                        for (int d = 0; d < 10; d++)
                            for (int e = 0; e < 10; e++)
                                for (int i = 0; i < 10; i++)
                                    for (int m = 0; m < 10; m++)
                                        if (a + e + i + m == a + b + c + d)
                                            for (int g = 0; g < 10; g++)
                                                for (int j = 0; j < 10; j++)
                                                    if (d + g + j + m == a + b + c + d)
                                                        for (int f = 0; f < 10; f++)
                                                            for (int h = 0; h < 10; h++)
                                                                if (e + f + g + h == a + b + c + d)
                                                                    for (int n = 0; n < 10; n++)
                                                                        if (b + f + j + n == a + b + c + d)
                                                                            for (int k = 0; k < 10; k++)
                                                                                for (int p = 0; p < 10; p++)
                                                                                    if (a + f + k + p == a + b + c + d)
                                                                                        for (int l = 0; l < 10; l++)
                                                                                            if (d + h + l + p == a + b + c + d)
                                                                                                if (i + j + k + l == a + b + c + d)
                                                                                                    for (int o = 0; o < 10; o++)
                                                                                                        if (c + g + k + o == a + b + c + d)
                                                                                                            if (m + n + o + p == a + b + c + d)
                                                                                                                ans++;
            Console.WriteLine(ans);
        }
    }
}