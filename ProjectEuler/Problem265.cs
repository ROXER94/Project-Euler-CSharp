using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all unique De Bruijn sequences of length 32
        /// </summary>
        static void P265()
        {
            long ans = 0;
            List<string> binary = new List<string>();
            for (int i = 0; i < 32; i++)
                binary.Add(Functions.getConvertBaseFromDecimal(i, 2).ToString().PadLeft(5, '0'));
            for (int a = 0; a < 2; a++)
                for (int b = 0; b < 2; b++)
                    for (int c = 0; c < 2; c++)
                        for (int d = 0; d < 2; d++)
                            for (int e = 0; e < 2; e++)
                                for (int f = 0; f < 2; f++)
                                    for (int g = 0; g < 2; g++)
                                        for (int h = 0; h < 2; h++)
                                            for (int i = 0; i < 2; i++)
                                                for (int j = 0; j < 2; j++)
                                                    for (int k = 0; k < 2; k++)
                                                        for (int l = 0; l < 2; l++)
                                                            for (int m = 0; m < 2; m++)
                                                                for (int n = 0; n < 2; n++)
                                                                    for (int o = 0; o < 2; o++)
                                                                        for (int p = 0; p < 2; p++)
                                                                            for (int q = 0; q < 2; q++)
                                                                                for (int r = 0; r < 2; r++)
                                                                                    for (int s = 0; s < 2; s++)
                                                                                        for (int t = 0; t < 2; t++)
                                                                                            for (int u = 0; u < 2; u++)
                                                                                                for (int v = 0; v < 2; v++)
                                                                                                    for (int w = 0; w < 2; w++)
                                                                                                        for (int x = 0; x < 2; x++)
                                                                                                            for (int y = 0; y < 2; y++)
                                                                                                            {
                                                                                                                string S = "000001" + a.ToString() + b.ToString() + c.ToString() + d.ToString() +
                                                                                                                    e.ToString() + f.ToString() + g.ToString() + h.ToString() + i.ToString() +
                                                                                                                    j.ToString() + k.ToString() + l.ToString() + m.ToString() + n.ToString() +
                                                                                                                    o.ToString() + p.ToString() + q.ToString() + r.ToString() + s.ToString() +
                                                                                                                    t.ToString() + u.ToString() + v.ToString() + w.ToString() + x.ToString() +
                                                                                                                    y.ToString() + "1";
                                                                                                                if (S.Count(C => C == '0') == 16)
                                                                                                                {
                                                                                                                    bool valid = true;
                                                                                                                    foreach (string B in binary)
                                                                                                                    {
                                                                                                                        if (S.Contains(B)) continue;
                                                                                                                        else if ((S.Substring(S.Length - 4) + S.Remove(4)).Contains(B)) continue;
                                                                                                                        else
                                                                                                                        {
                                                                                                                            valid = false;
                                                                                                                            break;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    if (valid) ans += Functions.getConvertBaseToDecimal(S, 2);
                                                                                                                }
                                                                                                            }
            Console.WriteLine(ans);
        }
    }
}