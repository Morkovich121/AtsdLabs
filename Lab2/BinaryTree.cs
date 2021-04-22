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
    }
}
