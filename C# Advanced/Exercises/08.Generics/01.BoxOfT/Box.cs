using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;
        public Box()
        {
            this.items = new List<T>();
        }
        public int Count { get => items.Count; }
        public void Add(T element)
        {
            items.Add(element);
        }
        public T Remove() // Removes top(last) element
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Can't remove from empty box");
            }

            var retVal = items[Count - 1];
            items.RemoveAt(Count - 1);

            return retVal;
        }
    }
}
