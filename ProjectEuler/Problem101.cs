using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// The generating function used to determine the sum of the FITs for the BOPs
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>A value of the generating function</returns>
        static long getU101(int n)
        {
            return 1 - n + (long)Math.Pow(n, 2) - (long)Math.Pow(n, 3) + (long)Math.Pow(n, 4) - (long)Math.Pow(n, 5) + (long)Math.Pow(n, 6) - (long)Math.Pow(n, 7) + (long)Math.Pow(n, 8) - (long)Math.Pow(n, 9) + (long)Math.Pow(n, 10);
        }

        /// <summary>
        /// Gets the transpose of a matrix
        /// </summary>
        /// <param name="m">Decimal[][]</param>
        /// <returns>The transpose of m</returns>
        static decimal[][] getMatrixTranspose(decimal[][] m)
        {
            List<List<decimal>> t = new List<List<decimal>>();
            for (int r = 0; r < m.Length; r++)
            {
                List<decimal> tRow = new List<decimal>();
                for (int c = 0; c < m[r].Length; c++)
                {
                    if (c == r) tRow.Add(m[r][c]);
                    else tRow.Add(m[c][r]);
                }
                t.Add(tRow);
            }
            return t.Select(Enumerable.ToArray).ToArray();
        }

        /// <summary>
        /// Gets the minor of a matrix
        /// </summary>
        /// <param name="m">Decimal[][]</param>
        /// <param name="i">Int</param>
        /// <param name="j">Int</param>
        /// <returns>The minor of m at location i,j</returns>
        static decimal[][] getMatrixMinor(decimal[][] m, int i, int j)
        {
            List<List<decimal>> t = new List<List<decimal>>();
            foreach (var row in m.Take(i).Concat(m.Skip(i + 1)))
                t.Add(row.Take(j).Concat(row.Skip(j + 1)).ToList());
            return t.Select(Enumerable.ToArray).ToArray();
        }

        /// <summary>
        /// Gets the determinant of a matrix
        /// </summary>
        /// <param name="m">Decimal[][]</param>
        /// <returns>The determinant of m</returns>
        static decimal getMatrixDeterminant(decimal[][] m)
        {
            if (m.Length == 2) return m[0][0] * m[1][1] - m[0][1] * m[1][0];
            decimal determinant = 0;
            for (int c = 0; c < m.Length; c++) determinant += (decimal)Math.Pow(-1, c) * m[0][c] * getMatrixDeterminant(getMatrixMinor(m, 0, c));
            return determinant;
        }

        /// <summary>
        /// Gets the matrix inverse of a matrix
        /// </summary>
        /// <param name="m">Decimal[][]</param>
        /// <returns>The inverse of m</returns>
        static decimal[][] getMatrixInverse(decimal[][] m)
        {
            decimal determinant = getMatrixDeterminant(m);
            if (m.Length == 2) return new decimal[][] { new decimal[] { m[1][1] / determinant, -1 * m[0][1] / determinant }, new decimal[] { -1 * m[1][0] / determinant, m[0][0] / determinant } };
            List<List<decimal>> cofactors = new List<List<decimal>>();
            for (int r = 0; r < m.Length; r++)
            {
                List<decimal> cofactorRow = new List<decimal>();
                for (int c = 0; c < m.Length; c++)
                {
                    decimal[][] minor = getMatrixMinor(m, r, c);
                    cofactorRow.Add((decimal)Math.Pow(-1, r + c) * getMatrixDeterminant(minor));
                }
                cofactors.Add(cofactorRow);
            }
            decimal[][] C = getMatrixTranspose(cofactors.Select(Enumerable.ToArray).ToArray());
            for (int r = 0; r < C.Length; r++)
                for (int c = 0; c < C.Length; c++)
                    C[r][c] = C[r][c] / determinant;
            return C;
        }

        /// <summary>
        /// Gets the result of multiplying two matrices
        /// </summary>
        /// <param name="a">Decimal[][]</param>
        /// <param name="b">Decimal[][]</param>
        /// <returns>The matrix product of a and b</returns>
        static decimal[][] getMatrixMultiplication(decimal[][] a, decimal[][] b)
        {
            decimal[][] c = new decimal[a[0].Length][];
            for (int i = 0; i < a[0].Length; i++)
            {
                c[i] = new decimal[b[0].Length];
                for (int j = 0; j < b[1].Length; j++)
                {
                    c[i][j] = 0;
                    for (int k = 0; k < a[1].Length; k++)
                    {
                        c[i][j] += a[i][k] * b[k][j];
                    }
                }
            }
            return c;
        }

        /// <summary>
        /// Calculates the sum of the FITs for the BOPs
        /// </summary>
        static void P101()
        {
            decimal ans = 0;
            decimal[][] BOPS = (from i in Enumerable.Range(1, 10) select new decimal[] { getU101(i) }).Cast<decimal[]>().ToArray();
            for (int i = 2; i <= BOPS.Count(); i++)
            {
                decimal[][] BOPSsubset = BOPS.Take(i).Cast<decimal[]>().ToArray();
                List<List<decimal>> ReversedPowers = new List<List<decimal>>();
                for (int j = 1; j <= BOPSsubset.Count(); j++)
                {
                    List<decimal> ReversedPowersElements = new List<decimal>();
                    for (int k = 0; k < BOPSsubset.Count(); k++)
                        ReversedPowersElements.Add((decimal)Math.Pow(j, k));
                    ReversedPowersElements.Reverse();
                    ReversedPowers.Add(ReversedPowersElements);
                }
                decimal[][] MatrixProduct = getMatrixMultiplication(getMatrixInverse(ReversedPowers.Select(Enumerable.ToArray).ToArray()), BOPSsubset);
                Array.Reverse(MatrixProduct);
                decimal[] FlattenedMatrixProduct = MatrixProduct.SelectMany(n => n).ToArray();
                for (int j = 0; j < FlattenedMatrixProduct.Count(); j++)
                    ans += FlattenedMatrixProduct[j] * (decimal)Math.Pow((FlattenedMatrixProduct.Count() + 1), j);
            }
            Console.WriteLine(Math.Round(ans) + 1);
        }
    }
}