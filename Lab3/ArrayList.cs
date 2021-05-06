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
        public void Heapify(T[] array, int pos, int size)
        {
            T temp;
            while (2 * pos + 1 < size)
            {
                int t = 2 * pos + 1;
                if (2 * pos + 2 < size && array[2 * pos + 2].CompareTo(array[t])>=0)
                {
                    t = 2 * pos + 2;
                }
                if (array[pos].CompareTo(array[t])<0)
                {
                    temp = array[pos];
                    array[pos] = array[t];
                    array[t] = temp;
                    pos = t;
                }
                else break;
            }
        }
        public void HeapMake(T[] array, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Heapify(array, i, n);
            }
        }
        public void HeapSort()
        {
            T temp;
            var n = last + 1;
            HeapMake(array, n);
            while (n > 0)
            {
                temp = array[0];
                array[0] = array[n - 1];
                array[n - 1] = temp;
                n--;
                Heapify(array, 0, n);
            }
        }
    }
}
