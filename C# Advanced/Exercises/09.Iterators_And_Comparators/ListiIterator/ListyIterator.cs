using System;
using System.Collections.Generic;
using System.Linq;

namespace ListiIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int currentIndex;
        public ListyIterator(params T[] collection)
        {
            items = collection.ToList();
            currentIndex = items.Count > 0 ? 0 : -1;
        }
        public bool Move()
        {
            if (HasNext)
            {
                currentIndex++;
                return true;
            }

            return false;
        }
        public bool HasNext => currentIndex + 1 < items.Count;
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[currentIndex].ToString());
        }
    }
}
