using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Item<T>
    {
        public T Data;

        public Item<T> Next;

        public Item(T data)
        {
            Data = data;
        }
    }
}
