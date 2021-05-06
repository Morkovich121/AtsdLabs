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
        

    }
}
