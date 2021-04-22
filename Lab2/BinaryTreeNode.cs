using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// Расположения узла относительно родителя
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }
    class BinaryTreeNode<T> where T : IComparable
    {   
        /// <summary>
        /// Данные которые хранятся в узле
        /// </summary>
        public int Data;

        /// <summary>
        /// Левая ветка
        /// </summary>
        public BinaryTreeNode<T> LeftNode;

        /// <summary>
        /// Правая ветка
        /// </summary>
        public BinaryTreeNode<T> RightNode;

        /// <summary>
        /// Родитель
        /// </summary>
        public BinaryTreeNode<T> ParentNode;

        /// <summary>
        /// Расположение узла относительно его родителя
        /// </summary>
        public Side? NodeSide => ParentNode == null ? (Side?)null : ParentNode.LeftNode == this ? Side.Left : Side.Right;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="data">Данные</param>
        public BinaryTreeNode(int data)
        {
            Data = data;
        }
    }
}
