﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Корень бинарного дерева
        /// </summary>
        public BinaryTreeNode<T> RootNode;

        /// <summary>
        /// Конструктор пустого дерева
        /// </summary>
        public BinaryTree()
        {
        }
        /// <summary>
        /// Добавление нового узла в бинарное дерево
        /// </summary>
        /// <param name="node">Новый узел</param>
        /// <param name="currentNode">Текущий узел</param>
        /// <returns>Узел</returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result = node.Data.CompareTo(currentNode.Data);
            if (result == 0)
            {
                return currentNode;
            }
            else
            {
                if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        return currentNode.LeftNode = node;
                    }
                    else
                    {
                        return Add(node, currentNode.LeftNode);
                    }
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        return currentNode.RightNode = node;
                    }
                    else
                    {
                        return Add(node, currentNode.RightNode);
                    }
                }
            }
        }

        public BinaryTreeNode<T> Add(int data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }
        /// <summary>
        /// Копирует выбранное дерево
        /// </summary>
        /// <param name="obj"></param>
        public void CopyBBST(BinaryTree<T> obj)
        {
            CopyBBST(obj.RootNode, ref RootNode);
        }
        private void CopyBBST(BinaryTreeNode<T> startNode, ref BinaryTreeNode<T> newNode, Side? side = null)
        {
            if (startNode != null)
            {
                var temp = startNode;
                newNode = temp;
                CopyBBST(startNode.LeftNode, ref newNode.LeftNode, Side.Left);
                CopyBBST(startNode.RightNode, ref newNode.RightNode, Side.Right);
            }
        }

        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }
        /// <summary>
        /// Удаление узла бинарного дерева
        /// </summary>
        /// <param name="node">Узел для удаления</param>
        private void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        /// <summary>
        /// Поиск узла по значению
        /// </summary>
        /// <param name="data">Искомое значение</param>
        /// <param name="startWithNode">Узел начала поиска</param>
        /// <returns>Найденный узел</returns>
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            if (startWithNode == null)
            {
                startWithNode = RootNode;
            }
            int result = data.CompareTo(startWithNode.Data);
            if (result == 0)
            {
                return startWithNode;
            }
            else
            {
                if (result < 0)
                {
                    if (startWithNode.LeftNode == null)
                    {
                        return null;
                    }
                    else return FindNode(data, startWithNode.LeftNode);
                }
                else
                {
                    if (startWithNode.RightNode == null)
                    {
                        return null;
                    }
                    else return FindNode(data, startWithNode.RightNode);
                }
            }
        }

        /// <summary>
        /// Вывод бинарного дерева
        /// </summary>
        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        /// <summary>
        /// Вывод бинарного дерева начиная с указанного узла
        /// </summary>
        /// <param name="startNode">Узел с которого начинается печать</param>
        /// <param name="indent">Отступ</param>
        /// <param name="side">Сторона</param>
        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        /// <summary>
        /// Удаление всех четных элементов
        /// </summary>
        public void DeleteEven()
        {
            DeleteEven(RootNode);
        }
        private void DeleteEven(BinaryTreeNode<T> startNode, int result = 0, Side? side = null)
        {
            if (startNode != null)
            {
                if (startNode.Data % 2 == 0)
                    Remove(startNode);
                //рекурсивный вызов для левой и правой веток
                DeleteEven(startNode.LeftNode, result, Side.Left);
                DeleteEven(startNode.RightNode, result, Side.Right);
            }
        }

        /// <summary>
        /// Количество левых значений
        /// </summary>
        public void CountNode()
        {
            var s = 0;
            CountNode(RootNode, ref s, false);
            Console.WriteLine("Количество левых значений: " + s);
        }
        private void CountNode(BinaryTreeNode<T> node, ref int s, bool detailed, Side? side = null)
        {
            if (node != null)
            {
                if (side == Side.Left)
                    s += 1;
                CountNode(node.LeftNode, ref s, detailed, Side.Left); // обойти левое поддерево
                CountNode(node.RightNode, ref s, detailed, Side.Right); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Сумма правых значений
        /// </summary>
        public void SumKeys()
        {
            var s = 0;
            SumKeys(RootNode, ref s, false);
            Console.WriteLine("Сумма правых значений: " + s);
        }
        private void SumKeys(BinaryTreeNode<T> node, ref int s, bool detailed, Side? side = null)
        {
            if (node != null)
            {
                if (side == Side.Right)
                    s += node.Data;
                SumKeys(node.LeftNode, ref s, detailed, Side.Left); // обойти левое поддерево
                SumKeys(node.RightNode, ref s, detailed, Side.Right); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Поиск второго наибольшего значения
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void FindSecondLargest()
        {
            var s = "";
            PrintSorted(RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            Console.WriteLine(arr[1]);
        }

        /// <summary>
        /// Проверка равны ли 2 дерева
        /// </summary>
        /// <param name="obj"></param>
        public void EqualsBBST(BinaryTree<T> obj)
        {
            var res = 0;
            EqualsBBST(obj.RootNode, RootNode, ref res);
            Console.WriteLine(res == 0);
        }
        private void EqualsBBST(BinaryTreeNode<T> startNode2, BinaryTreeNode<T> startNode, ref int result, Side? side = null)
        {
            if (startNode != null && startNode2 != null)
            {
                if (startNode.Data != startNode2.Data)
                    result = -1;
                //рекурсивный вызов для левой и правой веток
                EqualsBBST(startNode2.LeftNode, startNode.LeftNode, ref result, Side.Left);
                EqualsBBST(startNode2.RightNode, startNode.RightNode, ref result, Side.Right);
            }
            else
                if (startNode2 == null && startNode != null)
            {
                result = -1;
                EqualsBBST(startNode2, startNode.LeftNode, ref result, Side.Left);
                EqualsBBST(startNode2, startNode.RightNode, ref result, Side.Right);
            }
            else
                    if (startNode2 != null && startNode == null)
            {
                result = -1;
                EqualsBBST(startNode2.LeftNode, startNode, ref result, Side.Left);
                EqualsBBST(startNode2.RightNode, startNode, ref result, Side.Right);
            }
        }
        /// <summary>
        /// Вывод массива в сортированном виде
        /// </summary>
        /// <returns></returns>
        public int PrintSorted()
        {
            var s = "";
            PrintSorted(RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            return arr[1];
        }
        private void PrintSorted(BinaryTreeNode<T> node, ref string s, Side? side = null)
        {
            if (node != null)
            {
                s += node.Data.ToString() + " ";
                PrintSorted(node.LeftNode, ref s, Side.Left); // обойти левое поддерево
                PrintSorted(node.RightNode, ref s, Side.Right); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Поиск среднего значения
        /// </summary>
        public void FindMiddle()
        {
            var s = "";
            PrintSorted(RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            var middle = (arr[0] + arr[arr.Length - 1]) / 2;
            int min = 100000;
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i] - middle) < min)
                {
                    min = Math.Abs(arr[i] - middle);
                    result = arr[i];
                }
            }
            Console.WriteLine(result);
        }
        /// <summary>
        /// Вставляет все элементы из переметра Obj в дерево
        /// </summary>
        /// <param name="obj"></param>
        public void InsertBBST(BinaryTree<T> obj)
        {
            var s = "";
            PrintSorted(obj.RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Add(arr[i]);
            }
        }

        /// <summary>
        /// Проверка, все ли значения obj есть в дереве
        /// </summary>
        /// <param name="obj"></param>
        public void ContainsBBST(BinaryTree<T> obj)
        {
            var s = "";
            PrintSorted(obj.RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            var ss = "";
            PrintSorted(RootNode, ref ss);
            var arrr1 = ss.Split(" ");
            int[] arrr = new int[arrr1.Length - 1];
            for (int i = 0; i < arrr1.Length - 1; i++)
            {
                arrr[i] = Int32.Parse(arrr1[i]);
            }
            for (int i = 0; i < arrr.Length - 1; i++)
            {
                for (int j = 0; j < arrr.Length - 1; j++)
                {
                    if (arrr[j] > arrr[j + 1])
                    {
                        int z = arrr[j];
                        arrr[j] = arrr[j + 1];
                        arrr[j + 1] = z;
                    }
                }
            }
            var check = 0;
            var check_check = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                check = -1;
                for (int j = 0; j < arrr.Length; j++)
                {
                    if (arr[i] == arrr[j]) check = 0;
                }
                if (check == -1) check_check = -1;
            }
            if (check_check == 0) Console.WriteLine(true);
            else Console.WriteLine(false);
        }

        /// <summary>
        /// Возвращает родителя указанного узла
        /// </summary>
        /// <param name="node"></param>
        /// <param name="result"></param>
        /// <param name="k"></param>
        /// <param name="side"></param>
        private void FatherNode(BinaryTreeNode<T> node, ref int result, int k, Side? side = null)
        {
            if (node != null)
            {
                if (node.Data == k) result = node.ParentNode.Data;
                FatherNode(node.LeftNode, ref result, k, Side.Left); // обойти левое поддерево
                FatherNode(node.RightNode, ref result, k, Side.Right); // обойти правое поддерево
            }
        }

        public void FatherNode(int k)
        {
            var result = -100000;
            if (k == RootNode.Data)
            {
                Console.WriteLine(result);
            }
            else
            {
                FatherNode(RootNode, ref result, k);
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Функция поиска ближайшего общего родителя для 2 узлов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CommonAncestor(int a, int b)
        {
            var s = "";
            LCR(RootNode, ref s);
            var arr1 = s.Split(" ");
            int[] arr = new int[arr1.Length - 1];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Int32.Parse(arr1[i]);
            }
            var save1 = 0;
            var save2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a) save1 = i;
                if (arr[i] == b) save2 = i;
            }

            var ss = "";
            LRC(RootNode, ref ss);
            var arrr1 = ss.Split(" ");
            int[] arrr = new int[arrr1.Length - 1];
            for (int i = 0; i < arrr1.Length - 1; i++)
            {
                arrr[i] = Int32.Parse(arrr1[i]);
            }

            var max = -1;
            var result = 0;
            for (int i = save1 + 1; i < save2; i++)
            {
                for (int j = 0; j < arrr.Length; j++)
                {
                    if (arrr[j] == arr[i])
                    {
                        if (j > max)
                        {
                            result = arrr[j];
                            max = j;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Алгоритм обхода InOrder
        /// </summary>
        public void LCR()
        {
            var s = "";
            LCR(RootNode, ref s);
            Console.WriteLine(s);
        }
        private void LCR(BinaryTreeNode<T> node, ref string s)
        {
            if (node != null)
            {
                LCR(node.LeftNode, ref s); // обойти левое поддерево
                s += node.Data.ToString() + " "; // запомнить текущее значение;
                LCR(node.RightNode, ref s); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Алгоритм обхода PostOrder
        /// </summary>
        public void LRC()
        {
            var s = "";
            LRC(RootNode, ref s);
            Console.WriteLine(s);
        }
        private void LRC(BinaryTreeNode<T> node, ref string s)
        {
            if (node != null)
            {
                LRC(node.LeftNode, ref s); // обойти левое поддерево
                LRC(node.RightNode, ref s); // обойти правое поддерево
                s += node.Data.ToString() + " "; // запомнить текущее значение;
            }
        }

        /// <summary>
        /// Проверка на сбалансированность дерева
        /// </summary>
        public void IsBalanced()
        {
            bool balance = true;
            int heightLeftNode = HeightLeftNode(RootNode);
            Foo(RootNode, 1);
            if (balance == false)
            {
                Console.WriteLine("Дерево не сбалансированно");
            }
            else
            {
                Console.WriteLine("Дерево сбалансированно");
            }

            void Foo(BinaryTreeNode<T> node, int height)
            {
                if (node.LeftNode == null)
                {
                    if (Math.Abs(heightLeftNode - height) > 1)
                        balance = false;
                }
                else
                    Foo(node.LeftNode, height + 1);

                if (node.RightNode == null)
                {
                    if (Math.Abs(heightLeftNode - height) > 1)
                        balance = false;
                }
                else
                    Foo(node.RightNode, height + 1);
            }
        }

        /// <summary>
        /// Высота левого подкорня дерева
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int HeightLeftNode(BinaryTreeNode<T> node)
        {
            return node == null ? 0 : (HeightLeftNode(node.LeftNode) + 1);
        }
    }
}
