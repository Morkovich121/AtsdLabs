using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class ArrayList<T> where T : IComparable
    {
        public T[] array;
        public int max;
        int last;
        public ArrayList(int m = 10)
        {
            max = m;
            array = new T[max];
            last = -1;
        }

        public bool isFull()
        {
            return last >= array.Length - 1;
        }
        public bool IsEmpty()
        {
            return last == -1;
        }
        public int Size()
        {
            return array.Length;
        }
        public void AddItem(T item)
        {
            if (isFull()) Resize(ref array, array.Length + 1);
            array[++last] = item;

        }
        private void Resize(ref T[] array, int leng)
        {
            T[] array2 = new T[leng];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i];
            }
            array = array2;
        }

        public void PrintList()
        {
            for(int i = 0; i <= last; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
