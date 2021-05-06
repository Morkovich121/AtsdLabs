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
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="m"></param>
        public ArrayList(int m = 10)
        {
            max = m;
            array = new T[max];
            last = -1;
        }
        /// <summary>
        /// Полный ли массив
        /// </summary>
        /// <returns></returns>
        public bool isFull()
        {
            return last >= array.Length - 1;
        }
        /// <summary>
        /// Пустой ли массив
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return last == -1;
        }
        /// <summary>
        /// Длина массива
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return array.Length;
        }
        /// <summary>
        /// Добавление элемента в массив
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            if (isFull()) Resize(ref array, array.Length + 1);
            array[++last] = item;

        }
        /// <summary>
        /// Изменение максимального размера массива и его перезапись
        /// </summary>
        /// <param name="array"></param>
        /// <param name="leng"></param>
        private void Resize(ref T[] array, int leng)
        {
            T[] array2 = new T[leng];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i];
            }
            array = array2;
        }
        /// <summary>
        /// Вывод списка
        /// </summary>
        public void PrintList()
        {
            for(int i = 0; i <= last; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
        private void Heapify(T[] array, int pos, int size)
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
        private void HeapMake(T[] array, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Heapify(array, i, n);
            }
        }

        /// <summary>
        /// Сортировка пирамидой
        /// </summary>
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
