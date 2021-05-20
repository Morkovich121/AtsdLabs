using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> where T: IComparable<T>
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head;
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail;
        /// <summary>
        /// Длина списка
        /// </summary>
        public int Count;
        /// <summary>
        /// Конструктор пустого списка
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// Конструктор списка с 1 элементом
        /// </summary>
        /// <param name="data"></param>
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        /// <summary>
        /// Функция сортировки списка
        /// </summary>
        public void sort()
        {
            for(int j = 0; j < Count; j++)
            {
                var current = Head;
                
                for(int i = 0; i < Count - 1; i++)
                {
                    if (current.Next != null && current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        var temp = current.Data;
                        current.setItem(current.Next.Data);
                        current.Next.setItem(temp);
                    }
                    current = current.Next;
                }
            }
        }
        /// <summary>
        /// Функция добавления элемента
        /// </summary>
        /// <param name="data"></param>
        public void AddItem(T data)
        {
            var item = new Item<T>(data);
            if(Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                Head = item;
                Tail = item;
                Count = 1;
            }
            sort();
        }
        /// <summary>
        /// Функция удаления элемента
        /// </summary>
        /// <param name="data"></param>
        public void DeleteItem(T data)
        {
            if(Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
        }
        /// <summary>
        /// Функция очистки списка
        /// </summary>
        public void clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// Функция для проверки, пустой ли список
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
        /// <summary>
        /// Функция возврата длины списка
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return Count;
        }
        /// <summary>
        /// Функция вывода списка
        /// </summary>
        public void PrintList()
        {
            var current = Head;
            var result = "";

            while(current != null)
            {
                result += current.Data;
                result += " ";
                current = current.Next;
            }
            Console.WriteLine(result);
        }
        /// <summary>
        /// Функция для проверки, есть ли элемент в списке
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Search(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
