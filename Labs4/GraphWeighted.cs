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
    }
}
