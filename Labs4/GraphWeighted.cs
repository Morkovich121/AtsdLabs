using System;
using System.Collections.Generic;
using System.Text;

namespace Labs4
{
    public struct edge_t
    {
        public int x, y;
        public int weight;
    }
    class GraphWeighted
    {
        public int vertices, num_edges;
        public int[,] adjacencyMatrix;
        public edge_t[] edges = new edge_t[100];

        public GraphWeighted(int vertice, int num_edge)
        {
            vertices = vertice;
            num_edges = num_edge;
            adjacencyMatrix = new int[vertices, vertices];
            Console.WriteLine("Введите каждое ребро в строку(x y weight): ");
            for (var i = 0; i < num_edges; i++)
            {
                var s = Console.ReadLine();
                var arr = s.Split(" ");
                edges[i].x = Convert.ToInt32(arr[0]);
                edges[i].y = Convert.ToInt32(arr[1]);
                edges[i].weight = Convert.ToInt32(arr[2]);
                adjacencyMatrix[edges[i].x - 1, edges[i].y - 1] = edges[i].weight;
                adjacencyMatrix[edges[i].y - 1, edges[i].x - 1] = edges[i].weight;
            }
        }
        public void PrintGraph()
        {
            Console.WriteLine("Ваш граф:");
            Console.WriteLine();
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (adjacencyMatrix[i, j] == 0) adjacencyMatrix[i, j] = 101;
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Kruskal()
        {

            int[] nodes = new int[100];
            int last_n = 0;

            for (var i = 0; i < vertices; i++)
            {
                nodes[i] = -1 - i;
            }

            var sVes = from h in edges orderby h.weight select h;
            foreach (var s in sVes)
            {
                for (var i = 0; i < num_edges; i++)
                { // пока не прошли все ребра
                    int c = getColor(s.y);
                    if (getColor(s.x) != c)
                    {
                        nodes[last_n] = s.y;
                        Console.WriteLine(s.x + " " + s.y);
                    }
                }
            }
            int getColor(int n)
            {
                int c;
                if (nodes[n] < 0)
                {
                    return nodes[last_n = n];
                }
                c = getColor(nodes[n]);
                nodes[n] = last_n;
                return c;
            }
        }
        public void Dijkstra(int begin_index)
        {
            int[] d = new int[vertices];
            int[] v = new int[vertices];
            begin_index -= 1;

            int temp, minindex, min;

            for (int i = 0; i < vertices; i++)
            {
                d[i] = 10000;
                v[i] = 1;
            }
            d[begin_index] = 0;

            do
            {
                minindex = 10000;
                min = 10000;
                for (int i = 0; i < vertices; i++)
                {
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }
                if (minindex != 10000)
                {
                    for (int i = 0; i < vertices; i++)
                    {
                        if (adjacencyMatrix[minindex, i] > 0)
                        {
                            temp = min + adjacencyMatrix[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < 10000);

            Console.WriteLine("Кратчайшие расстояния до вершин:");
            Console.WriteLine();
            for (int i = 0; i < vertices; i++)
                Console.WriteLine("До вершины номер " + (i + 1) + ": " + d[i] + " ");


        }
        public int minKey(int[] key, bool[] mstSet)
        {

            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < vertices; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }
    }
}
