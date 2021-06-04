using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
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
    }
}
