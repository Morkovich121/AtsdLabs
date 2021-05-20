using System;
using System.Collections.Generic;

namespace Labs4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите кол-во вершин графа");
            var a = Console.ReadLine();
            Console.WriteLine("Укажите кол-во ребер графа");
            var b = Console.ReadLine();
            var graph = new GraphWeighted(Convert.ToInt32(a), Convert.ToInt32(b));
            graph.PrintGraph();
            Console.WriteLine();
            graph.Kruskal();
            graph.Dijkstra(1);
            var MST = new List<edge_t>();
            var arr = new LinkedList<string>();
            graph.Prim(arr);
            arr.PrintList();
        }
    }
}
