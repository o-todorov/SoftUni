using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    class CustomStack<T>: IEnumerable<T>
    {
        private List<T> items;
        public CustomStack()
        {
            items = new List<T>();
        }
        public int Count { get => items.Count;  }
        public void Push(T value)
        {
            items.Add(value);
        }
        public T Pop()
        {
            T ret = items[Count - 1];
            items.RemoveAt(Count - 1);
            return ret;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
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
