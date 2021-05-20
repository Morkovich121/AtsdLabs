using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
     public class Item<T>
    {
        /// <summary>
        /// Данные хранимые в ячейке списка
        /// </summary>
        public T Data;
        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T> Next;
        /// <summary>
        /// Конструктор элемента
        /// </summary>
        /// <param name="data"></param>
        public Item(T data)
        {
            Data = data;
        }
        /// <summary>
        /// Задать значение ячейке
        /// </summary>
        /// <param name="i"></param>
        public void setItem(T i)
        {
            Data = i;
        }
        /// <summary>
        /// Задать значение следующему элементу
        /// </summary>
        /// <param name="n"></param>
        public void setNext(Item<T> n)
        {
            Next = n;
        }
    }
}
