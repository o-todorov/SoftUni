
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListiIterator
{
    public class ListyIterator<T> : IEnumerable
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
            if (currentIndex == -1)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[currentIndex].ToString());
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
