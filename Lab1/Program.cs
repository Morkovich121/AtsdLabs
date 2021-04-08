using System;

namespace Lab1
{
    public class LinkedListForRead<T> where T : IComparable<T>
    {

        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<int> Head { get; private set; }
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<int> Tail { get; private set; }
        /// <summary>
        /// Длина списка
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Создать пустой список
        /// </summary>
        public LinkedListForRead()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public void AddItemForRead(Item<int> data)
        {
            var item = data;

            if (Tail != null)
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
        public void clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public string PrintList()
        {
            var current = Head;
            var result = "";

            while (current != null)
            {
                result += current.Data;
                result += " ";
                current = current.Next;
            }
            return result;
        }
        public void sort()
        {
            for (int j = 0; j < Count; j++)
            {

                var current = Head;

                for (int i = 0; i < Count - 1; i++)
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


    }
    class Program
    {
        static void Main(string[] args)
        {
            var arr2 = new LinkedListForRead<int>();
        }
    }
}
