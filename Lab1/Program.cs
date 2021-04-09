using System;

namespace Lab1
{
    public class LinkedListForRead<T> where T : IComparable<T>
    {

        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<int> Head;
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<int> Tail;
        /// <summary>
        /// Длина списка
        /// </summary>
        public int Count;
        /// <summary>
        /// Создать пустой список
        /// </summary>
        public LinkedListForRead()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// функция добавления элемента
        /// </summary>
        /// <param name="data"></param>
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
        /// Функция записи значений из строки
        /// </summary>
        public void Read()
        {
            clear();
            string s = Console.ReadLine();
            var a = s.Split(" ");
            int[] b = new int[a.Length];
            Item<int>[] c = new Item<int>[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = Int32.Parse(a[i]);
                c[i] = new Item<int>(b[i]);
                AddItemForRead(c[i]);
            }
        }
        /// <summary>
        /// Функция вывода списка
        /// </summary>
        /// <returns></returns>
        public void PrintList()
        {
            var current = Head;
            var result = "";

            while (current != null)
            {
                result += current.Data;
                result += " ";
                current = current.Next;
            }
            Console.WriteLine(result);
        }
        /// <summary>
        /// Функция сортировки списка
        /// </summary>
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
            arr2.Read();
            arr2.PrintList();
            var arr1 = new LinkedList<int>();
            arr1.AddItem(5);
            arr1.AddItem(6);
            arr1.AddItem(3);
            arr1.AddItem(7);
            Console.WriteLine(arr1.Search(7));
            Console.WriteLine(arr1.Search(8));
            arr1.DeleteItem(7);
            Console.WriteLine(arr1.IsEmpty());
            arr1.PrintList();
        }
    }
}
