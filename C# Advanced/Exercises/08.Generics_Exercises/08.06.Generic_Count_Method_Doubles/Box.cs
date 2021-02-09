using System;

namespace Generic_Count_Method_Doubles
{
    public class Box<T> : IComparable
        where T : IComparable
    {
        private readonly T item;
        public Box(T item)
        {
            this.item = item;
        }

        public int CompareTo(object obj)
        {
            return item.CompareTo((obj as Box<T>).item);
        }
    }
}
