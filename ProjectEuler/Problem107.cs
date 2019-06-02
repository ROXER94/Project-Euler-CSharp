using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the index of the smallest vertex from the set of vertices not yet included in the minimum spanning tree
        /// </summary>
        /// <param name="key">Int[]</param>
        /// <param name="mstSet">Bool[]</param>
        /// <returns>The index of the smallest vertex</returns>
        static int getMinKey(int[] key, bool[] mstSet)
        {
            int currentMinimum = int.MaxValue;
            int minimumIndex = -1;
            for (int v = 0; v < mstSet.Length; v++)
                if (!mstSet[v] && key[v] < currentMinimum)
                {
                    currentMinimum = key[v];
                    minimumIndex = v;
                }
            return minimumIndex;
        }

        /// <summary>
        /// Gets the size of the minimum spanning tree via Prim's Algorithm
        /// </summary>
        /// <param name="graph">Int[][]</param>
        /// <returns>The size of the minimum spanning tree</returns>
        static int getPrimSize(int[][] graph)
        {
            int V = graph.Length;
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < V - 1; count++)
            {
                int u = getMinKey(key, mstSet);
                mstSet[u] = true;
                for (int v = 0; v < V; v++)
                    if (graph[u][v] != 0 && !mstSet[v] && graph[u][v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u][v];
                    }
            }
            return (from i in Enumerable.Range(1, graph.Length - 1) select graph[i][parent[i]]).Sum();
        }

        /// <summary>
        /// Calculates the maximum saving which can be achieved by removing redundant edges whilst ensuring that the network remains connected
        /// </summary>
        static void P107()
        {
            List<int[]> matrix = new List<int[]>();
            foreach (string s in File.ReadAllText(@"...\...\Resources\p107_network.txt").Split('\n').Select(s => s.Replace("-", "0")))
                matrix.Add(s.Split(',').Select(n => Convert.ToInt32(n)).ToArray());
            int[][] m = matrix.ToArray();
            Console.WriteLine((from i in Enumerable.Range(0, m.Length - 1) from j in Enumerable.Range(i + 1, m.Length - i - 1) select m[i][j]).Sum() - getPrimSize(m));
        }
    }
}