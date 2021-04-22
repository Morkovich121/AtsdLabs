using System;
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
    }
}
