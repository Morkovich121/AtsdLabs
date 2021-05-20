using System;
using System.Collections.Generic;
using System.Text;

namespace Labs4
{
    public class LinkedList<T> where T : IComparable<T>
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
