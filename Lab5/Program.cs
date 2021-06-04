using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var binary1 = new BinaryTree<int>();
            var binary2 = new BinaryTree<int>();
            Console.WriteLine(binary1.Equals(binary2));
        }
    }
}
