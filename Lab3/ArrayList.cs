using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class ArrayList<T> where T : IComparable
    {
        public object[] array;
        public int max;
        int last;
        public ArrayList(int m = 10)
        {
            max = m;
            array = new object[max];
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
        public void AddItem(object item)
        {
            if (isFull()) Resize(ref array, array.Length + 1);
            array[++last] = item;

        }
        private void Resize(ref object[] array, int leng)
        {
            object[] array2 = new object[leng];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i];
            }
            array = array2;
        }

    }
}
