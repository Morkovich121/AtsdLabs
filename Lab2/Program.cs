using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(25);
            binaryTree.Add(17);
            binaryTree.Add(35);
            binaryTree.Add(10);
            binaryTree.Add(20);
            binaryTree.Add(31);

            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            var binaryTree2 = new BinaryTree<int>();
            binaryTree2.Add(1);
            binaryTree2.Add(2);
            binaryTree2.Add(44);
            binaryTree2.Add(19);
            binaryTree.PrintSorted();
            Console.WriteLine();
            binaryTree2.PrintTree();
            Console.WriteLine();
            Console.WriteLine(new string('-', 40));
            binaryTree.ContainsBBST(binaryTree2);
            binaryTree.EqualsBBST(binaryTree2);
            binaryTree.CountNode();
            binaryTree.SumKeys();
            Console.Write("Второй наибольший элемент: ");
            binaryTree.FindSecondLargest();
            Console.WriteLine(new string('-', 40));
            binaryTree.InsertBBST(binaryTree2);
            binaryTree.PrintTree();
            binaryTree.ContainsBBST(binaryTree2);
            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(20);
            binaryTree.PrintTree();
            binaryTree.FatherNode(333);
            Console.WriteLine(new string('-', 40));

            binaryTree.DeleteEven();
            binaryTree.PrintTree();
            binaryTree.FindMiddle();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            var binaryTree3 = new BinaryTree<int>();
            binaryTree3.Add(25);
            binaryTree3.Add(17);
            binaryTree3.Add(35);
            binaryTree3.Add(30);
            binaryTree3.Add(28);
            binaryTree3.Add(40);
            binaryTree3.PrintTree();
            Console.WriteLine(binaryTree3.CommonAncestor(28, 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            binaryTree.PrintTree();
            binaryTree.IsBalanced();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            binaryTree3.PrintTree();
            var binaryTree4 = new BinaryTree<int>();
            binaryTree4.SymmetricalBBST(binaryTree3);
            binaryTree4.PrintTree();
            var binaryTree5 = new BinaryTree<int>();
            binaryTree5.CopyBBST(binaryTree);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            binaryTree.PrintTree();
            binaryTree.Add(5);
            binaryTree5.PrintTree();
        }
    }
}
