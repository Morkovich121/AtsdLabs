using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class LinkedList<T> where T: IComparable<T>
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
        public void sort()
        {
            for(int j = 0; j < Count; j++)
            {
                var current = Head;
                
                for(int i = 0; i < Count - 1; i++)
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

        public void AddItem(T data)
        {
            var item = new Item<T>(data);
            if(Tail != null)
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
    }
}
