using System;
using System.Collections.Generic;
using System.Text;

namespace Labs4
{
    public class Item<T>
    {
        public T Data;
        public Item<T> Next;
        public Item(T data)
        {
            Data = data;
        }
        public void setItem(T i)
        {
            Data = i;
        }
        public void setNext(Item<T> n)
        {
            Next = n;
        }
    }
}
