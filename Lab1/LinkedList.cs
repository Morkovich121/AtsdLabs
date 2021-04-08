using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class LinkedList<T>
    {
        public Item<T> Head;

        public Item<T> Tail;

        public int Count;
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
    }
}
